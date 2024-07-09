namespace NumericArrays.Concrete {
    using System;

    using NumericArrays.Types;

    public interface IConcreteArrayFactory {
        #region Non-Generic Methods
        IConcreteArray Construct(ArrayValueType numericArrayType, int[] shape);
        #endregion

        #region Generic Methods
        IConcreteArray<T> Construct<T>(int[] shape) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>;
        #endregion
    }
}