using AutoMapper;
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

namespace PL.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly AuthBusinessRules _authBusinessRules;

            public RegisterUserCommandHandler(IUserRepository userRepository, IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, ITokenHelper tokenHelper, IOperationClaimRepository operationClaimRepository, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _userOperationClaimRepository = userOperationClaimRepository;
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<AccessToken> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.UserMailCannotBeDuplicatedWhenRegister(request.Email);
              
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                User mappedUser = _mapper.Map<User>(request);
                mappedUser.PasswordSalt=passwordSalt;
                mappedUser.PasswordHash = passwordHash;
                mappedUser.Status = true;

                User registeredUser=await _userRepository.AddAsync(mappedUser);

                UserOperationClaim userOperationClaim = new() { UserId = registeredUser.Id, OperationClaimId = 2 };
                var res = await _userOperationClaimRepository.AddAsync(userOperationClaim);


                IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(x=>x.Id==userOperationClaim.OperationClaimId);

                AccessToken accessToken = _tokenHelper.CreateToken(registeredUser, operationClaims.Items.ToList());

                return accessToken;
            }
        }

    }
}
