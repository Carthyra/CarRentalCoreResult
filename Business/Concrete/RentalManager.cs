using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Rental>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
            }
        }

        public IDataResult<Rental> Get(int rentId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<Rental>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentId), Messages.RentalListed);
            }
        }

        public IDataResult<List<Rental>> GetByCustomer(int userId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Rental>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.CustomerId==userId), Messages.UserRentalsListed);
            }
        }

        public IDataResult<List<Rental>> GetByDateRange(DateTime start, DateTime end)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Rental>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.RentDate>=start && (r.ReturnDate<=end || end==null)), Messages.DateRangeRentalsListed);
            }
        }

        public IDataResult<List<Rental>> GetByCar(int carId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Rental>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.CarId==carId), Messages.CarRentalsListed);
            }
        }

        public IResult Add(Rental rental)
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
        }

        public IResult Delete(Rental rental)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
        }

        public IResult Update(Rental rental)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
        }
    }
}
