using System;
using System.ComponentModel.DataAnnotations;

namespace Plant_Management_System.Models
{
    //// This class defines objects that will store plant propagations
    public class PropagationEvent
    {
        public int Id { get; set; }
        public AppUser Owner { get; set; }
        public Plant ParentPlant { get; set; }

        [DataType(DataType.Date)]
        public DateTime PropDate { get; set; }

        public PropagationEvent()
        {
            //this.ParentPlant = new Plant();
            //this.PropDate = DateTime.Now;
        }
    }
}
