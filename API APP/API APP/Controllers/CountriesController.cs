using API_APP.DAL.Entities;
using API_APP.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        [Route("Get")]  //concatena la url inicial api/countries/get
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
    }
}
