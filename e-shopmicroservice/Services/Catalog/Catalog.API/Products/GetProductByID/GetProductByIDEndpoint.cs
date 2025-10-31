using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductByID
{

    public record GetProductByIdRequest(Product Product);
    public class GetProductByIDEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id:guid}", async (Guid id,ISender sender) =>
            {
                var query = new GetProductByIdQuery(id);
                var result = await sender.Send(query);
                var response = result.Adapt<GetProductByIdRequest>(); //mapping result to getproductsrequest 
                return Results.Ok(response);
            })
             .WithName("GetProductsById")
             .Produces<GetProductsRequest>(StatusCodes.Status200OK)
               .ProducesProblem(StatusCodes.Status400BadRequest)
               .WithSummary("Get Products")
               .WithDescription("Get Products desc");
        }

    }
}
