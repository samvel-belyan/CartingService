using DAL.Models;

namespace DAL.Interfaces;

internal interface ICartRepository
{
    IEnumerable<Item> GetCartItems(string id);
    void AddCartItem(string id, Item item);
    void RemoveCartItem(string id, Item item);
}
