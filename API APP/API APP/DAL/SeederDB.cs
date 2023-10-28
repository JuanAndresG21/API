using API_APP.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API_APP.DAL
{
    public class SeederDB
    {
        private readonly DatabaseContext _context;

        public SeederDB(DatabaseContext context)
        {
            _context = context;
        }

        //metodo main, prepobla las tablas
        public async Task SeederAsync()
        {
            //metodo de EF que simula el comando update-database
            await _context.Database.EnsureCreatedAsync();

            //Metodos para prepoblar las tablas
            await PopulateCountriesAsync();

            await _context.SaveChangesAsync();
        }

        #region Methods
        private async Task PopulateCountriesAsync()
        {
            if(!_context.Countries.Any())  //si no hay nada entra
            {
                //Así creo yo un objeto país con sus respectivos estados
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Antioquia"
                        },

                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cundinamarca"
                        }
                    }
                });

                //Aquí creo otro nuevo país
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Argentina",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Buenos Aires"
                        }
                    }
                });
            }
        }


        #endregion
    }
}
