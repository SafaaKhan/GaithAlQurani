using GaithAlQuraniProject.Areas.Identity.Pages.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GaithAlQuraniProject.Models
{
    public class NewRegisteredStudent 
    {
        //add displayName
        //add Annotation
        public int Id { get; set; }

        [Required(ErrorMessage = "الرجاء إدخال الاسم")]
        public string Name { get; set; }

        [Required(ErrorMessage = "الرجاء إدخال رقم الجوال")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "الرجاء اختيار الرواية ")] //more details
        public string Rewayah { get; set; }

        [Required(ErrorMessage = "الرجاء إدخال الدولة ")]
        public string Country { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة البرامج الذي يمكن التسميع من خلاله ")] 
        public string CallingProgram { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة الوقت المناسب للتسميع مع الزميلة ")] 
        public string SuitableTime { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }
        //suitable time for doing the exam/ fajr/..
        //teacher
        //group num
        // exam time

    }
}
