using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.AutofacValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            if (DateTime.Now.Hour == 01)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.Maintaince);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<CarImage> Get(int imageId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<CarImage>(Messages.Maintaince);
            }

            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == imageId), Messages.CarImageListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.Maintaince);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId),
                Messages.ImagesListedByCar);
        }

        public IDataResult<List<CarImage>> GetByDateRange(DateTime start, DateTime end)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.Maintaince);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.Date >= start && i.Date <= end),
                Messages.CarImagesListedByDateRange);
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageExceeded(carImage.CarId));
            if (result!=null)
            {
                return result;
            }

            var result1 = FileHelper.Add(file);
            if (result1.Success==false)
            {
                return new ErrorResult(result1.Message);
            }

            carImage.ImagePath = result1.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }

            var imagepathexists = _carImageDal.Get(i => i.Id == carImage.Id);
            if (imagepathexists == null)
            {
                return new ErrorResult("image not found");
            }

            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }

            var imagepathexists = _carImageDal.Get(i => i.Id == carImage.Id);
            if (imagepathexists==null)
            {
                return new ErrorResult("image not found");
            }

            var updatedImage = FileHelper.Update(file, imagepathexists.ImagePath);
            if (updatedImage.Success==false)
            {
                return new ErrorResult(updatedImage.Message);
            }

            carImage.ImagePath = updatedImage.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfCarImageExceeded(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result>5)
            {
                return new ErrorResult(Messages.CarImageExecded);
            }

            return new SuccessResult();
        }
    }
}
