using API_APP.DAL.Entities;
using API_APP.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

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

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            //return await _context.Countries.FindAsync(id);
            //return await _context.Countries.FirstAsync(x => x.Id == id);
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id); //no retorna null
        }

        public async Task<Country> GetCountryByNameAsync(string name)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Name == name); //no retorna null
        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;
                _context.Countries.Update(country); 
                await _context.SaveChangesAsync(); //Llendo a la BD para hacer el insert en la tabla

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message); //Coallesences notation ??
            }
        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);

                if (country != null) return null;

                _context.Countries.Remove(country);

                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message); //Coallesences notation ??
            }
            
        }
    }
}
