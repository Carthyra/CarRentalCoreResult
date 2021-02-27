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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int rentid)
        {
            var result = _rentalService.Get(rentid);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerid)
        {
            var result = _rentalService.GetByCustomer(customerid);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbydaterange")]
        public IActionResult GetByDateRange(DateTime start, DateTime end)
        {
            var result = _rentalService.GetByDateRange(start,end);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycar")]
        public IActionResult GetByCar(int carid)
        {
            var result = _rentalService.GetByCar(carid);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success==true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
