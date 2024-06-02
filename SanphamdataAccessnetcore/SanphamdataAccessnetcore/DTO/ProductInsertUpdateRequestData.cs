using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanphamdataAccessnetcore.DTO
{
   public class ProductInsertUpdateRequestData
    {
            public int ProductID { get; set; }
            public int CategoryId { get; set; }
            public string ProductName { get; set; }

            public string AttributeValues { get; set; } // 256 lit -den , 10 , 1000 , 9000 _ 236 lit -den , 15 , 1200 , 10000  
        }

        public class Product_DeleteRequestData
        {
            public int ProductID { get; set; }
        }
    }

