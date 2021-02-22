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

        [Required(ErrorMessage = "الرجاء إدخال الاسم")]
        public string Name { get; set; }

        [Required(ErrorMessage = "الرجاء إدخال رقم الجوال")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "الرجاء اختيار الرواية ")] //more details
        public string Rewayah { get; set; }

        [Required(ErrorMessage = "الرجاء اختيار الدولة ")] 
        public string Country { get; set; }         

        [Required(ErrorMessage = "الرجاء كتابة مقدار ما تم حفظه ")] //more details
        public string MemorizedPart { get; set; }

        public GaithGroup GaithGroup { get; set; }

        public int GaithGroupId { get; set; }
        // how many Juzu memorized
        //drop down (inside Ksa (show phone key) or outside) asp.net course

        //Reywayah


    }
}
