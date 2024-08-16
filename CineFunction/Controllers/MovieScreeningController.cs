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
            var show = _movieScreeningServices.Get();
            return Ok(show);
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<MovieScreeningDto> GetById([FromRoute] int id)
        {
            var show = _movieScreeningServices.GetById(id); 
            return Ok(show);
        }
        [HttpPost("[action]")]
        public ActionResult Add([FromBody] MovieScreeningRequest movieScreeningRequest)
        {
            var show = _movieScreeningServices.Add(movieScreeningRequest);
            return Ok(show);
        }

        [HttpPut("[action]/{id}")]
        public ActionResult Update([FromBody] MovieScreeningRequest movieScreeningRequest , [FromRoute] int id) 
        {
             _movieScreeningServices.Update(movieScreeningRequest , id);
            return NoContent();

        }
        [HttpDelete("[action] / {id}")]
        public ActionResult Delete(int id) 
        { 
            _movieScreeningServices.Delete(id);
            return NoContent();
        }
        [HttpGet("[action]")]
        public ActionResult<List<FilmDto>> Getfilms()
        {
            var film = _movieScreeningServices.GetFilms();
            return Ok(film);
        }
    }
}
