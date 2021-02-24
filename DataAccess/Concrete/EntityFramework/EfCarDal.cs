using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,CarRentanContex>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentanContex contex = new CarRentanContex())
            {
                var joinresult = from c in contex.Cars
                    join b in contex.Brands on c.BrandId equals b.BrandId
                    join co in contex.Colors on c.ColorId equals co.ColorId
                    select new CarDetailDto()
                    {
                        CarName = c.CarName,
                        BrandName = b.BrandName,
                        ColorName = co.ColorName,
                    };
                return joinresult.ToList();
            }
        }
    }
}
