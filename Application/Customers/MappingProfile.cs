using System.Linq;
using AutoMapper;
using Domain;

namespace Application.Customers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Visit, VisitDto>()
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.Customer.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.Customer.LastName))
                .ForMember(d => d.Sex, o => o.MapFrom(s => s.Customer.Sex))
                .ForMember(d => d.Age, o => o.MapFrom(s => s.Customer.Age))
                .ForMember(d => d.Barangay, o => o.MapFrom(s => s.Customer.Barangay))
                .ForMember(d => d.City, o => o.MapFrom(s => s.Customer.City));
        }
    }
}


    // public string FirstName { get; set; }
    // public string LastName { get; set; }
    // public string Sex { get; set; }
    // public int Age { get; set; }
    // public string Barangay { get; set; }
    // public string City { get; set; }