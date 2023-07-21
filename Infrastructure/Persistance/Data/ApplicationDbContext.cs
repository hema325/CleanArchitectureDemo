using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Interceptors;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Infrastructure.Identity;

namespace Infrastructure.Data
{
    internal class ApplicationDbContext: IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
        private readonly IMediator _mediator;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, 
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor,
            IMediator mediator) :base(options) 
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<UserModel>();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
            base.OnConfiguring(optionsBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this, cancellationToken);
            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Item> Items { get; set; }
    }
}
