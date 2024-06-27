using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Apis.Filters;

namespace MyApi.Apis.Controllers
{
    [BaseControllerLog]
    [Route("api/[controller]")]
    [ApiController]
    public class MyBaseApiController : ControllerBase
    {
    }
}
