using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class MovieScreeningRepository : BaseRepository<MovieScreening> , IMovieScreeningRepository
    {
        private readonly ApplicationContext _context;
        public MovieScreeningRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        public override List<MovieScreening>? Get()
        {
            var movieScreening = _context.MoviesScreening.Include(f => f.Film).Include(f => f.Film.Director).ToList();
            return movieScreening;
        }
    }
}
