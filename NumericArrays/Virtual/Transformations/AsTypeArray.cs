namespace NumericArrays.Virtual.Transformations {
    using System;
    using System.Diagnostics;

    using NumericArrays.Types;

    public class AsTypeArray<T> : NumericArray<T>, ITransformationArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

        #region Private Fields
        protected readonly INumericArray _sourceArray;
        #endregion

        #region Public Constructors
        public AsTypeArray(INumericArray sourceArray) :
            base(sourceArray?.Shape ?? throw new ArgumentNullException(nameof(sourceArray))) {

            _sourceArray = sourceArray;
        }
        #endregion

        #region Public Properties
        public override T this[int linearIndex] {
            get {
                Debug.Assert(linearIndex >= 0 && linearIndex <= Length);

                if (ValueType == _sourceArray.ValueType)
                {
                    return ((INumericArray<T>)_sourceArray)[linearIndex];
                }

                return (T) _sourceArray[linearIndex].CastToArrayValueType(ValueType);
            }
            set {
                Debug.Assert(linearIndex >= 0 && linearIndex <= Length);
                if (ValueType == _sourceArray.ValueType)
                {
                    ((INumericArray<T>)_sourceArray)[linearIndex] = value;
                }
                else
                {
                    _sourceArray[linearIndex] = value.ToDouble(null);
                }
            }
        }
        #endregion

        #region Public Methods

        #region ICloneable Methods
        public override INumericArray<T> Clone() => new AsTypeArray<T>(_sourceArray);
        #endregion

        #endregion
    }
}