using Core.Persistence.Repositories;
using PL.Application.Services;
using PL.Domain.Entities;
using PL.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Persistence.Repositories
{
    public class SocialLinkRepository : EfRepositoryBase<SocialLink, BaseDbContext>, ISocialLinkRepository
    {
        public SocialLinkRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
