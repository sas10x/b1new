using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Employees
{
    public class Create
    {
        public class Command : IRequest
        {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int IdNumber { get; set; }
        
        public int Age { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Branch { get; set; }
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
                var address = new Address
                {
                    Street = request.Street,
                    City = request.City,
                    Province = request.Province,
                };
                _context.Addresses.Add(address);

                var employee = new Employee
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    IdNUmber = request.IdNumber,
                    Sex = request.Sex,
                    Age = request.Age,
                    Address = address,
                    Date = DateTime.Now,
                    Branch = request.Branch
                };
                _context.Employees.Add(employee);
                var success = await _context.SaveChangesAsync() > 0;
                
                if (success) return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}