using Plant.Data;
using Plant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Services
{
    public class CartService
    {
        private readonly Guid _userId;

        public CartService(Guid UserId)
        {
            _userId = UserId;
        }

        public bool CreateCart(CartCreate model)
        {
            var entity =
                new Cart()
                {
                    PlantId = model.PlantId,
                    OwnerId = _userId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Carts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CartListItem> GetCart()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Carts
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            c =>
                                new CartListItem
                                {
                                    PlantId = c.PlantId,
                                    TotalPrice = c.TotalPrice,
                                    CartId = c.CartId,
                                }
                        );
                return query.ToArray();
            }
        }

        public CartDetail GetCartById(int cartId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Carts
                        .Single(e => e.CartId == cartId && e.OwnerId == _userId);
                return
                    new CartDetail
                    {
                        PlantId = entity.PlantId,
                        TotalPrice = entity.TotalPrice,
                    };
            }
        }

        public bool UpdateCart(CartEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Carts
                        .Single(e => e.CartId == model.CartId && e.OwnerId == _userId);

                entity.PlantId = model.PlantId;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCart(int cartId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Carts
                        .Single(e => e.CartId == cartId && e.OwnerId == _userId);

                ctx.Carts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}