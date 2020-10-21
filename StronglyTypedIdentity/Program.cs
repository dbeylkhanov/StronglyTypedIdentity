using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace StronglyTypedIdentity
{
	class Program
	{
		static void Main(string[] args)
		{
			var identityGenerator = new TypedValueIdentityGenerator<CustomTypeId>("existingCustomTypeSqlSequence"); 
		}
	}
}