
namespace Catalog.API.Products.GetProductByCategory
{

    public record GetProductByCategoryQuery(String Category) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(Product Product);


    internal class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductByCategoryHandler> logger) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByIdHandler.Handle called with {@Query}", query);

            var product = await session.LoadAsync<Product>(query.Category, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException();

            }
            return new GetProductByCategoryResult(product);

        }



    }
}
