namespace NumericArrays.Concrete {
    using System;

    using global::NumericArrays.Types;
    
    public class SystemArrayFactory : IConcreteArrayFactory {
        #region Non-Generic Methods
        public IConcreteArray Construct(ArrayValueType numericArrayValueType, int[] shape) {
            IConcreteArray newArray = numericArrayValueType switch {
                ArrayValueType.Boolean => new SystemArray<bool>(shape),
                ArrayValueType.Byte => new SystemArray<byte>(shape),
                ArrayValueType.SByte => new SystemArray<sbyte>(shape),
                ArrayValueType.Int16 => new SystemArray<short>(shape),
                ArrayValueType.UInt16 => new SystemArray<ushort>(shape),
                ArrayValueType.Int32 => new SystemArray<int>(shape),
                ArrayValueType.UInt32 => new SystemArray<uint>(shape),
                ArrayValueType.Int64 => new SystemArray<long>(shape),
                ArrayValueType.UInt64 => new SystemArray<ulong>(shape),
                ArrayValueType.Half => new SystemArray<float>(shape),
                ArrayValueType.Single => new SystemArray<float>(shape),
                ArrayValueType.Double => new SystemArray<double>(shape),
                ArrayValueType.Decimal => new SystemArray<decimal>(shape),
                _ => throw new ArgumentException("Unsupported type")
            };

            return newArray;
        }
        #endregion

        #region Generic Methods
        public IConcreteArray<T> Construct<T>(int[] shape)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            IConcreteArray<T> newArray = new SystemArray<T>(shape);

            return newArray;
        }
        #endregion
    }
}