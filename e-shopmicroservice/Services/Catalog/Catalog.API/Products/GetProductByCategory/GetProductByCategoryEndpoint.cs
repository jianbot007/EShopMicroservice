
namespace Catalog.API.Products.GetProductByCategory
{

    public record GetProductByCategoryRequest(Product Product);

    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{category}", async (String category, ISender sender) =>
            {
                var query = new GetProductByCategoryQuery(category);
                var result = await sender.Send(query);
                var response = result.Adapt<GetProductByCategoryRequest>(); //mapping result to getproductsrequest 
                return Results.Ok(response);
            })
             .WithName("GetProductsByCategory")
             .Produces<GetProductByCategoryRequest>(StatusCodes.Status200OK)
               .ProducesProblem(StatusCodes.Status400BadRequest)
               .WithSummary("Get Products By Category")
               .WithDescription("Get Products By Category desc");
        }
    }

   
}
