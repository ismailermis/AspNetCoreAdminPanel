using Data.Repos;
using Data.Specifications.ProductSpecification;
using Microsoft.AspNetCore.Mvc;
using Models.DbEntities;
using Services.Aspects.ValidationAspect;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductService(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }
        public async Task<List<Product>> GetAllAsync(ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var retVal = await _repository.GetAllAsync(spec);
            return (List<Product>)retVal;
        }

        [TypeFilter(typeof(ValidationAspect))]
        public async Task<Product> Add(Product product)
        {
            return await _repository.AddAsync(product);
        }

        public void Update(Product product)
        {
            _repository.Update(product);
        }

        public void Delete(int productId)
        {
            var product = _repository.Find(x => x.Id == productId);
            if (product != null)
            {
                _repository.Delete(product);
            }
        }

        public Product GetById(int productId)
        {
            return _repository.GetById(productId);
        }

        public async Task<int> CountAsync(ProductSpecParams productParams)
        {
            var countSpec = new ProductWithFiltersForCountSpecificication(productParams);
            return await _repository.CountAsync(countSpec);
        }
    }
}
