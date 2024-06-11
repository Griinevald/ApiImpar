using ApiImpar.Models;
using ApiImpar.Repo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ApiImpar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
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

        [HttpGet("{id}")]
        public async Task<ActionResult<CarModel>> GetById(int id)
        {
            CarModel Car = await _carRepository.GetById(id);
            return Ok(Car);
        }

        [HttpPost]
        public async Task<ActionResult<CarModel>> Add([FromBody] CarModel Car)  
        {
            CarModel CarRess = await _carRepository.Add(Car);
            return Ok(CarRess);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarModel>> Delete( int id)
        {
            bool deleted = await _carRepository.Delete(id);
            return Ok(deleted);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CarModel>> Update([FromBody] CarModel Car, int id)
        {
            Car.Id = id;
            CarModel CarRess = await _carRepository.Update(Car,id);
            return Ok(CarRess);
        }
    }
}
