

namespace Basket.API.Basket.StoreBasket
{

    public record StoreBasketCommand(ShoppingCart ShoppingCart) : ICommand<StoreBasketResult>, IRequest<StoreBasketResult>; 
    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.ShoppingCart).NotNull().WithMessage("Cart can't be null");
            RuleFor(x => x.ShoppingCart.UserName).NotEmpty().WithMessage("Username is required");
        }
    }
    public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            ShoppingCart cart = command.ShoppingCart;
            // Store basket to database
            // UpdateCache(cart);
            return new StoreBasketResult("Demo");
        }
    }
    
}
