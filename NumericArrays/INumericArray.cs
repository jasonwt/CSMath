namespace NumericArrays {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using NumericArrays.Types;

    public interface INumericArray : ICloneable, IDisposable, IEnumerable {
        #region Operator Overloads
        public static INumericArray operator +(INumericArray leftArray, INumericArray rightArray) => leftArray.Add(rightArray);
        //public static INumericArray operator +(INumericArray leftArray, ValueType rightValue) => leftArray.Add(rightValue);
        public static INumericArray operator -(INumericArray leftArray, INumericArray rightArray) => leftArray.Subtract(rightArray);
        //public static INumericArray operator -(INumericArray leftArray, ValueType rightValue) => leftArray.Subtract(rightValue);
        public static INumericArray operator *(INumericArray leftArray, INumericArray rightArray) => leftArray.Multiply(rightArray);
        //public static INumericArray operator *(INumericArray leftArray, ValueType rightValue) => leftArray.Multiply(rightValue);
        public static INumericArray operator /(INumericArray leftArray, INumericArray rightArray) => leftArray.Divide(rightArray);
        //public static INumericArray operator /(INumericArray leftArray, ValueType rightValue) => leftArray.Divide(rightValue);
        public static INumericArray operator %(INumericArray leftArray, INumericArray rightArray) => leftArray.Mod(rightArray);
        //public static INumericArray operator %(INumericArray leftArray, ValueType rightValue) => leftArray.Mod(rightValue);
        public static INumericArray operator -(INumericArray array) => array.Negate();
        #endregion

        #region Properties
        double this[int linearIndex] { get; set; }
        double this[params int[] indices] { get; set; }
        INumericArray this[string slicingMask] { get; set; }

        int[] Shape { get; }
        int[] Strides { get; }
        int Rank { get; }
        int Length { get; }

        ArrayValueType ValueType { get; }
        #endregion

        #region Methods
        void Reshape(int[] newShape);
        int ComputeLinearIndex(int[] indices);
        int[] ComputeIndices(int linearIndex);
        new INumericArray Clone();
        #endregion
    }

    public interface INumericArray<T> : INumericArray, IEnumerable<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {
        #region Operator Overloads
        public static INumericArray<T> operator +(INumericArray<T> leftArray, INumericArray rightArray) => leftArray.Add(rightArray);
        //public static INumericArray<T> operator +(INumericArray<T> leftArray, ValueType rightValue) => leftArray.Add(rightValue);
        public static INumericArray<T> operator -(INumericArray<T> leftArray, INumericArray rightArray) => leftArray.Subtract(rightArray);
        //public static INumericArray<T> operator -(INumericArray<T> leftArray, ValueType rightValue) => leftArray.Subtract(rightValue);
        public static INumericArray<T> operator *(INumericArray<T> leftArray, INumericArray rightArray) => leftArray.Multiply(rightArray);
        //public static INumericArray<T> operator *(INumericArray<T> leftArray, ValueType rightValue) => leftArray.Multiply(rightValue);
        public static INumericArray<T> operator /(INumericArray<T> leftArray, INumericArray rightArray) => leftArray.Divide(rightArray);
        //public static INumericArray<T> operator /(INumericArray<T> leftArray, ValueType rightValue) => leftArray.Divide(rightValue);
        public static INumericArray<T> operator %(INumericArray<T> leftArray, INumericArray rightArray) => leftArray.Mod(rightArray);
        //public static INumericArray<T> operator %(INumericArray<T> leftArray, ValueType rightValue) => leftArray.Mod(rightValue);
        public static INumericArray<T> operator -(INumericArray<T> array) => array.Negate();
        #endregion

        #region Properties
        new T this[int linearIndex] { get; set; }
        new T this[params int[] indices] { get; set; }
        new INumericArray<T> this[string slicingMask] { get; set; }
        #endregion

        #region Methods
        new INumericArray<T> Clone();
        #endregion
    }
}