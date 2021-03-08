using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int imageId);
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<List<CarImage>> GetByDateRange(DateTime start, DateTime end);
        IResult Add(IFormFile file,CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);

    }
}
