using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataContracts
{
    public struct Id : IComparable, IComparable<Id>, IEquatable<Id>, IFormattable
    {
        // this would also work genericly
        // https://stackoverflow.com/questions/5377237/strongly-typing-id-values-in-c-sharp
        private readonly Guid _guid;
        private static readonly Guid _default = Guid.Empty;

        public Id(Guid? guid)
        {
            _guid = guid ?? Guid.Empty;
        }

        public static readonly Id Default = new Id(Guid.Empty);

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
            if(obj is Id)
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
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return _guid.ToString(format, formatProvider);
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
