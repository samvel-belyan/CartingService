using LiteDB;
using Persistence.Models;

namespace Persistence;

public class CartingDbContext
{
    private const string DbPath = @"C:\mpdb\MyData.db";
    private const string CollectionName = "carts";

    public IEnumerable<Item> GetCartItems(string id)
    {
        using (var db = new LiteDatabase(DbPath))
        {
            var collection = db.GetCollection<Cart>(CollectionName);

            var cart = collection.FindById(id);

            if (cart is null) return default;

            return cart.Items;
        }
    }
    public void AddCartItem(string id, Item item)
    {
        using (var db = new LiteDatabase(DbPath))
        {
            var collection = db.GetCollection<Cart>(CollectionName);

            var cart = collection.FindById(id);

            if (cart is null)
            {
                throw new Exception("Cart with this id not found");
            }

            cart.Items.Add(item);
            collection.Update(cart);
        }
    }

    public void RemoveCartItem(string id, Item item)
    {
        using (var db = new LiteDatabase(DbPath))
        {
            var collection = db.GetCollection<Cart>(CollectionName);

            var cart = collection.FindById(id);

            if (cart is null)
            {
                throw new Exception("Cart with this id not found");
            }

            cart.Items.Remove(item);
            collection.Update(cart);
        }
    }
}
