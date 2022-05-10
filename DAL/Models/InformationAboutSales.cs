using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{


    public partial class InformationAboutSales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Information_about_sales_id { get; set; }
        public int sales_count { get; set; }

        [Column(TypeName = "money")]
        public decimal sales_price { get; set; }

        public DateTime sales_date { get; set; }

        public int product_FK { get; set; }

        public virtual Products Products { get; set; }
    }
}
