namespace NumericArrays {
    using System;

    using NumericArrays.Types;
    using NumericArrays.Virtual.Reductions;

    public static partial class NA {
        #region MinArray (Min)
        public static double Min(this INumericArray thisArray, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Convert.ToDouble(Construct(new MinArray<bool>(thisArray, null), solidify)[0]),
                ArrayValueType.SByte => Convert.ToDouble(Construct(new MinArray<sbyte>(thisArray, null), solidify)[0]),
                ArrayValueType.Byte => Convert.ToDouble(Construct(new MinArray<byte>(thisArray, null), solidify)[0]),
                ArrayValueType.Int16 => Convert.ToDouble(Construct(new MinArray<short>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt16 => Convert.ToDouble(Construct(new MinArray<ushort>(thisArray, null), solidify)[0]),
                ArrayValueType.Int32 => Convert.ToDouble(Construct(new MinArray<int>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt32 => Convert.ToDouble(Construct(new MinArray<uint>(thisArray, null), solidify)[0]),
                ArrayValueType.Int64 => Convert.ToDouble(Construct(new MinArray<long>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt64 => Convert.ToDouble(Construct(new MinArray<ulong>(thisArray, null), solidify)[0]),
                ArrayValueType.Half => Convert.ToDouble(Construct(new MinArray<Half>(thisArray, null), solidify)[0]),
                ArrayValueType.Single => Convert.ToDouble(Construct(new MinArray<float>(thisArray, null), solidify)[0]),
                ArrayValueType.Double => Convert.ToDouble(Construct(new MinArray<double>(thisArray, null), solidify)[0]),
                ArrayValueType.Decimal => Convert.ToDouble(Construct(new MinArray<decimal>(thisArray, null), solidify)[0]),
                _ => throw new NotSupportedException($"Min() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static INumericArray Min(this INumericArray thisArray, int axis, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new MinArray<bool>(thisArray, axis), solidify),
                ArrayValueType.SByte => Construct(new MinArray<sbyte>(thisArray, axis), solidify),
                ArrayValueType.Byte => Construct(new MinArray<byte>(thisArray, axis), solidify),
                ArrayValueType.Int16 => Construct(new MinArray<short>(thisArray, axis), solidify),
                ArrayValueType.UInt16 => Construct(new MinArray<ushort>(thisArray, axis), solidify),
                ArrayValueType.Int32 => Construct(new MinArray<int>(thisArray, axis), solidify),
                ArrayValueType.UInt32 => Construct(new MinArray<uint>(thisArray, axis), solidify),
                ArrayValueType.Int64 => Construct(new MinArray<long>(thisArray, axis), solidify),
                ArrayValueType.UInt64 => Construct(new MinArray<ulong>(thisArray, axis), solidify),
                ArrayValueType.Half => Construct(new MinArray<Half>(thisArray, axis), solidify),
                ArrayValueType.Single => Construct(new MinArray<float>(thisArray, axis), solidify),
                ArrayValueType.Double => Construct(new MinArray<double>(thisArray, axis), solidify),
                ArrayValueType.Decimal => Construct(new MinArray<decimal>(thisArray, axis), solidify),
                _ => throw new NotSupportedException($"Min() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static T Min<T>(this INumericArray thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MinArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Min<T>(this INumericArray thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MinArray<T>(thisArray, axis), solidify);
        }
        public static T Min<T>(this INumericArray<T> thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MinArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Min<T>(this INumericArray<T> thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MinArray<T>(thisArray, axis), solidify);
        }
        #endregion

        #region MaxArray (Max)
        public static double Max(this INumericArray thisArray, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Convert.ToDouble(Construct(new MaxArray<bool>(thisArray, null), solidify)[0]),
                ArrayValueType.SByte => Convert.ToDouble(Construct(new MaxArray<sbyte>(thisArray, null), solidify)[0]),
                ArrayValueType.Byte => Convert.ToDouble(Construct(new MaxArray<byte>(thisArray, null), solidify)[0]),
                ArrayValueType.Int16 => Convert.ToDouble(Construct(new MaxArray<short>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt16 => Convert.ToDouble(Construct(new MaxArray<ushort>(thisArray, null), solidify)[0]),
                ArrayValueType.Int32 => Convert.ToDouble(Construct(new MaxArray<int>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt32 => Convert.ToDouble(Construct(new MaxArray<uint>(thisArray, null), solidify)[0]),
                ArrayValueType.Int64 => Convert.ToDouble(Construct(new MaxArray<long>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt64 => Convert.ToDouble(Construct(new MaxArray<ulong>(thisArray, null), solidify)[0]),
                ArrayValueType.Half => Convert.ToDouble(Construct(new MaxArray<Half>(thisArray, null), solidify)[0]),
                ArrayValueType.Single => Convert.ToDouble(Construct(new MaxArray<float>(thisArray, null), solidify)[0]),
                ArrayValueType.Double => Convert.ToDouble(Construct(new MaxArray<double>(thisArray, null), solidify)[0]),
                ArrayValueType.Decimal => Convert.ToDouble(Construct(new MaxArray<decimal>(thisArray, null), solidify)[0]),
                _ => throw new NotSupportedException($"Max() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static INumericArray Max(this INumericArray thisArray, int axis, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new MaxArray<bool>(thisArray, axis), solidify),
                ArrayValueType.SByte => Construct(new MaxArray<sbyte>(thisArray, axis), solidify),
                ArrayValueType.Byte => Construct(new MaxArray<byte>(thisArray, axis), solidify),
                ArrayValueType.Int16 => Construct(new MaxArray<short>(thisArray, axis), solidify),
                ArrayValueType.UInt16 => Construct(new MaxArray<ushort>(thisArray, axis), solidify),
                ArrayValueType.Int32 => Construct(new MaxArray<int>(thisArray, axis), solidify),
                ArrayValueType.UInt32 => Construct(new MaxArray<uint>(thisArray, axis), solidify),
                ArrayValueType.Int64 => Construct(new MaxArray<long>(thisArray, axis), solidify),
                ArrayValueType.UInt64 => Construct(new MaxArray<ulong>(thisArray, axis), solidify),
                ArrayValueType.Half => Construct(new MaxArray<Half>(thisArray, axis), solidify),
                ArrayValueType.Single => Construct(new MaxArray<float>(thisArray, axis), solidify),
                ArrayValueType.Double => Construct(new MaxArray<double>(thisArray, axis), solidify),
                ArrayValueType.Decimal => Construct(new MaxArray<decimal>(thisArray, axis), solidify),
                _ => throw new NotSupportedException($"Max() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static T Max<T>(this INumericArray thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MaxArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Max<T>(this INumericArray thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MaxArray<T>(thisArray, axis), solidify);
        }
        public static T Max<T>(this INumericArray<T> thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MaxArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Max<T>(this INumericArray<T> thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MaxArray<T>(thisArray, axis), solidify);
        }
        #endregion

        #region MeanArray (Mean)
        public static double Mean(this INumericArray thisArray, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Convert.ToDouble(Construct(new MeanArray<bool>(thisArray, null), solidify)[0]),
                ArrayValueType.SByte => Convert.ToDouble(Construct(new MeanArray<sbyte>(thisArray, null), solidify)[0]),
                ArrayValueType.Byte => Convert.ToDouble(Construct(new MeanArray<byte>(thisArray, null), solidify)[0]),
                ArrayValueType.Int16 => Convert.ToDouble(Construct(new MeanArray<short>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt16 => Convert.ToDouble(Construct(new MeanArray<ushort>(thisArray, null), solidify)[0]),
                ArrayValueType.Int32 => Convert.ToDouble(Construct(new MeanArray<int>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt32 => Convert.ToDouble(Construct(new MeanArray<uint>(thisArray, null), solidify)[0]),
                ArrayValueType.Int64 => Convert.ToDouble(Construct(new MeanArray<long>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt64 => Convert.ToDouble(Construct(new MeanArray<ulong>(thisArray, null), solidify)[0]),
                ArrayValueType.Half => Convert.ToDouble(Construct(new MeanArray<Half>(thisArray, null), solidify)[0]),
                ArrayValueType.Single => Convert.ToDouble(Construct(new MeanArray<float>(thisArray, null), solidify)[0]),
                ArrayValueType.Double => Convert.ToDouble(Construct(new MeanArray<double>(thisArray, null), solidify)[0]),
                ArrayValueType.Decimal => Convert.ToDouble(Construct(new MeanArray<decimal>(thisArray, null), solidify)[0]),
                _ => throw new NotSupportedException($"Mean() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static INumericArray Mean(this INumericArray thisArray, int axis, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new MeanArray<bool>(thisArray, axis), solidify),
                ArrayValueType.SByte => Construct(new MeanArray<sbyte>(thisArray, axis), solidify),
                ArrayValueType.Byte => Construct(new MeanArray<byte>(thisArray, axis), solidify),
                ArrayValueType.Int16 => Construct(new MeanArray<short>(thisArray, axis), solidify),
                ArrayValueType.UInt16 => Construct(new MeanArray<ushort>(thisArray, axis), solidify),
                ArrayValueType.Int32 => Construct(new MeanArray<int>(thisArray, axis), solidify),
                ArrayValueType.UInt32 => Construct(new MeanArray<uint>(thisArray, axis), solidify),
                ArrayValueType.Int64 => Construct(new MeanArray<long>(thisArray, axis), solidify),
                ArrayValueType.UInt64 => Construct(new MeanArray<ulong>(thisArray, axis), solidify),
                ArrayValueType.Half => Construct(new MeanArray<Half>(thisArray, axis), solidify),
                ArrayValueType.Single => Construct(new MeanArray<float>(thisArray, axis), solidify),
                ArrayValueType.Double => Construct(new MeanArray<double>(thisArray, axis), solidify),
                ArrayValueType.Decimal => Construct(new MeanArray<decimal>(thisArray, axis), solidify),
                _ => throw new NotSupportedException($"Mean() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static T Mean<T>(this INumericArray thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MeanArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Mean<T>(this INumericArray thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MeanArray<T>(thisArray, axis), solidify);
        }
        public static T Mean<T>(this INumericArray<T> thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MeanArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Mean<T>(this INumericArray<T> thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MeanArray<T>(thisArray, axis), solidify);
        }
        #endregion

        #region MedianArray (Median)
        public static double Median(this INumericArray thisArray, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Convert.ToDouble(Construct(new MedianArray<bool>(thisArray, null), solidify)[0]),
                ArrayValueType.SByte => Convert.ToDouble(Construct(new MedianArray<sbyte>(thisArray, null), solidify)[0]),
                ArrayValueType.Byte => Convert.ToDouble(Construct(new MedianArray<byte>(thisArray, null), solidify)[0]),
                ArrayValueType.Int16 => Convert.ToDouble(Construct(new MedianArray<short>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt16 => Convert.ToDouble(Construct(new MedianArray<ushort>(thisArray, null), solidify)[0]),
                ArrayValueType.Int32 => Convert.ToDouble(Construct(new MedianArray<int>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt32 => Convert.ToDouble(Construct(new MedianArray<uint>(thisArray, null), solidify)[0]),
                ArrayValueType.Int64 => Convert.ToDouble(Construct(new MedianArray<long>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt64 => Convert.ToDouble(Construct(new MedianArray<ulong>(thisArray, null), solidify)[0]),
                ArrayValueType.Half => Convert.ToDouble(Construct(new MedianArray<Half>(thisArray, null), solidify)[0]),
                ArrayValueType.Single => Convert.ToDouble(Construct(new MedianArray<float>(thisArray, null), solidify)[0]),
                ArrayValueType.Double => Convert.ToDouble(Construct(new MedianArray<double>(thisArray, null), solidify)[0]),
                ArrayValueType.Decimal => Convert.ToDouble(Construct(new MedianArray<decimal>(thisArray, null), solidify)[0]),
                _ => throw new NotSupportedException($"Median() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static INumericArray Median(this INumericArray thisArray, int axis, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new MedianArray<bool>(thisArray, axis), solidify),
                ArrayValueType.SByte => Construct(new MedianArray<sbyte>(thisArray, axis), solidify),
                ArrayValueType.Byte => Construct(new MedianArray<byte>(thisArray, axis), solidify),
                ArrayValueType.Int16 => Construct(new MedianArray<short>(thisArray, axis), solidify),
                ArrayValueType.UInt16 => Construct(new MedianArray<ushort>(thisArray, axis), solidify),
                ArrayValueType.Int32 => Construct(new MedianArray<int>(thisArray, axis), solidify),
                ArrayValueType.UInt32 => Construct(new MedianArray<uint>(thisArray, axis), solidify),
                ArrayValueType.Int64 => Construct(new MedianArray<long>(thisArray, axis), solidify),
                ArrayValueType.UInt64 => Construct(new MedianArray<ulong>(thisArray, axis), solidify),
                ArrayValueType.Half => Construct(new MedianArray<Half>(thisArray, axis), solidify),
                ArrayValueType.Single => Construct(new MedianArray<float>(thisArray, axis), solidify),
                ArrayValueType.Double => Construct(new MedianArray<double>(thisArray, axis), solidify),
                ArrayValueType.Decimal => Construct(new MedianArray<decimal>(thisArray, axis), solidify),
                _ => throw new NotSupportedException($"Median() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static T Median<T>(this INumericArray thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MedianArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Median<T>(this INumericArray thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MedianArray<T>(thisArray, axis), solidify);
        }
        public static T Median<T>(this INumericArray<T> thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MedianArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Median<T>(this INumericArray<T> thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new MedianArray<T>(thisArray, axis), solidify);
        }
        #endregion

        #region SumArray (Sum)
        public static double Sum(this INumericArray thisArray, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Convert.ToDouble(Construct(new SumArray<bool>(thisArray, null), solidify)[0]),
                ArrayValueType.SByte => Convert.ToDouble(Construct(new SumArray<sbyte>(thisArray, null), solidify)[0]),
                ArrayValueType.Byte => Convert.ToDouble(Construct(new SumArray<byte>(thisArray, null), solidify)[0]),
                ArrayValueType.Int16 => Convert.ToDouble(Construct(new SumArray<short>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt16 => Convert.ToDouble(Construct(new SumArray<ushort>(thisArray, null), solidify)[0]),
                ArrayValueType.Int32 => Convert.ToDouble(Construct(new SumArray<int>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt32 => Convert.ToDouble(Construct(new SumArray<uint>(thisArray, null), solidify)[0]),
                ArrayValueType.Int64 => Convert.ToDouble(Construct(new SumArray<long>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt64 => Convert.ToDouble(Construct(new SumArray<ulong>(thisArray, null), solidify)[0]),
                ArrayValueType.Half => Convert.ToDouble(Construct(new SumArray<Half>(thisArray, null), solidify)[0]),
                ArrayValueType.Single => Convert.ToDouble(Construct(new SumArray<float>(thisArray, null), solidify)[0]),
                ArrayValueType.Double => Convert.ToDouble(Construct(new SumArray<double>(thisArray, null), solidify)[0]),
                ArrayValueType.Decimal => Convert.ToDouble(Construct(new SumArray<decimal>(thisArray, null), solidify)[0]),
                _ => throw new NotSupportedException($"Sum() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static INumericArray Sum(this INumericArray thisArray, int axis, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new SumArray<bool>(thisArray, axis), solidify),
                ArrayValueType.SByte => Construct(new SumArray<sbyte>(thisArray, axis), solidify),
                ArrayValueType.Byte => Construct(new SumArray<byte>(thisArray, axis), solidify),
                ArrayValueType.Int16 => Construct(new SumArray<short>(thisArray, axis), solidify),
                ArrayValueType.UInt16 => Construct(new SumArray<ushort>(thisArray, axis), solidify),
                ArrayValueType.Int32 => Construct(new SumArray<int>(thisArray, axis), solidify),
                ArrayValueType.UInt32 => Construct(new SumArray<uint>(thisArray, axis), solidify),
                ArrayValueType.Int64 => Construct(new SumArray<long>(thisArray, axis), solidify),
                ArrayValueType.UInt64 => Construct(new SumArray<ulong>(thisArray, axis), solidify),
                ArrayValueType.Half => Construct(new SumArray<Half>(thisArray, axis), solidify),
                ArrayValueType.Single => Construct(new SumArray<float>(thisArray, axis), solidify),
                ArrayValueType.Double => Construct(new SumArray<double>(thisArray, axis), solidify),
                ArrayValueType.Decimal => Construct(new SumArray<decimal>(thisArray, axis), solidify),
                _ => throw new NotSupportedException($"Sum() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static T Sum<T>(this INumericArray thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new SumArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Sum<T>(this INumericArray thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new SumArray<T>(thisArray, axis), solidify);
        }
        public static T Sum<T>(this INumericArray<T> thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new SumArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Sum<T>(this INumericArray<T> thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new SumArray<T>(thisArray, axis), solidify);
        }
        #endregion

        #region ProductArray (Prod)
        public static double Prod(this INumericArray thisArray, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Convert.ToDouble(Construct(new ProductArray<bool>(thisArray, null), solidify)[0]),
                ArrayValueType.SByte => Convert.ToDouble(Construct(new ProductArray<sbyte>(thisArray, null), solidify)[0]),
                ArrayValueType.Byte => Convert.ToDouble(Construct(new ProductArray<byte>(thisArray, null), solidify)[0]),
                ArrayValueType.Int16 => Convert.ToDouble(Construct(new ProductArray<short>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt16 => Convert.ToDouble(Construct(new ProductArray<ushort>(thisArray, null), solidify)[0]),
                ArrayValueType.Int32 => Convert.ToDouble(Construct(new ProductArray<int>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt32 => Convert.ToDouble(Construct(new ProductArray<uint>(thisArray, null), solidify)[0]),
                ArrayValueType.Int64 => Convert.ToDouble(Construct(new ProductArray<long>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt64 => Convert.ToDouble(Construct(new ProductArray<ulong>(thisArray, null), solidify)[0]),
                ArrayValueType.Half => Convert.ToDouble(Construct(new ProductArray<Half>(thisArray, null), solidify)[0]),
                ArrayValueType.Single => Convert.ToDouble(Construct(new ProductArray<float>(thisArray, null), solidify)[0]),
                ArrayValueType.Double => Convert.ToDouble(Construct(new ProductArray<double>(thisArray, null), solidify)[0]),
                ArrayValueType.Decimal => Convert.ToDouble(Construct(new ProductArray<decimal>(thisArray, null), solidify)[0]),
                _ => throw new NotSupportedException($"Product() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static INumericArray Prod(this INumericArray thisArray, int axis, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new ProductArray<bool>(thisArray, axis), solidify),
                ArrayValueType.SByte => Construct(new ProductArray<sbyte>(thisArray, axis), solidify),
                ArrayValueType.Byte => Construct(new ProductArray<byte>(thisArray, axis), solidify),
                ArrayValueType.Int16 => Construct(new ProductArray<short>(thisArray, axis), solidify),
                ArrayValueType.UInt16 => Construct(new ProductArray<ushort>(thisArray, axis), solidify),
                ArrayValueType.Int32 => Construct(new ProductArray<int>(thisArray, axis), solidify),
                ArrayValueType.UInt32 => Construct(new ProductArray<uint>(thisArray, axis), solidify),
                ArrayValueType.Int64 => Construct(new ProductArray<long>(thisArray, axis), solidify),
                ArrayValueType.UInt64 => Construct(new ProductArray<ulong>(thisArray, axis), solidify),
                ArrayValueType.Half => Construct(new ProductArray<Half>(thisArray, axis), solidify),
                ArrayValueType.Single => Construct(new ProductArray<float>(thisArray, axis), solidify),
                ArrayValueType.Double => Construct(new ProductArray<double>(thisArray, axis), solidify),
                ArrayValueType.Decimal => Construct(new ProductArray<decimal>(thisArray, axis), solidify),
                _ => throw new NotSupportedException($"Product() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static T Prod<T>(this INumericArray thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new ProductArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Prod<T>(this INumericArray thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new ProductArray<T>(thisArray, axis), solidify);
        }
        public static T Prod<T>(this INumericArray<T> thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new ProductArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Prod<T>(this INumericArray<T> thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new ProductArray<T>(thisArray, axis), solidify);
        }
        #endregion

        #region StandardDeviationArray (Std)
        public static double Std(this INumericArray thisArray, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Convert.ToDouble(Construct(new StandardDeviationArray<bool>(thisArray, null), solidify)[0]),
                ArrayValueType.SByte => Convert.ToDouble(Construct(new StandardDeviationArray<sbyte>(thisArray, null), solidify)[0]),
                ArrayValueType.Byte => Convert.ToDouble(Construct(new StandardDeviationArray<byte>(thisArray, null), solidify)[0]),
                ArrayValueType.Int16 => Convert.ToDouble(Construct(new StandardDeviationArray<short>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt16 => Convert.ToDouble(Construct(new StandardDeviationArray<ushort>(thisArray, null), solidify)[0]),
                ArrayValueType.Int32 => Convert.ToDouble(Construct(new StandardDeviationArray<int>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt32 => Convert.ToDouble(Construct(new StandardDeviationArray<uint>(thisArray, null), solidify)[0]),
                ArrayValueType.Int64 => Convert.ToDouble(Construct(new StandardDeviationArray<long>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt64 => Convert.ToDouble(Construct(new StandardDeviationArray<ulong>(thisArray, null), solidify)[0]),
                ArrayValueType.Half => Convert.ToDouble(Construct(new StandardDeviationArray<Half>(thisArray, null), solidify)[0]),
                ArrayValueType.Single => Convert.ToDouble(Construct(new StandardDeviationArray<float>(thisArray, null), solidify)[0]),
                ArrayValueType.Double => Convert.ToDouble(Construct(new StandardDeviationArray<double>(thisArray, null), solidify)[0]),
                ArrayValueType.Decimal => Convert.ToDouble(Construct(new StandardDeviationArray<decimal>(thisArray, null), solidify)[0]),
                _ => throw new NotSupportedException($"Std() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static INumericArray Std(this INumericArray thisArray, int axis, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new StandardDeviationArray<bool>(thisArray, axis), solidify),
                ArrayValueType.SByte => Construct(new StandardDeviationArray<sbyte>(thisArray, axis), solidify),
                ArrayValueType.Byte => Construct(new StandardDeviationArray<byte>(thisArray, axis), solidify),
                ArrayValueType.Int16 => Construct(new StandardDeviationArray<short>(thisArray, axis), solidify),
                ArrayValueType.UInt16 => Construct(new StandardDeviationArray<ushort>(thisArray, axis), solidify),
                ArrayValueType.Int32 => Construct(new StandardDeviationArray<int>(thisArray, axis), solidify),
                ArrayValueType.UInt32 => Construct(new StandardDeviationArray<uint>(thisArray, axis), solidify),
                ArrayValueType.Int64 => Construct(new StandardDeviationArray<long>(thisArray, axis), solidify),
                ArrayValueType.UInt64 => Construct(new StandardDeviationArray<ulong>(thisArray, axis), solidify),
                ArrayValueType.Half => Construct(new StandardDeviationArray<Half>(thisArray, axis), solidify),
                ArrayValueType.Single => Construct(new StandardDeviationArray<float>(thisArray, axis), solidify),
                ArrayValueType.Double => Construct(new StandardDeviationArray<double>(thisArray, axis), solidify),
                ArrayValueType.Decimal => Construct(new StandardDeviationArray<decimal>(thisArray, axis), solidify),
                _ => throw new NotSupportedException($"Std() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static T Std<T>(this INumericArray thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new StandardDeviationArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Std<T>(this INumericArray thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new StandardDeviationArray<T>(thisArray, axis), solidify);
        }
        public static T Std<T>(this INumericArray<T> thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new StandardDeviationArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Std<T>(this INumericArray<T> thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new StandardDeviationArray<T>(thisArray, axis), solidify);
        }
        #endregion

        #region VarianceArray (Var)
        public static double Var(this INumericArray thisArray, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Convert.ToDouble(Construct(new VarianceArray<bool>(thisArray, null), solidify)[0]),
                ArrayValueType.SByte => Convert.ToDouble(Construct(new VarianceArray<sbyte>(thisArray, null), solidify)[0]),
                ArrayValueType.Byte => Convert.ToDouble(Construct(new VarianceArray<byte>(thisArray, null), solidify)[0]),
                ArrayValueType.Int16 => Convert.ToDouble(Construct(new VarianceArray<short>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt16 => Convert.ToDouble(Construct(new VarianceArray<ushort>(thisArray, null), solidify)[0]),
                ArrayValueType.Int32 => Convert.ToDouble(Construct(new VarianceArray<int>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt32 => Convert.ToDouble(Construct(new VarianceArray<uint>(thisArray, null), solidify)[0]),
                ArrayValueType.Int64 => Convert.ToDouble(Construct(new VarianceArray<long>(thisArray, null), solidify)[0]),
                ArrayValueType.UInt64 => Convert.ToDouble(Construct(new VarianceArray<ulong>(thisArray, null), solidify)[0]),
                ArrayValueType.Half => Convert.ToDouble(Construct(new VarianceArray<Half>(thisArray, null), solidify)[0]),
                ArrayValueType.Single => Convert.ToDouble(Construct(new VarianceArray<float>(thisArray, null), solidify)[0]),
                ArrayValueType.Double => Convert.ToDouble(Construct(new VarianceArray<double>(thisArray, null), solidify)[0]),
                ArrayValueType.Decimal => Convert.ToDouble(Construct(new VarianceArray<decimal>(thisArray, null), solidify)[0]),
                _ => throw new NotSupportedException($"Variance() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static INumericArray Var(this INumericArray thisArray, int axis, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new VarianceArray<bool>(thisArray, axis), solidify),
                ArrayValueType.SByte => Construct(new VarianceArray<sbyte>(thisArray, axis), solidify),
                ArrayValueType.Byte => Construct(new VarianceArray<byte>(thisArray, axis), solidify),
                ArrayValueType.Int16 => Construct(new VarianceArray<short>(thisArray, axis), solidify),
                ArrayValueType.UInt16 => Construct(new VarianceArray<ushort>(thisArray, axis), solidify),
                ArrayValueType.Int32 => Construct(new VarianceArray<int>(thisArray, axis), solidify),
                ArrayValueType.UInt32 => Construct(new VarianceArray<uint>(thisArray, axis), solidify),
                ArrayValueType.Int64 => Construct(new VarianceArray<long>(thisArray, axis), solidify),
                ArrayValueType.UInt64 => Construct(new VarianceArray<ulong>(thisArray, axis), solidify),
                ArrayValueType.Half => Construct(new VarianceArray<Half>(thisArray, axis), solidify),
                ArrayValueType.Single => Construct(new VarianceArray<float>(thisArray, axis), solidify),
                ArrayValueType.Double => Construct(new VarianceArray<double>(thisArray, axis), solidify),
                ArrayValueType.Decimal => Construct(new VarianceArray<decimal>(thisArray, axis), solidify),
                _ => throw new NotSupportedException($"Variance() is not supported for array type {thisArray.ValueType}"),
            };
        }
        public static T Var<T>(this INumericArray thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new VarianceArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Var<T>(this INumericArray thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new VarianceArray<T>(thisArray, axis), solidify);
        }
        public static T Var<T>(this INumericArray<T> thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new VarianceArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> Var<T>(this INumericArray<T> thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new VarianceArray<T>(thisArray, axis), solidify);
        }
        #endregion

        #region ArgMinArray (ArgMin)
        public static int ArgMin(this INumericArray thisArray, bool? solidify = null) {
            return Construct(new ArgMinArray<int>(thisArray, null), solidify)[0];
        }
        public static INumericArray ArgMin(this INumericArray thisArray, int axis, bool? solidify = null) {
            return Construct(new ArgMinArray<int>(thisArray, axis), solidify);
        }
        public static T ArgMin<T>(this INumericArray thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new ArgMinArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> ArgMin<T>(this INumericArray thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new ArgMinArray<T>(thisArray, axis), solidify);
        }
        public static T ArgMin<T>(this INumericArray<T> thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new ArgMinArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> ArgMin<T>(this INumericArray<T> thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new ArgMinArray<T>(thisArray, axis), solidify);
        }
        #endregion

        #region ArgMaxArray (ArgMax)
        public static int ArgMax(this INumericArray thisArray, bool? solidify = null) {
            return Construct(new ArgMaxArray<int>(thisArray, null), solidify)[0];
        }
        public static INumericArray ArgMax(this INumericArray thisArray, int axis, bool? solidify = null) {
            return Construct(new ArgMaxArray<int>(thisArray, axis), solidify);
        }
        public static T ArgMax<T>(this INumericArray thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new ArgMaxArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> ArgMax<T>(this INumericArray thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new ArgMaxArray<T>(thisArray, axis), solidify);
        }
        public static T ArgMax<T>(this INumericArray<T> thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new ArgMaxArray<T>(thisArray, null), solidify)[0];
        }
        public static INumericArray<T> ArgMax<T>(this INumericArray<T> thisArray, int axis, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new ArgMaxArray<T>(thisArray, axis), solidify);
        }
        #endregion
    }
}