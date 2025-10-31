
namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductRequest(Guid Id);
    public record class DeleteProductResponse(bool IsDeleted);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id:guid}", async (Guid id, ISender sender) =>
            {
                var command = new DeleteProductCommand(id);
                var result = await sender.Send(command);
                var response = result.Adapt<DeleteProductResponse>();

                 return Results.Ok(response);
            })
             .WithName("DeleteProduct")
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
             .WithSummary("Delete Product")
             .WithDescription("Delete Product desc");
        }
    }
}
