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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Brand>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed1);
            }
        }

        public IDataResult<Brand> Get(int brandId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<Brand>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId==brandId), Messages.BrandListed);
            }
        }

        public IResult Add(Brand brand)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
        }

        public IResult Delete(Brand brand)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandDeleted);
            }
        }

        public IResult Update(Brand brand)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
        }
    }
}
