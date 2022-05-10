using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackAPI.Models
{
    public class InformationAboutSuppliers
    {
        [Key]
        public int Information_about_supplie_id { get; set; }
        public int supplies_count { get; set; }
        public decimal supplies_price { get; set; }
        public DateTime supplies_date { get; set; }
        public int supplier_FK { get; set; }
        public int product_FK { get; set; }
        public virtual Products Products { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}