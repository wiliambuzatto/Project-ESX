using ESX.Domain.Entities;
using ESX.Domain.Interfaces.Repository;
using ESX.Domain.Interfaces.UnitWork;

namespace ESX.Data.Repository
{
    public class RepositoryPatrimonio : RepositoryBase<Patrimonio>, IRepositoryPatrimonio
    {
        public RepositoryPatrimonio(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
