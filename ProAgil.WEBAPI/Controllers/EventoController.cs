using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;
using ProAgil.WEBAPI.Dtos;

namespace ProAgil.WEBAPI.Controllers {
    [Route ("api/[Controller]")]
    [ApiController]
    public class EventoController : ControllerBase {
        public IProAgilRepository _repo { get; }
        public IMapper _mapper { get; }
        public EventoController (IProAgilRepository repo, IMapper mapper) {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> Get () {
            try {
                var eventos = await _repo.GetAllEventoAsync (true);
                var results = _mapper.Map<EventoDto[]>(eventos);
                return Ok (results);
            } catch (System.Exception ex) {

                return this.StatusCode (StatusCodes.Status500InternalServerError, $"Deu ruim no Banco de Dados {ex.Message}");
            }

        }

        [HttpGet ("{EventoId}")]
        public async Task<IActionResult> Get (int EventoId) {
            try {
                var evento = await _repo.GetEventoAsyncById (EventoId, true);
                var results = _mapper.Map<EventoDto>(evento);
                return Ok (results);
            } catch (System.Exception) {

                return this.StatusCode (StatusCodes.Status500InternalServerError, "Deu ruim no Banco de Dados");
            }

        }

        [HttpGet ("getByTema/{tema}")]
        public async Task<IActionResult> Get (string tema) {
            try {                
                var eventos = await _repo.GetEventoAsyncByTema (tema, true);
                var results = _mapper.Map<EventoDto[]>(eventos);
                return Ok (results);
            } catch (System.Exception) {

                return this.StatusCode (StatusCodes.Status500InternalServerError, "Deu ruim no Banco de Dados");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post (EventoDto model) {
            try {
                var evento = _mapper.Map<Evento>(model);
                _repo.Add (evento);
                if (await _repo.SaveChangesAsync ()) {
                    return Created ($"/api/evento/{model.Id}", _mapper.Map<EventoDto>(evento));
                }

            } catch (System.Exception ex) {

                return this.StatusCode (StatusCodes.Status500InternalServerError, $"Deu ruim no Banco de Dados {ex.Message}");
            }

            return BadRequest ();

        }

        [HttpPut ("{EventoId}")]
        public async Task<IActionResult> Put (int EventoId, EventoDto model) {
            try {
                var evento = await _repo.GetEventoAsyncById (EventoId, false);                
                if (evento == null) return NotFound ();
                _mapper.Map(model, evento);
                _repo.Update(evento);
                if (await _repo.SaveChangesAsync ()) {
                    return Created ($"/api/evento/{model.Id}", _mapper.Map<EventoDto>(evento));
                }

            } catch (System.Exception) {

                return this.StatusCode (StatusCodes.Status500InternalServerError, "Deu ruim no Banco de Dados");
            }

            return BadRequest ();

        }

        [HttpDelete ("{EventoId}")]
        public async Task<IActionResult> Delete (int EventoId) {
            try {
                var evento = await _repo.GetEventoAsyncById (EventoId, false);
                if (evento == null) return NotFound ();
                _repo.Delete (evento);
                if (await _repo.SaveChangesAsync ()) {
                    return Ok ();
                }

            } catch (System.Exception) {

                return this.StatusCode (StatusCodes.Status500InternalServerError, "Deu ruim no Banco de Dados");
            }

            return BadRequest ();

        }
    }
}