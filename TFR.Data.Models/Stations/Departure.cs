using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFR.Data.Models
{
    class Departure:IStation
    {           
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter a Departure Station name.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter a valid TFL Station (numbers or symbols are NOT permitted")]
        [Display(Name = "Enter Departure Station")]
        public string Station { get; set; }
    }
}
