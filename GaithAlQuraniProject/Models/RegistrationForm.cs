using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GaithAlQuraniProject.Models
{
    public class RegistrationForm
    {

        //add Annotation
        public int Id { get; set; }

      
        [Required]
        public string Name { get; set; }
        //country
        //key
        public string phoneNumber { get; set; }

        public GaithGroup GaithGroup { get; set; }


        public int GaithGroupId { get; set; }
        // how many Juzu memorized
        //drop down (inside Ksa (show phone key) or outside) asp.net course

        //Reywayah


    }
}
