using Api.Src.Domain.Interfaces;
using Api.Src.Infra.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Src.Application.Controllers
{
    [Route("api/hotelSystem")]
    [ApiController]
    public class HotelSystemController : ControllerBase
    {
        private readonly IHotelSystemService _hotelSystemService;

        public HotelSystemController(IHotelSystemService hotelSystemService)
        {
            _hotelSystemService = hotelSystemService;
        }

        /// <summary>
        /// Busca uma lista dos hóspedes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllGuests()
        {
            try
            {
                var data = await _hotelSystemService.GetAll();

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
        /// <param name="guestName"></param>
        /// <returns></returns>
        [HttpGet("{guestByName}")]
        public async Task<ActionResult> GetGuestByName([FromRoute] string guestName)
        {
            try
            {
                var data = await _hotelSystemService.GetByName(guestName);

                return Ok(guestName);
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
        /// <param name="suite"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> RegisterNewGuest(Person person, Suite suite)
        {
            try
            {
                var data = await _hotelSystemService.NewGuest(person, suite);

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
        /// <param name="suite"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> ChangeGuestRegistration(Person person, Suite suite)
        {
            try
            {
                return Ok(await _hotelSystemService.ChangeRegistration(person, suite));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deleta do sistema um hóspede
        /// </summary>
        /// <param name="nameGuest"></param>
        /// <returns></returns>
        [HttpDelete("{guestByName}")]
        public async Task<ActionResult> DeleteSystemGuest([FromForm] string nameGuest)
        {
            try
            {
                return Ok(await _hotelSystemService.DeleteGuest(nameGuest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
    }
}
