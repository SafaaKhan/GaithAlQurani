using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaithAlQuraniProject.Models
{
    public class Attendence
    {
        public int Id { get; set; }

        public string date { get; set; }

        public string groupName { get; set; }

        public string surahName { get; set; }

        public string attendenceState { get; set; }

        public string Notes { get; set; }

        public NewRegisteredStudent NewRegisteredStudent { get; set; }

        public int NewRegisteredStudentId { get; set; }
    }
}
