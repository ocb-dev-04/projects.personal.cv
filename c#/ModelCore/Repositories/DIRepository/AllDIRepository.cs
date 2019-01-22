using Microsoft.Extensions.Logging;
using ModelCore.Data;

namespace ModelCore.Repositories.DIRepository
{
    public class AllDIRepository
    {
        #region Properties

        protected readonly AppContext _appContext;
        protected readonly ILogger _logger;

        #endregion

        #region Construct

        public AllDIRepository(
            AppContext appContext,
            ILogger logger)
        {
            _appContext = appContext;
            _logger = logger;
        }

        #endregion
    }
}
