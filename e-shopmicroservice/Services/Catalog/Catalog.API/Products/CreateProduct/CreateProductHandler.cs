using BuildingBlock.CQRS;
namespace Catalog.API.Products.CreateProduct
{ 

    public record CreateProductCommand(String Name, List<String> Category,String Descroption, String ImageFile , Decimal Price)
        : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Descroption,
                ImageFile = command.ImageFile,
                price = command.Price,
            };

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);


            return new CreateProductResult(product.Id);
        }
    }
}
