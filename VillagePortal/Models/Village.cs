using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VillagePortal.Models
{
    public class Village
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VillageID { get; set; }

        public string VillageName { get; set; }

        public string VillageDescription { get; set; }

        public int NumberOfSchool { get; set; }

        public int NumberOfTemple { get; set; }

        public int NumberOfMosque { get; set; }
    }
}