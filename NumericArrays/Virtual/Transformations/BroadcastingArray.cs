namespace NumericArrays.Virtual.Transformations {
    using System;
    using System.Linq;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using NumericArrays.Types;

    public class BroadcastingArray<T> : NumericArray<T>, ITransformationArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

        #region Private Fields
        private readonly INumericArray _sourceArray;
        private readonly bool _isBroadcasting;
        private readonly int[] _sourceArrayShape;
        private readonly int[] _sourceArrayStrides;
        private readonly int[] _otherArrayShape;
        #endregion

        #region Public Constructors
        public BroadcastingArray(INumericArray sourceArray, int[] otherArrayShape) :
            base(sourceArray is null ? throw new ArgumentNullException(nameof(sourceArray)) : ComputeBroadcastingShape(sourceArray.Shape, otherArrayShape)) {

            _sourceArray = sourceArray;
            _sourceArrayShape = sourceArray.Shape;
            _sourceArrayStrides = sourceArray.Strides;
            _otherArrayShape = otherArrayShape;

            _isBroadcasting = !sourceArray.Shape.SequenceEqual(Shape);
        }
        public BroadcastingArray(INumericArray<T> sourceArray, int[] otherArrayShape) :
            this((INumericArray)sourceArray, otherArrayShape) {
        }
        #endregion

        #region Public Properties
        public override T this[int linearIndex] {
            get {
                Debug.Assert(linearIndex >= 0 && linearIndex <= Length);

                linearIndex = ComputeSourceArrayLinearIndex(linearIndex);

                if (ValueType == _sourceArray.ValueType)
                {
                    return ((INumericArray<T>)_sourceArray)[linearIndex];
                }

                return (T)_sourceArray[linearIndex].CastToArrayValueType(ValueType);
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

        #region Protected Methods
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected int ComputeSourceArrayLinearIndex(int linearIndex) {
            int broadcastingRank = Rank;
            int actualLinearIndex = 0;

            for (int i = 0, j = _sourceArrayShape.Length - broadcastingRank; i < broadcastingRank && linearIndex > 0; i++, j++)
            {
                int dimensionalIndex = linearIndex / ProtectedStrides[i];

                if (j >= 0 && _sourceArrayShape[j] > 1)
                {
                    actualLinearIndex += (dimensionalIndex * _sourceArrayStrides[j]);
                }

                linearIndex -= dimensionalIndex * ProtectedStrides[i];
            }

            return actualLinearIndex;
        }

        #endregion

        #region Pulbic Static Methods
        public static int[] ComputeBroadcastingShape(int[] shape1, int[] shape2) {
            if (shape1 == null)
            {
                throw new ArgumentNullException(nameof(shape1));
            }

            if (shape2 == null)
            {
                throw new ArgumentNullException(nameof(shape2));
            }

            if (shape1.Length == 0)
            {
                throw new ArgumentException("Shape can not be empty.", nameof(shape1));
            }

            if (shape2.Length == 0)
            {
                throw new ArgumentException("Shape can not be empty.", nameof(shape2));
            }

            var shape1List = shape1.ToList();
            var shape2List = shape2.ToList();

            // Pad the shapes to have the same length
            int maxLength = Math.Max(shape1List.Count, shape2List.Count);
            shape1List.InsertRange(0, Enumerable.Repeat(1, maxLength - shape1List.Count));
            shape2List.InsertRange(0, Enumerable.Repeat(1, maxLength - shape2List.Count));

            int[] broadcastingShape = new int[maxLength];
            // Check if the shapes are compatible
            for (int i = 0; i < shape1List.Count; i++)
            {
                if (shape1List[i] != shape2List[i] && shape1List[i] != 1 && shape2List[i] != 1)
                {
                    throw new ArgumentException("Shapes are not compatible for broadcasting.");
                }

                broadcastingShape[i] = shape1List[i] > shape2List[i] ? shape1List[i] : shape2List[i];
            }

            return broadcastingShape;
        }
        #endregion

        #region Public Methods

        #region ICloneable Methods
        public override INumericArray<T> Clone() => new BroadcastingArray<T>(_sourceArray, _otherArrayShape);
        #endregion

        #endregion
    }
}