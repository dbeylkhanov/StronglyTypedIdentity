using StronglyTypedIdentity.Infrastructure;

namespace StronglyTypedIdentity.Domain
{
	public class CustomType
	{
		public CustomTypeId Id { get; }

		public CustomType()
		{
			// todo: uncomment the 12th line and test will be failed!
			//var dbContext = new CustomDbContext(); // Expected: Failed vs. Actual: Failed
			
			// todo: uncomment the 15th line and test will be passed! Looks like NetArchTest missed the `nameof` exp., even though the CustomType depends on the StronglyTypedIdentity.Infrastructure namespace anyway
			var dbContextName = nameof(CustomDbContext); // Expected: Failed vs. Actual: Success 
		}
	}
}