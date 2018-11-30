using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace WebApiSample.Api._21
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                // add overview info
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ASP.NET Core 2.1+ Web API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Dave",
                        Email = string.Empty,
                        Url = "wzhiu@163.com"
                    }
                });
                // Add summary/title for each api
                c.IncludeXmlComments(GetXmlCommentsPath());

                // Add Basic Authentication
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    In = "header",
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = "apiKey"
                }
                );
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };
                c.AddSecurityRequirement(security);
                c.OperationFilter<AddAuthTokenHeaderParameter>();
            });

            return services;
        }
        private static string GetXmlCommentsPath()
        {
            return string.Format("{0}/SiteCore.WebApi.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }

        /// <summary>
        /// Using swagger
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                //Using 'http' in develop and 'https' in production
                //var schemes = env.IsDevelopment() ? new[] { "http" } : new[] { "https" };
                var schemes = new[] { "http", "https" };
                c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Schemes = schemes);
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

                c.DocExpansion(DocExpansion.None);
                //c.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}