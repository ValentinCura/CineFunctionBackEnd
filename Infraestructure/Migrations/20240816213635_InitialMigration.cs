using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IdDirector = table.Column<int>(type: "INTEGER", nullable: false),
                    Origin = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Directors_IdDirector",
                        column: x => x.IdDirector,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesScreening",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    IdDirector = table.Column<int>(type: "INTEGER", nullable: false),
                    IdFilm = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesScreening", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviesScreening_Directors_IdDirector",
                        column: x => x.IdDirector,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesScreening_Films_IdFilm",
                        column: x => x.IdFilm,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Christopher Nolan" },
                    { 2, "George Lucas" },
                    { 3, "Juan José Campanella" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "IdDirector", "ImageUrl", "Name", "Origin" },
                values: new object[,]
                {
                    { 1, "Durante la Segunda Guerra Mundial, el teniente general Leslie Groves designa al físico J. Robert Oppenheimer para un grupo de trabajo que está desarrollando el Proyecto Manhattan, cuyo objetivo consiste en fabricar la primera bomba atómica.", 1, "https://m.media-amazon.com/images/M/MV5BMjVhNGYyMTktNWU0Yi00YjQwLWJmYTQtNDJmODliOTE0NmY5XkEyXkFqcGdeQXVyMTQ4NTgxNzYx._V1_FMjpg_UX880_.jpg", "Oppenheimer", "Internacional" },
                    { 2, "Gracias a un descubrimiento, un grupo de científicos y exploradores, encabezados por Cooper, se embarcan en un viaje espacial para encontrar un lugar con las condiciones necesarias para reemplazar a la Tierra y comenzar una nueva vida allí.", 1, "https://m.media-amazon.com/images/M/MV5BZjdkOTU3MDktN2IxOS00OGEyLWFmMjktY2FiMmZkNWIyODZiXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_FMjpg_UY3600_.jpg", "Interestelar", "Internacional" },
                    { 3, "Dom Cobb es un ladrón con una extraña habilidad para entrar a los sueños de la gente y robarles los secretos de sus subconscientes. Su habilidad lo ha vuelto muy popular en el mundo del espionaje corporativo, pero ha tenido un gran costo en la gente que ama. Cobb obtiene la oportunidad de redimirse cuando recibe una tarea imposible: plantar una idea en la mente de una persona. Si tiene éxito, será el crimen perfecto, pero un enemigo se anticipa a sus movimientos.", 1, "https://m.media-amazon.com/images/M/MV5BMTUzMzUyOTktNmYyNS00YTA1LWIxNmQtMGIzZDYxZGI3OTliXkEyXkFqcGdeQXVyMTYzMDM0NTU@.V1_FMjpg_UY2812.jpg", "El origen", "Internacional" },
                    { 4, "Obi-Wan Kenobi es un joven aprendiz caballero Jedi bajo la tutela de Qui-Gon Jinn; Anakin Skywalker, quien después será padre de Luke Skywalker y se convertirá en Darth Vader, solamente es un niño de 9 años. Cuando la Federación de Comercio corta todas las rutas al planeta Naboo, Qui-Gon y Obi-Wan son asignados para solucionar el problema.", 2, "https://m.media-amazon.com/images/M/MV5BZWYwZDZjMmQtZGYzZC00MzhkLWE4MDYtMDg0ZGQ4MmU3YjRlXkEyXkFqcGdeQXVyNzA4ODc3ODU@._V1_FMjpg_UX398_.jpg", "Star Wars: episodio I", "Internacional" },
                    { 5, "En el Senado Galáctico reina la inquietud. Varios miles de sistemas solares han declarado su intención de abandonar la República. La reina Amidala regresa al Senado para conseguir un ejército que ayude a los caballeros jedi.", 2, "https://m.media-amazon.com/images/M/MV5BYTAzNjA4ZDMtNTZmNi00MDg2LTg4NzctNGI4NDYyMDMyZmNjXkEyXkFqcGdeQXVyNzExODc3Nzk@._V1_FMjpg_UX871_.jpg", "Star Wars: episodio II", "Internacional" },
                    { 6, "Seducido por el lado oscuro, Anakin Skywalker se rebela contra su mentor, Obi-Wan Kenobi, y se convierte en Darth Vader.", 2, "https://m.media-amazon.com/images/M/MV5BMzk2NDEzYjAtMGNhZC00MjAyLWFjNjctYWQwNDgyNzg3YTFkXkEyXkFqcGdeQXVyODIyOTEyMzY@._V1_FMjpg_UX816_.jpg", "Star wars: episodio III", "Internacional" },
                    { 7, "Amadeo es un chico tímido y virtuoso que deberá enfrentarse a un habilidoso rival sobre el campo de fútbol, conocido con el apodo de El Crack. Para ello, contará con la inestimable ayuda de unos jugadores de futbolín liderados por el Wing, un carismático extremo derecho. Las aventuras de Amadeo y los jugadores tendrán como telón de fondo no solo el fútbol, sino también el amor, la amistad y la pasión.", 3, "https://m.media-amazon.com/images/M/MV5BMTEzMjY1OTM5NjVeQTJeQWpwZ15BbWU3MDcyMjU2NTk@._V1_FMjpg_UY1969_.jpg", "Metegol", "Nacional" },
                    { 8, "Un juez tiene dudas acerca de los planes de un oficial de justicia recientemente retirado que intenta descubrir al culpable de la violación y el asesinato de una joven, crimen ocurrido varias décadas atrás.", 3, "https://m.media-amazon.com/images/M/MV5BMTk0NTYzNjEyOF5BMl5BanBnXkFtZTcwOTAwMDk2Mw@@._V1_FMjpg_UX352_.jpg", "El secreto de sus ojos", "Nacional" },
                    { 9, "Rafael Belvedere piensa que las cosas deberían irle mejor. Dedica las veinticuatro horas del día al restaurante fundado por su padre, carga con un divorcio, no se ha tomado el tiempo suficiente para ver crecer a su hija, no tiene amigos y prefiere eludir un mayor compromiso con su novia. Además, hace más de un año que no visita a su madre, que sufre el mal de Alzheimer y está internada en un geriátrico.", 3, "https://m.media-amazon.com/images/M/MV5BZDk2OTkxYmItZTc5Ni00YjI0LTg4M2YtN2Y2NjRhYTA4NTA4XkEyXkFqcGdeQXVyMTU3NDU4MDg2._V1_FMjpg_UX1070_.jpg", "El hijo de la novia", "Nacional" },
                    { 10, "El club social Luna de Avellaneda está amenazado de ser transformado en un casino a causa de la crisis económica en Argentina. Román, uno de los más antiguos miembros del club, luchará para mantenerlo.", 3, "https://m.media-amazon.com/images/M/MV5BMjA5NTM3NTkzN15BMl5BanBnXkFtZTcwNzAzNDMzMQ@@._V1_FMjpg_UX279_.jpg", "Luna de avellaneda", "Nacional" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_IdDirector",
                table: "Films",
                column: "IdDirector");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesScreening_IdDirector",
                table: "MoviesScreening",
                column: "IdDirector");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesScreening_IdFilm",
                table: "MoviesScreening",
                column: "IdFilm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviesScreening");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
