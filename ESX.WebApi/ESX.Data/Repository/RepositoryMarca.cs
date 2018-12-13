using ESX.Domain.Entities;
using ESX.Domain.Interfaces.Repository;
using ESX.Domain.Interfaces.UnitWork;

namespace ESX.Data.Repository
{
    public class RepositoryMarca : RepositoryBase<Marca>, IRepositoryMarca
    {
        public RepositoryMarca(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
