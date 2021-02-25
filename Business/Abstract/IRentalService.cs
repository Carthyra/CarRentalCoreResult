using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> Get(int rentId);
        IDataResult<List<Rental>> GetByCustomer(int userId);
        IDataResult<List<Rental>> GetByDateRange(DateTime start, DateTime end);
        IDataResult<List<Rental>> GetByCar(int carId);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);

    }
}
