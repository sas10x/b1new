using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Employees
{
    public class SignIn
    {
       public class Query : IRequest<int>
        {
            public int IdNumber { get; set; }
        }   

        public class Handler : IRequestHandler<Query, int>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<int> Handle(Query request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees
                    .Where(s => s.IdNUmber == request.IdNumber)
                    .SingleAsync();
                return employee.Id;
            }
        }
    }
}