using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GaithAlQuraniProject.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Subject { get; set; }

        //either must be required or put any default image in the uploadfile or leave it as it is
        public string Image { get; set; }

        //if button status true must those two also be true
        public string ButtonLink { get; set; }

        public string ButtonContent { get; set; }

        [Required]
        public string ButtonStatus { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
