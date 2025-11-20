
using Basket.API.Data;

namespace Basket.API.Basket.GetBasket
{

    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
    
    public record GetBasketResult(ShoppingCart? ShoppingCart);



    public class GetBasketHandler(IBasketRepository repository) : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            //get basket from database
            var basket = await repository.GetBasketAsync(query.UserName);

            return new GetBasketResult(basket);
        }
    }
}
