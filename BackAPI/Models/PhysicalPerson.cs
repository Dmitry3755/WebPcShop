using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackAPI.Models
{
    public class PhysicalPerson
    {
        [Key]
        public int physical_person_id { get; set; }
        public string physical_person_name { get; set; }
        public string physical_person_pasport_number { get; set; }
        public string physical_person_TIN { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
