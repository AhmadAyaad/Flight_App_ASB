using Flight.Core.Interfaces;
using Flight.Entities.Entities;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _countryService.GetCountries();
            if (countries != null)
                return Ok(new Response<List<Country>> { Data = countries, Error = null, IsSucceeded = true });
            return NotFound(new Response<List<Country>> { Data = null, Error = "Not found", IsSucceeded = false });
        }
    }
}
