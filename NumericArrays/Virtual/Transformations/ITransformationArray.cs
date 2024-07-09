namespace NumericArrays.Virtual.Transformations {
    using System;

    public interface ITransformationArray : IVirtualArray {
    }

    public interface ITransformationArray<T> : ITransformationArray, IVirtualArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {
    }
}
