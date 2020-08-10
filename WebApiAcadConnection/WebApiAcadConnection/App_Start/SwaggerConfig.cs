using System.Web.Http;
using WebActivatorEx;
using WebApiAcadConnection;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;
using System.Collections.Generic;
using Swashbuckle.Swagger;
using System.Web.Http.Description;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApiAcadConnection
{
    /// <summary>
    /// Class SwaggerConfig.
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Register of swagger configuration.
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "WebApiAcadConnection");
                    c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\bin\WebApiAcadConnection.XML");
                    c.DescribeAllEnumsAsStrings();

                    // You can use "BasicAuth", "ApiKey" or "OAuth2" options to describe security schemes for the API.
                    // See https://github.com/swagger-api/swagger-spec/blob/master/versions/2.0.md for more details.
                    // NOTE: These only define the schemes and need to be coupled with a corresponding "security" property
                    // at the document or operation level to indicate which schemes are required for an operation. To do this,
                    // you'll need to implement a custom IDocumentFilter and/or IOperationFilter to set these properties
                    // according to your specific authorization implementation
                    c.OAuth2("oauth2")
                        .Description("OAuth2 Implicit Grant")
                        .Flow("implicit")
                        .AuthorizationUrl("https://localhost:56103/authorize")
                        .TokenUrl("https://localhost:56103/token")
                        .Scopes(scopes =>
                        {
                            scopes.Add("read", "Read access to protected resources");
                            scopes.Add("write", "Write access to protected resources");
                        });

                    c.OperationFilter<AssignOAuth2SecurityRequirements>();
                    c.DocumentFilter<AuthTokenOperation>();
                })
                .EnableSwaggerUi(c =>
                {
                    //c.EnableOAuth2Support("implicitclient", null, "test-realm", "Swagger UI", ",");
                    c.EnableOAuth2Support("implicitclient", "secret", "test", "Swagger UI");

                    // Use the CustomAsset option to provide your own version of assets used in the swagger-ui.
                    // It's typically used to instruct Swashbuckle to return your version instead of the default
                    // when a request is made for "index.html". As with all custom content, the file must be included
                    // in your project as an "Embedded Resource", and then the resource's "Logical Name" is passed to
                    // the method as shown below.
                    //
                    //c.CustomAsset("index", containingAssembly, "SwaggerDemoApi.SwaggerExtensions.index.html");

                    // Use the "InjectJavaScript" option to invoke one or more custom JavaScripts after the swagger-ui
                    // has loaded. The file must be included in your project as an "Embedded Resource", and then the resource's
                    // "Logical Name" is passed to the method as shown above.
                    //
                    c.InjectJavaScript(thisAssembly, "SwaggerDemoApi.SwaggerExtensions.fixOAuthScopeSeparator.js");
                });
        }
    }

    /// <summary>
    /// The class to add the authorization header.
    /// </summary>
    public class AssignOAuth2SecurityRequirements : IOperationFilter
    {
        /// <summary>
        /// Applies the operation filter.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiDescription"></param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters != null)
            {
                operation.parameters.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    description = "access token",
                    required = false,
                    type = "string"
                });
            }

        }
    }

    /// <summary>
    /// The class to add token request.
    /// </summary>
    public class AuthTokenOperation : IDocumentFilter
    {
        /// <summary>
        /// Apply custom operation.
        /// </summary>
        /// <param name="swaggerDoc">The swagger document.</param>
        /// <param name="schemaRegistry">The schema registry.</param>
        /// <param name="apiExplorer">The api explorer.</param>
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/token", new PathItem
            {
                post = new Operation
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
                        },
                    }
                }
            });
        }
    }
}
