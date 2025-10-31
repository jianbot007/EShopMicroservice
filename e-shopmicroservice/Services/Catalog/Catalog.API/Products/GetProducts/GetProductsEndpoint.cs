
using Catalog.API.Products.GetProducts;
public record GetProductsRequest(IEnumerable<Product> Products);
public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
         app.MapGet("/products", async (ISender sender) =>
        {
            var query = new GetProductQuery();
            var result = await sender.Send(query);
            var response = result.Adapt<GetProductsRequest>(); //mapping result to getproductsrequest 
            return Results.Ok(response);
        })
         .WithName("GetProducts")
         .Produces<GetProductsRequest>(StatusCodes.Status200OK)
           .ProducesProblem(StatusCodes.Status400BadRequest)
           .WithSummary("Get Products")
           .WithDescription("Get Products desc");   
    }
}

