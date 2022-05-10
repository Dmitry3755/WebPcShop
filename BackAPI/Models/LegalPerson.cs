using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackAPI.Models
{
    public class LegalPerson
    {
        [Key]
        public int legal_person_id { get; set; }
        public string Legal_person_TIN { get; set; }
        public string Legal_person_CRS { get; set; }
        public string Legal_person_MSRN { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
