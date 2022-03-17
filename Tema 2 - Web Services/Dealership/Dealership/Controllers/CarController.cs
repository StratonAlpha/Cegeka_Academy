using Dealership.Entities;
using Dealership.Repsoitories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private ICarRepository _carRepository { get; set; }

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpPost("addCar")]
        public async Task<IActionResult> AddCar(CarRequest car)
        {
            _carRepository.AddCar(new Car(car));
            return Ok();
        }

        [HttpPatch("updateCar")]
        public async Task<ActionResult> UpdateCar(int id, string model, string brand, int stock)
        {
            _carRepository.UpdateCar(id, model, brand, stock);
            return Ok();
        }

        [HttpGet("getCar")]
        public async Task<IActionResult> GetCar()
        {
            var cars = _carRepository.GetAllCar();
            return Ok(cars);
        }

        [HttpDelete("removeCar")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            _carRepository.RemoveCar(id);
            return Ok();
        }
    }
}
