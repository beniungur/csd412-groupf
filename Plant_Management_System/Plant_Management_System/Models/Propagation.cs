using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
    public class Propagation
    {
        public int PropagationId { get; set; }
        public Plant ParentPlant { get; set; }
        public string Type { get; set; }
        public DateTime DateStarted { get; set; }
        public string PropagationMedium { get; set; }
    }
}
