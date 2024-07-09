namespace NumericArrays.Concrete {
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class SystemArray<T> : ConcreteArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

        #region Private Fields
        private T[] _array;
        #endregion

        #region Public Constructors
        public SystemArray(int[] shape) :
            base(shape) {

            _array = new T[_length];
        }
        #endregion

        #region Public Properties
        public override T this[int linearIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                Debug.Assert(linearIndex >= 0 && linearIndex <= Length);
                return _array[linearIndex];
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                Debug.Assert(linearIndex >= 0 && linearIndex <= Length);
                _array[linearIndex] = value;
            }
        }
        #endregion

        #region Public Methods
        public override INumericArray<T> Clone() {
            return new SystemArray<T>(Shape) {
                _array = (T[])_array.Clone()
            };
        }
        #endregion
    }
}