using Dal_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoryModel
    {
        [Key]
            public int id { get; set; }
        [Required]
            public string Name { get; set; }
    }
}
