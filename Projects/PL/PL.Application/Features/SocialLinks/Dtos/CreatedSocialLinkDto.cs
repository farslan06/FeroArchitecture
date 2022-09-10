using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.SocialLinks.Dtos
{
    public class CreatedSocialLinkDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }
    }
}
