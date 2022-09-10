using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using PL.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.Auth.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserMailCannotBeDuplicatedWhenRegister(string email)
        {
            IPaginate<User> userExists = await _userRepository.GetListAsync(x => x.Email == email);
            //User? userExits=await _userRepository.GetAsync(x => x.Email == email);
            if (userExists.Items.Any()) throw new BusinessException("User exists");
        }

        public async Task UserExistsWhenLogin(string email)
        {
            IPaginate<User> users=await _userRepository.GetListAsync(x=>x.Email == email);
            if (!users.Items.Any()) throw new BusinessException("User not found");
        }
    }
}
