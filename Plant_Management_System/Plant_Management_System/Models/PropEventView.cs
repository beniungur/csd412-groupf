using System.Collections.Generic;

namespace Plant_Management_System.Models
{
    //This Class is used to support the create view for the Propagations view
    public class PropEventView
    {
        public PropagationEvent prop { get; set; }
      
        public List<Plant> plantList { get; set; }
      
        public int ParentPlant { get; set;}
      
        public string OwnerName { get; set; }
      
        public string OwnerName { get; set; }
      
        public PropEventView()
        {
            this.prop = new PropagationEvent();
        }
    }
}
