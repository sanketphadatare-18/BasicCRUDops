using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Layer
{
    public class Category
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
