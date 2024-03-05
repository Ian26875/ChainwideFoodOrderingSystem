using System.Collections;
using System.Reflection;

namespace ChainwideFoodOrderingSystem.SeedWork.DomainModel;

/// <summary>
/// The value object class
/// </summary>
public abstract class ValueObject<T> where T : ValueObject<T>
{
    /// <summary>
    /// The to array
    /// </summary>
    private static readonly Member[] Members = GetMembers().ToArray();

    /// <summary>
    /// Describes whether this instance equals
    /// </summary>
    /// <param name="other">The other</param>
    /// <returns>The bool</returns>
    public override bool Equals(object other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return other.GetType() == typeof(T) && Members.All(
            m =>
            {
                var otherValue = m.GetValue(other);
                var thisValue = m.GetValue(this);

                return m.IsNonStringEnumerable
                    ? GetEnumerableValues(otherValue).SequenceEqual(GetEnumerableValues(thisValue))
                    : otherValue?.Equals(thisValue) ?? thisValue == null;
            }
        );
    }

    /// <summary>
    /// Gets the hash code
    /// </summary>
    /// <returns>The int</returns>
    public override int GetHashCode()
    {
        return CombineHashCodes(
            Members.Select(
                m => m.IsNonStringEnumerable
                    ? CombineHashCodes(GetEnumerableValues(m.GetValue(this)))
                    : m.GetValue(this)
            )
        );
    }

    public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    /// Returns the string
    /// </summary>
    /// <returns>The string</returns>
    public override string ToString()
    {
        if (Members.Length == 1)
        {
            var m = Members[0];
            var value = m.GetValue(this);

            return m.IsNonStringEnumerable
                ? $"{string.Join("|", GetEnumerableValues(value))}"
                : value.ToString();
        }

        var values = Members.Select(
            m =>
            {
                var value = m.GetValue(this);

                return m.IsNonStringEnumerable
                    ? $"{m.Name}:{string.Join("|", GetEnumerableValues(value))}"
                    : m.Type != typeof(string)
                        ? $"{m.Name}:{value}"
                        : value == null
                            ? $"{m.Name}:null"
                            : $"{m.Name}:\"{value}\"";
            }
        );
        return $"{typeof(T).Name}[{string.Join("|", values)}]";
    }

    /// <summary>
    /// Gets the members
    /// </summary>
    /// <returns>An enumerable of member</returns>
    private static IEnumerable<Member> GetMembers()
    {
        var t = typeof(T);
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;

        while (t != typeof(object))
        {
            if (t == null) continue;

            foreach (var p in t.GetProperties(flags)) yield return new Member(p);
            foreach (var f in t.GetFields(flags)) yield return new Member(f);

            t = t.BaseType;
        }
    }

    /// <summary>
    /// Gets the enumerable values using the specified obj
    /// </summary>
    /// <param name="obj">The obj</param>
    /// <returns>An enumerable of object</returns>
    private static IEnumerable<object> GetEnumerableValues(object obj)
    {
        var enumerator = ((IEnumerable) obj).GetEnumerator();
        while (enumerator.MoveNext()) yield return enumerator.Current;
    }

    /// <summary>
    /// Combines the hash codes using the specified objs
    /// </summary>
    /// <param name="objs">The objs</param>
    /// <returns>The int</returns>
    private static int CombineHashCodes(IEnumerable<object> objs)
    {
        unchecked
        {
            return objs.Aggregate(17, (current, obj) => current * 59 + (obj?.GetHashCode() ?? 0));
        }
    }

    /// <summary>
    /// The member
    /// </summary>
    private struct Member
    {
        /// <summary>
        /// The name
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// The get value
        /// </summary>
        public readonly Func<object, object> GetValue;
        /// <summary>
        /// The is non string enumerable
        /// </summary>
        public readonly bool IsNonStringEnumerable;
        /// <summary>
        /// The type
        /// </summary>
        public readonly Type Type;

        /// <summary>
        /// Initializes a new instance of the <see cref="Member"/> class
        /// </summary>
        /// <param name="info">The info</param>
        /// <exception cref="ArgumentException">Member is not a field or property?!?! </exception>
        public Member(MemberInfo info)
        {
            switch (info)
            {
                case FieldInfo field:
                    Name = field.Name;
                    GetValue = obj => field.GetValue(obj);

                    IsNonStringEnumerable = typeof(IEnumerable).IsAssignableFrom(field.FieldType) &&
                                            field.FieldType != typeof(string);
                    Type = field.FieldType;
                    break;
                case PropertyInfo prop:
                    Name = prop.Name;
                    GetValue = obj => prop.GetValue(obj);

                    IsNonStringEnumerable = typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) &&
                                            prop.PropertyType != typeof(string);
                    Type = prop.PropertyType;
                    break;
                default:
                    throw new ArgumentException("Member is not a field or property?!?!", info.Name);
            }
        }
    }
}