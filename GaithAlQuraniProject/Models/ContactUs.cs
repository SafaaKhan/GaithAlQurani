using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GaithAlQuraniProject.Models
{
    public class ContactUs
    {

        public int Id { get; set; }

        [DisplayName("الاسم")]
        public string Name { get; set; }

        [Required]
        [DisplayName("العنوان")]
        public string Subject { get; set; }

        [Required]
        [DisplayName("الايميل")]
        public string Email { get; set; }

        [DisplayName("الموضوع")]
        public string Message { get; set; }

    }
}
