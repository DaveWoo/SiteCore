using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace WebApiSample.Api._21
{
    public class AddAuthTokenHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new HeaderParameter
            {
                Name = "X-API-AccessToken",
                In = "header",
                Description = "header fields",
                Required = true
            });
        }
    }
    class HeaderParameter : NonBodyParameter
    {
    }
}
