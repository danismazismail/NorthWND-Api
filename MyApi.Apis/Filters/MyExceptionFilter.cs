using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyApi.EH;

namespace MyApi.Apis.Filters
{
    public class MyExceptionFilter : Attribute, IActionFilter, IExceptionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //action bittikten sonra
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            //action dan önce
        }

        public void OnException(ExceptionContext context)
        {
            // ex meydana geldiğinde
            string logdata = "";

            if (context.Exception is NullReferenceException)
            {
                //log al
                logdata = "asdsfsdfdfsd";
            }
            else if (context.Exception is InvalidCastException)
            {
                //log al
            }
            else if (context.Exception is ModelNotValidEx)
            {
                //log al
            }
            else if (context.Exception is BLLEX)
            {
                //log al
                string actionName = context.ActionDescriptor.RouteValues["action"];
                string controllerName = context.ActionDescriptor.RouteValues["controller"];
                var values = context.ActionDescriptor.RouteValues;
            }
            else
            {
                //log al
            }

            context.Result = new RedirectToActionResult("hata", "MyErrors", new { MelikeErrorMessage=context.Exception.Message}); 
        }
    }
}
