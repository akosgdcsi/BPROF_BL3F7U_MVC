using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class System
    {
        [Key]
        public string SystemID { get; set; }
        
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string SectorName { get; set; }
        public virtual ICollection<Star> Stars { get; set; }

    }
}
