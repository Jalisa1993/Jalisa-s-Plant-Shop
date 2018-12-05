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

        public bool CreatesCart(CartCreate model)
        {
            var entity =
                new Cart()
                {
                    CartId = model.CartId,
                    PlantId = model.PlantId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Carts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
