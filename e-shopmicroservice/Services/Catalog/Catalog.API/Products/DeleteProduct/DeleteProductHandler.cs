﻿
using JasperFx.Events.Daemon;

namespace Catalog.API.Products.DeleteProduct
{

    public record DeleteProductCommand(Guid Id):ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsDeleted);
    public class DeleteProductHandler(IDocumentSession session,ILogger<DeleteProductHandler> logger) : ICommandHandler<DeleteProductCommand,DeleteProductResult>
    {

        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {    
            logger.LogInformation("DeleteProductHandler.Handle called with {@Command}", command);
            
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
            if(product is null)
            {
                throw new ProductNotFoundException();
            }

            session.Delete<Product>(product.Id);
            await session.SaveChangesAsync(cancellationToken);
            return (new DeleteProductResult(true));
        }
    }
}
