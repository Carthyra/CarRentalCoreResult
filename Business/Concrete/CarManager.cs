using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.AutofacValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validaton;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cardal;

        public CarManager(ICarDal cardal)
        {
            _cardal = cardal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_cardal.GetAll(), Messages.CarsListed);
            }
            
        }

        public IDataResult<Car> Get(int carId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<Car>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<Car>(_cardal.Get(c=>c.CarId==carId), Messages.CarListed);
            }
        }

        public IDataResult<List<Car>> GetByBrand(int brandId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_cardal.GetAll(c=>c.BrandId==brandId), Messages.BrandsListed);
            }
        }

        public IDataResult<List<Car>> GetByColor(int colorId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_cardal.GetAll(c=>c.ColorId==colorId), Messages.ColorsListed);
            }
        }

        public IDataResult<List<Car>> GetByPrice(int min, int max)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_cardal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max), Messages.PriceRangeListed);
            }
        }

        public IDataResult<List<Car>> GetByModelYear(int modelYear)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_cardal.GetAll(c=>c.ModelYear==modelYear), Messages.ModelYearListed);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetails(), Messages.CarDetailsListed);
            }
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _cardal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
        }

        public IResult Delete(Car car)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _cardal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
        }

        public IResult Update(Car car)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _cardal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
        }
    }
}
