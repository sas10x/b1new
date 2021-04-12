using System.Linq;
using AutoMapper;
using Domain;

namespace Application.Employees
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Answer, AnswerDto>()
                .ForMember(d => d.Question, o => o.MapFrom(s => s.Question.Description))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Employee.LastName+","+s.Employee.FirstName))
                .ForMember(d => d.Sex, o => o.MapFrom(s => s.Employee.Sex))
                .ForMember(d => d.Age, o => o.MapFrom(s => s.Employee.Age))
                .ForMember(d => d.Address, o => o.MapFrom(s => s.Employee.Address.Province+","+s.Employee.Address.City+","+s.Employee.Address.Street));
        }
    }
}