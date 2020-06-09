using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using Domain;
using System.Linq;
using System;
using Application.Errors;
using System.Net;

namespace Application.Employees
{
    public class Daily
    {
        public class Command : IRequest
        {
        public int Id { get; set; }
        public int QId { get; set; }
        public string q { get; set; }
        
        }

        
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;   
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees
                    .FindAsync(request.Id);
                var quest = await _context.Questions.FindAsync(request.QId);
                if (quest == null)
                    throw new RestException(HttpStatusCode.NotFound, new {Activity = "Could not find question"});
                 var ans1 = new Answer
                {
                    Description = request.q,
                    Question = quest,
                    Employee = employee,
                    Date = DateTime.Now
                };
                 _context.Answers.Add(ans1);

                
                var success = await _context.SaveChangesAsync() > 0;
                
                if (success) return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}