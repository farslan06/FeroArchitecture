using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PL.Application.Features.Technologies.Models;
using PL.Application.Services;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetListTechnologyByDynamicQuery:IRequest<TechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }

        public class GetListTechnologyByDynamicQueryHandler : IRequestHandler<GetListTechnologyByDynamicQuery, TechnologyListModel>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public GetListTechnologyByDynamicQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<TechnologyListModel> Handle(GetListTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Technology> technologies = await _technologyRepository.
                    GetListByDynamicAsync(dynamic: request.Dynamic,
                                          include: m=>m.Include(c=>c.ProgrammingLanguage),
                                          index:request.PageRequest.Page,
                                          size:request.PageRequest.PageSize
                                          );

                TechnologyListModel technologyListModel=_mapper.Map<TechnologyListModel>(technologies);

                return technologyListModel;
                
            }
        }
    }
}
