using UnitOfWork.Architecture.Domain.Entities;

namespace UnitOfWork.Architecture.Application.DTOs;

public class PersonDto
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public IList<Address> Addresses { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}
