using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get(int carId);
        IDataResult<List<Car>> GetByBrand(int brandId);
        IDataResult<List<Car>> GetByColor(int colorId);
        IDataResult<List<Car>> GetByPrice(int min, int max);
        IDataResult<List<Car>> GetByModelYear(int modelYear);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult TransactionalTest(Car car);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

    }
}
