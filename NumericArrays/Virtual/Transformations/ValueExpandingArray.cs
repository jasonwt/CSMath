namespace NumericArrays.Virtual.Transformations {
    using System;
    using System.Diagnostics;

    public class ValueExpandingArray<T> : NumericArray<T>, ITransformationArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

        #region Private Fields
        protected readonly T _expandingValue;
        #endregion

        #region Public Constructors
        public ValueExpandingArray(ValueType expandingValue, int[] arrayShape) :
            this((T)Convert.ChangeType(expandingValue, typeof(T)), arrayShape) {
        }
        public ValueExpandingArray(T expandingValue, int[] arrayShape) :
            base(arrayShape) {

            _expandingValue = (T)Convert.ChangeType(expandingValue, typeof(T));
        }
        #endregion

        #region Public Properties
        public override T this[int linearIndex] {
            get {
                Debug.Assert(linearIndex >= 0 && linearIndex <= Length);

                return _expandingValue;
            }
            set => throw new InvalidOperationException($"Can not set values on a {GetType().Name}.");
        }
        #endregion

        #region Public Methods

        #region ICloneable Methods
        public override INumericArray<T> Clone() => new ValueExpandingArray<T>(_expandingValue, Shape);
        #endregion

        #endregion
    }
}