using Core.Persistence.Repositories;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Services
{
    public interface ISocialLinkRepository:IAsyncRepository<SocialLink>,IRepository<SocialLink>
    {
    }
}
