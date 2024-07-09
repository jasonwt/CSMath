namespace NumericArrays {
    using System;
    using System.Linq;

    using NumericArrays.Types;
    using NumericArrays.Virtual.Transformations;

    public static partial class NA {
        #region AsType Extensions
        public static INumericArray<T> AsType<T>(this INumericArray thisArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new AsTypeArray<T>(thisArray), solidify);
        }
        #endregion

        #region Broadcast Extensions
        public static INumericArray Broadcast(this INumericArray thisArray, int[] shape, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new BroadcastingArray<bool>(thisArray, shape), solidify),
                ArrayValueType.SByte => Construct(new BroadcastingArray<sbyte>(thisArray, shape), solidify),
                ArrayValueType.Byte => Construct(new BroadcastingArray<byte>(thisArray, shape), solidify),
                ArrayValueType.Int16 => Construct(new BroadcastingArray<short>(thisArray, shape), solidify),
                ArrayValueType.UInt16 => Construct(new BroadcastingArray<ushort>(thisArray, shape), solidify),
                ArrayValueType.Int32 => Construct(new BroadcastingArray<int>(thisArray, shape), solidify),
                ArrayValueType.UInt32 => Construct(new BroadcastingArray<uint>(thisArray, shape), solidify),
                ArrayValueType.Int64 => Construct(new BroadcastingArray<long>(thisArray, shape), solidify),
                ArrayValueType.UInt64 => Construct(new BroadcastingArray<ulong>(thisArray, shape), solidify),
                ArrayValueType.Half => Construct(new BroadcastingArray<Half>(thisArray, shape), solidify),
                ArrayValueType.Single => Construct(new BroadcastingArray<float>(thisArray, shape), solidify),
                ArrayValueType.Double => Construct(new BroadcastingArray<double>(thisArray, shape), solidify),
                ArrayValueType.Decimal => Construct(new BroadcastingArray<decimal>(thisArray, shape), solidify),
                _ => throw new NotSupportedException($"Broadcasting is not supported for {thisArray.ValueType}"),
            };
        }
        public static INumericArray<T> Broadcast<T>(this INumericArray<T> thisArray, int[] shape, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new BroadcastingArray<T>(thisArray, shape), solidify);
        }
        #endregion

        #region Slice Extensions
        public static INumericArray Slice(this INumericArray thisArray, string slicingString, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new SlicingArray<bool>(thisArray, slicingString), solidify),
                ArrayValueType.SByte => Construct(new SlicingArray<sbyte>(thisArray, slicingString), solidify),
                ArrayValueType.Byte => Construct(new SlicingArray<byte>(thisArray, slicingString), solidify),
                ArrayValueType.Int16 => Construct(new SlicingArray<short>(thisArray, slicingString), solidify),
                ArrayValueType.UInt16 => Construct(new SlicingArray<ushort>(thisArray, slicingString), solidify),
                ArrayValueType.Int32 => Construct(new SlicingArray<int>(thisArray, slicingString), solidify),
                ArrayValueType.UInt32 => Construct(new SlicingArray<uint>(thisArray, slicingString), solidify),
                ArrayValueType.Int64 => Construct(new SlicingArray<long>(thisArray, slicingString), solidify),
                ArrayValueType.UInt64 => Construct(new SlicingArray<ulong>(thisArray, slicingString), solidify),
                ArrayValueType.Half => Construct(new SlicingArray<Half>(thisArray, slicingString), solidify),
                ArrayValueType.Single => Construct(new SlicingArray<float>(thisArray, slicingString), solidify),
                ArrayValueType.Double => Construct(new SlicingArray<double>(thisArray, slicingString), solidify),
                ArrayValueType.Decimal => Construct(new SlicingArray<decimal>(thisArray, slicingString), solidify),
                _ => throw new NotSupportedException($"Slicing is not supported for {thisArray.ValueType}"),
            };
        }
        public static INumericArray<T> Slice<T>(this INumericArray<T> thisArray, string slicingString, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new SlicingArray<T>(thisArray, slicingString), solidify);
        }
        #endregion

        #region Transpose Extensions
        public static INumericArray Transpose(this INumericArray thisArray, int[] axes, bool? solidify = null) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            return thisArray.ValueType switch
            {
                ArrayValueType.Boolean => Construct(new TransposingArray<bool>(thisArray, axes), solidify),
                ArrayValueType.SByte => Construct(new TransposingArray<sbyte>(thisArray, axes), solidify),
                ArrayValueType.Byte => Construct(new TransposingArray<byte>(thisArray, axes), solidify),
                ArrayValueType.Int16 => Construct(new TransposingArray<short>(thisArray, axes), solidify),
                ArrayValueType.UInt16 => Construct(new TransposingArray<ushort>(thisArray, axes), solidify),
                ArrayValueType.Int32 => Construct(new TransposingArray<int>(thisArray, axes), solidify),
                ArrayValueType.UInt32 => Construct(new TransposingArray<uint>(thisArray, axes), solidify),
                ArrayValueType.Int64 => Construct(new TransposingArray<long>(thisArray, axes), solidify),
                ArrayValueType.UInt64 => Construct(new TransposingArray<ulong>(thisArray, axes), solidify),
                ArrayValueType.Half => Construct(new TransposingArray<Half>(thisArray, axes), solidify),
                ArrayValueType.Single => Construct(new TransposingArray<float>(thisArray, axes), solidify),
                ArrayValueType.Double => Construct(new TransposingArray<double>(thisArray, axes), solidify),
                ArrayValueType.Decimal => Construct(new TransposingArray<decimal>(thisArray, axes), solidify),
                _ => throw new NotSupportedException($"Transposing is not supported for {thisArray.ValueType}")
            };
        }
        public static INumericArray<T> Transpose<T>(this INumericArray<T> thisArray, int[] axes, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct(new TransposingArray<T>(thisArray, axes), solidify);
        }

        #endregion

        #region SwapAxes Extensions
        public static INumericArray SwapAxes(this INumericArray sourceArray, int axis1, int axis2, bool? solidify = null) {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            if (axis1 < 0 || axis1 >= sourceArray.Rank)
            {
                throw new ArgumentOutOfRangeException(nameof(axis1));
            }

            if (axis2 < 0 || axis2 >= sourceArray.Rank)
            {
                throw new ArgumentOutOfRangeException(nameof(axis2));
            }

            int[] axisIndices = Enumerable.Range(0, sourceArray.Rank).ToArray();
            axisIndices[axis1] = axis2;
            axisIndices[axis2] = axis1;

            return Transpose(sourceArray, axisIndices, solidify);
        }
        public static INumericArray<T> SwapAxes<T>(this INumericArray<T> sourceArray, int axis1, int axis2, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            if (axis1 < 0 || axis1 >= sourceArray.Rank)
            {
                throw new ArgumentOutOfRangeException(nameof(axis1));
            }

            if (axis2 < 0 || axis2 >= sourceArray.Rank)
            {
                throw new ArgumentOutOfRangeException(nameof(axis2));
            }

            int[] axisIndices = Enumerable.Range(0, sourceArray.Rank).ToArray();
            axisIndices[axis1] = axis2;
            axisIndices[axis2] = axis1;

            return Transpose(sourceArray, axisIndices, solidify);
        }
        #endregion
    }
}