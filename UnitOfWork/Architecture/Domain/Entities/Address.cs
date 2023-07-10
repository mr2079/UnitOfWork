using System.ComponentModel.DataAnnotations.Schema;
using UnitOfWork.Architecture.Domain.Common;

namespace UnitOfWork.Architecture.Domain.Entities;

public record Address : BaseEntity
{
    public int? PersonId { get; init; }
    public string Country { get; init; }
    public string POBox { get; init; }
    public string City { get; init; }
    public string Street { get; init; }
    public string Apartment { get; init; }


    [ForeignKey(nameof(PersonId))]
    public Person? Person { get; init; }
}
