using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MovieScreening
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [Required]
        public double Price { get; set; }
       
        //no creo q haga falta ya que film tiene una relacion con el director 
        //[ForeignKey("IdDirector")]
        //public int IdDirector { get; set; }
        //public Director Director { get; set; }

        [Required]
        [ForeignKey("IdFilm")]
        public int IdFilm { get; set; }
        public Film Film { get; set; }
        
    }
}
