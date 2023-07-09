﻿using UnitOfWork.Architecture.Domain.Entities.Common;

namespace UnitOfWork.Architecture.Domain.Entities;

public record Person : BaseEntity
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public virtual ICollection<Address> Addresses { get; set; }
}