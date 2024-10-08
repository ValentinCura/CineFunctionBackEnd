﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class MovieScreeningRequest
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        
        public string Time { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int IdFilm { get; set; }
    }
}
