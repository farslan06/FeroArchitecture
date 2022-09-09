using AutoMapper;
using MediatR;
using PL.Application.Features.Technologies.Dtos;
using PL.Application.Services;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQuery:IRequest<TechnologyGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, TechnologyGetByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;

            public GetByIdTechnologyQueryHandler(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<TechnologyGetByIdDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
            {
                Technology technology=await _technologyRepository.GetAsync(x=>x.Id==request.Id);

                TechnologyGetByIdDto technologyGetByIdDto=_mapper.Map<TechnologyGetByIdDto>(technology);

                return technologyGetByIdDto;
            }
        }
    }
}
