using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Employees
{
    public class List
    {
        public class Query : IRequest<List<Question>> { }

        public class Handler : IRequestHandler<Query, List<Question>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<Question>> Handle(Query request, CancellationToken cancellationToken)
            {
                var questions = await _context.Questions
                    .ToListAsync();
                    
                return questions;
            }

        }
    }
}