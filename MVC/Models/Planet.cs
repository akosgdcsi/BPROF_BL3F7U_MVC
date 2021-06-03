using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Models
{
    public enum PlanetType
    {
        Miniterran, Subterran, Terran, Superterran, Neptunian, Jovian
    }
    public class Planet
    {
        [Key]
        public string PlanetID { get; set; }
        
        [StringLength(200)]
        public string Name { get; set; }
        public PlanetType PlanetType { get; set; }
        public bool Habitable { get; set; }
        public int Population { get; set; }
        public string StarID { get; set; }
        
        [NotMapped]
        [Newtonsoft.Json.JsonIgnore]
        [JsonIgnore]
        public virtual Star Star { get; set; }

        public override bool Equals(object obj)
        {
            return (obj as Planet).PlanetID == this.PlanetID;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
