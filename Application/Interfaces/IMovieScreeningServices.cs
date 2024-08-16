using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieScreeningServices
    {
        List<MovieScreeningDto> Get();
        MovieScreeningDto GetById(int id);
        MovieScreening Add(MovieScreeningRequest movieScreeningRequest);
        void Delete(int id);
        void Update(MovieScreeningRequest movieScreeningRequest, int id);
        List<FilmDto> GetFilms();
    }
}
