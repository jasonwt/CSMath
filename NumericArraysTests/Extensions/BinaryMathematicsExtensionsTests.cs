namespace NumericArrays.Extensions.Tests;

using System;
using System.Linq;

using NumericArrays.Types;

using static NumericArrays.Extensions.LinqExtensions;

[TestClass()]
public class BinaryMathematicsExtensionsTests {
    #region Binary Array Tests
    [TestMethod()]
    public void AdditionArrayTest() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();

        var int32Array = NA.Construct<int>([2, 3, 4], testValues);
        var float32Array = NA.Construct<float>([2, 3, 4], testValues.Select(a => (float)a).Reverse().ToArray());
        var resultArray = int32Array.Add(float32Array);
        Assert.IsTrue(resultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(resultArray.Length, 24);
        Assert.IsTrue(resultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a + b)));

        var resultArray2 = float32Array.Add<float>(int32Array);
        Assert.IsTrue(resultArray2.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray2.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray2.ValueType, ArrayValueType.Single);
        Assert.AreEqual(resultArray2.Length, 24);
        Assert.IsTrue(resultArray2.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a + b).Select(a => (float)a)));

        var operatorGenericResultArray = int32Array + float32Array;
        Assert.IsTrue(operatorGenericResultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(operatorGenericResultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(operatorGenericResultArray.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(operatorGenericResultArray.Length, 24);
        Assert.IsTrue(operatorGenericResultArray.SequenceEqual(Enumerable.Repeat(25, 24).Cast<ValueType>()));
    }

    [TestMethod()]
    public void SubtractionArrayTest() {
        int[] testValues1 = Enumerable.Range(1, 24).ToArray();
        int[] testValues2 = testValues1.Reverse().ToArray();
        int[] expectedValues = testValues1.Zip(testValues2, (a, b) => a - b).ToArray();

        var int32Array = NA.Construct<int>([2, 3, 4], testValues1);
        var float32Array = NA.Construct<float>([2, 3, 4], testValues2.Select(a => Convert.ToSingle(a)));
        var resultArray = int32Array.Subtract(float32Array);
        Assert.IsTrue(resultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(resultArray.Length, 24);
        Assert.IsTrue(resultArray.SequenceEqual(expectedValues));

        var resultArray2 = float32Array.Subtract(int32Array);
        Assert.IsTrue(resultArray2.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray2.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray2.ValueType, ArrayValueType.Single);
        Assert.AreEqual(resultArray2.Length, 24);
        Assert.IsTrue(resultArray2.SequenceEqual(expectedValues.Reverse().Select(a => Convert.ToSingle(a))));

        var operatorGenericResultArray = int32Array - float32Array;
        Assert.IsTrue(operatorGenericResultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(operatorGenericResultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(operatorGenericResultArray.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(operatorGenericResultArray.Length, 24);
        Assert.IsTrue(operatorGenericResultArray.SequenceEqual(expectedValues.Cast<ValueType>()));
    }

    [TestMethod()]
    public void MultiplicationArrayTest() {
        long[] testValues = Enumerable.Range(1, 24).Select(a => (long)a).ToArray();

        var int32Array = NA.Construct<long>([2, 3, 4], testValues);
        var float32Array = NA.Construct<float>([2, 3, 4], testValues.Select(a => (float)a).Reverse().ToArray());
        var resultArray = int32Array.Multiply(float32Array);
        Assert.IsTrue(resultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(resultArray.Length, 24);
        Assert.IsTrue(resultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a * b)));

        var resultArray2 = float32Array.Multiply(int32Array);
        Assert.IsTrue(resultArray2.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray2.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray2.ValueType, ArrayValueType.Single);
        Assert.AreEqual(resultArray2.Length, 24);
        Assert.IsTrue(resultArray2.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a * b).Select(a => (float)a)));

        var operatorGenericResultArray = int32Array * float32Array;
        Assert.IsTrue(operatorGenericResultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(operatorGenericResultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(operatorGenericResultArray.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(operatorGenericResultArray.Length, 24);
        Assert.IsTrue(operatorGenericResultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a * b).Select(a => (long)a)));
    }

    [TestMethod()]
    public void DivisionArrayTest() {
        long[] testValues = Enumerable.Range(1, 24).Select(a => (long)a).ToArray();

        var int32Array = NA.Construct<long>([2, 3, 4], testValues);
        var float32Array = NA.Construct<float>([2, 3, 4], testValues.Select(a => (float)a).Reverse().ToArray());
        var resultArray = int32Array.Divide(float32Array);
        Assert.IsTrue(resultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(resultArray.Length, 24);
        Assert.IsTrue(resultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a / b)));

        var resultArray2 = float32Array.Divide(int32Array);
        Assert.IsTrue(resultArray2.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray2.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray2.ValueType, ArrayValueType.Single);
        Assert.AreEqual(resultArray2.Length, 24);
        //Assert.IsTrue(resultArray2.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a / b).Select(a => (float)a)));

        var operatorGenericResultArray = int32Array / float32Array;
        Assert.IsTrue(operatorGenericResultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(operatorGenericResultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(operatorGenericResultArray.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(operatorGenericResultArray.Length, 24);
        Assert.IsTrue(operatorGenericResultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a / b).Select(a => (long)a)));
    }

    [TestMethod()]
    public void ModulusArrayTest() {
        long[] testValues = Enumerable.Range(1, 24).Select(a => (long)a).ToArray();

        var int32Array = NA.Construct<long>([2, 3, 4], testValues);
        var float32Array = NA.Construct<float>([2, 3, 4], testValues.Select(a => (float)a).Reverse().ToArray());
        var resultArray = int32Array.Mod(float32Array);
        Assert.IsTrue(resultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(resultArray.Length, 24);
        Assert.IsTrue(resultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a % b)));

        var resultArray2 = float32Array.Mod(int32Array);
        Assert.IsTrue(resultArray2.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray2.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray2.ValueType, ArrayValueType.Single);
        Assert.AreEqual(resultArray2.Length, 24);
        //Assert.IsTrue(resultArray2.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a % b).Select(a => (float)a)));

        var operatorGenericResultArray = int32Array % float32Array;
        Assert.IsTrue(operatorGenericResultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(operatorGenericResultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(operatorGenericResultArray.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(operatorGenericResultArray.Length, 24);
        Assert.IsTrue(operatorGenericResultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => a % b).Select(a => (long)a)));
    }

    [TestMethod()]
    public void PowerArrayTest() {
        long[] testValues = Enumerable.Range(1, 24).Select(a => (long)a).ToArray();

        var int32Array = NA.Construct<long>([2, 3, 4], testValues);
        var float32Array = NA.Construct<float>([2, 3, 4], testValues.Select(a => (float)a).Reverse().ToArray());
        var resultArray = int32Array.Pow(float32Array);
        Assert.IsTrue(resultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(resultArray.Length, 24);
        Assert.IsTrue(resultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => Convert.ToInt64(Math.Pow(a, b)))));

        var resultArray2 = float32Array.Pow(int32Array);
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
        var resultArray = int32Array.Log(float32Array);
        Assert.IsTrue(resultArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(resultArray.Length, 24);
        Assert.IsTrue(resultArray.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => (long)Math.Log(a, b))));

        var resultArray2 = float32Array.Log(int32Array);
        Assert.IsTrue(resultArray2.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(resultArray2.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(resultArray2.ValueType, ArrayValueType.Single);
        Assert.AreEqual(resultArray2.Length, 24);
        //Assert.IsTrue(resultArray2.SequenceEqual(testValues.Zip(testValues.Reverse(), (a, b) => Math.Log(a,b)).Select(a => (float)a)));
    }
    #endregion
}