using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Customers
{
    public class List
    {
        // public class Query : IRequest<ActivityDto>
        // {
        //     public Guid Id { get; set; }
        // }   
        public class Query : IRequest<List<VisitDto>> { 
            public DateTime? Date { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<VisitDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<VisitDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var visits = await _context.Visits
                    .Where(x => x.Date >= request.Date)
                    .ToListAsync();
                    
                // return VisitDtos;
                return _mapper.Map<List<Visit>, List<VisitDto>>(visits);
            }

        }
    }
}