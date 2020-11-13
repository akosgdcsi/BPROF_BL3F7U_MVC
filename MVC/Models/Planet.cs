using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

    }
}
