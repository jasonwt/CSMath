namespace NumericArrays.Concrete {
    using System;

    using NumericArrays.Types;

    public class BinaryFileArrayFactory : IConcreteArrayFactory {
        #region Non-Generic Methods
        public IConcreteArray Construct(ArrayValueType numericArrayValueType, int[] shape) {
            IConcreteArray newArray = numericArrayValueType switch
            {
                ArrayValueType.Boolean => new BinaryFileArray<bool>(shape),
                ArrayValueType.Byte => new BinaryFileArray<byte>(shape),
                ArrayValueType.SByte => new BinaryFileArray<sbyte>(shape),
                ArrayValueType.Int16 => new BinaryFileArray<short>(shape),
                ArrayValueType.UInt16 => new BinaryFileArray<ushort>(shape),
                ArrayValueType.Int32 => new BinaryFileArray<int>(shape),
                ArrayValueType.UInt32 => new BinaryFileArray<uint>(shape),
                ArrayValueType.Int64 => new BinaryFileArray<long>(shape),
                ArrayValueType.UInt64 => new BinaryFileArray<ulong>(shape),
                ArrayValueType.Half => new BinaryFileArray<float>(shape),
                ArrayValueType.Single => new BinaryFileArray<float>(shape),
                ArrayValueType.Double => new BinaryFileArray<double>(shape),
                ArrayValueType.Decimal => new BinaryFileArray<decimal>(shape),
                _ => throw new ArgumentException("Unsupported type")
            };

            return newArray;
        }
        #endregion

        #region Generic Methods
        public IConcreteArray<T> Construct<T>(int[] shape)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            IConcreteArray<T> newArray = new BinaryFileArray<T>(shape);

            return newArray;
        }
        #endregion
    }
}