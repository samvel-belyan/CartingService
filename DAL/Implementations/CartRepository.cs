using AutoMapper;
using DAL.Interfaces;
using Persistence;

namespace DAL.Implementations;

internal class CartRepository : ICartRepository
{
    private readonly CartingDbContext _cartingDbContext;
    private readonly IMapper _mapper;

    public CartRepository(CartingDbContext cartingDbContext, IMapper mapper)
    {
        _cartingDbContext = cartingDbContext;
        _mapper = mapper;
    }

    public void AddCartItem(string id, Models.Item item) 
    {
        var item1 = _mapper.Map<Persistence.Models.Item>(item);
        _cartingDbContext.AddCartItem(id, item1);
    }

    public IEnumerable<Models.Item> GetCartItems(string id)
    {
        var items = _cartingDbContext.GetCartItems(id);
        var itemsToReturn = _mapper.Map<List<Models.Item>>(items);
        return itemsToReturn;
    }

    public void RemoveCartItem(string id, Models.Item item)
    {
        var item1 = _mapper.Map<Persistence.Models.Item>(item);
        _cartingDbContext.RemoveCartItem(id, item1);
    }
}
