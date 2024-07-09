namespace NumericArrays {
    using System;

    using NumericArrays.Concrete;
    using NumericArrays.Virtual;

    public static partial class NA {
        #region Non-Generic Methods
        public static IConcreteArray<T> Solidify<T>(this IVirtualArray<T> virtualArray, IConcreteArrayFactory concreteArrayFactory, int requestedThreads = 1)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            IConcreteArray<T> newConcreteArray = concreteArrayFactory.Construct<T>(virtualArray.Shape);

            newConcreteArray.Fill(virtualArray, requestedThreads);

            return newConcreteArray;
        }
        #endregion

        #region Generic Methods
        public static IConcreteArray Solidify(this IVirtualArray virtualArray, IConcreteArrayFactory concreteArrayFactory, int requestedThreads = 1) {
            IConcreteArray newConcreteArray = concreteArrayFactory.Construct(virtualArray.ValueType, virtualArray.Shape, requestedThreads);

            newConcreteArray.Fill(virtualArray, requestedThreads);

            return newConcreteArray;
        }
        #endregion
    }
}