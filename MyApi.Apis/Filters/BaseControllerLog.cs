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
            //var routeInfo = context.ActionDescriptor.AttributeRouteInfo.ToString;
            //var actionarguments = context.ActionArguments.Values.ToList();
            //var whichController = context.Controller.ToString();
            //var whichMethod = context.HttpContext.Request.Method.ToString();
            //var queryString = context.HttpContext.Request.QueryString.Value;

            try
            {
                //log alma.
                JsonFileLogger<RequestLogDTO> log = new Logs.JsonFileLogger<RequestLogDTO>(filePath: "C:\\Intel\\");
                log.DoLog(new RequestLogDTO()
                {

                    HttpVerbORAction = context.HttpContext.Request.Method.ToString(),
                    RequestQueryString = context.HttpContext.Request.QueryString.Value.ToString()
                }, DateTime.Now, "Info");

                //request e devam et (kaldığın yerden devam et)
                next();
            }
            catch (Exception ex)
            {
                //hata fırlat

                context.Result = new NotFoundObjectResult("log alamadım.");
            }


            return base.OnActionExecutionAsync(context, next);
        }
    }
}
