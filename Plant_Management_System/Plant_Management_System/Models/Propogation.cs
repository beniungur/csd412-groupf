using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
    public class Propogation
    {
        public int PropogationId { get; set; }
        public int ParentPlantId { get; set; }
        public string Type { get; set; }
        public DateTime DateStarted { get; set; }
        public string PropogationMedium { get; set; }
    }
}
