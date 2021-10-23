using Flight.Entities.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flight.Core.Interfaces
{
    public interface ICountryService
    {
        Task<List<Country>> GetCountries();
    }
}
