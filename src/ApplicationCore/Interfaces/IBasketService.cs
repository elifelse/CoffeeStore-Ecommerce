using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBasketService
    {
        Task AddItemToBasketAsync(int basketId, int productId, int quantity);
    }
}
