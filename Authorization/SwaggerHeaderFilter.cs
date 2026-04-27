using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SystemBase.Authorization;

public class SwaggerHeaderFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters ??= [];

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "X-Active-Scope",
            In = ParameterLocation.Header,
            Required = false,
            Schema = new OpenApiSchema { Type = JsonSchemaType.String },
            Description = "Permisos activos del usuario (ej: users.read,users.write)"
        });
    }
}
