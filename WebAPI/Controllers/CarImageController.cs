using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImageController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int imageId)
        {
            var result = _carImageService.Get(imageId);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbydaterange")]
        public IActionResult GetByDateRange(DateTime start, DateTime end)
        {
            var result = _carImageService.GetByDateRange(start,end);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file,carImage);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("ID"))] int id)
        {
            var carImage = _carImageService.Get(id).Data;
            var result = _carImageService.Delete(carImage);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("ID"))] int id)
        {
            var carImage = _carImageService.Get(id).Data;
            var result = _carImageService.Update(file,carImage);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
