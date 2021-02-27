using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _carService.Get(id);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbybrand")]
        public IActionResult GetByBrand(int brandid)
        {
            var result = _carService.GetByBrand(brandid);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycolor")]
        public IActionResult GetByColor(int colorid)
        {
            var result = _carService.GetByColor(colorid);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyprice")]
        public IActionResult GetByPrice(int min, int max)
        {
            var result = _carService.GetByPrice(min,max);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbymodelyear")]
        public IActionResult GetByModelYear(int modelyear)
        {
            var result = _carService.GetByModelYear(modelyear);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success==true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
