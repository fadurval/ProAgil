using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.WEBAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        public IProAgilRepository _repo { get; }
        public EventoController(IProAgilRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetEventoAsync(true);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Deu ruim no Banco de Dados");
            }

        }

        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int EventoId)
        {
            try
            {
                var results = await _repo.GetEventoAsyncById(EventoId, true);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Deu ruim no Banco de Dados");
            }

        }

        [HttpGet("getByTema/{tema}")]
        public async Task<IActionResult> Get(string tema)
        {
            try
            {
                var results = await _repo.GetEventoAsyncByTema(tema, true);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Deu ruim no Banco de Dados");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Deu ruim no Banco de Dados");
            }

            return BadRequest();

        }

        [HttpPut("{EventoId}")]
        public async Task<IActionResult> Put(int EventoId, Evento model)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(EventoId, false);
                if (evento == null) return NotFound();
                _repo.Update(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Deu ruim no Banco de Dados");
            }

            return BadRequest();

        }

        [HttpDelete("{EventoId}")]
        public async Task<IActionResult> Delete(int EventoId)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(EventoId, false);
                if (evento == null) return NotFound();
                _repo.Delete(evento);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Deu ruim no Banco de Dados");
            }

            return BadRequest();

        }
    }
}