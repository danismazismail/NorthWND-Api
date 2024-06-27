using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyApi.Dtos.LogDTO;
using MyApi.Logs;

namespace MyApi.Apis.Filters
{
    public class BaseControllerLog : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            try
            {
                JsonFileLogger<RequestLogDTO> log = new Logs.JsonFileLogger<RequestLogDTO>(filePath: "C:\\Intel\\");
                log.DoLog(new RequestLogDTO()
                {

                    HttpVerbORAction = context.HttpContext.Request.Method.ToString(),
                    RequestQueryString = context.HttpContext.Request.QueryString.Value.ToString()
                }, DateTime.Now, "Info");

                
                next();
            }
            catch (Exception ex)
            {
                context.Result = new NotFoundObjectResult("log alamadım.");
            }

            return base.OnActionExecutionAsync(context, next);
        }
    }
}
