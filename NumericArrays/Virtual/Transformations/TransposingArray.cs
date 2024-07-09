namespace NumericArrays.Virtual.Transformations {
    using System;
    using System.Data;
    using System.Linq;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using NumericArrays.Types;

    public class TransposingArray<T> : NumericArray<T>, ITransformationArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

        #region Private Fields
        private readonly INumericArray _sourceArray;
        private readonly int[] _transposedAxises;
        private readonly int[] _transposedStrides;
        #endregion

        #region Public Constructors
        public TransposingArray(INumericArray sourceArray, int[] transposedAxises) :
            base (sourceArray is null ? throw new ArgumentNullException(nameof(sourceArray)) : TransposedArray(sourceArray.Shape, transposedAxises)) {

            _sourceArray = sourceArray;
            _transposedAxises = transposedAxises.ToArray();
            _transposedStrides = TransposedArray(sourceArray.Strides, transposedAxises);
        }
        public TransposingArray(INumericArray<T> sourceArray, int[] transposedAxises) :
            this((INumericArray)sourceArray, transposedAxises) {
        }
        #endregion

        #region Public Properties
        public override T this[int linearIndex] {
            get {
                Debug.Assert(linearIndex >= 0 && linearIndex <= Length);

                linearIndex = ComputeSourceArrayLinearIndex(linearIndex);

                if (_arrayValueType == _sourceArray.ValueType)
                {
                    return ((INumericArray<T>)_sourceArray)[linearIndex];
                }

                return (T)_sourceArray[linearIndex].CastToArrayValueType(ValueType);
            }
            set {
                linearIndex = ComputeSourceArrayLinearIndex(linearIndex);

                Debug.Assert(linearIndex >= 0 && linearIndex <= Length);

                if (_arrayValueType == _sourceArray.ValueType)
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

        #region Protected Methods
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected int ComputeSourceArrayLinearIndex(int linearIndex) {
            int dataSourceLinearIndex = 0;

            for (int i = 0; i < Strides.Length; i++)
            {
                dataSourceLinearIndex += _transposedStrides[i] * (linearIndex / ProtectedStrides[i]);
                linearIndex %= ProtectedStrides[i];
            }

            return dataSourceLinearIndex;
        }
        #endregion

        #region Public Static Methods
        public static int[] TransposedArray(int[] originalArray, int[] transposedArrayIndices) {
            if (originalArray == null)
            {
                throw new ArgumentNullException(nameof(originalArray));
            }

            if (originalArray.Length == 0)
            {
                throw new ArgumentException("Array must have at least one element.", nameof(originalArray));
            }

            if (transposedArrayIndices == null)
            {
                throw new ArgumentNullException(nameof(transposedArrayIndices));
            }

            if (transposedArrayIndices.Length != originalArray.Length)
            {
                throw new ArgumentException("Array must have the same length as the original array");
            }

            int minTransposedIndex = transposedArrayIndices.Min();
            int maxTransposedIndex = transposedArrayIndices.Max();

            if (minTransposedIndex < 0 || maxTransposedIndex >= originalArray.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(transposedArrayIndices));
            }

            if (transposedArrayIndices.Distinct().Count() != transposedArrayIndices.Length)
            {
                throw new ArgumentException("transposedArrayIndices must not contain duplicates.");
            }

            return transposedArrayIndices.Select(index => originalArray[index]).ToArray();
        }
        #endregion

        #region Public Methods

        #region ICloneable Methods
        public override INumericArray<T> Clone() => new TransposingArray<T>(_sourceArray, _transposedAxises);
        
        #endregion

        #endregion
    }
}