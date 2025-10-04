using Microsoft.AspNetCore.Mvc;
using ServiceExpress.Application.Common;

namespace ServiceExpress.Controllers.Extensions
{
    public static class ResultExtension
    {
        public static ActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller)
        {
            if (result.IsSuccess)
                return controller.Ok(result.Value);

            if (result.IsForbidden)
                return controller.Forbid();

            return controller.BadRequest(result.ErrorMessage);
        }
    }
}
