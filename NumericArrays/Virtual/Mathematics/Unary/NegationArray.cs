namespace NumericArrays.Virtual.Mathematics.Unary {
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using NumericArrays.Types;

    public class NegationArray<T> : NumericArray<T>, IMathematicsArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {
        #region Private Fields
        private readonly INumericArray _sourceArray;
        #endregion

        #region Public Constructors
        public NegationArray(INumericArray sourceArray) :
            base(sourceArray?.Shape ?? throw new ArgumentNullException(nameof(sourceArray))) {

            _sourceArray = sourceArray;

            if (ValueType == ArrayValueType.Byte || ValueType == ArrayValueType.UInt16 || ValueType == ArrayValueType.UInt32 || ValueType == ArrayValueType.UInt64) 
            {
                throw new NotSupportedException($"Negation is not supported for unsigned integer arrays of type {ValueType}.");
            }
        }

        public NegationArray(INumericArray<T> sourceArray) :
            this((INumericArray)sourceArray) {
        }
        #endregion

        #region Public Properties
        public override T this[int linearIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                Debug.Assert(linearIndex >= 0 && linearIndex <= Length);

                return (T) (-(_sourceArray[linearIndex])).CastToArrayValueType(ValueType);
            }
            set => throw new InvalidOperationException($"Can not set values in a virtual array of type {GetType().Name}.");
        }
        #endregion

        #region Public Methods

        #region ICloneable Methods
        public override INumericArray<T> Clone() => new NegationArray<T>(_sourceArray);
        #endregion

        #endregion
    }
}