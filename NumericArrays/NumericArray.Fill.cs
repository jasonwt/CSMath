namespace NumericArrays {
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using NumericArrays.Types;

    public abstract partial class NumericArray<T> : INumericArray<T>
        where T : struct, IConvertible, IComparable, IComparable<T>, IEquatable<T> {

        #region Public Fill Methods
        public virtual void Fill(Func<int, ValueType> fillFunc, int requestedThreads = 1) {
            if (fillFunc == null)
            {
                throw new ArgumentNullException(nameof(fillFunc));
            }

            for (int i = 0; i < _length; i++)
            {
                this[i] = (T)((IConvertible)fillFunc(i)).ToDouble(null).CastToArrayValueType(ValueType);
            }
        }
        public virtual void Fill(Func<int, T> fillFunc, int requestedThreads = 1) {
            if (fillFunc == null)
            {
                throw new ArgumentNullException(nameof(fillFunc));
            }

            for (int i = 0; i < _length; i++)
            {
                this[i] = fillFunc(i);
            }
        }

        public virtual void Fill(INumericArray otherArray, int requestedThreads = 1) {
            if (otherArray == null)
            {
                throw new ArgumentNullException(nameof(otherArray));
            }

            if (otherArray.Length != _length)
            {
                throw new ArgumentException("Other array must have the same length as the array");
            }

            Fill((i) => otherArray[i], requestedThreads);
        }
        public virtual void Fill(INumericArray<T> otherArray, int requestedThreads = 1) {
            if (otherArray == null)
            {
                throw new ArgumentNullException(nameof(otherArray));
            }

            if (otherArray.Length != _length)
            {
                throw new ArgumentException("Other array must have the same length as the array");
            }

            Fill((i) => otherArray[i], requestedThreads);
        }

        public virtual void Fill(ValueType[] values, int requestedThreads = 1) {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length != _length)
            {
                throw new ArgumentException("Values must have the same length as the array");
            }

            Fill((i) => values[i], requestedThreads);
        }
        public virtual void Fill(T[] values, int requestedThreads = 1) {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length != _length)
            {
                throw new ArgumentException("Values must have the same length as the array");
            }

            Fill((i) => values[i], requestedThreads);
        }

        public virtual void Fill(IEnumerable<ValueType> values, int requestedThreads = 1) {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            Fill(values.ToArray(), requestedThreads);
        }
        public virtual void Fill(IEnumerable<T> values, int requestedThreads = 1) {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            Fill(values.ToArray(), requestedThreads);
        }

        public virtual void Fill(ValueType value, int requestedThreads = 1) {
            Fill((i) => value, requestedThreads);
        }
        public virtual void Fill(T value, int requestedThreads = 1) {
            Fill((i) => value, requestedThreads);
        }
        #endregion
    }
}
