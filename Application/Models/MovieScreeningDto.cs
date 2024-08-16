using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class MovieScreeningDto
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        
        public string Time { get; set; }

        [Required]
        public double Price { get; set; }

        public Film Film { get; set; }




        public static MovieScreeningDto Create(MovieScreening movieScreening)
        {
            return new MovieScreeningDto
            {
                Date = movieScreening.Date,
                Time = movieScreening.Time,
                Price = movieScreening.Price,
                Film = movieScreening.Film
            };
        }


        public static List<MovieScreeningDto> CreateList(IEnumerable<MovieScreening> movieScreenings)
        {
            return movieScreenings.Select(Create).ToList();
        }
    }

}

