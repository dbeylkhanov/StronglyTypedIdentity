using Microsoft.EntityFrameworkCore;

namespace StronglyTypedIdentity
{
	public class CustomDbContext : DbContext
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CustomType>().Property(p => p.Id).HasValueGenerator((property, type) => new TypedValueIdentityGenerator<CustomTypeId>("existingCustomTypeSqlSequence"));
		}
	}
}