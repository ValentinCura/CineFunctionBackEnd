using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovieScreeningService : IMovieScreeningServices
    {
        private readonly IMovieScreeningRepository _repositoryBase;

        private readonly IFilmRepository _filmRepository;

        private readonly IDirectorRepository _directorRepository; 
        public MovieScreeningService(IMovieScreeningRepository movieScreeningRepository, IFilmRepository filmRepository, IDirectorRepository directorRepository)
        {
            _repositoryBase = movieScreeningRepository;
            _filmRepository = filmRepository;
            _directorRepository = directorRepository;
        }

        public List<MovieScreeningDto> Get()
        {

            var show = _repositoryBase.Get();

            if (show == null || !show.Any())
            {
                return new List<MovieScreeningDto>();
            }

            var movieScreeningDto = MovieScreeningDto.CreateList(show);
            return movieScreeningDto;
        }
        public MovieScreeningDto GetById(int id)
        {
            var show = _repositoryBase.GetById(id);

            if (show == null)
            {
                throw new Exception("La funcion no se ha encontrado.");
            }

            var movieScreeningDto = MovieScreeningDto.Create(show);
            return movieScreeningDto;
        }
        public MovieScreening Add(MovieScreeningRequest movieScreeningRequest)
        {

            //en este caso traemos la listaa de shows para verificar y buscar los directores si ya tienen 1o funciones o mas
            var showsByDirector = _repositoryBase.Get();
            var film = _filmRepository.GetById(movieScreeningRequest.IdFilm);
            var directorShows = showsByDirector.Where(s => s.Film.IdDirector == film.IdDirector && s.Date.Date == movieScreeningRequest.Date.Date).ToList();

            if (directorShows.Count >= 10)
                throw new Exception("El director ya tiene 10 funciones en el día.");
            //aca esta la otra logica que verifica si la la peli es internacional 
            if (film.Origin == "Internacional")
            {
                var filmShowings = _repositoryBase.Get()
                                    .Where(s => s.IdFilm == movieScreeningRequest.IdFilm && s.Date.Date == movieScreeningRequest.Date.Date)
                                    .Count();

                if (filmShowings >= 8)
                {
                    throw new Exception("La película internacional ya tiene 8 funciones asignadas.");
                }
            }

            var filmA = _filmRepository.GetById(movieScreeningRequest.IdFilm);
            var director = _directorRepository.GetById(filmA.IdDirector);

            var shows = new MovieScreening
            {
                Date = movieScreeningRequest.Date,
                Time = movieScreeningRequest.Time,
                Price = movieScreeningRequest.Price,
                IdFilm = movieScreeningRequest.IdFilm,
                Director = director,

            };

            return _repositoryBase.Add(shows);
        }
        public void Delete(int id)
        {
            var movieScreening = _repositoryBase.GetById(id);

            if (movieScreening == null)
            {
                throw new Exception("La función no existe.");
            }


            _repositoryBase.Remove(movieScreening);
        }
        public void Update(MovieScreeningRequest movieScreeningRequest, int id)
        {

            var existingMovieScreening = _repositoryBase.GetById(id);

            if (existingMovieScreening == null)
            {
                throw new Exception("La función no existe.");
            }

            //var film = _filmRepository.GetById(movieScreening.IdFilm);


            existingMovieScreening.Date = movieScreeningRequest.Date;
            existingMovieScreening.Time = movieScreeningRequest.Time;
            existingMovieScreening.Price = movieScreeningRequest.Price;
            //existingMovieScreening.Film = film;
            existingMovieScreening.IdFilm = movieScreeningRequest.IdFilm;



            _repositoryBase.Update(existingMovieScreening);
        }

        public List<FilmDto> GetFilms()
        {

            var film = _filmRepository.Get();

            if (film == null || !film.Any())
            {
                return new List<FilmDto>();
            }

            var filmDto = FilmDto.CreateList(film);
            return filmDto;
        }

    }
}
