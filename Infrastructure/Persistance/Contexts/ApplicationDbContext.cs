using Domain.Entities;
using Infrastructure.Interceptors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Application.Common.Interfaces.Data;
using Infrastructure.Persistance.Extensions;
using Infrastructure.Persistance.Seeding;
using Infrastructure.Common.Extensions;
using Domain.Common.Contracts;
using Infrastructure.Persistance.Configurations;

namespace Infrastructure.Persistance.Context
{
    internal class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IMediator _mediator;
        private readonly ModelSeeder _modelSeeder;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IMediator mediator,
            ModelSeeder modelSeeder) : base(options)
        {
            _mediator = mediator;
            _modelSeeder = modelSeeder;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _modelSeeder.Seed(modelBuilder);
            modelBuilder.AppendGlobalQueryFilter<ISoftDeletableEntity>(e => e.DeletedOn == null);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            AuditableEntityConfiguration.Configure(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this, cancellationToken);
            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}
