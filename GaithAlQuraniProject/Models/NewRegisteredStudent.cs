using GaithAlQuraniProject.Areas.Identity.Pages.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("الاسم")]
        public string Name { get; set; }

        [Required(ErrorMessage = "الرجاء إدخال رقم الجوال")]
        [DisplayName("رقم الجوال")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "الرجاء اختيار الرواية ")] //more details
        [DisplayName("الرواية")]
        public string Rewayah { get; set; }

        [Required(ErrorMessage = "الرجاء إدخال الدولة ")]
        [DisplayName("الدولة")]
        public string Country { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة البرامج الذي يمكن التسميع من خلاله ")]
        [DisplayName("البرامج الذي يمكن التسميع من خلاله")] //more than one may choose
        public string CallingProgram { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة الوقت المناسب للتسميع مع الزميلة ")]
        [DisplayName("الوقت المناسب للتسميع مع الزميلة")]
        public string SuitableTime { get; set; }

        //[Required(ErrorMessage = "الرجاء كتابة البرنامج التي تريدين الاختبار من خلاله ")]
        [DisplayName("البرنامج الذي سيتم الاختبار من خلاله")] //make sure by zome or other program
        public string CallingProgramExam { get; set; }

        //[Required(ErrorMessage = "الرجاء كتابة الوقت المناسب لاختبار التلاوة ")]
        [DisplayName("وقت  لاختبار التلاوة")]
        public string SuitableTimeExam { get; set; }   
        
        [DisplayName("المعلمة المسؤولة عن اختبار التلاوة")]
        public string ExamTeacher { get; set; }
        
        [DisplayName("ملاحظات المعلمة")]
        public string TeacherNotes { get; set; }
        
        [DisplayName("ملاحظات الطالبة")]
        public string StudentNotes { get; set; }
        
        [DisplayName("مجموعة غيث القرآني التي تم الانضمام لها")]
        public string GaithGroup { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }
        //suitable time for doing the exam/ fajr/..
        //teacher
        //group num
        // exam time

    }
}
