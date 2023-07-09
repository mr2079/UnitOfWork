using AutoMapper;
using UnitOfWork.Architecture.Application.DTOs;
using UnitOfWork.Architecture.Domain.Entities;

namespace UnitOfWork.Architecture.Application.Mapper;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, PersonDto>().ReverseMap();
    }
}
