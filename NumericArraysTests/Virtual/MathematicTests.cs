namespace NumericArrays.Virtual.Mathematics.Tests;

using System;

using NumericArrays.Types;
using NumericArrays.Virtual.Mathematics.Unary;
using NumericArrays.Virtual.Mathematics.Binary;

using static NumericArrays.Extensions.LinqExtensions;

[TestClass()]
public class MathematicTests {
    #region Unary Array Tests
    [TestMethod()]
    public void SquareRootArrayTest() {
        int[] testValues = Enumerable.Range(0, 24).ToArray();

        var int32Array = NA.Construct<int>([2, 3, 4], testValues);
        Console.WriteLine(int32Array);

        var int32SquareRootArray = new SquareRootArray<int>(int32Array);
        Assert.IsTrue(int32SquareRootArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(int32SquareRootArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(int32SquareRootArray.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(int32SquareRootArray.Length, 24);
        Assert.IsTrue(int32SquareRootArray.SequenceEqual(testValues.Select(a => Convert.ToInt32(Math.Truncate(Math.Sqrt(a))))));

        var singleSquareRootArray = new SquareRootArray<float>(int32Array);
        Assert.IsTrue(singleSquareRootArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(singleSquareRootArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(singleSquareRootArray.ValueType, ArrayValueType.Single);
        Assert.AreEqual(singleSquareRootArray.Length, 24);
        Assert.IsTrue(singleSquareRootArray.SequenceEqual(testValues.Select(a => (float)Math.Sqrt(a))));
    }

    [TestMethod()]
    public void NegationArrayTest() {
        int[] testValues = Enumerable.Range(0, 24).Select(a => a % 2 == 0 ? a : -a).ToArray();

        var int32Array = NA.Construct<int>([2, 3, 4], testValues);
        Console.WriteLine(int32Array);

        var int32NegationArray = new NegationArray<int>(int32Array);
        Assert.IsTrue(int32NegationArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(int32NegationArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(int32NegationArray.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(int32NegationArray.Length, 24);
        Assert.IsTrue(int32NegationArray.SequenceEqual(testValues.Select(a => -a)));

        var singleNegationArray = new NegationArray<float>(int32Array);
        Assert.IsTrue(singleNegationArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(singleNegationArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(singleNegationArray.ValueType, ArrayValueType.Single);
        Assert.AreEqual(singleNegationArray.Length, 24);
        Assert.IsTrue(singleNegationArray.SequenceEqual(testValues.Select(a => -(float)a)));
    }

    [TestMethod()]
    public void AbsoluteValueArrayTest() {
        int[] testValues = Enumerable.Range(0, 24).Select(a => a % 2 == 0 ? a : -a).ToArray();

        var int32Array = NA.Construct<int>([2, 3, 4], testValues);
        Console.WriteLine(int32Array);

        var int32AbsoluteValueArray = new AbsoluteValueArray<int>(int32Array);
        Assert.IsTrue(int32AbsoluteValueArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(int32AbsoluteValueArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(int32AbsoluteValueArray.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(int32AbsoluteValueArray.Length, 24);
        Assert.IsTrue(int32AbsoluteValueArray.SequenceEqual(testValues.Select(a => (int)Math.Abs(a))));

        var singleAbsoluteValueArray = new AbsoluteValueArray<float>(int32Array);
        Assert.IsTrue(singleAbsoluteValueArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(singleAbsoluteValueArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(singleAbsoluteValueArray.ValueType, ArrayValueType.Single);
        Assert.AreEqual(singleAbsoluteValueArray.Length, 24);
        Assert.IsTrue(singleAbsoluteValueArray.SequenceEqual(testValues.Select(a => (float)Math.Abs(a))));
    }
    #endregion

    #region Binary Array Tests
    [TestMethod()]
    public void AdditionArrayTest() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();

        var int32Array = NA.Construct<int>([2, 3, 4], testValues);
        var float32Array = NA.Construct<float>([2, 3, 4], testValues.Select(a => (float)a).Reverse().ToArray());
        var resultArray = new AdditionArray<int>(int32Array, float32Array);
        Assert.IsTrue(resultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(resultArray.Length, 24);
        Assert.IsTrue(resultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a + b)));

        var resultArray2 = new AdditionArray<float>(float32Array, int32Array);
        Assert.IsTrue(resultArray2.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray2.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray2.ValueType, ArrayValueType.Single);
        Assert.AreEqual(resultArray2.Length, 24);
        Assert.IsTrue(resultArray2.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a + b).Select(a => (float)a)));
    }

    [TestMethod()]
    public void SubtractionArrayTest() {
        int[] testValues1 = Enumerable.Range(1, 24).ToArray();
        int[] testValues2 = testValues1.Reverse().ToArray();
        int[] expectedValues = testValues1.Zip(testValues2, (a, b) => a - b).ToArray();

        var int32Array = NA.Construct<int>([2, 3, 4], testValues1);
        var float32Array = NA.Construct<float>([2, 3, 4], testValues2.Select(a => Convert.ToSingle(a)));
        var resultArray = new SubtractionArray<int>(int32Array, float32Array);
        Assert.IsTrue(resultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(resultArray.Length, 24);
        Assert.IsTrue(resultArray.SequenceEqual(expectedValues));

        var resultArray2 = new SubtractionArray<float>(float32Array, int32Array);
        Assert.IsTrue(resultArray2.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray2.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray2.ValueType, ArrayValueType.Single);
        Assert.AreEqual(resultArray2.Length, 24);
        Assert.IsTrue(resultArray2.SequenceEqual(expectedValues.Reverse().Select(a => Convert.ToSingle(a))));
    }

    [TestMethod()]
    public void MultiplicationArrayTest() {
        long[] testValues = Enumerable.Range(1, 24).Select(a => (long)a).ToArray();

        var int32Array = NA.Construct<long>([2, 3, 4], testValues);
        var float32Array = NA.Construct<float>([2, 3, 4], testValues.Select(a => (float)a).Reverse().ToArray());
        var resultArray = new MultiplicationArray<long>(int32Array, float32Array);
        Assert.IsTrue(resultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(resultArray.Length, 24);
        Assert.IsTrue(resultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a * b)));

        var resultArray2 = new MultiplicationArray<float>(float32Array, int32Array);
        Assert.IsTrue(resultArray2.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray2.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray2.ValueType, ArrayValueType.Single);
        Assert.AreEqual(resultArray2.Length, 24);
        Assert.IsTrue(resultArray2.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a * b).Select(a => (float)a)));
    }

    [TestMethod()]
    public void DivisionArrayTest() {
        long[] testValues = Enumerable.Range(1, 24).Select(a => (long)a).ToArray();

        var int32Array = NA.Construct<long>([2, 3, 4], testValues);
        var float32Array = NA.Construct<float>([2, 3, 4], testValues.Select(a => (float)a).Reverse().ToArray());
        var resultArray = new DivisionArray<long>(int32Array, float32Array);
        Assert.IsTrue(resultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(resultArray.Length, 24);
        Assert.IsTrue(resultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a / b)));

        var resultArray2 = new DivisionArray<float>(float32Array, int32Array);
        Assert.IsTrue(resultArray2.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray2.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray2.ValueType, ArrayValueType.Single);
        Assert.AreEqual(resultArray2.Length, 24);
        //Assert.IsTrue(resultArray2.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a / b).Select(a => (float)a)));
    }

    [TestMethod()]
    public void ModulusArrayTest() {
        long[] testValues = Enumerable.Range(1, 24).Select(a => (long)a).ToArray();

        var int32Array = NA.Construct<long>([2, 3, 4], testValues);
        var float32Array = NA.Construct<float>([2, 3, 4], testValues.Select(a => (float)a).Reverse().ToArray());
        var resultArray = new ModuloArray<long>(int32Array, float32Array);
        Assert.IsTrue(resultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(resultArray.Length, 24);
        Assert.IsTrue(resultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a % b)));

        var resultArray2 = new ModuloArray<float>(float32Array, int32Array);
        Assert.IsTrue(resultArray2.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray2.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray2.ValueType, ArrayValueType.Single);
        Assert.AreEqual(resultArray2.Length, 24);
        //Assert.IsTrue(resultArray2.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a % b).Select(a => (float)a)));
    }

    [TestMethod()]
    public void PowerArrayTest() {
        long[] testValues = Enumerable.Range(1, 24).Select(a => (long)a).ToArray();

        var int32Array = NA.Construct<long>([2, 3, 4], testValues);
        var float32Array = NA.Construct<float>([2, 3, 4], testValues.Select(a => (float)a).Reverse().ToArray());
        var resultArray = new PowerArray<long>(int32Array, float32Array);
        Assert.IsTrue(resultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(resultArray.Length, 24);
        Assert.IsTrue(resultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => Convert.ToInt64(Math.Pow(a, b)))));

        var resultArray2 = new PowerArray<float>(float32Array, int32Array);
        Assert.IsTrue(resultArray2.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray2.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray2.ValueType, ArrayValueType.Single);
        Assert.AreEqual(resultArray2.Length, 24);
        //Assert.IsTrue(resultArray2.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => Math.Pow(a,b)).Select(a => (float)a)));
    }

    [TestMethod()]
    public void LogarithmArrayTest() {
        long[] testValues = Enumerable.Range(1, 24).Select(a => (long)a).ToArray();

        var int32Array = NA.Construct<long>([2, 3, 4], testValues);
        var float32Array = NA.Construct<float>([2, 3, 4], testValues.Select(a => (float)a).Reverse().ToArray());
        var resultArray = new LogarithmArray<long>(int32Array, float32Array);
        Assert.IsTrue(resultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(resultArray.Length, 24);
        Assert.IsTrue(resultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => (long)Math.Log(a, b))));

        var resultArray2 = new LogarithmArray<float>(float32Array, int32Array);
        Assert.IsTrue(resultArray2.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray2.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray2.ValueType, ArrayValueType.Single);
        Assert.AreEqual(resultArray2.Length, 24);
        //Assert.IsTrue(resultArray2.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => Math.Log(a,b)).Select(a => (float)a)));
    }
    #endregion
}