using Application.Interfaces;
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
        private readonly IBaseRepository<MovieScreening> _repositoryBase;
        public MovieScreeningService(IBaseRepository<MovieScreening> repositoryBase) 
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<IEnumerable<MovieScreening>> Get()
        {
            
        }
        public async Task<MovieScreening> GetById(int id)
        {

        }
        public async Task<MovieScreening> Add(MovieScreening movieScreening, int sellerId)
        {

        }
        public async Task Delete(int id)
        {

        }
        public async Task Update(MovieScreening movieScreening)
        {

        }
    }
}
