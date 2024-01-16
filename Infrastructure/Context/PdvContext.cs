using Domain.Entities;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class PdvContext : DbContext
    {
        public PdvContext(DbContextOptions<PdvContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PdvContext).Assembly);

            var entityTypes = modelBuilder.Model
                                                        .GetEntityTypes()
                                                        .Where(t => typeof(Entity).IsAssignableFrom(t.ClrType));

            foreach (var entityType in entityTypes)
            {
                var configurationType = typeof(EntityMapping<>)
                    .MakeGenericType(entityType.ClrType);

                modelBuilder
                    .ApplyConfiguration((dynamic)Activator.CreateInstance(configurationType));
            }


        }

        public DbSet<UserEntity> User { get; set; }
       

    }
}
