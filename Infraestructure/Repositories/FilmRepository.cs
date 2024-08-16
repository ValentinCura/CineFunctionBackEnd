using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class FilmRepository : BaseRepository<Film>, IFilmRepository
    {
        private readonly ApplicationContext _context;
        public FilmRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
