using System.ComponentModel.DataAnnotations;

namespace UnitOfWork.Architecture.Domain.Common;

public record BaseEntity
{
    [Key]
    public int Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}
