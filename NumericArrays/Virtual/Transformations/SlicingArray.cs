namespace NumericArrays.Virtual.Transformations {
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using NumericArrays.Types;

    public class SlicingArray<T> : NumericArray<T>, ITransformationArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

        #region Public SlicingMask Struct
        public readonly struct SlicingMask {
            public SlicingMask(int offset, int length, int step) {
                Offset = offset;
                Length = length;
                Step = step;
            }

            public int Offset { get; }
            public int Length { get; }
            public int Step { get; }

            public static int MemoryUsage => sizeof(int) * 3;
        }
        #endregion

        #region Private Fields
        private readonly INumericArray _sourceArray;
        private readonly string _slicingMaskString;
        private readonly SlicingMask[] _slicingMask;
        private readonly int[] _sourceArrayStrides;
        #endregion

        #region Public Constructors
        public SlicingArray(INumericArray sourceArray, string slicingMaskString) :
            base(sourceArray is null ? throw new ArgumentNullException(nameof(sourceArray)) : ComputeMaskShape(ComputeMask(slicingMaskString, sourceArray.Shape))) {

            _sourceArray = sourceArray;
            _slicingMask = ComputeMask(slicingMaskString, sourceArray.Shape);
            _slicingMaskString = slicingMaskString;
            _sourceArrayStrides = sourceArray.Strides;
        }
        public SlicingArray(INumericArray<T> sourceArray, string slicingMaskString) :
            this((INumericArray)sourceArray, slicingMaskString) {
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
            int j = 0;
            //Console.WriteLine($"this.Shape: {string.Join(",", Shape.Length)}");
            //Console.WriteLine($"this.Strides: {string.Join(",", Strides.Length)}");
            //Console.WriteLine($"this.Length: {Length}");

            //Console.WriteLine($"ComputeSourceArrayLinearIndex: {linearIndex}");

            for (int i = 0; i < _slicingMask.Length; i++)
            {
                if (linearIndex > 0)
                {
                    dataSourceLinearIndex += (_slicingMask[i].Offset + linearIndex / ProtectedStrides[j] * _slicingMask[i].Step) * _sourceArrayStrides[i];

                    linearIndex %= ProtectedStrides[j];
                    j++;
                }
                else
                {
                    dataSourceLinearIndex += _slicingMask[i].Offset * _sourceArrayStrides[i];
                }
            }

            
            //Console.WriteLine($"ComputeSourceArrayLinearIndex: {dataSourceLinearIndex}");

            return dataSourceLinearIndex;
        }
        #endregion

        #region Pulbic Static Methods
        public static int[] ComputeMaskShape(SlicingMask[] slicingMasks) {
            int rank = slicingMasks.Length;
            int[] shape = new int[rank];

            for (int i = 0; i < rank; i++)
            {
                shape[i] = slicingMasks[i].Length;
            }

            return shape;
            //return shape.SkipWhile(s => s == 1).ToArray();
        }
        public static SlicingMask[] ComputeMask(string maskString, int[] shape) {
            int rank = shape.Length;

            string[] maskParts = maskString.Trim().Split(',');

            if (maskParts.Length > rank)
            {
                throw new ArgumentException("mastParts.Length must be <= Rank");
            }

            var mask = new SlicingMask[rank];

            for (int i = 0; i < rank; i++)
            {
                if (i >= maskParts.Length)
                {
                    mask[i] = new SlicingMask(0, shape[i], 1);
                    continue;
                }

                maskParts[i] = maskParts[i].Trim();

                if (maskParts[i].Length == 0)
                {
                    mask[i] = new SlicingMask(0, shape[i], 1);
                    continue;
                }

                if (int.TryParse(maskParts[i], out int idx))
                {
                    if (idx < 0)
                    {
                        idx += shape[i];
                    }

                    if (idx >= shape[i])
                    {
                        throw new ArgumentException("Index out of range");
                    }

                    mask[i] = new SlicingMask(idx, 1, 1);
                    continue;
                }

                string[] maskPart = maskParts[i].Split(':');

                if (maskPart.Length == 0 || maskPart.Length > 3)
                {
                    throw new ArgumentException("maskPart.Length must be > 0 and <= 3");
                }

                int offset = 0;
                int length = shape[i];
                int step = 1;

                for (int l = 0; l < maskPart.Length; l++)
                {
                    if (maskPart[l].Length == 0)
                    {
                        continue;
                    }

                    if (int.TryParse(maskPart[l], out int value))
                    {
                        if (l == 0)
                        {
                            if (value < 0 || value >= shape[i])
                            {
                                throw new ArgumentException("Index out of range");
                            }

                            offset = value;
                            length = shape[i] - offset;
                        }
                        else if (l == 1)
                        {

                            if (value < 0 || value > shape[i] || value < offset)
                            {
                                throw new ArgumentException("Index out of range");
                            }

                            length = value - offset;
                        }
                        else if (l == 2)
                        {
                            step = value;
                        }
                    }
                }

                mask[i] = new SlicingMask(offset, (int)Math.Ceiling(length / (double)step), step);
            }

            return mask;
        }
        #endregion 

        #region Public Methods

        #region ICloneable Methods
        public override INumericArray<T> Clone() => new SlicingArray<T>(_sourceArray, _slicingMaskString);
        #endregion

        #endregion
    }
}