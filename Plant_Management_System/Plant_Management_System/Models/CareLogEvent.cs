using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
    public enum CareTasks
    {
        Water,
        Repot,
        Clean,
        Prune
    }
    public class CareLogEvent
    {

        public int Id { get; set; }

        public AppUser Owner { get; set; }

        public Plant PlantName { get; set; }

        public CareTasks CareDone { get; set; }


        [DataType(DataType.Date)]
        public DateTime DateOfCare { get; set; }

      
    }
}
