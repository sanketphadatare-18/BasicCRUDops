using AutoMapper;
using Dal_Layer;
using Repo_Layer.Implimentations;
using Repo_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service_layer.Impli
{
    public class ProductServices : IProductService
    {
        private readonly IProductRepo _prorepo;
        private readonly IMapper _mapper;

        public ProductServices(IProductRepo prorepo, IMapper mapper)
        {
            _prorepo = prorepo;
            _mapper = mapper;
        }

    


        public bool Any(Func<Product, bool> predicate)
        {
            return _prorepo.Any(predicate);
        }

        public void Create(ProductModel product)
        {
            var prod = _mapper.Map<Product>(product);
            _prorepo.Create(prod);
        }

        public void Delete(int Id)
        {
             _prorepo.Delete(Id);
        }

        public IEnumerable<ProductModel> GetAll()
        {
            var get = _prorepo.GetAll();
            var getall = _mapper.Map<List<ProductModel>>(get);
            return getall;
        }

        public ProductModel GetbyId(int? Id)
        {
            Product get = _prorepo.GetbyId(Id);
            return _mapper.Map<ProductModel>(get);
        }

        public void Update(ProductModel product)
        {
            var prod = _mapper.Map<Product>(product);
            _prorepo.Update(prod);
        }
    }
}
