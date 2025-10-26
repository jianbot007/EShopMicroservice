using MediatR;

namespace Catalog.API.Products.CreateProduct
{ 

    public record CreateProductCommand(String Name, List<String> Category,String Descroption, String ImageFile , Decimal Price)
        : IRequest<CreateProductResult>;

    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
