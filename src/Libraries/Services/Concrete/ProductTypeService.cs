using Data.Repos;
using Models.DbEntities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class ProductTypeService : IProductType
    {
        private readonly IGenericRepository<ProductType> _repository;

        public ProductTypeService(IGenericRepository<ProductType> repository)
        {
            _repository = repository;
        }
        public async Task<List<ProductType>> GetAllAsync()
        {
            return (List<ProductType>)await _repository.GetAllAsync();
        }
    }
}
