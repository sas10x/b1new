using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;
using Domain;

namespace Application.Customers
{
    public class Session
    {
        public class Command : IRequest
        {
        public Guid Id { get; set; }
        public int Temperature { get; set; }
        
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
                var customer = await _context.Customers
                    .FindAsync(request.Id);
                if (customer == null)
                    throw new RestException(HttpStatusCode.NotFound, new {Customer = "Could not find question"});

                var visit = new Visit
                {
                    Temperature = request.Temperature,
                    Date = DateTime.Now
                };
                 _context.Visits.Add(visit);
                var success = await _context.SaveChangesAsync() > 0;
                
                if (success) return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}