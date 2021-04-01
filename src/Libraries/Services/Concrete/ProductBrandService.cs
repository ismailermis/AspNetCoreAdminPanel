using Data.Repos;
using Models.DbEntities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class ProductBrandService : IProductBrand
    {
        private readonly IGenericRepository<ProductBrand> _repository;

        public ProductBrandService(IGenericRepository<ProductBrand> repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductBrand>> GetAllAsync()
        {
            return (List<ProductBrand>)await _repository.GetAllAsync();
        }
    }
}
