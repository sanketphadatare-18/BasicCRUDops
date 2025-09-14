using Dal_Layer;
using Dal_Layer.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repo_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Layer.Implimentations
{
    public class ProductRepo : IProductRepo
    {
        ApplicationDbContext _dbcontext;

        public ProductRepo(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Create(Product product)
        {
            _dbcontext.Products.Add(product);
            _dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var product = _dbcontext.Products.Find(Id);
            if(product != null)
            {
                _dbcontext.Products.Remove(product);
                _dbcontext.SaveChanges();

            }
        }

  

        public IEnumerable<Product> GetAll()
        {
            return _dbcontext.Products.Include(p => p.Category).ToList();
        }

        public Product GetbyId(int? Id)
        {
            return _dbcontext.Products.Include(c => c.Category).FirstOrDefault(p => p.id == Id);
        }

        public void Update(Product product)
        {
            var ExistingProduct = _dbcontext.Products.Find(product.id);
            if(ExistingProduct != null)
            {
                ExistingProduct.Name = product.Name;
                ExistingProduct.price = product.price;
                ExistingProduct.CategoryId = product.CategoryId;

                _dbcontext.SaveChanges();
            }
            
        }

        public bool Any(Func<Product, bool> predicate)
        {
            return _dbcontext.Products.Any(predicate);
        }
    }
}
