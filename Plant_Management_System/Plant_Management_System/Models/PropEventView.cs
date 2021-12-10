using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
    public class PropEventView
    {
        public PropagationEvent prop { get; set; }

        public List<Plant> plantList { get; set; }

        public int ParentPlant { get; set;}

        public string OwnerName { get; set; }

        public PropEventView()
        {
            this.prop = new PropagationEvent();
        }

    }
}
