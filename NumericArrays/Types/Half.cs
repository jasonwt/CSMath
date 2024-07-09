namespace NumericArrays.Types {
    using System;

    public struct Half : INumericArrayValueType, IComparable<Half>, IEquatable<Half> {
        int IComparable.CompareTo(object obj) {
            throw new NotImplementedException();
        }

        int IComparable<Half>.CompareTo(Half other) {
            throw new NotImplementedException();
        }

        bool IEquatable<Half>.Equals(Half other) {
            throw new NotImplementedException();
        }

        TypeCode IConvertible.GetTypeCode() {
            throw new NotImplementedException();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        byte IConvertible.ToByte(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        char IConvertible.ToChar(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        double IConvertible.ToDouble(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        short IConvertible.ToInt16(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        int IConvertible.ToInt32(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        long IConvertible.ToInt64(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        float IConvertible.ToSingle(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        string IConvertible.ToString(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider) {
            throw new NotImplementedException();
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        uint IConvertible.ToUInt32(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider) {
            throw new NotImplementedException();
        }
    }

    public static class IConvertibleExtensions {
        public static Half ToHalf<T>(this T convertible, IFormatProvider? formatProvider)
            where T : IConvertible {

            throw new NotImplementedException();
        }
    }
}
