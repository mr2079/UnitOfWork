using System.ComponentModel.DataAnnotations;

namespace UnitOfWork.Architecture.Domain.Common;

public abstract record BaseEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
