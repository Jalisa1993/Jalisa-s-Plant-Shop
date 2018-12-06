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

        public PlantDetail GetPlantById(int plantId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Plants
                        .Single(e => e.PlantId == plantId && e.OwnerId == _userId);
                return
                    new PlantDetail
                    {
                        Quantity = entity.Quantity,
                        TypeOfPlant = entity.TypeOfPlant,
                        PlantName = entity.PlantName,
                        PlantId = entity.PlantId
                    };
            }
        }

        public bool UpdatePlant(PlantEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Plants
                        .Single(e => e.PlantId == model.PlantId && e.OwnerId == _userId);

                entity.Quantity = model.Quantity;
                entity.TypeOfPlant = model.TypeOfPlant;
                entity.PlantName = model.PlantName;
                entity.PlantId = model.PlantId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlant(int plantId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Plants
                        .Single(e => e.PlantId == plantId && e.OwnerId == _userId);
                ctx.Plants.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
