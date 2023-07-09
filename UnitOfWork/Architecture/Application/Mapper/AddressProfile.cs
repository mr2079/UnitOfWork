using AutoMapper;
using UnitOfWork.Architecture.Application.DTOs;
using UnitOfWork.Architecture.Domain.Entities;

namespace UnitOfWork.Architecture.Application.Mapper;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, AddressDto>().ReverseMap(); 
    }
}
