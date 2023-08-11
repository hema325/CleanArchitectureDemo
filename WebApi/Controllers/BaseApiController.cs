using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [ApiController]
    //[GlobalExceptionFilter]  
    public abstract class BaseApiController : ControllerBase {   }

}
