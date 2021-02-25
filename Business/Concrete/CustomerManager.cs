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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Customer>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
            }
        }

        public IDataResult<List<Customer>> GetByCompany(string companyName)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Customer>>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c=>c.CompanyName==companyName), Messages.CustomersByCompanyListed);
            }
        }

        public IDataResult<Customer> Get(int userId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<Customer>(Messages.Maintaince);
            }
            else
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.CustomerId==userId),Messages.CustomerListed);
            }
        }

        public IResult Add(Customer customer)
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            }
        }

        public IResult Delete(Customer customer)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.CustomerDeleted);
            }
        }

        public IResult Update(Customer customer)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.Maintaince);
            }
            else
            {
                _customerDal.Update(customer);
                return new SuccessResult(Messages.CustomerUpdated);
            }
        }
    }
}
