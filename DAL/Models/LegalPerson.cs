using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{

    public partial class LegalPerson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LegalPerson()
        {
            Supplier = new HashSet<Supplier>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int legal_person_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Legal_person_TIN { get; set; }

        [Required]
        [StringLength(50)]
        public string Legal_person_CRS { get; set; }

        [Required]
        [StringLength(50)]
        public string Legal_person_MSRN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
