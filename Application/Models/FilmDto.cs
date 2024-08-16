using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class FilmDto
    {
        public int Id { get; set; } 
        [Required]
        
        public string Name { get; set; }

        [Required]
       
        public string Description { get; set; }

        public int IdDirector { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public Director Director { get; set; }


        public static FilmDto Create(Film film)
        {
            return new FilmDto
            {
                Id = film.Id,
                Name= film.Name,
                Description= film.Description,
                IdDirector= film.IdDirector,
                Origin= film.Origin,
                ImageUrl= film.ImageUrl,
                Director= film.Director,
            };
        }


        public static List<FilmDto> CreateList(IEnumerable<Film> film)
        {
            return film.Select(Create).ToList();
        }
    }
}
