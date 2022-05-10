using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackAPI.Models
{
    public class Supplier
    {
        [Key]
        public int supplier_id { get; set; }
        public int? physical_person_FK { get; set; }
        public int? legal_person_FK { get; set; }
        public virtual PhysicalPerson PhysicalPerson { get; set; }
        public virtual LegalPerson LegalPerson { get; set; }
        public virtual ICollection<InformationAboutSuppliers> InformationAboutSuppliers { get; set; }
    }
}

