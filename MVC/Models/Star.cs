﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public enum StarType
    {
        Blue_Stars, Yellow_Dwarfs, Orange_Dwarfs, Red_Dwarfs, White_Dwarfs, Red_Giants, Blue_Giants
    }
    public class Star
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string StarID { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
        public StarType StarType { get; set; }
        
        public int Age { get; set; }
        public string SystemID { get; set; }
        [NotMapped]
        [Newtonsoft.Json.JsonIgnore]
        [JsonIgnore]
        public virtual System System { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }
        //public override bool Equals(object obj)
        //{
        //    return (obj as Star).StarID == this.StarID;
        //}
        public override int GetHashCode()
        {
            return base.GetHashCode();  
        }
    }
}
