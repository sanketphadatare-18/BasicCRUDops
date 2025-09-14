using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Layer.Repositories
{
    public interface ICategoryRepo
    {
        public ICollection<Category> GetAll();

        public Category GetbyId(int? Id);

        public void Create(Category category);

        public void Update(Category category);

        public void Delete(int Id);
    }
}
