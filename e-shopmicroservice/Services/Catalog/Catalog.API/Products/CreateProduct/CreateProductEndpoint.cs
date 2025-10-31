namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductRequest(String Name, List<String> Category, String Descroption, String ImageFile, Decimal Price);
       

    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response);
            })
             .WithName("CreatedProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Created Product")
            .WithDescription("Created Product des");

        }
    }
}

