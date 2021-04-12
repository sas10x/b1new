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
        public string Id { get; set; }
        public string Temperature { get; set; }
        
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
                // var id = Guid.Parse(request.Id);

                // var customer = await _context.Customers
                //     .FindAsync(id);
                // if (customer == null)
                //     throw new RestException(HttpStatusCode.NotFound, new {Customer = "Could not find question"});
                
                var temperature = decimal.Parse(request.Temperature);
                var Entry = new Entry
                {
                    Qcode = request.Id,
                    // CustomerId = id,
                    // Customer = customer,
                    Action = "IN",
                    Branch = "CHBC Banilad",
                    Temperature = temperature,
                    Date = DateTime.Now
                };
                 _context.Entrys.Add(Entry);
                var success = await _context.SaveChangesAsync() > 0;
                
                if (success) return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}