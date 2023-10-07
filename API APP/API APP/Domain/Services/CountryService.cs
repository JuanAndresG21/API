using API_APP.DAL.Entities;
using API_APP.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_APP.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DatabaseContext _context;
        public CountryService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            var countries = await _context.Countries.ToListAsync(); //trae todos los datos de la tabla

            return countries;

            //return await _context.Countries.ToListAsync(); //trae todos los datos de la tabla

        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid(); //asigna id automatico
                country.CreatedDate = DateTime.Now;

                _context.Countries.Add(country); //Creacion de country en el contexto de la BD
                await _context.SaveChangesAsync(); //Llendo a la BD para hacer el insert en la tabla

                return country;
            }
            catch (DbUpdateException dbUpdateException) 
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message); //Coallesences notation ??
            }
        }
    }
}
