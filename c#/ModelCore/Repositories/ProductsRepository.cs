using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModelCore.Data;
using ModelCore.Entities;
using ModelCore.Interfaces;
using ModelCore.Repositories.DIRepository;

namespace ModelCore.Repositories
{
    public class ProductsRepository : AllDIRepository, IProductsRepository
    {
        #region Properties



        #endregion

        #region Construct

        public ProductsRepository(
            AppContext appContext,
            ILogger<ProductsRepository> logger) : base(appContext, logger)
        { }

        #endregion

        #region GetAll, GetById

        //get all
        public async Task<ICollection<Products>> GetAllProductsAsync(int categoryId)
            => await _appContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();

        //get by id
        public async Task<Products> GetProductById(int id)
            => await _appContext.Products.FirstOrDefaultAsync(p=>p.Id == id);

        #endregion

        #region CRUD

        //create
        public async Task<Products> CreateProductAsync(Products create)
        {
            var add = await _appContext.Products.AddAsync(create);
            if (add == null)
                throw new System.ArgumentNullException(nameof(add));

            await _appContext.SaveChangesAsync();
            return create;
        }

        //update
        public async Task UpdateProductAsync(int id, Products updateP)
        {
            var update = await _appContext.Products.FindAsync(id);
            _appContext.Entry(update).State = EntityState.Modified;
            if (update == null)
                throw new System.ArgumentNullException(nameof(update));
            
            await _appContext.SaveChangesAsync();
        }

        //delete
        public async Task DeleteProductAsync(int id)
        {
            var delete = await _appContext.Products.FindAsync(id);
            var response = _appContext.Products.Remove(delete);
            if (response == null)
                throw new System.ArgumentNullException(nameof(response));

            await _appContext.SaveChangesAsync();
        }

        #endregion
    }
}
