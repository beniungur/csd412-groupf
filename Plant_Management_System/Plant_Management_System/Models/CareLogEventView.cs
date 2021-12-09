using System.Collections.Generic;

namespace Plant_Management_System.Models
{
    //This Class is used to support the create view for care log
    public class CareLogEventView
    {
        public CareLogEvent care { get; set; }
        public List<Plant> PlantList { get; set; }
        public int PlantId { get; set; }
        public string OwnerName { get; set; }
        public CareLogEventView()
        {
            this.care = new CareLogEvent();
        }
    }
}
