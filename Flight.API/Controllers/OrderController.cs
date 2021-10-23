using Flight.API.Hubs;
using Flight.API.Services;
using Flight.Core.Dtos;
using Flight.Core.Interfaces;
using Flight.Entities.Entities;
using Flight.Entities.Views;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMessagePublisher _messagePublisher;
        IHubContext<OrderStatusHub> _hubContext;
        public OrderController(IOrderService orderService, IMessagePublisher messagePublisher, IHubContext<OrderStatusHub> hubContext)
        {
            _orderService = orderService;
            _messagePublisher = messagePublisher;
            _hubContext = hubContext;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(OrderForCreateDto orderForCreateDto)
        {

            await _hubContext.Clients.All.SendAsync("OrderCreated", orderForCreateDto);


            try
            {
                var order = await _orderService.CreateOrder(orderForCreateDto);
                await _messagePublisher.Publish<Order>(order);
                return Ok(new Response<OrderForCreateDto> { IsSucceeded = true, Error = null });
            }
            catch (Exception e)
            {

                return BadRequest(new Response<OrderForCreateDto>
                {
                    Data = null,
                    IsSucceeded = false,
                    Error = e.Message
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderStatus(OrderForUpdateDto orderForUpdateDto)
        {
            try
            {
                if (orderForUpdateDto != null)
                {
                    var updatedOrder = await _orderService.UpdateOrder(orderForUpdateDto);
                    if (updatedOrder != null)
                    {
                        await _hubContext.Clients.All.SendAsync("OrderUpdated", updatedOrder.OrderStatus.ToString());

                        return Ok(new Response<OrderForUpdateDto> { Data = null, IsSucceeded = true, Error = null });
                    }
                }
                return BadRequest(new Response<OrderForUpdateDto> { Data = null, IsSucceeded = false, Error = "object cannot be null" });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<OrderForUpdateDto> { Data = null, IsSucceeded = false, Error = e.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] PaginationFilter filter)
        {
            try
            {
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

                var ordersDetailsQuery = await _orderService.GetOrderDetails();
                var countQuery = await _orderService.GetOrderDetails();
                var totalRecords = countQuery.Count();
                var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
                int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
                var pagedData = await ordersDetailsQuery.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                         .Take(validFilter.PageSize)
                                         .ToListAsync();
                return Ok(new PagedResponse<List<OrderDetails>>(pagedData, validFilter.PageNumber
                                                                , validFilter.PageSize, totalRecords, roundedTotalPages));
            }
            catch (Exception e)
            {
                return NotFound(new Response<List<OrderDetails>> { Data = null, IsSucceeded = false, Error = e.Message });
            }
        }

    }
}
