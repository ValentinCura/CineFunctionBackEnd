using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieScreeringServices
    {
        Task<IEnumerable<MovieScreening>> GetAllMovieScreening();
        Task<MovieScreening> GetMovieScreeningById(int id);
        Task<MovieScreening> CreateMovieScreening(MovieScreening movieScreening, int sellerId);
        Task DeleteMovieScreening(int id);
        Task UpdateMovieScreening(int id, MovieScreening movieScreening);
    }
}
