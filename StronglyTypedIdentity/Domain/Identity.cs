using System;

namespace StronglyTypedIdentity.Domain
{
	public class Identity : IEquatable<Identity> {
		public int Value { get; }

		protected Identity(int value) {
			if (value <= 0) {
				throw new InvalidOperationException("Incorrect Id value");
			}
			Value = value;
		}

		public bool Equals(Identity other) {
			if (ReferenceEquals(null, other)) {
				return false;
			}
			if (ReferenceEquals(this, other)) {
				return true;
			}
			return Value.Equals(other.Value);
		}

		public override bool Equals(object obj) {
			if (ReferenceEquals(null, obj)) {
				return false;
			}
			if (ReferenceEquals(this, obj)) {
				return true;
			}
			if (obj.GetType() != GetType()) {
				return false;
			}
			return Equals((Identity)obj);
		}

		public override int GetHashCode() {
			return Value.GetHashCode();
		}

		public static bool operator ==(Identity left, Identity right) {
			return Equals(left, right);
		}

		public static bool operator !=(Identity left, Identity right) {
			return !Equals(left, right);
		}
	}
}