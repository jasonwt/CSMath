namespace NumericArrays {
    using System;

    public static partial class NA {
        #region Non-Generic Methods
        public static void Fill(this INumericArray thisArray, Func<int, ValueType> fillFunc, int requestedThreads = 1) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            if (fillFunc == null)
            {
                throw new ArgumentNullException(nameof(fillFunc));
            }

            int arrayLength = thisArray.Length;

            for (int i = 0; i < arrayLength; i++)
            {
                thisArray[i] = ((IConvertible)fillFunc(i)).ToDouble(null);
            }
        }
        public static void Fill(this INumericArray thisArray, INumericArray otherArray, int requestedThreads = 1) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            if (otherArray == null)
            {
                throw new ArgumentNullException(nameof(otherArray));
            }

            if (thisArray.Length != otherArray.Length)
            {
                throw new ArgumentException("Other array must have the same length as the array");
            }

            Fill(thisArray, i => otherArray[i], requestedThreads);
        }
        public static void Fill(this INumericArray thisArray, ValueType[] values, int requestedThreads = 1) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length != thisArray.Length)
            {
                throw new ArgumentException("Values must have the same length as the array");
            }

            Fill(thisArray, i => values[i], requestedThreads);
        }
        public static void Fill(this INumericArray thisArray, ValueType value, int requestedThreads = 1) {
            Fill(thisArray, i => value, requestedThreads);
        }
        #endregion

        #region Generic Methods
        public static void Fill<T>(this INumericArray<T> thisArray, Func<int, T> fillFunc, int requestedThreads = 1)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            if (fillFunc == null)
            {
                throw new ArgumentNullException(nameof(fillFunc));
            }

            int arrayLength = thisArray.Length;

            for (int i = 0; i < arrayLength; i++)
            {
                thisArray[i] = fillFunc(i);
            }
        }
        public static void Fill<T>(this INumericArray<T> thisArray, INumericArray<T> otherArray, int requestedThreads = 1)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            if (otherArray == null)
            {
                throw new ArgumentNullException(nameof(otherArray));
            }

            if (thisArray.Length != otherArray.Length)
            {
                throw new ArgumentException("Other array must have the same length as the array");
            }

            Fill(thisArray, i => otherArray[i], requestedThreads);
        }
        public static void Fill<T>(this INumericArray<T> thisArray, T[] values, int requestedThreads = 1)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length != thisArray.Length)
            {
                throw new ArgumentException("Values must have the same length as the array");
            }

            Fill(thisArray, i => values[i], requestedThreads);
        }
        public static void Fill<T>(this INumericArray<T> thisArray, T value, int requestedThreads = 1)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            Fill(thisArray, i => value, requestedThreads);
        }
        #endregion
    }
}