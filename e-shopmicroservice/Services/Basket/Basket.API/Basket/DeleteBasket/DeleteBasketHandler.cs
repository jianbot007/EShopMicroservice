
namespace Basket.API.Basket.DeleteBasket
{

    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;

    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {   
        public DeleteBasketCommandValidator()
         {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
                }
    }
    public class DeleteBasketHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            // Delete basket from database
            //session.deleyte(command.UserName);

            return new DeleteBasketResult(true);
        }
    }
}
