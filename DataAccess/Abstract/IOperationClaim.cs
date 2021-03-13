using System.Security.Claims;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IOperationClaim : IEntityRepository<OperationClaim>
    {
        
    }
}