using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Domain.Entities
{
    public class Film
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        [Required]
        [ForeignKey("IdDirector")]
        public int IdDirector { get; set; }
        public Director Director { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string ImageUrl {  get; set; } 

    }
}
