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
    public class EfCarDal : EfEntityRepositoryBase<Car,CarRentalContex>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContex contex = new CarRentalContex())
            {
                var joinresult = from c in contex.Car
                    join b in contex.Brand on c.BrandId equals b.BrandId
                    join co in contex.Color on c.ColorId equals co.ColorId
                    select new CarDetailDto()
                    {
                        BrandName = b.Name,
                        ColorName = co.Name,
                    };
                return joinresult.ToList();
            }
        }
    }
}
