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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>().HasData(
                new Director
                {
                    Id = 1,
                    Name = "Christopher Nolan"
                });

            modelBuilder.Entity<Director>().HasData(
                new Director
                {
                    Id = 2,
                    Name = "George Lucas"
                });

            modelBuilder.Entity<Director>().HasData(
                new Director
                {
                    Id = 3,
                    Name = "Juan José Campanella"
                });

            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 1,
                    Name = "Oppenheimer",
                    Description = "Durante la Segunda Guerra Mundial, el teniente general Leslie Groves designa al físico J. Robert Oppenheimer para un grupo de trabajo que está desarrollando el Proyecto Manhattan, cuyo objetivo consiste en fabricar la primera bomba atómica.",
                    IdDirector = 1,
                    Origin = "Internacional"
                });

            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 2,
                    Name = "Interestelar",
                    Description = "Gracias a un descubrimiento, un grupo de científicos y exploradores, encabezados por Cooper, se embarcan en un viaje espacial para encontrar un lugar con las condiciones necesarias para reemplazar a la Tierra y comenzar una nueva vida allí.",
                    IdDirector = 1,
                    Origin = "Internacional"
                });

            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 3,
                    Name = "El origen",
                    Description = "Dom Cobb es un ladrón con una extraña habilidad para entrar a los sueños de la gente y robarles los secretos de sus subconscientes. Su habilidad lo ha vuelto muy popular en el mundo del espionaje corporativo, pero ha tenido un gran costo en la gente que ama. Cobb obtiene la oportunidad de redimirse cuando recibe una tarea imposible: plantar una idea en la mente de una persona. Si tiene éxito, será el crimen perfecto, pero un enemigo se anticipa a sus movimientos.",
                    IdDirector = 1,
                    Origin = "Internacional"
                });

            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 4,
                    Name = "Star Wars: episodio I",
                    Description = "Obi-Wan Kenobi es un joven aprendiz caballero Jedi bajo la tutela de Qui-Gon Jinn; Anakin Skywalker, quien después será padre de Luke Skywalker y se convertirá en Darth Vader, solamente es un niño de 9 años. Cuando la Federación de Comercio corta todas las rutas al planeta Naboo, Qui-Gon y Obi-Wan son asignados para solucionar el problema.",
                    IdDirector = 2,
                    Origin = "Internacional"
                });

            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 5,
                    Name = "Star Wars: episodio II",
                    Description = "En el Senado Galáctico reina la inquietud. Varios miles de sistemas solares han declarado su intención de abandonar la República. La reina Amidala regresa al Senado para conseguir un ejército que ayude a los caballeros jedi.",
                    IdDirector = 2.
                    Origin = "Internacional"
                });

            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 6,
                    Name = "Star wars: episodio III",
                    Description = "Seducido por el lado oscuro, Anakin Skywalker se rebela contra su mentor, Obi-Wan Kenobi, y se convierte en Darth Vader.",
                    IdDirector = 2,
                    Origin = "Internacional"
                });

            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 7,
                    Name = "Metegol",
                    Description = "Amadeo es un chico tímido y virtuoso que deberá enfrentarse a un habilidoso rival sobre el campo de fútbol, conocido con el apodo de El Crack. Para ello, contará con la inestimable ayuda de unos jugadores de futbolín liderados por el Wing, un carismático extremo derecho. Las aventuras de Amadeo y los jugadores tendrán como telón de fondo no solo el fútbol, sino también el amor, la amistad y la pasión.",
                    IdDirector = 3,
                    Origin = "Nacional"
                });

            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 8,
                    Name = "El secreto de sus ojos",
                    Description = "Un juez tiene dudas acerca de los planes de un oficial de justicia recientemente retirado que intenta descubrir al culpable de la violación y el asesinato de una joven, crimen ocurrido varias décadas atrás.",
                    IdDirector = 3,
                    Origin = "Nacional"
                });

            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 9,
                    Name = "El hijo de la novia",
                    Description = "Rafael Belvedere piensa que las cosas deberían irle mejor. Dedica las veinticuatro horas del día al restaurante fundado por su padre, carga con un divorcio, no se ha tomado el tiempo suficiente para ver crecer a su hija, no tiene amigos y prefiere eludir un mayor compromiso con su novia. Además, hace más de un año que no visita a su madre, que sufre el mal de Alzheimer y está internada en un geriátrico.",
                    IdDirector = 3,
                    Origin = "Nacional"
                });

            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 10,
                    Name = "Luna de avellaneda",
                    Description = "El club social Luna de Avellaneda está amenazado de ser transformado en un casino a causa de la crisis económica en Argentina. Román, uno de los más antiguos miembros del club, luchará para mantenerlo.",
                    IdDirector = 3,
                    Origin = "Nacional"
                });

            modelBuilder.Entity<Film>()
                .HasOne(f => f.Director)
                .WithMany()
                .HasForeignKey(f => f.IdDirector);

            base.OnModelCreating(modelBuilder);
        }
    }
}
