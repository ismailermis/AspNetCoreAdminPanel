using Data.Specifications.ProductSpecification;
using Models.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        Task<List<Product>> GetAllAsync(ProductSpecParams productParams);
        Task<int> CountAsync(ProductSpecParams productParams);
        Task<Product> Add(Product product);
        void Update(Product product);
        void Delete(int productId);
        Product GetById(int productId);
    }
}
