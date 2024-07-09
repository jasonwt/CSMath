namespace NumericArrays {
    using System;
    using System.Linq;

    using NumericArrays.Types;
    using NumericArrays.Virtual;
    using NumericArrays.Concrete;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    public static partial class NA {
        #region Construct Methods
        public static INumericArray<T> Construct<T>(IVirtualArray<T> virtualArray, bool? solidify = null)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            solidify ??= false;

            if (!solidify.Value)
            {
                return virtualArray;
            }

            return virtualArray.Solidify(new SystemArrayFactory());
        }

        public static IConcreteArray Construct(ArrayValueType type, int[] shape) {
            return type switch {
                ArrayValueType.Boolean => new SystemArray<bool>(shape),
                ArrayValueType.Byte => new SystemArray<byte>(shape),
                ArrayValueType.SByte => new SystemArray<sbyte>(shape),
                ArrayValueType.Int16 => new SystemArray<short>(shape),
                ArrayValueType.UInt16 => new SystemArray<ushort>(shape),
                ArrayValueType.Int32 => new SystemArray<int>(shape),
                ArrayValueType.UInt32 => new SystemArray<uint>(shape),
                ArrayValueType.Int64 => new SystemArray<long>(shape),
                ArrayValueType.UInt64 => new SystemArray<ulong>(shape),
                ArrayValueType.Half => new SystemArray<Half>(shape),
                ArrayValueType.Single => new SystemArray<float>(shape),
                ArrayValueType.Double => new SystemArray<double>(shape),
                ArrayValueType.Decimal => new SystemArray<decimal>(shape),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid NumericArrayValueType")
            };
        }
        public static IConcreteArray Construct(ArrayValueType type, int[] shape, IEnumerable<ValueType> enumerableValues) {
            IConcreteArray newArray = Construct(type, shape);

            newArray.Fill(enumerableValues.ToArray());

            return newArray;
        }

        public static IConcreteArray<T> Construct<T>(int[] shape)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return new SystemArray<T>(shape);
        }
        public static IConcreteArray<T> Construct<T>(int[] shape, IEnumerable<T> enumerableValues)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            IConcreteArray<T> newArray = Construct<T>(shape);

            newArray.Fill(enumerableValues.ToArray());

            return newArray;
        }
        
        #endregion

        #region Full Methods
        public static IConcreteArray<T> Full<T>(int[] shape, T value)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            IConcreteArray<T> newArray = Construct<T>(shape);

            newArray.Fill(value);

            return newArray;
        }
        public static IConcreteArray Full(ArrayValueType type, int[] shape, ValueType value) {
            return type switch {
                ArrayValueType.Boolean => Full<bool>(shape, Convert.ToBoolean(value)),
                ArrayValueType.Byte => Full<byte>(shape, Convert.ToByte(value)),
                ArrayValueType.SByte => Full<sbyte>(shape, Convert.ToSByte(value)),
                ArrayValueType.Int16 => Full<short>(shape, Convert.ToInt16(value)),
                ArrayValueType.UInt16 => Full<ushort>(shape, Convert.ToUInt16(value)),
                ArrayValueType.Int32 => Full<int>(shape, Convert.ToInt32(value)),
                ArrayValueType.UInt32 => Full<uint>(shape, Convert.ToUInt32(value)),
                ArrayValueType.Int64 => Full<long>(shape, Convert.ToInt64(value)),
                ArrayValueType.UInt64 => Full<ulong>(shape, Convert.ToUInt64(value)),
                //NumericArrayValueType.Half => Full<Half>(shape, Convert.ToSingle(value)),
                ArrayValueType.Single => Full<float>(shape, Convert.ToSingle(value)),
                ArrayValueType.Double => Full<double>(shape, Convert.ToDouble(value)),
                ArrayValueType.Decimal => Full<decimal>(shape, Convert.ToDecimal(value)),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid NumericArrayValueType")
            };
        }
        #endregion

        #region Zeros Methods
        public static IConcreteArray<T> Zeros<T>(int[] shape)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            return Construct<T>(shape);
        }
        public static IConcreteArray Zeros(ArrayValueType type, int[] shape) {
            return type switch {
                ArrayValueType.Boolean => Zeros<bool>(shape),
                ArrayValueType.Byte => Zeros<byte>(shape),
                ArrayValueType.SByte => Zeros<sbyte>(shape),
                ArrayValueType.Int16 => Zeros<short>(shape),
                ArrayValueType.UInt16 => Zeros<ushort>(shape),
                ArrayValueType.Int32 => Zeros<int>(shape),
                ArrayValueType.UInt32 => Zeros<uint>(shape),
                ArrayValueType.Int64 => Zeros<long>(shape),
                ArrayValueType.UInt64 => Zeros<ulong>(shape),
                ArrayValueType.Half => Zeros<Half>(shape),
                ArrayValueType.Single => Zeros<float>(shape),
                ArrayValueType.Double => Zeros<double>(shape),
                ArrayValueType.Decimal => Zeros<decimal>(shape),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid NumericArrayValueType")
            };
        }
        #endregion

        #region Ones Methods
        public static IConcreteArray<T> Ones<T>(int[] shape)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            IConcreteArray<T> newArray = Construct<T>(shape);

            newArray.Fill(1);

            return newArray;
        }
        public static IConcreteArray Ones(ArrayValueType type, int[] shape) {
            return type switch {
                ArrayValueType.Boolean => Ones<bool>(shape),
                ArrayValueType.Byte => Ones<byte>(shape),
                ArrayValueType.SByte => Ones<sbyte>(shape),
                ArrayValueType.Int16 => Ones<short>(shape),
                ArrayValueType.UInt16 => Ones<ushort>(shape),
                ArrayValueType.Int32 => Ones<int>(shape),
                ArrayValueType.UInt32 => Ones<uint>(shape),
                ArrayValueType.Int64 => Ones<long>(shape),
                ArrayValueType.UInt64 => Ones<ulong>(shape),
                ArrayValueType.Half => Ones<Half>(shape),
                ArrayValueType.Single => Ones<float>(shape),
                ArrayValueType.Double => Ones<double>(shape),
                ArrayValueType.Decimal => Ones<decimal>(shape),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid NumericArrayValueType")
            };
        }
        #endregion

        #region ARange Methods
        public static IConcreteArray<T> ARange<T>(double inclusiveStart, double inclusiveEnd, double step = 1.0f)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            double range = inclusiveEnd - inclusiveStart;

            if (range < 0)
            {
                step = (step > 0) ? -step : step;
            }
            else if (range > 0)
            {
                step = (step < 0) ? -step : step;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(inclusiveEnd), "Inclusive end must not be equal to inclusive start.");
            }

            int numIterations = (int)Math.Ceiling(range / step) + 1;

            IConcreteArray<T> newArray = Construct<T>(new int[] { numIterations });

            newArray.Fill((i) => (T)Convert.ChangeType(inclusiveStart + i * step, typeof(T)));

            return newArray;
        }
        public static IConcreteArray ARange(ArrayValueType type, double inclusiveStart, double inclusiveEnd, double step = 1.0f) {
            return type switch {
                ArrayValueType.Boolean => ARange<bool>(inclusiveStart, inclusiveEnd, step),
                ArrayValueType.Byte => ARange<byte>(inclusiveStart, inclusiveEnd, step),
                ArrayValueType.SByte => ARange<sbyte>(inclusiveStart, inclusiveEnd, step),
                ArrayValueType.Int16 => ARange<short>(inclusiveStart, inclusiveEnd, step),
                ArrayValueType.UInt16 => ARange<ushort>(inclusiveStart, inclusiveEnd, step),
                ArrayValueType.Int32 => ARange<int>(inclusiveStart, inclusiveEnd, step),
                ArrayValueType.UInt32 => ARange<uint>(inclusiveStart, inclusiveEnd, step),
                ArrayValueType.Int64 => ARange<long>(inclusiveStart, inclusiveEnd, step),
                ArrayValueType.UInt64 => ARange<ulong>(inclusiveStart, inclusiveEnd, step),
                ArrayValueType.Half => ARange<Half>(inclusiveStart, inclusiveEnd, step),
                ArrayValueType.Single => ARange<float>(inclusiveStart, inclusiveEnd, step),
                ArrayValueType.Double => ARange<double>(inclusiveStart, inclusiveEnd, step),
                ArrayValueType.Decimal => ARange<decimal>(inclusiveStart, inclusiveEnd, step),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid NumericArrayValueType")
            };
        }
        #endregion

        #region Linspace Methods
        public static IConcreteArray<T> Linspace<T>(double start, double end, int numPoints)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            if (numPoints < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(numPoints), "Number of points must be greater than or equal to two.");
            }

            double step = (end - start) / (numPoints - 1);

            IConcreteArray<T> newArray = Construct<T>(new int[] { numPoints });

            newArray.Fill((i) => (T)Convert.ChangeType(start + i * step, typeof(T)));

            return newArray;
        }
        public static IConcreteArray Linspace(ArrayValueType type, double start, double end, int numPoints) {
            return type switch {
                ArrayValueType.Boolean => Linspace<bool>(start, end, numPoints),
                ArrayValueType.Byte => Linspace<byte>(start, end, numPoints),
                ArrayValueType.SByte => Linspace<sbyte>(start, end, numPoints),
                ArrayValueType.Int16 => Linspace<short>(start, end, numPoints),
                ArrayValueType.UInt16 => Linspace<ushort>(start, end, numPoints),
                ArrayValueType.Int32 => Linspace<int>(start, end, numPoints),
                ArrayValueType.UInt32 => Linspace<uint>(start, end, numPoints),
                ArrayValueType.Int64 => Linspace<long>(start, end, numPoints),
                ArrayValueType.UInt64 => Linspace<ulong>(start, end, numPoints),
                ArrayValueType.Half => Linspace<Half>(start, end, numPoints),
                ArrayValueType.Single => Linspace<float>(start, end, numPoints),
                ArrayValueType.Double => Linspace<double>(start, end, numPoints),
                ArrayValueType.Decimal => Linspace<decimal>(start, end, numPoints),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid NumericArrayValueType")
            };
        }
        #endregion

        #region Logspace Methods

        #endregion

        #region Eye Methods
        public static IConcreteArray<T> Eye<T>(int size, int rank = 2)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be greater than zero.");
            }

            if (rank < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(rank), "Rank must be greater than or equal to two.");
            }

            int[] arrayShape = Enumerable.Repeat(size, rank).ToArray();

            IConcreteArray<T> newArray = Construct<T>(arrayShape);

            var oneOfT = (T)Convert.ChangeType(1, typeof(T));

            for (int i = 0; i < size; i++)
            {
                int[] currentIndex = new int[rank];
                Array.Fill(currentIndex, i);
                newArray[currentIndex] = oneOfT;
            }

            return newArray;
        }
        public static IConcreteArray Eye(ArrayValueType type, int size, int rank = 2) {
            return type switch {
                ArrayValueType.Boolean => Eye<bool>(size, rank),
                ArrayValueType.Byte => Eye<byte>(size, rank),
                ArrayValueType.SByte => Eye<sbyte>(size, rank),
                ArrayValueType.Int16 => Eye<short>(size, rank),
                ArrayValueType.UInt16 => Eye<ushort>(size, rank),
                ArrayValueType.Int32 => Eye<int>(size, rank),
                ArrayValueType.UInt32 => Eye<uint>(size, rank),
                ArrayValueType.Int64 => Eye<long>(size, rank),
                ArrayValueType.UInt64 => Eye<ulong>(size, rank),
                ArrayValueType.Half => Eye<Half>(size, rank),
                ArrayValueType.Single => Eye<float>(size, rank),
                ArrayValueType.Double => Eye<double>(size, rank),
                ArrayValueType.Decimal => Eye<decimal>(size, rank),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid NumericArrayValueType")
            };
        }
        #endregion
    }
}