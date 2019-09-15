using Microsoft.AspNetCore.Mvc;
using Animals.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Animals.Server.Extensions
{
    public static class APIResponseExtensions
    {
        public static IActionResult OKResult(this ControllerBase controller)
        {
            return JsonResult(HttpStatusCode.OK, new BodyResponseFormat<object>());
        }
        public static IActionResult OKResult<T>(this ControllerBase controller, T result)
        {
            return JsonResult(HttpStatusCode.OK, new BodyResponseFormat<T>(result));
        }
        public static IActionResult BadRequestResult(this ControllerBase controller, ErrorCode code)
        {
            return JsonResult(HttpStatusCode.BadRequest, new BodyResponseFormat<object>(code));
        }
        public static IActionResult JsonResult<T>(HttpStatusCode statusCode, BodyResponseFormat<T> body)
        {
            return new APIResponse<T>(statusCode, body);
        }
    }
}
