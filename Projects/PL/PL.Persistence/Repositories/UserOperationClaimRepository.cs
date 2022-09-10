using Core.Persistence.Repositories;
using Core.Security.Entities;
using PL.Application.Services;
using PL.Persistence.Contexts;

namespace PL.Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
