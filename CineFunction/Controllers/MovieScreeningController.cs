using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CineFunction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieScreeningController : ControllerBase
    {
        private readonly IMovieScreeningServices _movieScreeningServices;

        public MovieScreeningController(IMovieScreeningServices movieScreeningServices) 
        { 
            _movieScreeningServices = movieScreeningServices;
        }

        [HttpGet("[action]")]
        public ActionResult<List<MovieScreeningDto>> Get() 
        {
            try 
            {
                var show = _movieScreeningServices.Get();
                return Ok(show);
            }
            catch (Exception ex) {
                return NotFound(ex.Message);
            }
            
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<MovieScreeningDto> GetById([FromRoute] int id)
        {
            try 
            {
                var show = _movieScreeningServices.GetById(id);
                return Ok(show);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("[action]")]
        public ActionResult Add([FromBody] MovieScreeningRequest movieScreeningRequest)
        {
            try
            {
                var show = _movieScreeningServices.Add(movieScreeningRequest);
                return Ok(show);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]/{id}")]
        public ActionResult Update([FromBody] MovieScreeningRequest movieScreeningRequest , [FromRoute] int id) 
        {
            try 
            {
                _movieScreeningServices.Update(movieScreeningRequest, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpDelete("[action] / {id}")]
        public ActionResult Delete(int id)
        {
            try 
            {
                _movieScreeningServices.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("[action]")]
        public ActionResult<List<FilmDto>> Getfilms()
        {
            try 
            {
                var film = _movieScreeningServices.GetFilms();
                return Ok(film);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
