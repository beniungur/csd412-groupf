using System;
using System.ComponentModel.DataAnnotations;

namespace Plant_Management_System.Models
{
    public enum CareTasks
    {
        Water,
        Repot,
        Clean,
        Prune
    }
    // Care log event defines objects that will store plant maintenence activities
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
