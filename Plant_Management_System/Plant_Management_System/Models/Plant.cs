using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Plant_Management_System.Models
{
    public enum WaterNeed
    {
        High,
        Medium,
        Low
    }
    public enum LightNeed
    {
        Direct,
        Indirect,
        Minimal
    }
    public enum GrowthMediums
    {
        Soil,
        [Display(Name = "Aroid-mix")]
        AroidMix,
        [Display(Name = "Cactus-Mix")]
        CactusMix,
        Soilless
    }
    public enum PotTypes
    {
        Plastic,
        Terracotta,
        Metal,
        Other
    }
    public enum Rarities
    {
        Rare,
        [Display(Name = "Semi-Rare")]
        SemiRare,
        Common
    }
    public enum Availabilities
    {
        [Display(Name = "Not For Sale")]
        NotForSale,
        [Display(Name = "For Sale")]
        ForSale
    }

    public class Plant
    {
        public int PlantId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Water Needs")]
        public WaterNeed WaterNeeds { get; set; }
        [Display(Name = "Light Needs")]
        public LightNeed LightNeeds { get; set; }
        [Display(Name = "Growth Medium")]
        public GrowthMediums GrowthMedium { get; set; }
        [Display(Name = "Pot Type")]
        public PotTypes PotType { get; set; }
        public Rarities Rarity { get; set; }
        public Availabilities Availability { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Last Repotted")]
        public DateTime LastRepotted { get; set; }
        public int CareLogId { get; set; }
        public AppUser Owner { get; set; }
    }
}
