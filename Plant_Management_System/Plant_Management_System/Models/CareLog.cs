using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
    public class CareLog
    {
        public int CareLogId { get; set; }
        public DateTime Date { get; set; }
        public string CareDone { get; set; }
    }
}
