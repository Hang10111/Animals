using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Server
{
    public class APIResponse<T> : IActionResult
    {
        private HttpStatusCode _statusCode;
        private BodyResponseFormat<T> _body;
        public APIResponse(HttpStatusCode statusCode, BodyResponseFormat<T> body)
        {
            _statusCode = statusCode;
            _body = body;
        }
        public Task ExecuteResultAsync(ActionContext context)
        {
            var httpContext = context.HttpContext;
            var request = httpContext.Request;
            var response = httpContext.Response;
            response.ContentType = string.Format("{0}; charset={1}", MediaTypeNames.Application.Json, Encoding.UTF8.HeaderName);
            response.StatusCode = (int)_statusCode;
            var writerFactory = httpContext.RequestServices.GetRequiredService<IHttpResponseStreamWriterFactory>();
            var options = httpContext.RequestServices.GetRequiredService<IOptions<MvcJsonOptions>>().Value;
            var serializerSettings = options.SerializerSettings;

            using (var writer = writerFactory.CreateWriter(response.Body, Encoding.UTF8))
            {
                using (var jsonWriter = new JsonTextWriter(writer))
                {
                    jsonWriter.CloseOutput = false;
                    var jsonSerializer = JsonSerializer.Create(serializerSettings);
                    jsonSerializer.Serialize(jsonWriter, _body);
                }
            }
            return Task.CompletedTask;
        }
    }
}
