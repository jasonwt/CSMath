namespace NumericArrays.Virtual.Mathematics.Unary {
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using NumericArrays.Types;

    public class SquareRootArray<T> : NumericArray<T>, IMathematicsArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {
        #region Private Fields
        private readonly INumericArray _sourceArray;
        #endregion

        #region Public Constructors
        public SquareRootArray(INumericArray leftArray) :
            base(leftArray?.Shape ?? throw new ArgumentNullException(nameof(leftArray))) {

            _sourceArray = leftArray;
        }
        #endregion

        #region Public Properties
        public override T this[int linearIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                Debug.Assert(linearIndex >= 0 && linearIndex <= Length);
                return (T) Math.Sqrt(_sourceArray[linearIndex]).CastToArrayValueType(ValueType);
            }
            set => throw new InvalidOperationException($"Can not set values in a virtual array of type {GetType().Name}.");
        }
        #endregion

        #region Public Methods

        #region ICloneable Methods
        public override INumericArray<T> Clone() => new SquareRootArray<T>(_sourceArray);
        #endregion

        #endregion
    }
}