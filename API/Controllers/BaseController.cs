using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        public override CreatedResult Created(string uri = "", [ActionResultObjectValue] object value = null) =>
            base.Created(uri, value);
    }
}
