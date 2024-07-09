namespace NumericArrays {
    using System;

    using NumericArrays.Types;
    using NumericArrays.Virtual.Mathematics.Binary;

    public static partial class NA {
        #region AdditionArray (Add)
        public static INumericArray Add(this INumericArray leftArray, INumericArray rightArray, bool? solidify = null) {
            if (leftArray == null)
            {
                throw new ArgumentNullException(nameof(leftArray));
            }

            return leftArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new AdditionArray<bool>(leftArray, rightArray), solidify),
                ArrayValueType.SByte => Construct(new AdditionArray<sbyte>(leftArray, rightArray), solidify),
                ArrayValueType.Byte => Construct(new AdditionArray<byte>(leftArray, rightArray), solidify),
                ArrayValueType.Int16 => Construct(new AdditionArray<short>(leftArray, rightArray), solidify),
                ArrayValueType.UInt16 => Construct(new AdditionArray<ushort>(leftArray, rightArray), solidify),
                ArrayValueType.Int32 => Construct(new AdditionArray<int>(leftArray, rightArray), solidify),
                ArrayValueType.UInt32 => Construct(new AdditionArray<uint>(leftArray, rightArray), solidify),
                ArrayValueType.Int64 => Construct(new AdditionArray<long>(leftArray, rightArray), solidify),
                ArrayValueType.UInt64 => Construct(new AdditionArray<ulong>(leftArray, rightArray), solidify),
                ArrayValueType.Half => Construct(new AdditionArray<Half>(leftArray, rightArray), solidify),
                ArrayValueType.Single => Construct(new AdditionArray<float>(leftArray, rightArray), solidify),
                ArrayValueType.Double => Construct(new AdditionArray<double>(leftArray, rightArray), solidify),
                ArrayValueType.Decimal => Construct(new AdditionArray<decimal>(leftArray, rightArray), solidify),
                _ => throw new NotSupportedException($"Absolute value is not supported for {leftArray.ValueType}"),
            };
        }
        public static INumericArray<T> Add<T>(this INumericArray leftArray, INumericArray rightArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new AdditionArray<T>(leftArray, rightArray), solidify);
        }
        public static INumericArray<T> Add<T>(this INumericArray<T> leftArray, INumericArray rightArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new AdditionArray<T>(leftArray, rightArray), solidify);
        }
        #endregion

        #region SubtractionArray (Subtract)
        public static INumericArray Subtract(this INumericArray leftArray, INumericArray rightArray, bool? solidify = null) {
            if (leftArray == null)
            {
                throw new ArgumentNullException(nameof(leftArray));
            }

            return leftArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new SubtractionArray<bool>(leftArray, rightArray), solidify),
                ArrayValueType.SByte => Construct(new SubtractionArray<sbyte>(leftArray, rightArray), solidify),
                ArrayValueType.Byte => Construct(new SubtractionArray<byte>(leftArray, rightArray), solidify),
                ArrayValueType.Int16 => Construct(new SubtractionArray<short>(leftArray, rightArray), solidify),
                ArrayValueType.UInt16 => Construct(new SubtractionArray<ushort>(leftArray, rightArray), solidify),
                ArrayValueType.Int32 => Construct(new SubtractionArray<int>(leftArray, rightArray), solidify),
                ArrayValueType.UInt32 => Construct(new SubtractionArray<uint>(leftArray, rightArray), solidify),
                ArrayValueType.Int64 => Construct(new SubtractionArray<long>(leftArray, rightArray), solidify),
                ArrayValueType.UInt64 => Construct(new SubtractionArray<ulong>(leftArray, rightArray), solidify),
                ArrayValueType.Half => Construct(new SubtractionArray<Half>(leftArray, rightArray), solidify),
                ArrayValueType.Single => Construct(new SubtractionArray<float>(leftArray, rightArray), solidify),
                ArrayValueType.Double => Construct(new SubtractionArray<double>(leftArray, rightArray), solidify),
                ArrayValueType.Decimal => Construct(new SubtractionArray<decimal>(leftArray, rightArray), solidify),
                _ => throw new NotSupportedException($"Unsupported value type: {leftArray.ValueType}"),
            };
        }
        public static INumericArray<T> Subtract<T>(this INumericArray leftArray, INumericArray rightArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new SubtractionArray<T>(leftArray, rightArray), solidify);
        }
        public static INumericArray<T> Subtract<T>(this INumericArray<T> leftArray, INumericArray rightArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new SubtractionArray<T>(leftArray, rightArray), solidify);
        }
        #endregion

        #region MultiplicationArray (Multiply)
        public static INumericArray Multiply(this INumericArray leftArray, INumericArray rightArray, bool? solidify = null) {
            if (leftArray == null)
            {
                throw new ArgumentNullException(nameof(leftArray));
            }

            return leftArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new MultiplicationArray<bool>(leftArray, rightArray), solidify),
                ArrayValueType.SByte => Construct(new MultiplicationArray<sbyte>(leftArray, rightArray), solidify),
                ArrayValueType.Byte => Construct(new MultiplicationArray<byte>(leftArray, rightArray), solidify),
                ArrayValueType.Int16 => Construct(new MultiplicationArray<short>(leftArray, rightArray), solidify),
                ArrayValueType.UInt16 => Construct(new MultiplicationArray<ushort>(leftArray, rightArray), solidify),
                ArrayValueType.Int32 => Construct(new MultiplicationArray<int>(leftArray, rightArray), solidify),
                ArrayValueType.UInt32 => Construct(new MultiplicationArray<uint>(leftArray, rightArray), solidify),
                ArrayValueType.Int64 => Construct(new MultiplicationArray<long>(leftArray, rightArray), solidify),
                ArrayValueType.UInt64 => Construct(new MultiplicationArray<ulong>(leftArray, rightArray), solidify),
                ArrayValueType.Half => Construct(new MultiplicationArray<Half>(leftArray, rightArray), solidify),
                ArrayValueType.Single => Construct(new MultiplicationArray<float>(leftArray, rightArray), solidify),
                ArrayValueType.Double => Construct(new MultiplicationArray<double>(leftArray, rightArray), solidify),
                ArrayValueType.Decimal => Construct(new MultiplicationArray<decimal>(leftArray, rightArray), solidify),
                _ => throw new NotSupportedException($"Unsupported value type: {leftArray.ValueType}"),
            };
        }
        public static INumericArray<T> Multiply<T>(this INumericArray leftArray, INumericArray rightArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MultiplicationArray<T>(leftArray, rightArray), solidify);
        }
        public static INumericArray<T> Multiply<T>(this INumericArray<T> leftArray, INumericArray rightArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MultiplicationArray<T>(leftArray, rightArray), solidify);
        }
        #endregion

        #region DivisionArray (Divide)
        public static INumericArray Divide(this INumericArray leftArray, INumericArray rightArray, bool? solidify = null) {
            if (leftArray == null)
            {
                throw new ArgumentNullException(nameof(leftArray));
            }

            return leftArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new DivisionArray<bool>(leftArray, rightArray), solidify),
                ArrayValueType.SByte => Construct(new DivisionArray<sbyte>(leftArray, rightArray), solidify),
                ArrayValueType.Byte => Construct(new DivisionArray<byte>(leftArray, rightArray), solidify),
                ArrayValueType.Int16 => Construct(new DivisionArray<short>(leftArray, rightArray), solidify),
                ArrayValueType.UInt16 => Construct(new DivisionArray<ushort>(leftArray, rightArray), solidify),
                ArrayValueType.Int32 => Construct(new DivisionArray<int>(leftArray, rightArray), solidify),
                ArrayValueType.UInt32 => Construct(new DivisionArray<uint>(leftArray, rightArray), solidify),
                ArrayValueType.Int64 => Construct(new DivisionArray<long>(leftArray, rightArray), solidify),
                ArrayValueType.UInt64 => Construct(new DivisionArray<ulong>(leftArray, rightArray), solidify),
                ArrayValueType.Half => Construct(new DivisionArray<Half>(leftArray, rightArray), solidify),
                ArrayValueType.Single => Construct(new DivisionArray<float>(leftArray, rightArray), solidify),
                ArrayValueType.Double => Construct(new DivisionArray<double>(leftArray, rightArray), solidify),
                ArrayValueType.Decimal => Construct(new DivisionArray<decimal>(leftArray, rightArray), solidify),
                _ => throw new NotSupportedException($"Unsupported value type: {leftArray.ValueType}"),
            };
        }
        public static INumericArray<T> Divide<T>(this INumericArray leftArray, INumericArray rightArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new DivisionArray<T>(leftArray, rightArray), solidify);
        }
        public static INumericArray<T> Divide<T>(this INumericArray<T> leftArray, INumericArray rightArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new DivisionArray<T>(leftArray, rightArray), solidify);
        }
        #endregion

        #region ModuloArray (Mod)
        public static INumericArray Mod(this INumericArray leftArray, INumericArray rightArray, bool? solidify = null) {
            if (leftArray == null)
            {
                throw new ArgumentNullException(nameof(leftArray));
            }

            return leftArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new ModuloArray<bool>(leftArray, rightArray), solidify),
                ArrayValueType.SByte => Construct(new ModuloArray<sbyte>(leftArray, rightArray), solidify),
                ArrayValueType.Byte => Construct(new ModuloArray<byte>(leftArray, rightArray), solidify),
                ArrayValueType.Int16 => Construct(new ModuloArray<short>(leftArray, rightArray), solidify),
                ArrayValueType.UInt16 => Construct(new ModuloArray<ushort>(leftArray, rightArray), solidify),
                ArrayValueType.Int32 => Construct(new ModuloArray<int>(leftArray, rightArray), solidify),
                ArrayValueType.UInt32 => Construct(new ModuloArray<uint>(leftArray, rightArray), solidify),
                ArrayValueType.Int64 => Construct(new ModuloArray<long>(leftArray, rightArray), solidify),
                ArrayValueType.UInt64 => Construct(new ModuloArray<ulong>(leftArray, rightArray), solidify),
                ArrayValueType.Half => Construct(new ModuloArray<Half>(leftArray, rightArray), solidify),
                ArrayValueType.Single => Construct(new ModuloArray<float>(leftArray, rightArray), solidify),
                ArrayValueType.Double => Construct(new ModuloArray<double>(leftArray, rightArray), solidify),
                ArrayValueType.Decimal => Construct(new ModuloArray<decimal>(leftArray, rightArray), solidify),
                _ => throw new NotSupportedException($"Unsupported value type: {leftArray.ValueType}"),
            };
        }
        public static INumericArray<T> Mod<T>(this INumericArray leftArray, INumericArray rightArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new ModuloArray<T>(leftArray, rightArray), solidify);
        }
        public static INumericArray<T> Mod<T>(this INumericArray<T> leftArray, INumericArray rightArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new ModuloArray<T>(leftArray, rightArray), solidify);
        }
        #endregion

        #region PowerArray (Pow)
        public static INumericArray Pow(this INumericArray leftArray, INumericArray rightArray, bool? solidify = null) {
            if (leftArray == null)
            {
                throw new ArgumentNullException(nameof(leftArray));
            }

            return leftArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new PowerArray<bool>(leftArray, rightArray), solidify),
                ArrayValueType.SByte => Construct(new PowerArray<sbyte>(leftArray, rightArray), solidify),
                ArrayValueType.Byte => Construct(new PowerArray<byte>(leftArray, rightArray), solidify),
                ArrayValueType.Int16 => Construct(new PowerArray<short>(leftArray, rightArray), solidify),
                ArrayValueType.UInt16 => Construct(new PowerArray<ushort>(leftArray, rightArray), solidify),
                ArrayValueType.Int32 => Construct(new PowerArray<int>(leftArray, rightArray), solidify),
                ArrayValueType.UInt32 => Construct(new PowerArray<uint>(leftArray, rightArray), solidify),
                ArrayValueType.Int64 => Construct(new PowerArray<long>(leftArray, rightArray), solidify),
                ArrayValueType.UInt64 => Construct(new PowerArray<ulong>(leftArray, rightArray), solidify),
                ArrayValueType.Half => Construct(new PowerArray<Half>(leftArray, rightArray), solidify),
                ArrayValueType.Single => Construct(new PowerArray<float>(leftArray, rightArray), solidify),
                ArrayValueType.Double => Construct(new PowerArray<double>(leftArray, rightArray), solidify),
                ArrayValueType.Decimal => Construct(new PowerArray<decimal>(leftArray, rightArray), solidify),
                _ => throw new NotSupportedException($"Unsupported value type: {leftArray.ValueType}"),
            };
        }
        public static INumericArray<T> Pow<T>(this INumericArray leftArray, INumericArray rightArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new PowerArray<T>(leftArray, rightArray), solidify);
        }
        public static INumericArray<T> Pow<T>(this INumericArray<T> leftArray, INumericArray rightArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new PowerArray<T>(leftArray, rightArray), solidify);
        }
        #endregion

        #region LogarithmArray (Log)
        public static INumericArray Log(this INumericArray leftArray, INumericArray rightArray, bool? solidify = null) {
            if (leftArray == null)
            {
                throw new ArgumentNullException(nameof(leftArray));
            }

            return leftArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new LogarithmArray<bool>(leftArray, rightArray), solidify),
                ArrayValueType.SByte => Construct(new LogarithmArray<sbyte>(leftArray, rightArray), solidify),
                ArrayValueType.Byte => Construct(new LogarithmArray<byte>(leftArray, rightArray), solidify),
                ArrayValueType.Int16 => Construct(new LogarithmArray<short>(leftArray, rightArray), solidify),
                ArrayValueType.UInt16 => Construct(new LogarithmArray<ushort>(leftArray, rightArray), solidify),
                ArrayValueType.Int32 => Construct(new LogarithmArray<int>(leftArray, rightArray), solidify),
                ArrayValueType.UInt32 => Construct(new LogarithmArray<uint>(leftArray, rightArray), solidify),
                ArrayValueType.Int64 => Construct(new LogarithmArray<long>(leftArray, rightArray), solidify),
                ArrayValueType.UInt64 => Construct(new LogarithmArray<ulong>(leftArray, rightArray), solidify),
                ArrayValueType.Half => Construct(new LogarithmArray<Half>(leftArray, rightArray), solidify),
                ArrayValueType.Single => Construct(new LogarithmArray<float>(leftArray, rightArray), solidify),
                ArrayValueType.Double => Construct(new LogarithmArray<double>(leftArray, rightArray), solidify),
                ArrayValueType.Decimal => Construct(new LogarithmArray<decimal>(leftArray, rightArray), solidify),
                _ => throw new NotSupportedException($"Unsupported value type: {leftArray.ValueType}"),
            };
        }
        public static INumericArray<T> Log<T>(this INumericArray leftArray, INumericArray rightArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new LogarithmArray<T>(leftArray, rightArray), solidify);
        }
        public static INumericArray<T> Log<T>(this INumericArray<T> leftArray, INumericArray rightArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new LogarithmArray<T>(leftArray, rightArray), solidify);
        }
        #endregion
    }
}