using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DAL.Models
{
    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            InformationAboutSales = new HashSet<InformationAboutSales>();
            informationAboutSuppliers = new HashSet<InformationAboutSuppliers>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int product_id { get; set; }

        [Required]
        [StringLength(50)]
        public string product_name { get; set; }

        [Required]
        [StringLength(777)]
        public string technical_specifications { get; set; }

        public int count_of_products { get; set; }

        [Column(TypeName = "money")]
        public decimal product_price { get; set; }

        public double? discount { get; set; }

        public int category_FK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InformationAboutSales> InformationAboutSales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InformationAboutSuppliers> informationAboutSuppliers { get; set; }

        public virtual Category Category { get; set; }
    }
}
