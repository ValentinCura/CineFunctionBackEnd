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
        Task<IEnumerable<MovieScreening>> Get();
        Task<MovieScreening> GetById(int id);
        Task<MovieScreening> Add(MovieScreening movieScreening, int sellerId);
        Task Delete(int id);
        Task Update( MovieScreening movieScreening);
    }
}
