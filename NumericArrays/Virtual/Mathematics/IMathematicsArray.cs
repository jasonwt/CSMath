namespace NumericArrays.Virtual.Mathematics {
    using System;

    public interface IMathematicsArray : IVirtualArray {
    }

    public interface IMathematicsArray<T> : IMathematicsArray, IVirtualArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {
    }
}
