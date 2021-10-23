using Flight.Core.Interfaces;
using Flight.Entities.Entities;
using Flight.Entities.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<List<Country>> GetCountries()
        {
            var countries = _unitOfWork.CountryRepository.GetAll().ToList();
            return countries != null ? Task.FromResult(countries) : null;
        }
    }
}
