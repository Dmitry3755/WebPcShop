using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            informationAboutSuppliers = new HashSet<InformationAboutSuppliers>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int supplier_id { get; set; }

        public int? physical_person_FK { get; set; }

        public int? legal_person_FK { get; set; }

        public virtual LegalPerson legalPerson { get; set; }

        public virtual PhysicalPerson physicalPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InformationAboutSuppliers> informationAboutSuppliers { get; set; }
    }
}

