namespace NumericArrays.Concrete {
    using System;

    public abstract class ConcreteArray<T> : NumericArray<T>, IConcreteArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

        #region Protected Constructors
        protected ConcreteArray(int[] shape) :
            base(shape) {
        }
        #endregion
    }
}
