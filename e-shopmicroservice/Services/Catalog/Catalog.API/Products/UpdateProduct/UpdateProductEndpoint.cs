
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Descroption, string ImageFile, Decimal Price);

    public record UpdateProductResponse(bool IsSucess);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products/", async (UpdateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateProductResponse>();

                return Results.Ok(response);
            })
             .WithName("UpdateProduct")
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
             .WithSummary("Update Product")
             .WithDescription("Update Product desc"); 
        }
    }

}
