using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataContracts
{
    public struct Id : IComparable, IComparable<Id>, IEquatable<Id>
    {
        private readonly Guid _guid;
        private static readonly Guid _default = default(Guid);

        public Id(Guid? guid)
        {
            _guid = guid ?? _default;
        }

        public bool IsDefault()
        {
            return this._guid.Equals(_default);
        }

        public static Id Default()
        { 
            return new Id(_default);
        }

        public static Id New()
        {
            return new Id(Guid.NewGuid());
        }

        public static explicit operator Id(Guid guid)
        {
            return new Id(guid);
        }

        public static implicit operator Guid(Id id)
        {
            return id._guid;
        }

        public override bool Equals(object obj)
        {
            return obj is Id && this.Equals((Id)obj);
        }

        public int CompareTo(object obj)
        {
            if (obj is Id)
            {
                return this.CompareTo((Id)obj);
            }
            else
            {
                throw new Exception("Types not comparable");
            }
        }

        public int CompareTo(Id other)
        {
            return _guid.CompareTo(other);
        }

        public bool Equals(Id other)
        {
            return _guid.Equals(other);
        }

        public override string ToString()
        {
            return _guid.ToString();
        }

        public override int GetHashCode()
        {
            return _guid.GetHashCode();
        }
        public static bool operator ==(Id a, Id b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Id a, Id b)
        {
            return !(a == b);
        }
    }
}
