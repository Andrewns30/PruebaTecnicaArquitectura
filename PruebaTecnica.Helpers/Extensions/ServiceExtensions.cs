using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCorsCoustoms(this IServiceCollection services, IConfiguration configuration)
        {
            var HostsSection = configuration.GetSection("AppSettings:AvailableOrigins");
            var HostsArray = HostsSection.Value!.Split(';');
            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowOrigin", options =>
                    options.WithOrigins(HostsArray).AllowAnyMethod().AllowCredentials().AllowAnyHeader().SetIsOriginAllowedToAllowWildcardSubdomains().WithExposedHeaders("Access-Control-Allow-Origin"));
            });

        }

        public static void AddSwaggerCustom(this IServiceCollection services, string xmlPath, string NameApp)
        {
            services.AddSwaggerGen(c =>
            {
                c.ExampleFilters();
                c.SwaggerDoc("v1", new OpenApiInfo

                {
                    Title = NameApp,
                    Version = "v1",
                    Description = "Servicios correspondientes " + NameApp,
                    Contact = new OpenApiContact
                    {
                        Name = NameApp,
                        Email = "andrewns.30@gmail.com",
                    }
                });

                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                c.OperationFilter<SecurityRequirementsOperationFilter>();


                c.IncludeXmlComments(xmlPath, true);               
                
                c.EnableAnnotations();
            });
        }

    }
}
