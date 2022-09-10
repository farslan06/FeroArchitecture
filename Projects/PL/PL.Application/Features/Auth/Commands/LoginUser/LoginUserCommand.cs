using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PL.Application.Features.Auth.Rules;
using PL.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommand:IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AccessToken>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginUserCommandHandler(IMapper mapper, IUserRepository userRepository, IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper, AuthBusinessRules authBusinessRules)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _userOperationClaimRepository = userOperationClaimRepository;
                _tokenHelper = tokenHelper;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<AccessToken> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.UserExistsWhenLogin(request.Email);

                User user = await _userRepository.GetAsync(x => x.Email == request.Email);

                if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                    throw new BusinessException("Password incorrect!");

                //IPaginate<UserOperationClaim> userGetClaims = await _userOperationClaimRepository.GetListAsync(u => u.UserId == userRegister.Id,
                //    include: i => i.Include(i => i.OperationClaim));

                IPaginate<UserOperationClaim> userClaims = await _userOperationClaimRepository.GetListAsync(x => x.UserId == user.Id,
                    include: i => i.Include(i => i.OperationClaim));

                AccessToken accessToken = _tokenHelper.CreateToken(user, userClaims.Items.Select(s=>s.OperationClaim).ToList());

                return accessToken;
;            }
        }
    }
}
