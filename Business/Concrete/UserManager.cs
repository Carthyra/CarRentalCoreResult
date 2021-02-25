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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<User>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
            }
        }

        public IDataResult<User> Get(int userId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<User>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId), Messages.UserListed);
            }
        }

        public IResult Add(User user)
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
        }

        public IResult Delete(User user)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
        }

        public IResult Update(User user)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }
        }
    }
}
