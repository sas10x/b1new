using System;
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
        public class Query : IRequest<List<AnswerDto>> 
        {
            
            public string Petsa { get; set; }
            public string Branch { get; set; }
         }

        public class Handler : IRequestHandler<Query, List<AnswerDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<AnswerDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var pizza = DateTime.Parse(request.Petsa);
                var date1 = (pizza).AddDays(1);
                var startPetsa = pizza.ToString("d");
                var endPetsa = date1.ToString("d");

                var from = new SqlParameter("@From", startPetsa);
                var to = new SqlParameter("@To", endPetsa);
                // var answers = await _context.Answers
                //     .Where(t => t.Date > DateTime.Parse(startPetsa) && t.Date < DateTime.Parse(endPetsa))
                //     .ToListAsync();
                var answers = await _context.Answers
                    .FromSqlRaw("SELECT * FROM Answers WHERE Date BETWEEN @From AND @To", from, to)
                    .ToListAsync();
                return _mapper.Map<List<Answer>, List<AnswerDto>>(answers);
                // return answers;
            }

        }
    }
}