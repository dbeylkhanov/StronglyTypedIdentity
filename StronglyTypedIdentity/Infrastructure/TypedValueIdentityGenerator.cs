using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using StronglyTypedIdentity.Domain;

namespace StronglyTypedIdentity.Infrastructure
{
	public class TypedValueIdentityGenerator<TTypedIdValue> : ValueGenerator<TTypedIdValue> where TTypedIdValue : Identity {
		private readonly string _sequenceName;

		public override bool GeneratesTemporaryValues => false;

		public TypedValueIdentityGenerator(string sequenceName) {
			if (string.IsNullOrWhiteSpace(sequenceName)) {
				throw new ArgumentException("Incorrect sequence name");
			}
			_sequenceName = sequenceName;
		}

		public override TTypedIdValue Next(EntityEntry entry) {
			return Activator.CreateInstance(typeof(TTypedIdValue), GenerateNextId(entry.Context)) as TTypedIdValue;
		}

		private int GenerateNextId(DbContext context) {
			return context.GetNextSequenceValue(_sequenceName);
		}
	}
}