using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GaithAlQuraniProject.Models
{
    public class StudentLogin
    {
        [Required(ErrorMessage = "الرجاء إدخال اسم المستخدم")] /*the username exists*/
        [DisplayName("اسم المستخدم")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "الرجاء إدخال كلمة مرور")]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }
    }
}
