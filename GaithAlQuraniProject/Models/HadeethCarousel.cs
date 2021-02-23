using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GaithAlQuraniProject.Models
{
    public class HadeethCarousel
    {
        public int Id{ get; set; }

        [DisplayName("حديث أو آية قرآنية")]
        public string Subject{ get; set; }
    }
}
