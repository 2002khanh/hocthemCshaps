using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanphamdataAccessnetcore.DTO
{
    public class Product
    {
         {
        [Key]
        public int ProductID { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public List<ProductAttribute> productAttributes { get; set; }
    }

    public class Product_Attribute
    {
        public int ProductID { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }


    }
}

