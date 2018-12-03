using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SiteCore.WebApi.Utils;
using WebApiSample.DataAccess;
using WebApiSample.DataAccess.Repositories;

namespace WebApiSample.Api._21
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Binding dao

            services.AddScoped<PetsRepository>();

            //services.AddDbContext<SiteCoreContext>(opt =>
            //    opt.UseInMemoryDatabase("ProductInventory"));
            //services.AddDbContext<SiteCoreContext>(opt =>
            //    opt.UseInMemoryDatabase("PetInventory"));

            // Register my database context as .NET Microservices with the .net core framework in order to access my database within my application. 
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SiteCoreContext>(
                 options => options.UseSqlServer(connection, b => b.MigrationsAssembly("SiteCore.WebApi"))
            );
            #endregion

            #region snippet_SetCompatibilityVersion
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #endregion

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Add our Config object so it can be injected
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            #region Swagger
            // add addtional info including overview, Auth, summary of api 
            // which added by dave in file SwaggerServiceExtensions.cs
            services.AddSwaggerDocumentation();

            #endregion

            #region snippet_ConfigureApiBehaviorOptions
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressConsumesConstraintForFormFileParameters = true;
                options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressModelStateInvalidFilter = true;
            });
            #endregion

            // binding httpConext
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();//添加NLog

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            #region Swagger

            // Swashbuckle components requires adding the resources to serve static files 
            // and building the folder structure to host those files.
            app.UseStaticFiles();

            app.UseSwaggerDocumentation();
            #endregion

            // Adds middleware for redirecting HTTP Requests to HTTPS.
            app.UseHttpsRedirection();

            // Router
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // '            
            HttpContextUtil.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());

        }
    }
}
