using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Customers
{
    public class SignUp
    {
        public class Command : IRequest<Guid>
        {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.FirstName).MaximumLength(255);
                RuleFor(x => x.LastName).MaximumLength(255);
                RuleFor(x => x.Sex).MaximumLength(255);
                RuleFor(x => x.Age).GreaterThan(18).WithMessage("Should be greater than 18");
                RuleFor(x => x.Barangay).MaximumLength(255);
                RuleFor(x => x.City).MaximumLength(255);
            }
        }
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;   
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                
                var customer = new Customer
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Sex = request.Sex,
                    Age = request.Age,
                    Barangay = request.Barangay,
                    City = request.City,
                    Date = DateTime.Now
                };
                _context.Customers.Add(customer);
                var success = await _context.SaveChangesAsync() > 0;
                
                if (success) return customer.Id;
                throw new Exception("Problem saving changes");
            }
        }
    }
}