using Models.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductBrand
    {
        Task<List<ProductBrand>> GetAllAsync();
    }
}
