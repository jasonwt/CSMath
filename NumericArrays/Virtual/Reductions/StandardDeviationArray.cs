namespace NumericArrays.Virtual.Reductions {
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using NumericArrays.Types;

    public class StandardDeviationArray<T> : NumericArray<T>, IReductionArray<T>
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
        public StandardDeviationArray(INumericArray sourceArray, int? axis) :
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

                //double[] values = new double[_axisIterations];
                //double mean = 0;

                //for (int j = 0, i = start; i < end; i += _axisStep, j++)
                //{
                //    values[j] += _sourceArray[i];
                //    mean += values[j];
                //}

                //mean /= _axisIterations;

                //double squaredDeviations = 0;
                //for (int i = 0; i < _axisIterations; i++)
                //{
                //    double deviation = values[i] - mean;
                //    squaredDeviations += (deviation * deviation);
                //}

                double mean = 0;
                double m2 = 0;
                int count = 0;

                for (int i = start; i < end; i += _axisStep)
                {
                    double value = _sourceArray[i];
                    count++;
                    double delta = value - mean;
                    mean += delta / count;
                    m2 += delta * (value - mean);
                }

                double variance = m2 / _axisIterations;
                double stdDev = Math.Sqrt(variance);

                return (T)stdDev.CastToArrayValueType(ValueType);
            }
            set => throw new InvalidOperationException($"Can not set values in a virtual array of type {GetType().Name}.");
        }
        #endregion

        #region Public Methods

        #region ICloneable Methods
        public override INumericArray<T> Clone() => new StandardDeviationArray<T>(_sourceArray, _axis);
        #endregion

        #endregion
    }
}