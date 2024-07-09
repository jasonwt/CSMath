namespace NumericArrays {
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using NumericArrays.Types;
    using System.Numerics;

    public abstract partial class NumericArray<T> : INumericArray<T>
        where T: struct, IConvertible, IComparable, IComparable<T>, IEquatable<T> {

        #region Private Fields
        private bool _isDisposed = false;
        private int[] _shape;
        private int[] _strides;
        private int _rank;
        #endregion

        #region Protected Readonly Fields
        protected readonly int _length;
        protected readonly ArrayValueType _arrayValueType;
        #endregion

        #region Protected Constructors and Finalizers
        protected NumericArray(int[] shape) {
            _shape = shape?.ToArray() ?? throw new ArgumentNullException(nameof(shape));
            _strides = ComputeStrides(shape);
            _rank = shape.Length;
            _length = shape[0] * _strides[0];
            _arrayValueType = typeof(T).ArrayValueTypeOf();
        }
        ~NumericArray() {
            Dispose(false);
        }
        #endregion

        #region Public Properties
        public abstract T this[int linearIndex] { get; set; }
        double INumericArray.this[int linearIndex] { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => this[linearIndex].ToDouble(null);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                this[linearIndex] = (T)value.CastToArrayValueType(ValueType);
            }
        }

        public virtual T this[params int[] indices] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => this[ComputeLinearIndex(indices)];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => this[ComputeLinearIndex(indices)] = value;
        }
        double INumericArray.this[params int[] indices] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => this[ComputeLinearIndex(indices)].ToDouble(null);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                int linearIndex = ComputeLinearIndex(indices);

                this[linearIndex] = (T) value.CastToArrayValueType(ValueType);
            }
        }

        public virtual INumericArray<T> this[string slicingMask] {
            get => this.Slice(slicingMask);
            set => throw new NotImplementedException();
        }
        INumericArray INumericArray.this[string slicingMask] {
            get => this[slicingMask];
            set => throw new NotImplementedException();
        }

        public ArrayValueType ValueType {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _arrayValueType;
        }

        public int[] Shape => _shape.ToArray();
        public int[] Strides => _strides.ToArray();
        public int Rank {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _rank;
        }
        public int Length {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _length;
        }
        #endregion

        #region Protected Properties
        protected int[] ProtectedShape {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _shape;
        }
        protected int[] ProtectedStrides {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _strides;
        }
        #endregion

        #region Protected Methods

        #region IDisposable Methods
        protected virtual void Dispose(bool disposing) {
            if (!_isDisposed)
            {
                //TotalArraysMemoryUsageInBytes -= SystemMemoryUsageInBytes;
                //TotalArraysAllocated--;

                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _isDisposed = true;
            }
        }
        #endregion

        #endregion

        #region Public Static Methods
        public static int[] ComputeStrides(int[] shape) {
            if (shape.Length == 0)
            {
                throw new ArgumentException("Shape must have at least one dimension.");
            }

            int[] strides = new int[shape.Length];

            strides[shape.Length - 1] = 1;

            for (int i = shape.Length - 2; i >= 0; i--)
            {
                if (shape[i + 1] <= 0)
                {
                    throw new ArgumentException("Shape dimensions must be greater than zero.");
                }

                strides[i] = strides[i + 1] * shape[i + 1];
            }

            return strides;
        }
        #endregion

        #region Public Methods

        #region INumericArray Methods
        public virtual void Reshape(int[] newShape) {
            int[] newStrides = ComputeStrides(newShape);

            if ((newShape[0] * newStrides[0]) != _length)
            {
                throw new ArgumentException("New shape must have the same number of elements as the original shape.");
            }

            _shape = newShape;
            _strides = newStrides;
            _rank = newShape.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ComputeLinearIndex(int[] indices) {
            if (indices.Length != _rank)
            {
                throw new ArgumentException("Indices must have the same length as the rank of the array.");
            }

            int linearIndex = 0;

            for (int i = 0; i < _rank; i++)
            {
                if (indices[i] < 0 || indices[i] >= _shape[i])
                {
                    throw new ArgumentOutOfRangeException(nameof(indices), "Index is out of range.");
                }

                linearIndex += indices[i] * _strides[i];
            }

            return linearIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int[] ComputeIndices(int linearIndex) {
            if (linearIndex < 0 || linearIndex >= _length)
            {
                throw new ArgumentOutOfRangeException(nameof(linearIndex), "Linear index is out of range.");
            }

            int[] indices = new int[Rank];

            for (int i = 0; i < Rank; i++)
            {
                indices[i] = linearIndex / _strides[i];
                linearIndex -= indices[i] * _strides[i];
            }

            return indices;
        }
        #endregion

        #region ICloneable Methods
        public virtual INumericArray<T> Clone() => (INumericArray<T>)MemberwiseClone();
        INumericArray INumericArray.Clone() => Clone();
        object ICloneable.Clone() => Clone();
        #endregion

        #region IEnumerable Methods
        public IEnumerator<T> GetEnumerator() {
            for (int i = 0; i < _length; i++)
            {
                yield return this[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion

        #region IDisposable Methods
        public void Dispose() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #endregion
    }
}