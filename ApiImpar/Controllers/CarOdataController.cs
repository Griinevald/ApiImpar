using ApiImpar.Models;
using ApiImpar.Repo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ApiImpar.Controllers
{
    public class CarOdataController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarOdataController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<CarModel>>> Get()
        {
            var cars = await _carRepository.Get();
            return Ok(cars.AsQueryable());
        }

    }
}
