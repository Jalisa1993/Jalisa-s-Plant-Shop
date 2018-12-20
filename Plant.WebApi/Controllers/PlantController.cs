using Microsoft.AspNet.Identity;
using Plant.Models;
using Plant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Plant.WebApi.Controllers
{
    [Authorize]
    public class PlantController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            PlantService plantService = CreatePlantService();
            var plants = plantService.GetPlants();
            return Ok(plants);
        }

        public IHttpActionResult Get(int id)
        {
            PlantService plantService = CreatePlantService();
            var plant = plantService.GetPlantById(id);
            return Ok();
        }

        public IHttpActionResult Post(PlantCreate plant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlantService();

            if (!service.CreatePlants(plant))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(PlantEdit plant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlantService();

            if (!service.UpdatePlant(plant))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePlantService();

            if (!service.DeletePlant(id))
                return InternalServerError();

            return Ok();

        }

        private PlantService CreatePlantService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var plantService = new PlantService(userId);
            return plantService;
        }
    }
}
