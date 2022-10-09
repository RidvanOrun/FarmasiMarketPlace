using FarmasiMarketPlace.Business.Model;
using FarmasiMarketPlace.Core.Responses;
using FarmasiMarketPlace.Entities.Model;

namespace FarmasiMarketPlace.Business.Interfcae
{
    public interface IShoppingCartService
    {
        ServiceResponse<ShoppingCart> AddCart(ShoppingCartModel model);

        ServiceResponse<object> RemoveCart();

        ServiceResponse<ShoppingCart> GetCart();
    }
}
