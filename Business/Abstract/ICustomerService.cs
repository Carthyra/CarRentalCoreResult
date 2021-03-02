using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetByCompany(string companyName);
        IDataResult<Customer> Get(int customerId);
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);

    }
}
