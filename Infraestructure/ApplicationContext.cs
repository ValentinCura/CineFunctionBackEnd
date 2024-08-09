using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Director>? Directors { get; set; } 
        public DbSet<Film>? Films { get; set; }
        public DbSet<MovieScreening>? MoviesScreening { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {

        }
    }
}
