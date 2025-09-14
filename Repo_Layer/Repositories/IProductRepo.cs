using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Layer.Repositories
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAll();

        public Product GetbyId(int? Id);

        public void Create(Product product);

        public void Update(Product product);

        public void Delete(int Id);
        bool Any(Func<Product, bool> predicate);

    }
}
