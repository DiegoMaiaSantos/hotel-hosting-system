using Api.Src.Domain.Interfaces.Services;
using Api.Src.Infra.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Src.Application.Controllers
{
    [Route("api/personHotelSystem")]
    [ApiController]
    public class PersonHotelSystemController : ControllerBase
    {
        private readonly IPersonHotelSystemService _personHotelSystemService;

        public PersonHotelSystemController(IPersonHotelSystemService personHotelSystemService)
        {
            _personHotelSystemService = personHotelSystemService;
        }

        /// <summary>
        /// Busca uma lista dos hóspedes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllPerson()
        {
            try
            {
                var data = await _personHotelSystemService.GetAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Busca um hóspede pelo o nome
        /// </summary>
        /// <param name="namePerson"></param>
        /// <returns></returns>
        [HttpGet("{personByName}")]
        public async Task<ActionResult> GetPersonByName([FromRoute] string namePerson)
        {
            try
            {
                var data = await _personHotelSystemService.GetByName(namePerson);

                return Ok(namePerson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Casdastra um novo hóspede e seu quarto
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> RegisterNewPerson(Person person)
        {
            try
            {
                var data = await _personHotelSystemService.NewPerson(person);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// atualiza os dados do hóspede
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> ChangePersonRegistration(Person person)
        {
            try
            {
                return Ok(await _personHotelSystemService.ChangePerson(person));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deleta do sistema um hóspede
        /// </summary>
        /// <param name="namePerson"></param>
        /// <returns></returns>
        [HttpDelete("{personByName}")]
        public async Task<ActionResult> DeleteSystemPerson([FromForm] string namePerson)
        {
            try
            {
                return Ok(await _personHotelSystemService.DeletePerson(namePerson));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
    }
}
