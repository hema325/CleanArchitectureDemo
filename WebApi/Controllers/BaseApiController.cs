using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [GlobalExceptionFilter]
    public abstract class BaseApiController : ControllerBase {   }

}
