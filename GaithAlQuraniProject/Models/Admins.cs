using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GaithAlQuraniProject.Models
{
    public class Admins
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("اسم المشرفة")]
        public string Name { get; set; }

        [Required]
        [DisplayName("اسم المجموعة المسؤولة عنها")]
        public string Subject { get; set; }  
        
        [Required]
        [DisplayName("عبارة أو مقولة")]
        public string Phrases { get; set; }
    }
}
