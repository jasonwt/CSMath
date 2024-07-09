namespace NumericArrays.Extensions {
    using System;
    using System.Collections.Generic;

    public static class LinqExtensions {
        public static bool SequenceEqual(this INumericArray thisArray, IEnumerable<ValueType> otherEnumerable) {
            if (thisArray == null)
            {
                throw new ArgumentNullException(nameof(thisArray));
            }

            if (otherEnumerable == null)
            {
                throw new ArgumentNullException(nameof(otherEnumerable));
            }

            int thisIndex = 0;
            int thisArrayLength = thisArray.Length;

            foreach (ValueType otherValue in otherEnumerable)
            {
                if (thisIndex == thisArrayLength)
                {
                    return false;
                }

                if (Convert.ToDouble(thisArray[thisIndex++]) != Convert.ToDouble(otherValue))
                {
                    return false;
                }
            }

            return thisIndex == thisArrayLength;
        }
        //public static bool SequenceEqual<T>(this INumericArray thisArray, IEnumerable<T> otherEnumerable)
        //    where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

        //    if (thisArray == null)
        //    {
        //        throw new ArgumentNullException(nameof(thisArray));
        //    }

        //    if (otherEnumerable == null)
        //    {
        //        throw new ArgumentNullException(nameof(otherEnumerable));
        //    }

        //    int thisIndex = 0;
        //    int thisArrayLength = thisArray.Length;

        //    foreach (var otherValue in otherEnumerable)
        //    {
        //        if (thisIndex == thisArrayLength)
        //        {
        //            return false;
        //        }

        //        if (thisArray[thisIndex++] != otherValue.ToDouble(null))
        //        {
        //            return false;
        //        }
        //    }

        //    return thisIndex == thisArrayLength;
        //}
        public static bool SequenceEqual(this INumericArray thisArray, INumericArray otherArray) {
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
                return false;
            }

            for (int i = 0; i < thisArray.Length; i++)
            {
                if (thisArray[i] != otherArray[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}