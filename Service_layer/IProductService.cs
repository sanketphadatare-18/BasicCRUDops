using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service_layer
{
    public interface IProductService
    {
        public IEnumerable<ProductModel> GetAll();

        public ProductModel GetbyId(int? Id);

        public void Create(ProductModel product);

        public void Update(ProductModel product);

        public void Delete(int Id);
        bool Any(Func<Product, bool> predicate);

    }
}
