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
                    CartId = model.CartId,
                    PlantId = model.PlantId,
                    TotalPrice = model.TotalPrice,
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
                        .Where(e => e.UserId == _userId)
                        .Select(
                            c =>
                                new CartListItem
                                {
                                    CartId = c.CartId,
                                    PlantId = c.PlantId,
                                    TotalPrice = c.TotalPrice,
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
                        .Single(e => e.CartId == cartId && e.UserId == _userId);
                return
                    new CartDetail
                    {
                        CartId = entity.CartId,
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
                        .Single(e => e.CartId == model.CartId && e.UserId == _userId);

                entity.CartId = model.CartId;
                entity.PlantId = model.PlantId;
                entity.TotalPrice = model.TotalPrice;
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
                        .Single(e => e.CartId == cartId && e.UserId == _userId);

                ctx.Carts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}