
namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(
          string Name,
          List<string> Category,
          string Description,
          string ImageFile,
          decimal Price
          );
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products",
                async (CreateProductRequest request, ISender sender) =>
            {
                // Map the incoming request to a command object
                var command = request.Adapt<CreateProductCommand>();

                // Send the command to the MediatR pipeline
                var result = await sender.Send(command);
                // Check if the result is null or not
                var response = result.Adapt<CreateProductResponse>();
                // If the result is null, return a BadRequest otherwise return Created response
                return Results.Created($"/products/{response.Id}", response);

            })
            // Configure the endpoint with metadata and response types
            .WithName("CreateProduct")
            // Configure the request body type
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            // Configure the error response type
            .ProducesProblem(StatusCodes.Status400BadRequest)
            // Configure the request body type
            .WithSummary("Create a new product")
            // Configure the description for the endpoint
            .WithDescription("Creates a new product in the catalog with the specified details.");
        }
    }
    
    
}
