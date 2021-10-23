using Flight.Core.Dtos;
using Flight.Core.Interfaces;
using Flight.Entities.Entities;
using Flight.Entities.Interfaces;
using Flight.Entities.Views;

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Create Order
        public async Task<Order> CreateOrder(OrderForCreateDto orderForCreateDto)
        {
            if (orderForCreateDto != null)
            {
                try
                {
                    Customer customer = MapToCustomer(orderForCreateDto);
                    await _unitOfWork.CustomerRepository.Create(customer);
                    Ticket ticket = MapToTicket(orderForCreateDto);
                    await _unitOfWork.TicketRepository.Create(ticket);
                    CreditCard creditCard = MapToCreditCard(orderForCreateDto, customer);
                    await _unitOfWork.CreditCardRepository.Create(creditCard);
                    Order order = new Order()
                    {
                        Customer = customer,
                        Ticket = ticket
                    };
                    await _unitOfWork.OrderRepository.Create(order);
                    await _unitOfWork.SaveChangesAsync();
                    return order;
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                }
            }
            return null;
        }

        #endregion

        public async Task<Order> UpdateOrder(OrderForUpdateDto orderForUpdateDto)
        {
            try
            {
                var orderFromDb = await _unitOfWork.OrderRepository.GetById(orderForUpdateDto.OrderId);
                orderFromDb.OrderStatus = orderForUpdateDto.OrderStatus;
                //var order = MapToOrder(orderForUpdateDto);
                await _unitOfWork.OrderRepository.Update(orderFromDb);
                await _unitOfWork.SaveChangesAsync();
                return orderFromDb;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return null;
            }
        }





        #region Order Details
        public async Task<IQueryable<OrderDetails>> GetOrderDetails()
        {
            var ordersDetails = await _unitOfWork.SpecficOrderRepository.GetOrdersWithDetails();
            if (ordersDetails != null)
                return ordersDetails;
            return null;
        }
        #endregion

        #region mappers 

        private CreditCard MapToCreditCard(OrderForCreateDto orderForCreateDto, Customer customer)
        {
            return new CreditCard
            {
                CreditCardNumber = orderForCreateDto.CreditCardNumber,
                HolderName = orderForCreateDto.CreditCardHolderName,
                Customer = customer
            };
        }
        private Ticket MapToTicket(OrderForCreateDto orderForCreateDto)
        {
            return new Ticket
            {
                CountryId = orderForCreateDto.CountryId,
                IsTransit = orderForCreateDto.IsTransit,
                Departure = orderForCreateDto.Departure,
                Quantity = orderForCreateDto.NumberOfPersons,

            };
        }
        private Customer MapToCustomer(OrderForCreateDto orderForCreateDto)
        {
            if (!string.IsNullOrEmpty(orderForCreateDto.CusotmerName))
            {
                return new Customer
                {
                    Name = orderForCreateDto.CusotmerName
                };
            }
            return null;
        }
        private Order MapToOrder(OrderForUpdateDto orderForUpdateDto)
        {
            return new Order
            {
                OrderId = orderForUpdateDto.OrderId,
                TicketId = orderForUpdateDto.TicketId,
                OrderStatus = orderForUpdateDto.OrderStatus,
                CustomerId = orderForUpdateDto.CutomerId
            };
        }

        #endregion
    }
}
