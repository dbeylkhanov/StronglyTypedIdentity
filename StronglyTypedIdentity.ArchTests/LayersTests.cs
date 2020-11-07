using NetArchTest.Rules;
using NUnit.Framework;
using StronglyTypedIdentity.Domain;

namespace StronglyTypedIdentity.ArchTests
{
	[TestFixture]
	public class LayersTests
	{
		/// <summary>
		/// <see cref="CustomType"/> to reproduce the bug within this test
		/// </summary>
		[Test]
		public void DomainLayerDoesNotHaveDependencyOnInfrastructureLayer() {
			TestResult result = Types.InAssembly(typeof(Identity).Assembly)
				.That()
				.ResideInNamespace("StronglyTypedIdentity.Domain")
				.ShouldNot()
				.HaveDependencyOn("StronglyTypedIdentity.Infrastructure")
				.GetResult();

			Assert.That(result.IsSuccessful);
		}
	}
}