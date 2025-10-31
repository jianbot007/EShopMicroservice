using Catalog.API.Products.CreateProduct;
using Catalog.API.Products.GetProducts;
using JasperFx.Events.Daemon;

namespace Catalog.API.Products.UpdateProduct
{



    public record UpdateProductCommand(Guid Id,string Name, List<string> Category, string Description, string ImageFile, Decimal Price)
    : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool IsSucess);
    public class UpdateProductHandler(IDocumentSession session, ILogger<UpdateProductHandler> logger) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

            if(product is null)
            {
                throw new ProductNotFoundException();
            }

            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.price = command.Price;
            

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);

            logger.LogInformation("Product updated successfully with ID: {ProductId}", product.Id);

            return new UpdateProductResult(true);
        }
    }
}
