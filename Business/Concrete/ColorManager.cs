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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Color>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed1);
            }
        }

        public IDataResult<Color> Get(int colorId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<Color>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<Color>(_colorDal.Get(c=>c.ColorId==colorId), Messages.ColorListed);
            }
        }

        public IResult Add(Color color)
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
        }

        public IResult Delete(Color color)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            }
        }

        public IResult Update(Color color)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
        }
    }
}
