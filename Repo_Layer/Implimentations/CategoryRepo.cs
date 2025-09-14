using Dal_Layer;
using Dal_Layer.DBContext;
using Microsoft.EntityFrameworkCore;
using Repo_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Layer.Implimentations
{
    public class CategoryRepo : ICategoryRepo
    {

        private readonly ApplicationDbContext _dbContext;
        public CategoryRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var remove = _dbContext.Categories.Include(c =>c.products).FirstOrDefault(c =>c.id == Id);

            if(remove != null)
            {
                _dbContext.Products.RemoveRange(remove.products);
                _dbContext.Categories.Remove(remove);
                _dbContext.SaveChanges();
            }
        }

        public ICollection<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetbyId(int? Id)
        {
            var GetID = _dbContext.Categories.Find(Id);
            if(GetID != null)
            {
                return GetID;
            }
            return null;
        }

        //public void Update(Category category)
        //{
        //    var ExistingData = _dbContext.Categories.Find(category.id);
        //    if(ExistingData != null)
        //    {
        //        _dbContext.Entry(category).State = EntityState.Modified;
        //        _dbContext.SaveChanges();
        //    }
            
        //}
        public void Update(Category category)
        {
            var existingCategory = _dbContext.Categories.Find(category.id);
            if (existingCategory != null)
            {
                // Update only modified fields
                existingCategory.Name = category.Name;


                _dbContext.SaveChanges(); // Save changes
            }
        }
    }
}
