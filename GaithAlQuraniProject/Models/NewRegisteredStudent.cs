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

        [Required(ErrorMessage = "الرجاء كتابة مقدار ما تم حفظه ")] //more details
        public string MemorizedPart { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة البرامج الذي يمكن التسميع من خلاله ")] 
        public string CallingProgram { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة الوقت المناسب للتسميع مع الزميلة ")] 
        public string SuitableTime { get; set; }

    }
}
