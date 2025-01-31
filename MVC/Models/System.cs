﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class System
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SystemID { get; set; }
        
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string SectorName { get; set; }
        public virtual ICollection<Star> Stars { get; set; }
        public override bool Equals(object obj)
        {
            return (obj as System).SystemID == this.SystemID;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
