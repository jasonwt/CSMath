namespace NumericArrays.Virtual {
    using System;

    using NumericArrays.Concrete;

    public interface IVirtualArray : INumericArray {
    }

    public interface IVirtualArray<T> : INumericArray<T>, IVirtualArray
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {
    }
}