using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Domain.Entities
{
    public class SocialLink:Entity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public SocialLink()
        {

        }

        public SocialLink(string name, string link, int userId)
        {
            Name = name;
            Link = link;
            UserId = userId;
            
        }
    }
}
