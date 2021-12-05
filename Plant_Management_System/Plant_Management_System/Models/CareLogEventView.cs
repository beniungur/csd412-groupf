using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
    public class CareLogEventView
    {
        public CareLogEvent care { get; set; }

        //public List<AppUser> OwnerList { get; set; }

        public List<Plant> PlantList { get; set; }

        public int PlantId { get; set; }

        public string OwnerName { get; set; }

        public CareLogEventView()
        {
            this.care = new CareLogEvent();
        }
    }


}
