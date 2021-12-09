using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
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
