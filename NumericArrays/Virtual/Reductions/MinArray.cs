namespace NumericArrays.Virtual.Reductions {
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using NumericArrays.Types;

    public class MinArray<T> : NumericArray<T>, IReductionArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

        #region Private Fields
        private readonly INumericArray _sourceArray;
        private readonly int? _axis;
        private readonly int _axisStride;
        private readonly int _prevAxisStride = 1;
        private readonly int _axisIterations = 1;
        private readonly int _axisStep = 1;
        #endregion

        #region Public Constructors
        public MinArray(INumericArray sourceArray, int? axis) :
            base(IReductionArray.ComputeShape(sourceArray, axis)) {

            int[] sourceArrayStrides = sourceArray.Strides;

            _sourceArray = sourceArray;
            _axis = axis;
            _axisIterations = _sourceArray.Length / Length;
            _axisStep = _axis != null ? sourceArrayStrides[_axis.Value] : _axisStep;
            _axisStride = _axis != null ? sourceArrayStrides[_axis.Value] : _axisStride;
            _prevAxisStride = _axis != null ? (_axis.Value == 0 ? 1 : sourceArrayStrides[_axis.Value - 1]) : _prevAxisStride;
        }
        #endregion

        #region Public Properties
        public override T this[int linearIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                Debug.Assert(linearIndex >= 0 && linearIndex <= Length);

                int start = _axis is null ? 0 : linearIndex / _axisStride * _prevAxisStride + (linearIndex % _axisStride);
                int end = start + (_axisIterations * _axisStep);

                double minValue = _sourceArray[start];

                for (int i = start + _axisStep; i < end; i += _axisStep)
                {
                    minValue = Math.Min(_sourceArray[i], minValue);
                }

                return (T) minValue.CastToArrayValueType(ValueType);
            }
            set => throw new InvalidOperationException($"Can not set values in a virtual array of type {GetType().Name}.");
        }
        #endregion

        #region Public Methods

        #region ICloneable Methods
        public override INumericArray<T> Clone() => new MinArray<T>(_sourceArray, _axis);
        #endregion

        #endregion
    }
}