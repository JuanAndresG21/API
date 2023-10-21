using API_APP.DAL.Entities;

namespace API_APP.Domain.Interfaces
{
    public interface ICountryService
    {
        //IList para manipular, ICollection para manipular, IEnumerable para estaticas (para solo mostrar)
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<Country> CreateCountryAsync(Country country);

        Task<Country> GetCountryByIdAsync(Guid id);

        Task<Country> GetCountryByNameAsync(string name);

        Task<Country> EditCountryAsync(Country country);

        Task<Country> DeleteCountryAsync(Guid id);
    }
}
