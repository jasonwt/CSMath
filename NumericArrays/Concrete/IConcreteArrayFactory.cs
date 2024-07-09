namespace NumericArrays.Concrete {
    using System;

    using NumericArrays.Types;

    public interface IConcreteArrayFactory {
        #region Non-Generic Methods
        IConcreteArray Construct(ArrayValueType numericArrayType, int[] shape);
        IConcreteArray Construct(ArrayValueType numericArrayType, int[] shape, Func<int, ValueType> setValueFunc, int requestedThreads = 1) {
            IConcreteArray newArray = Construct(numericArrayType, shape);

            newArray.Fill(setValueFunc, requestedThreads);

            return newArray;
        }
        IConcreteArray Construct(INumericArray otherArray, int requestedThreads = 1) {
            IConcreteArray newArray = Construct(otherArray.ValueType, otherArray.Shape);

            newArray.Fill(otherArray, requestedThreads);

            return newArray;
        }
        IConcreteArray Construct(ArrayValueType numericArrayType, int[] shape, ValueType[] values, int requestedThreads = 1) {
            IConcreteArray newArray = Construct(numericArrayType, shape);

            newArray.Fill(values, requestedThreads);

            return newArray;
        }
        IConcreteArray Construct(ArrayValueType numericArrayType, int[] shape, ValueType value, int requestedThreads = 1) {
            IConcreteArray newArray = Construct(numericArrayType, shape);

            newArray.Fill(value, requestedThreads);

            return newArray;
        }
        #endregion

        #region Generic Methods
        IConcreteArray<T> Construct<T>(int[] shape) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>;
        IConcreteArray<T> Construct<T>(INumericArray otherArray, int requestedThreads = 1)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            IConcreteArray<T> newArray = Construct<T>(otherArray.Shape);

            newArray.Fill(otherArray, requestedThreads);

            return newArray;
        }
        IConcreteArray<T> Construct<T>(int[] shape, Func<int, T> setValueFunc, int requestedThreads = 1)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            IConcreteArray<T> newArray = Construct<T>(shape);

            newArray.Fill(setValueFunc, requestedThreads);

            return newArray;
        }
        IConcreteArray<T> Construct<T>(int[] shape, T[] values, int requestedThreads = 1)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            IConcreteArray<T> newArray = Construct<T>(shape);

            newArray.Fill(values, requestedThreads);

            return newArray;
        }
        IConcreteArray<T> Construct<T>(int[] shape, T value, int requestedThreads = 1)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

            IConcreteArray<T> newArray = Construct<T>(shape);

            newArray.Fill(value, requestedThreads);

            return newArray;
        }
        #endregion
    }
}