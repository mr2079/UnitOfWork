using UnitOfWork.Architecture.Domain.Common;

namespace UnitOfWork.Architecture.Domain.Entities;

public record Person : BaseEntity
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public ICollection<Address>? Addresses { get; init; }
}
