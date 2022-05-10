using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public partial class InformationAboutSuppliers
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Information_about_supplie_id { get; set; }


        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int supplies_count { get; set; }


        [Column(Order = 2, TypeName = "money")]
        public decimal supplies_price { get; set; }


        [Column(Order = 3)]
        public DateTime supplies_date { get; set; }


        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int supplier_FK { get; set; }


        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int product_FK { get; set; }

        public virtual Products Products { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
