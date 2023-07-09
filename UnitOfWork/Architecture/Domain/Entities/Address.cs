using System.ComponentModel.DataAnnotations.Schema;
using UnitOfWork.Architecture.Domain.Entities.Common;

namespace UnitOfWork.Architecture.Domain.Entities;

public record Address : BaseEntity
{
    public string Country { get; init; }
    public string POBox { get; init; }
    public string City { get; init; }
    public string Street { get; init; }
    public string Apartment { get; init; }

    [ForeignKey(nameof(Entities.Person))]
    public int PersonId { get; init; }
    public virtual Person Person { get; init; }
}
