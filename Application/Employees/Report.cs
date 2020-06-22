using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Employees
{
    public class Report
    {
        public class Query : IRequest<List<Answer>> 
        {
            
            public string Petsa { get; set; }
         }

        public class Handler : IRequestHandler<Query, List<Answer>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<Answer>> Handle(Query request, CancellationToken cancellationToken)
            {
                var petsa = new SqlParameter("@Petsa", request.Petsa+"%");
                var answers = await _context.Answers
                    .FromSqlRaw("SELECT * FROM Answers WHERE Id LIKE @Petsa", petsa)
                    .ToListAsync();

                return answers;
            }

        }
    }
}