using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GaithAlQuraniProject.Models
{
    public class ProgramConditionsDefinition
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة العنوان")]
        [DisplayName("عنوان لشروط البرنامج")]
        public string ConditionTitle { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة الشروط")]
        [DisplayName("معلومات عن شروط البرنامج")]
        public string ConditionInfo { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة العنوان")]
        [DisplayName("عنوان للتعريف عن البرنامج")]
        public string DefinitionTitle { get; set; }


        [Required(ErrorMessage = "الرجاء إدخال العنوان")]
        [DisplayName("معلومات للتعريف بالبرنامج")]
        public string DefinitionInfo { get; set; }
    }
}
