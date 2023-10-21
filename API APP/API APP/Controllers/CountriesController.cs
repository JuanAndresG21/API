using API_APP.DAL.Entities;
using API_APP.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace API_APP.Controllers
{
    [ApiController]
    [Route("api/controller")]  //primera parte de la url api/countries
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        //En un controlador los metodos pasan a llamarse acciones (actions) - Si es una API se llama Endpoint
        //Todo Endpoint retorna un ActionResult osea el resultado de una accion
        //El ActionResult recibe casi todo tipo de objetos como listas, pdf, word etc

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]  //concatena la url inicial api/countries/get
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {
            var countries = await _countryService.GetCountriesAsync(); //se va a la capa Domain para traer la lista

            if(countries == null || !countries.Any())// Any() significa si hay almenos un elemento
                                                     // !Any() significa si no hay nada
            {
                return NotFound(); // NotFound = 404 Http Status Code
            }

            return Ok(countries); // Ok = 200 Http Status Code
        }

        [HttpPost, ActionName("Post")]
        [Route("Create")]
        public async Task<ActionResult<Country>> CreateCountryAsync(Country country)
        {
            try
            {
                var createdCountry = await _countryService.CreateCountryAsync(country);

                if(createdCountry == null)
                {
                    return NotFound();
                }

                return Ok(createdCountry); //retorne 200 y el objeto Country
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El pais {0} ya existe", country.Name));
                }

                return Conflict(ex.Message);
            }
            
        }


        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]  //concatena la url inicial api/countries/get
        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid id)
        {
            if(id == null) 
            {
                return BadRequest("Id es requerido!"); 
            }

            var countries = await _countryService.GetCountryByIdAsync(id); //se va a la capa Domain para traer la lista

            if (countries == null)// Any() significa si hay almenos un elemento
                                                      // !Any() significa si no hay nada
            {
                return NotFound(); // NotFound = 404 Http Status Code
            }

            return Ok(countries); // Ok = 200 Http Status Code
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByName/{name}")]  //concatena la url inicial api/countries/get
        public async Task<ActionResult<Country>> GetCountryByIdAsync(string name)
        {
            if (name == null)
            {
                return BadRequest("Nombre es requerido!");
            }

            var countries = await _countryService.GetCountryByNameAsync(name); //se va a la capa Domain para traer la lista

            if (countries == null)// Any() significa si hay almenos un elemento
                                  // !Any() significa si no hay nada
            {
                return NotFound(); // NotFound = 404 Http Status Code
            }

            return Ok(countries); // Ok = 200 Http Status Code
        }


        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Country>> EditCountryAsync(Country country)
        {
            try
            {
                var editedCountry = await _countryService.EditCountryAsync(country);

                if (editedCountry == null)
                {
                    return NotFound();
                }

                return Ok(editedCountry); //retorne 200 y el objeto Country
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El pais {0} ya existe", country.Name));
                }

                return Conflict(ex.Message);
            }

        }


        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)
        {
          
            if (id == null)
            {
                return BadRequest("Id es requerido!");
            }

            var deletedCountry = await _countryService.DeleteCountryAsync(id);

            if (deletedCountry == null) return NotFound("Pais no encontrado");

            return Ok(deletedCountry);
            


        }
    }
}
