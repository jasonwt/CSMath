namespace NumericArrays.Types {
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;

    public interface INumericArrayValueType : IConvertible, IComparable {

    }

    public enum ArrayValueType {
        Boolean,
        SByte,
        Byte,
        Int16,
        UInt16,
        Int32,
        UInt32,
        Int64,
        UInt64,
        Half,
        Single,
        Double,
        Decimal
    }

    public static class ArrayValueTypes {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryStreamRead(Stream stream, ArrayValueType arrayValueType, out ValueType readValue) {



            readValue = arrayValueType switch {
                ArrayValueType.Boolean => stream.ReadByte(),
                ArrayValueType.SByte => throw new NotImplementedException(),
                ArrayValueType.Byte => throw new NotImplementedException(),
                ArrayValueType.Int16 => throw new NotImplementedException(),
                ArrayValueType.UInt16 => throw new NotImplementedException(),
                ArrayValueType.Int32 => throw new NotImplementedException(),
                ArrayValueType.UInt32 => throw new NotImplementedException(),
                ArrayValueType.Int64 => throw new NotImplementedException(),
                ArrayValueType.UInt64 => throw new NotImplementedException(),
                ArrayValueType.Half => throw new NotImplementedException(),
                ArrayValueType.Single => throw new NotImplementedException(),
                ArrayValueType.Double => throw new NotImplementedException(),
                ArrayValueType.Decimal => throw new NotImplementedException(),
                _ => throw new ArgumentException("Unsupported type", nameof(arrayValueType))
            };

            return false;

        }

        public static int SizeOf(this ArrayValueType valueType) {
            return valueType switch {
                ArrayValueType.Boolean => sizeof(bool),
                ArrayValueType.SByte => sizeof(sbyte),
                ArrayValueType.Byte => sizeof(byte),
                ArrayValueType.Int16 => sizeof(short),
                ArrayValueType.UInt16 => sizeof(ushort),
                ArrayValueType.Int32 => sizeof(int),
                ArrayValueType.UInt32 => sizeof(uint),
                ArrayValueType.Int64 => sizeof(long),
                ArrayValueType.UInt64 => sizeof(ulong),
                ArrayValueType.Half => sizeof(short),
                ArrayValueType.Single => sizeof(float),
                ArrayValueType.Double => sizeof(double),
                ArrayValueType.Decimal => sizeof(decimal),
                _ => throw new ArgumentException("Unsupported type", nameof(valueType))
            };
        }
        public static int SizeOf<T>()
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return SizeOf(ArrayValueTypeOf<T>());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueType CastToArrayValueType<T>(this T value, ArrayValueType valueType)
            where T : struct, IConvertible, IComparable, IComparable<T>, IEquatable<T> {

            return valueType switch {
                ArrayValueType.Boolean => ((IConvertible)value).ToBoolean(null),
                ArrayValueType.SByte => ((IConvertible)value).ToSByte(null),
                ArrayValueType.Byte => ((IConvertible)value).ToByte(null),
                ArrayValueType.Int16 => ((IConvertible)value).ToInt16(null),
                ArrayValueType.UInt16 => ((IConvertible)value).ToUInt16(null),
                ArrayValueType.Int32 => ((IConvertible)value).ToInt32(null),
                ArrayValueType.UInt32 => ((IConvertible)value).ToUInt32(null),
                ArrayValueType.Int64 => ((IConvertible)value).ToInt64(null),
                ArrayValueType.UInt64 => ((IConvertible)value).ToUInt64(null),
                ArrayValueType.Half => ((IConvertible)value).ToSingle(null),
                ArrayValueType.Single => ((IConvertible)value).ToSingle(null),
                ArrayValueType.Double => ((IConvertible)value).ToDouble(null),
                ArrayValueType.Decimal => ((IConvertible)value).ToDecimal(null),
                _ => throw new ArgumentException("Unsupported type", nameof(valueType))
            };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueType CastToArrayValueType(this float value, ArrayValueType valueType) {
            return valueType switch {
                ArrayValueType.Boolean => ((IConvertible)(long)value).ToBoolean(null),
                ArrayValueType.SByte => ((IConvertible)(long)value).ToSByte(null),
                ArrayValueType.Byte => ((IConvertible)(long)value).ToByte(null),
                ArrayValueType.Int16 => ((IConvertible)(long)value).ToInt16(null),
                ArrayValueType.UInt16 => ((IConvertible)(long)value).ToUInt16(null),
                ArrayValueType.Int32 => ((IConvertible)(long)value).ToInt32(null),
                ArrayValueType.UInt32 => ((IConvertible)(long)value).ToUInt32(null),
                ArrayValueType.Int64 => ((IConvertible)(long)value).ToInt64(null),
                ArrayValueType.UInt64 => ((IConvertible)(long)value).ToUInt64(null),
                ArrayValueType.Half => ((IConvertible)value).ToSingle(null),
                ArrayValueType.Single => ((IConvertible)value).ToSingle(null),
                ArrayValueType.Double => ((IConvertible)value).ToDouble(null),
                ArrayValueType.Decimal => ((IConvertible)value).ToDecimal(null),
                _ => throw new ArgumentException("Unsupported type", nameof(valueType))
            };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueType CastToArrayValueType(this double value, ArrayValueType valueType) {
            return valueType switch {
                ArrayValueType.Boolean => ((IConvertible)(long)value).ToBoolean(null),
                ArrayValueType.SByte => ((IConvertible)(long)value).ToSByte(null),
                ArrayValueType.Byte => ((IConvertible)(long)value).ToByte(null),
                ArrayValueType.Int16 => ((IConvertible)(long)value).ToInt16(null),
                ArrayValueType.UInt16 => ((IConvertible)(long)value).ToUInt16(null),
                ArrayValueType.Int32 => ((IConvertible)(long)value).ToInt32(null),
                ArrayValueType.UInt32 => ((IConvertible)(long)value).ToUInt32(null),
                ArrayValueType.Int64 => ((IConvertible)(long)value).ToInt64(null),
                ArrayValueType.UInt64 => ((IConvertible)(long)value).ToUInt64(null),
                ArrayValueType.Half => ((IConvertible)value).ToSingle(null),
                ArrayValueType.Single => ((IConvertible)value).ToSingle(null),
                ArrayValueType.Double => ((IConvertible)value).ToDouble(null),
                ArrayValueType.Decimal => ((IConvertible)value).ToDecimal(null),
                _ => throw new ArgumentException("Unsupported type", nameof(valueType))
            };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueType CastToArrayValueType(this decimal value, ArrayValueType valueType) {
            return valueType switch {
                ArrayValueType.Boolean => ((IConvertible)(long)value).ToBoolean(null),
                ArrayValueType.SByte => ((IConvertible)(long)value).ToSByte(null),
                ArrayValueType.Byte => ((IConvertible)(long)value).ToByte(null),
                ArrayValueType.Int16 => ((IConvertible)(long)value).ToInt16(null),
                ArrayValueType.UInt16 => ((IConvertible)(long)value).ToUInt16(null),
                ArrayValueType.Int32 => ((IConvertible)(long)value).ToInt32(null),
                ArrayValueType.UInt32 => ((IConvertible)(long)value).ToUInt32(null),
                ArrayValueType.Int64 => ((IConvertible)(long)value).ToInt64(null),
                ArrayValueType.UInt64 => ((IConvertible)(long)value).ToUInt64(null),
                ArrayValueType.Half => ((IConvertible)value).ToSingle(null),
                ArrayValueType.Single => ((IConvertible)value).ToSingle(null),
                ArrayValueType.Double => ((IConvertible)value).ToDouble(null),
                ArrayValueType.Decimal => ((IConvertible)value).ToDecimal(null),
                _ => throw new ArgumentException("Unsupported type", nameof(valueType))
            };
        }

        public static ArrayValueType ArrayValueTypeOf(this Type type) {
            return Type.GetTypeCode(type) switch {
                TypeCode.Boolean => ArrayValueType.Boolean,
                TypeCode.SByte => ArrayValueType.SByte,
                TypeCode.Byte => ArrayValueType.Byte,
                TypeCode.Int16 => ArrayValueType.Int16,
                TypeCode.UInt16 => ArrayValueType.UInt16,
                TypeCode.Int32 => ArrayValueType.Int32,
                TypeCode.UInt32 => ArrayValueType.UInt32,
                TypeCode.Int64 => ArrayValueType.Int64,
                TypeCode.UInt64 => ArrayValueType.UInt64,
                TypeCode.Single => ArrayValueType.Single,
                TypeCode.Double => ArrayValueType.Double,
                TypeCode.Decimal => ArrayValueType.Decimal,
                TypeCode.Object => type == typeof(Half) ? ArrayValueType.Half : throw new ArgumentException("Unsupported type", nameof(type)),
                _ => throw new ArgumentException("Unsupported type", nameof(type))
            };
        }
        public static ArrayValueType ArrayValueTypeOf<T>()
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return ArrayValueTypeOf(typeof(T));
        }
        //public static TOutput CastValueTo<TOutput, TInput>(this TInput value, NumericArrayValueType tOutputType)
        //    where TOutput : struct, IComparable, IComparable<TOutput>, IConvertible, IEquatable<TOutput>
        //    where TInput : struct, IComparable, IComparable<TInput>, IConvertible, IEquatable<TInput> {

        //    return tOutputType switch {
        //        NumericArrayValueType.Boolean => (TOutput)(ValueType)value.ToBoolean(null),
        //        NumericArrayValueType.SByte => (TOutput)(ValueType)value.ToSByte(null),
        //        NumericArrayValueType.Byte => (TOutput)(ValueType)value.ToByte(null),
        //        NumericArrayValueType.Int16 => (TOutput)(ValueType)value.ToInt16(null),
        //        NumericArrayValueType.UInt16 => (TOutput)(ValueType)value.ToUInt16(null),
        //        NumericArrayValueType.Int32 => (TOutput)(ValueType)value.ToInt32(null),
        //        NumericArrayValueType.UInt32 => (TOutput)(ValueType)value.ToUInt32(null),
        //        NumericArrayValueType.Int64 => (TOutput)(ValueType)value.ToInt64(null),
        //        NumericArrayValueType.UInt64 => (TOutput)(ValueType)value.ToUInt64(null),
        //        NumericArrayValueType.Half => (TOutput)(ValueType)value.ToInt32(null),
        //        NumericArrayValueType.Single => (TOutput)(ValueType)value.ToSingle(null),
        //        NumericArrayValueType.Double => (TOutput)(ValueType)value.ToDouble(null),
        //        NumericArrayValueType.Decimal => (TOutput)(ValueType)value.ToDecimal(null),
        //        _ => throw new InvalidEnumArgumentException("Unsupported type")
        //    };
        //}
    }
}
