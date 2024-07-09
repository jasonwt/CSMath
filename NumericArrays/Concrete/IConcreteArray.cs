namespace NumericArrays.Concrete {
    using System;

    public interface IConcreteArray : INumericArray {
    }

    public interface IConcreteArray<T> : INumericArray<T>, IConcreteArray
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {
    }
}
