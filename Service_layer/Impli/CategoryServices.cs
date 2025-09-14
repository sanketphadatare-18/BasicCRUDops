using AutoMapper;
using Dal_Layer;
using Repo_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service_layer.Impli
{
    public class CategoryServices : ICategoryServieces
    {
        ICategoryRepo _catrepo;
        IMapper _mapper;

        public CategoryServices(ICategoryRepo catrepo, IMapper mapper)
        {
            _catrepo = catrepo;
            _mapper = mapper;
        }

        public void Create(CategoryModel category)
        {
            var cate = _mapper.Map<Category>(category);
            _catrepo.Create(cate);
        }

        public void Delete(int Id)
        {
            _catrepo.Delete(Id);
        }

        public ICollection<CategoryModel> GetAll()
        {
            var category = _catrepo.GetAll();
            var categoryModels = _mapper.Map<List<CategoryModel>>(category);
            return categoryModels;

            //var category = _catrepo.GetAll(); // Ensure GetAll() is a method, not a property
            //return _mapper.Map<List<CategoryModel>>(category);
        }

        public CategoryModel GetbyId(int? Id)
        {
            Category car = _catrepo.GetbyId(Id);
            return _mapper.Map<CategoryModel>(car);
        }

        public void Update(CategoryModel category)
        {
            //_catrepo.Update(_mapper.Map<Category>(category));
            var categ = _mapper.Map<Category>(category);
            _catrepo.Update(categ);
        }
    }
}
