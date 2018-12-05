using Plant.Data;
using Plant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Services
{
    public class PlantService
    {
        private readonly Guid _userId;

        public PlantService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePlants(PlantCreate model)
        {
            var entity =
                new Plant.Data.Plant()
                {
                    OwnerId = _userId,
                    Quantity = model.Quantity,
                    TypeOfPlant = model.TypeOfPlant,
                    PlantName = model.Name,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Plants.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlantListItem> GetPlants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Plants
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PlantListItem
                                {
                                    Quantity = e.Quantity,
                                    TypeOfPlant = e.TypeOfPlant,
                                    PlantName = e.PlantName
                                }
                            );

                return query.ToArray();
            }
        }
    }
}
