using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DIController : ControllerBase
    {
        #region Properties

        protected readonly ILogger _logger;

        #endregion

        #region Contruct

        public DIController(ILogger logger)
            => _logger = logger;

        #endregion
    }
}
