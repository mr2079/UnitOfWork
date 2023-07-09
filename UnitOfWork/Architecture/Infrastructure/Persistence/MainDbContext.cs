﻿using Microsoft.EntityFrameworkCore;
using UnitOfWork.Architecture.Domain.Common;
using UnitOfWork.Architecture.Domain.Entities;

namespace UnitOfWork.Architecture.Infrastructure.Persistence;

public class MainDbContext : DbContext, IMainDbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>().AsEnumerable())
        {
            entry.Entity.CreatedAt = DateTime.Now;
            entry.Entity.UpdatedAt = DateTime.Now;
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().ToTable("Persons");
        modelBuilder.Entity<Address>().ToTable("Addresses");

        //Seed data
        modelBuilder.Entity<Person>().HasData(
            new Person { Id = 1, FirstName = "Jordan", LastName = "Davila" },
            new Person { Id = 2, FirstName = "Giovanni", LastName = "Krueger" },
            new Person { Id = 3, FirstName = "Marjorie", LastName = "Nolan" });

        modelBuilder.Entity<Address>().HasData(
        new Address { Id = 1, Country = "Portuguese", POBox = "1900-349", City = "Lisboa", Street = "Yango Avenida, Quadra 25", Apartment = "3", PersonId = 1 },
        new Address { Id = 2, Country = "Portuguese", POBox = "1900-123", City = "Faro", Street = "Braga Rua, Quadra 01", Apartment = "54", PersonId = 2 },
        new Address { Id = 3, Country = "Portuguese", POBox = "1900-73", City = "Albufeira", Street = "Moraes Alameda, Casa 2", Apartment = "", PersonId = 3 });
        
        base.OnModelCreating(modelBuilder);
    }

}
