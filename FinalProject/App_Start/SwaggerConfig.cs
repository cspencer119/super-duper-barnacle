using System.Web.Http;
using WebActivatorEx;
using FinalProject;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;
using System.Web.Http.Filters;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace FinalProject
{
    /// <summary>
    /// Document filter for adding Authorization header in Swashbuckle/Swagger.
    /// </summary>
    public class AddAuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescriptionExtensions apiDescription)
        {
            var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline();
            var isAuthorized = filterPipeline
                .Select(filterInfo => filterInfo.Instance)
                .Any(filter => filter is IAuthorizationFilter);

            var allowAnonymous = apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();

            if (!isAuthorized || allowAnonymous) return;

            if (operation.parameters == null) operation.parameters = new List<Parameter>();

            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                description = "from/token endpoint",
                required = true,
                type = "string",
            });
        }
    }

    ///<summary>
    ///Document filter for adding OAuth Token endpoint documentation in Swashbuckle / Swagger.
    ///Swagger normally won't find it - the /token endpoint - due to it being programmatically generated.
    ///</summary>
    
    class AuthTokenEndpointOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/toekn", new PathItem
            {
                post = new Operation()
                {
                    tags = new List<string> { "Auth" },
                    consumes = new List<string>
                    {
                        "application/x-www-form-urlencoded"
                    },
                    parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            type = "string",
                            name = "grant_type",
                            required = true,
                            @in = "formData"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "username",
                            required = false,
                            @in = "formData"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "password",
                            required = false,
                            @in = "formData"
                        }
                    }
                }
            });

        }
    }

    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "FinalProject.WebAPI");

                    c.OperationFilter(() => new AddAuthorizationHeaderParameterOperationFilter());

                    c.DocumentFilter<AuthTokenEndpointOperation>();

                })
                .EnableSwaggerUi(c =>
                {

                });
        }
    }
}
