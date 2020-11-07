using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StronglyTypedIdentity.Domain;

namespace StronglyTypedIdentity.Infrastructure
{
	public class CustomDbContext : DbContext
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CustomType>().Property(p => p.Id)
				.HasConversion(new ValueConverter<CustomTypeId, int>(id => id.Value, g => new CustomTypeId(g)));

			modelBuilder.Entity<CustomType>().Property(p => p.Id)
				.HasValueGenerator((property, type) => new TypedValueIdentityGenerator<CustomTypeId>("existingCustomTypeSqlSequence"));
		}
	}
}