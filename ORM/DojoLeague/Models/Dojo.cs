using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DojoLeague.Models {
    public class Dojo {

        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string description { get; set; }

        public IEnumerable<Ninja> ninjas {get; set;}

        public Dojo() {
            ninjas = new List<Ninja>(); 
        }
    }
}