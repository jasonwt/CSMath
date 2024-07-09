namespace NumericArrays.Virtual.Mathematics.Binary {
    using System;
    using System.Diagnostics;

    using NumericArrays.Types;
    using NumericArrays.Virtual.Transformations;

    public class LogarithmArray<T> : NumericArray<T>, IMathematicsArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

        #region Private Fields
        protected readonly INumericArray _leftArray;
        protected readonly INumericArray _rightArray;
        #endregion

        #region Protected Constructors
        public LogarithmArray(INumericArray leftArray, INumericArray rightArray) :
            base(
                leftArray is null ? throw new ArgumentNullException(nameof(leftArray)) :
                    rightArray is null ? throw new ArgumentNullException(nameof(rightArray)) :
                    BroadcastingArray<T>.ComputeBroadcastingShape(leftArray.Shape, rightArray.Shape)
            ) {

            _leftArray = leftArray;
            _rightArray = rightArray;
        }
        #endregion

        #region Public Properties
        public override T this[int linearIndex] {
            get {
                Debug.Assert(linearIndex >= 0 && linearIndex <= Length);

                return (T)Math.Log(_leftArray[linearIndex], _rightArray[linearIndex]).CastToArrayValueType(ValueType);
            }
            set => throw new InvalidOperationException($"Can not set values in a virtual array of type {GetType().Name}.");
        }
        #endregion

        #region Public Methods

        #region ICloneable Methods
        public override INumericArray<T> Clone() => new LogarithmArray<T>(_leftArray, _rightArray);
        #endregion

        #endregion
    }
}