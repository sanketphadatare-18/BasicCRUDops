using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Layer
{
     public class Product
    {
        public int id { get; set; }

        public string Name { get; set; }

        public decimal? price { get; set; }


        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
