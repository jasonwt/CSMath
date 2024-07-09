namespace NumericArrays {
    using System;
    
    using NumericArrays.Types;
    using NumericArrays.Virtual.Mathematics.Unary;

    public static partial class NA {
        #region AbsoluteValueArray (Abs)
        public static INumericArray Abs(this INumericArray thisArray, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new AbsoluteValueArray<bool>(thisArray), solidify),
                ArrayValueType.SByte => Construct(new AbsoluteValueArray<sbyte>(thisArray), solidify),
                ArrayValueType.Byte => Construct(new AbsoluteValueArray<byte>(thisArray), solidify),
                ArrayValueType.Int16 => Construct(new AbsoluteValueArray<short>(thisArray), solidify),
                ArrayValueType.UInt16 => Construct(new AbsoluteValueArray<ushort>(thisArray), solidify),
                ArrayValueType.Int32 => Construct(new AbsoluteValueArray<int>(thisArray), solidify),
                ArrayValueType.UInt32 => Construct(new AbsoluteValueArray<uint>(thisArray), solidify),
                ArrayValueType.Int64 => Construct(new AbsoluteValueArray<long>(thisArray), solidify),
                ArrayValueType.UInt64 => Construct(new AbsoluteValueArray<ulong>(thisArray), solidify),
                ArrayValueType.Half => Construct(new AbsoluteValueArray<Half>(thisArray), solidify),
                ArrayValueType.Single => Construct(new AbsoluteValueArray<float>(thisArray), solidify),
                ArrayValueType.Double => Construct(new AbsoluteValueArray<double>(thisArray), solidify),
                ArrayValueType.Decimal => Construct(new AbsoluteValueArray<decimal>(thisArray), solidify),
                _ => throw new NotSupportedException($"Absolute value is not supported for {thisArray.ValueType}"),
            };
        }
        public static INumericArray<T> Abs<T>(this INumericArray thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new AbsoluteValueArray<T>(thisArray), solidify);
        }
        public static INumericArray<T> Abs<T>(this INumericArray<T> thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new AbsoluteValueArray<T>(thisArray), solidify);
        }
        #endregion

        #region SquareRootArray (Sqrt)
        public static INumericArray Sqrt(this INumericArray thisArray, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new SquareRootArray<bool>(thisArray), solidify),
                ArrayValueType.SByte => Construct(new SquareRootArray<sbyte>(thisArray), solidify),
                ArrayValueType.Byte => Construct(new SquareRootArray<byte>(thisArray), solidify),
                ArrayValueType.Int16 => Construct(new SquareRootArray<short>(thisArray), solidify),
                ArrayValueType.UInt16 => Construct(new SquareRootArray<ushort>(thisArray), solidify),
                ArrayValueType.Int32 => Construct(new SquareRootArray<int>(thisArray), solidify),
                ArrayValueType.UInt32 => Construct(new SquareRootArray<uint>(thisArray), solidify),
                ArrayValueType.Int64 => Construct(new SquareRootArray<long>(thisArray), solidify),
                ArrayValueType.UInt64 => Construct(new SquareRootArray<ulong>(thisArray), solidify),
                ArrayValueType.Half => Construct(new SquareRootArray<Half>(thisArray), solidify),
                ArrayValueType.Single => Construct(new SquareRootArray<float>(thisArray), solidify),
                ArrayValueType.Double => Construct(new SquareRootArray<double>(thisArray), solidify),
                ArrayValueType.Decimal => Construct(new SquareRootArray<decimal>(thisArray), solidify),
                _ => throw new NotSupportedException($"Square root is not supported for {thisArray.ValueType}"),
            };
        }
        public static INumericArray<T> Sqrt<T>(this INumericArray thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new SquareRootArray<T>(thisArray), solidify);
        }
        public static INumericArray<T> Sqrt<T>(this INumericArray<T> thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new SquareRootArray<T>(thisArray), solidify);
        }
        #endregion

        #region NegationArray (Negate)
        public static INumericArray Negate(this INumericArray thisArray, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new NegationArray<bool>(thisArray), solidify),
                ArrayValueType.SByte => Construct(new NegationArray<sbyte>(thisArray), solidify),
                ArrayValueType.Byte => Construct(new NegationArray<byte>(thisArray), solidify),
                ArrayValueType.Int16 => Construct(new NegationArray<short>(thisArray), solidify),
                ArrayValueType.UInt16 => Construct(new NegationArray<ushort>(thisArray), solidify),
                ArrayValueType.Int32 => Construct(new NegationArray<int>(thisArray), solidify),
                ArrayValueType.UInt32 => Construct(new NegationArray<uint>(thisArray), solidify),
                ArrayValueType.Int64 => Construct(new NegationArray<long>(thisArray), solidify),
                ArrayValueType.UInt64 => Construct(new NegationArray<ulong>(thisArray), solidify),
                ArrayValueType.Half => Construct(new NegationArray<Half>(thisArray), solidify),
                ArrayValueType.Single => Construct(new NegationArray<float>(thisArray), solidify),
                ArrayValueType.Double => Construct(new NegationArray<double>(thisArray), solidify),
                ArrayValueType.Decimal => Construct(new NegationArray<decimal>(thisArray), solidify),
                _ => throw new NotSupportedException($"Negation is not supported for {thisArray.ValueType}"),
            };
        }
        public static INumericArray<T> Negate<T>(this INumericArray thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new NegationArray<T>(thisArray), solidify);
        }
        public static INumericArray<T> Negate<T>(this INumericArray<T> thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new NegationArray<T>(thisArray), solidify);
        }
        #endregion
    }
}