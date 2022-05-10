using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackAPI.Models
{
    public partial class PhysicalPerson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhysicalPerson()
        {
            Supplier = new HashSet<Supplier>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int physical_person_id { get; set; }

        [Required]
        [StringLength(100)]
        public string physical_person_name { get; set; }

        [Required]
        [StringLength(50)]
        public string physical_person_pasport_number { get; set; }

        [Required]
        [StringLength(50)]
        public string physical_person_TIN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
