using System.Collections.Generic;
using System.Threading.Tasks;
using ModelCore.Entities;

namespace ModelCore.Interfaces
{
    public interface IProductsRepository
    {
        #region GetAll, GetById

        Task<ICollection<Products>> GetAllProductsAsync(int categoryId);
        Task<Products> GetProductById(int id);

        #endregion

        #region CRUD

        Task<Products> CreateProductAsync(Products create);
        Task UpdateProductAsync(int id, Products update);
        Task DeleteProductAsync(int id);

        #endregion
    }
}
