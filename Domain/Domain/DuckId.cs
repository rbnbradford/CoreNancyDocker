using System;

namespace Domain.Domain
{
    public class DuckId
    {
        private string Id { get; }
        private DuckId(string id) => Id = id;
        public static DuckId FromExisiting(string id) => new DuckId(id);
        public static DuckId Generate() => new DuckId(Guid.NewGuid().ToString());

        private bool Equals(DuckId other) => string.Equals(Id, other.Id);
        public override int GetHashCode() => Id != null ? Id.GetHashCode() : 0;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((DuckId) obj);
        }

        public override string ToString() => Id;
    }
}
