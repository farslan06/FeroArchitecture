using Core.Persistence.Repositories;
using Core.Security.Entities;
using PL.Application.Services;
using PL.Persistence.Contexts;

namespace PL.Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
