using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModelCore.Data;
using ModelCore.Entities;
using ModelCore.Interfaces;
using ModelCore.Repositories.DIRepository;

namespace ModelCore.Repositories
{
    public class CategoriesRepository : AllDIRepository, ICategoriesRepository
    {
        #region Properties

        
        
        #endregion

        #region Construct

        public CategoriesRepository(
            AppContext appContext,
            ILogger<CategoriesRepository> logger):base(appContext, logger)
        {}

        #endregion

        #region GetAll, GetById

        //get all
        public async Task<ICollection<Categories>> GetAllCategoriesAsync()
            => await _appContext.Categories.ToListAsync();

        //get by id
        public async Task<Categories> GetCategoryById(int id)
            => await _appContext.Categories.Include(p => p.Products).FirstOrDefaultAsync(p => p.Id == id);

        #endregion

        #region CRUD

        //create
        public async Task<Categories> CreateCategoryAsync(Categories categories)
        {
            var response = await _appContext.Categories.AddAsync(categories);
            if (response == null)
                throw new System.ArgumentNullException(nameof(response));

            await _appContext.SaveChangesAsync();
            return categories;
        }

        //update
        public async Task UpdateCategoryAsync(int id, Categories categories)
        {
            var update = await _appContext.Categories.FindAsync(id);
            if (update == null)
                throw new System.ArgumentNullException(nameof(update));

            _appContext.Entry(update).State = EntityState.Modified;
            await _appContext.SaveChangesAsync();
        }

        //delete
        public async Task DeleteCategoryAsync(int id)
        {
            var delete = await _appContext.Categories.FindAsync(id);
            var response = _appContext.Categories.Remove(delete);
            if (response == null)
                throw new System.ArgumentNullException(nameof(response));

            await _appContext.SaveChangesAsync();
        }

        #endregion
    }
}
