using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackAPI.Models
{
    public class Products
    {
        [Key]
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string technical_specifications { get; set; }
        public int count_of_products { get; set; }
        public decimal product_price { get; set; }
        public double? discount { get; set; }
        public int category_FK { get; set; }

        public virtual ICollection<InformationAboutSales> InformationAboutSales { get; set; }
        public virtual ICollection<InformationAboutSuppliers> InformationAboutSuppliers { get; set; }
        public virtual Category Category { get; set; }
    }
}
