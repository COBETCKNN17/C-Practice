using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DojoLeague.Models {
    public class Ninja {

        [Key]
        public int ninja_id { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public string description { get; set; }
        public int dojo_id {get; set;}

        public Dojo dojo {get; set;}

    }
}