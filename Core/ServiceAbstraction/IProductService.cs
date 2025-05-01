using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IProductService
    {
        //GetAll products
        Task<IEnumerable<ProductDTo>> GetAllProductsAsync();

        //Get product by id 
        Task<ProductDTo> GetProductByIdAsync(int Id);
        //GetAll types
        Task<IEnumerable<TypeDTo>> GetAllTypesAsync();

        //GetAll brands
        Task<IEnumerable<BrandDTo>> GetAllBrandsAsync();


    }
}
