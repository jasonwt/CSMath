namespace NumericArrays.Extensions.Tests;

using NumericArrays.Types;

[TestClass()]
public class ReductionExtensionsTests {
    [TestMethod()]
    public void MinTests() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleMinArrayNoAxis = int32Array.Min();
        Assert.AreEqual(doubleMinArrayNoAxis, 1.0);

        var longMinArrayAxis0 = int32Array.Min<long>(0);
        Assert.IsTrue(longMinArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longMinArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longMinArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMinArrayAxis0.Length, 12);
        Assert.IsTrue(longMinArrayAxis0.SequenceEqual([
            1, 2, 3, 4,
            5, 6, 7, 8,
            9, 10, 11, 12
        ]));

        var floatMinArrayAxis1 = int32Array.Min<float>(1);
        Console.WriteLine(floatMinArrayAxis1);
        Assert.IsTrue(floatMinArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatMinArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatMinArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatMinArrayAxis1.Length, 8);
        Assert.IsTrue(floatMinArrayAxis1.SequenceEqual([
            1.0f, 2.0f, 3.0f, 4.0f,
            13.0f, 14.0f, 15.0f, 16.0f
        ]));

        var shortMinArrayAxis2 = int32Array.Min<short>(2);
        Assert.IsTrue(shortMinArrayAxis2.Shape.SequenceEqual([2, 3]));
        Assert.IsTrue(shortMinArrayAxis2.Strides.SequenceEqual([3, 1]));
        Assert.AreEqual(shortMinArrayAxis2.ValueType, ArrayValueType.Int16);
        Assert.AreEqual(shortMinArrayAxis2.Length, 6);
        Assert.IsTrue(shortMinArrayAxis2.SequenceEqual([
            1, 5, 9,
            13, 17, 21
        ]));
    }

    [TestMethod()]
    public void MaxTests() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleMaxArrayNoAxis = int32Array.Max();
        Assert.AreEqual(doubleMaxArrayNoAxis, 24.0);

        var longMaxArrayAxis0 = int32Array.Max<long>(0);
        Assert.IsTrue(longMaxArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longMaxArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longMaxArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMaxArrayAxis0.Length, 12);
        Assert.IsTrue(longMaxArrayAxis0.SequenceEqual([
            13, 14, 15, 16,
            17, 18, 19, 20,
            21, 22, 23, 24
        ]));

        var floatMaxArrayAxis1 = int32Array.Max<float>(1);
        Console.WriteLine(floatMaxArrayAxis1);
        Assert.IsTrue(floatMaxArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatMaxArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatMaxArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatMaxArrayAxis1.Length, 8);
        Assert.IsTrue(floatMaxArrayAxis1.SequenceEqual([
            9.0f, 10.0f, 11.0f, 12.0f,
            21.0f, 22.0f, 23.0f, 24.0f
        ]));

        var shortMaxArrayAxis2 = int32Array.Max<short>(2);
        Assert.IsTrue(shortMaxArrayAxis2.Shape.SequenceEqual([2, 3]));
        Assert.IsTrue(shortMaxArrayAxis2.Strides.SequenceEqual([3, 1]));
        Assert.AreEqual(shortMaxArrayAxis2.ValueType, ArrayValueType.Int16);
        Assert.AreEqual(shortMaxArrayAxis2.Length, 6);
        Assert.IsTrue(shortMaxArrayAxis2.SequenceEqual([
            4, 8, 12,
            16, 20, 24
        ]));
    }

    [TestMethod()]
    public void MeanTests() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleMeanArrayNoAxis = int32Array.Mean<double>();
        Assert.AreEqual(doubleMeanArrayNoAxis, 12.5);

        var longMeanArrayAxis0 = int32Array.Mean<long>(0);
        Assert.IsTrue(longMeanArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longMeanArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longMeanArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMeanArrayAxis0.Length, 12);
        Assert.IsTrue(longMeanArrayAxis0.SequenceEqual([
            7, 8, 9, 10,
            11, 12, 13, 14,
            15, 16, 17, 18
        ]));

        var floatMeanArrayAxis1 = int32Array.Mean<float>(1);
        Console.WriteLine(floatMeanArrayAxis1);
        Assert.IsTrue(floatMeanArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatMeanArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatMeanArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatMeanArrayAxis1.Length, 8);
        Assert.IsTrue(floatMeanArrayAxis1.SequenceEqual([
            5.0f, 6.0f, 7.0f, 8.0f,
            17.0f, 18.0f, 19.0f, 20.0f
        ]));

        var shortMeanArrayAxis2 = int32Array.Mean<short>(2);
        Assert.IsTrue(shortMeanArrayAxis2.Shape.SequenceEqual([2, 3]));
        Assert.IsTrue(shortMeanArrayAxis2.Strides.SequenceEqual([3, 1]));
        Assert.AreEqual(shortMeanArrayAxis2.ValueType, ArrayValueType.Int16);
        Assert.AreEqual(shortMeanArrayAxis2.Length, 6);
        Assert.IsTrue(shortMeanArrayAxis2.SequenceEqual([
            2, 6, 10,
            14, 18, 22
        ]));
    }

    [TestMethod()]
    public void MedianTests() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleMedianArrayNoAxis = int32Array.Median<double>();
        Assert.AreEqual(doubleMedianArrayNoAxis, 12.5);

        var longMedianArrayAxis0 = int32Array.Median<long>(0);
        Assert.IsTrue(longMedianArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longMedianArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longMedianArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMedianArrayAxis0.Length, 12);
        Assert.IsTrue(longMedianArrayAxis0.SequenceEqual([
            7, 8, 9, 10,
        11, 12, 13, 14,
        15, 16, 17, 18
        ]));

        var floatMedianArrayAxis1 = int32Array.Median<float>(1);
        Console.WriteLine(floatMedianArrayAxis1);
        Assert.IsTrue(floatMedianArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatMedianArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatMedianArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatMedianArrayAxis1.Length, 8);
        Assert.IsTrue(floatMedianArrayAxis1.SequenceEqual([
            5.0f, 6.0f, 7.0f, 8.0f,
        17.0f, 18.0f, 19.0f, 20.0f
        ]));

        var shortMedianArrayAxis2 = int32Array.Median<short>(2);
        Assert.IsTrue(shortMedianArrayAxis2.Shape.SequenceEqual([2, 3]));
        Assert.IsTrue(shortMedianArrayAxis2.Strides.SequenceEqual([3, 1]));
        Assert.AreEqual(shortMedianArrayAxis2.ValueType, ArrayValueType.Int16);
        Assert.AreEqual(shortMedianArrayAxis2.Length, 6);
        Assert.IsTrue(shortMedianArrayAxis2.SequenceEqual([
            2, 6, 10,
        14, 18, 22
        ]));
    }

    [TestMethod()]
    public void SumTests() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleSumArrayNoAxis = int32Array.Sum<double>();
        Assert.AreEqual(doubleSumArrayNoAxis, 300.0);

        var longSumArrayAxis0 = int32Array.Sum<long>(0);
        Assert.IsTrue(longSumArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longSumArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longSumArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longSumArrayAxis0.Length, 12);
        Assert.IsTrue(longSumArrayAxis0.SequenceEqual([
            14, 16, 18, 20,
            22, 24, 26, 28,
            30, 32, 34, 36
        ]));

        var floatSumArrayAxis1 = int32Array.Sum<float>(1);
        Console.WriteLine(floatSumArrayAxis1);
        Assert.IsTrue(floatSumArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatSumArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatSumArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatSumArrayAxis1.Length, 8);
        Assert.IsTrue(floatSumArrayAxis1.SequenceEqual([
            15.0f, 18.0f, 21.0f, 24.0f,
            51.0f, 54.0f, 57.0f, 60.0f
        ]));

        var shortSumArrayAxis2 = int32Array.Sum<short>(2);
        Assert.IsTrue(shortSumArrayAxis2.Shape.SequenceEqual([2, 3]));
        Assert.IsTrue(shortSumArrayAxis2.Strides.SequenceEqual([3, 1]));
        Assert.AreEqual(shortSumArrayAxis2.ValueType, ArrayValueType.Int16);
        Assert.AreEqual(shortSumArrayAxis2.Length, 6);
        Assert.IsTrue(shortSumArrayAxis2.SequenceEqual([
            10, 26, 42,
            58, 74, 90
        ]));
    }

    [TestMethod()]
    public void ProdTests() {
        int[] testValues = Enumerable.Range(1, 6).ToArray();
        var int32Array = NA.Construct<int>([2, 3], testValues);

        var doubleMeanArrayNoAxis = int32Array.Prod<double>(null);
        Assert.AreEqual(doubleMeanArrayNoAxis, 720.0);

        var longMeanArrayAxis0 = int32Array.Prod<long>(0);
        Assert.IsTrue(longMeanArrayAxis0.Shape.SequenceEqual([3]));
        Assert.IsTrue(longMeanArrayAxis0.Strides.SequenceEqual([1]));
        Assert.AreEqual(longMeanArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMeanArrayAxis0.Length, 3);
        Assert.IsTrue(longMeanArrayAxis0.SequenceEqual([
            4, 10, 18
        ]));

        var floatMeanArrayAxis1 = int32Array.Prod<float>(1);
        Console.WriteLine(floatMeanArrayAxis1);
        Assert.IsTrue(floatMeanArrayAxis1.Shape.SequenceEqual([2]));
        Assert.IsTrue(floatMeanArrayAxis1.Strides.SequenceEqual([1]));
        Assert.AreEqual(floatMeanArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatMeanArrayAxis1.Length, 2);
        Assert.IsTrue(floatMeanArrayAxis1.SequenceEqual([
            6.0f, 120.0f
        ]));
    }

    [TestMethod()]
    public void StdTests() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleStdArrayNoAxis = int32Array.Std<double>();
        Assert.AreEqual(doubleStdArrayNoAxis, 6.922186552431729);

        var longStdArrayAxis0 = int32Array.Std<long>(0);
        Assert.IsTrue(longStdArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longStdArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longStdArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longStdArrayAxis0.Length, 12);
        Assert.IsTrue(longStdArrayAxis0.SequenceEqual([
            6, 6, 6, 6,
            6, 6, 6, 6,
            6, 6, 6, 6
        ]));

        var floatStdArrayAxis1 = int32Array.Std<float>(1);
        Console.WriteLine(floatStdArrayAxis1);
        Assert.IsTrue(floatStdArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatStdArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatStdArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatStdArrayAxis1.Length, 8);
        Assert.IsTrue(floatStdArrayAxis1.SequenceEqual([
            3.265986323710904f, 3.265986323710904f, 3.265986323710904f, 3.265986323710904f,
            3.265986323710904f, 3.265986323710904f, 3.265986323710904f, 3.265986323710904f
        ]));

        var shortStdArrayAxis2 = int32Array.Std<short>(2);
        Assert.IsTrue(shortStdArrayAxis2.Shape.SequenceEqual([2, 3]));
        Assert.IsTrue(shortStdArrayAxis2.Strides.SequenceEqual([3, 1]));
        Assert.AreEqual(shortStdArrayAxis2.ValueType, ArrayValueType.Int16);
        Assert.AreEqual(shortStdArrayAxis2.Length, 6);
        Assert.IsTrue(shortStdArrayAxis2.SequenceEqual([
            1,1,1,
            1,1,1
        ]));
    }

    [TestMethod()]
    public void VarTests() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleVarArrayNoAxis = int32Array.Var<double>();
        Assert.AreEqual(doubleVarArrayNoAxis, 47.916666666666664);

        var longVarArrayAxis0 = int32Array.Var<long>(0);
        Assert.IsTrue(longVarArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longVarArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longVarArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longVarArrayAxis0.Length, 12);
        Assert.IsTrue(longVarArrayAxis0.SequenceEqual([
            36, 36, 36, 36,
            36, 36, 36, 36,
            36, 36, 36, 36
        ]));

        var floatVarArrayAxis1 = int32Array.Var<float>(1);
        Console.WriteLine(floatVarArrayAxis1);
        Assert.IsTrue(floatVarArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatVarArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatVarArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatVarArrayAxis1.Length, 8);
        Assert.IsTrue(floatVarArrayAxis1.SequenceEqual([
            10.666666666666666f, 10.666666666666666f, 10.666666666666666f, 10.666666666666666f,
            10.666666666666666f, 10.666666666666666f, 10.666666666666666f, 10.666666666666666f
        ]));

        var shortVarArrayAxis2 = int32Array.Var<short>(2);
        Assert.IsTrue(shortVarArrayAxis2.Shape.SequenceEqual([2, 3]));
        Assert.IsTrue(shortVarArrayAxis2.Strides.SequenceEqual([3, 1]));
        Assert.AreEqual(shortVarArrayAxis2.ValueType, ArrayValueType.Int16);
        Assert.AreEqual(shortVarArrayAxis2.Length, 6);
        Assert.IsTrue(shortVarArrayAxis2.SequenceEqual([
            1,1,1,
            1,1,1
        ]));
    }

    [TestMethod()]
    public void ArgMinTests() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleArgMinArrayNoAxis = int32Array.ArgMin();
        Assert.AreEqual(doubleArgMinArrayNoAxis, 0);

        var longArgMinArrayAxis0 = int32Array.ArgMin<long>(0);
        Assert.IsTrue(longArgMinArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longArgMinArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longArgMinArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longArgMinArrayAxis0.Length, 12);
        Assert.IsTrue(longArgMinArrayAxis0.SequenceEqual([
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0
        ]));

        var floatArgMinArrayAxis1 = int32Array.ArgMin<float>(1);
        Console.WriteLine(floatArgMinArrayAxis1);
        Assert.IsTrue(floatArgMinArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatArgMinArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatArgMinArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatArgMinArrayAxis1.Length, 8);
        Assert.IsTrue(floatArgMinArrayAxis1.SequenceEqual([
            0.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 0.0f
        ]));

        var shortArgMinArrayAxis2 = int32Array.ArgMin<short>(2);
        Assert.IsTrue(shortArgMinArrayAxis2.Shape.SequenceEqual([2, 3]));
        Assert.IsTrue(shortArgMinArrayAxis2.Strides.SequenceEqual([3, 1]));
        Assert.AreEqual(shortArgMinArrayAxis2.ValueType, ArrayValueType.Int16);
        Assert.AreEqual(shortArgMinArrayAxis2.Length, 6);
        Assert.IsTrue(shortArgMinArrayAxis2.SequenceEqual([
            0, 0, 0,
            0, 0, 0
        ]));
    }

    [TestMethod()]
    public void ArgMaxTests() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleArgMaxArrayNoAxis = int32Array.ArgMax();
        Assert.AreEqual(doubleArgMaxArrayNoAxis, 23);

        var longArgMaxArrayAxis0 = int32Array.ArgMax<long>(0);
        Assert.IsTrue(longArgMaxArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longArgMaxArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longArgMaxArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longArgMaxArrayAxis0.Length, 12);
        Assert.IsTrue(longArgMaxArrayAxis0.SequenceEqual([
            1, 1, 1, 1,
            1, 1, 1, 1,
            1, 1, 1, 1
        ]));

        var floatArgMaxArrayAxis1 = int32Array.ArgMax<float>(1);
        Console.WriteLine(floatArgMaxArrayAxis1);
        Assert.IsTrue(floatArgMaxArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatArgMaxArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatArgMaxArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatArgMaxArrayAxis1.Length, 8);
        Assert.IsTrue(floatArgMaxArrayAxis1.SequenceEqual([
            2.0f, 2.0f, 2.0f, 2.0f,
            2.0f, 2.0f, 2.0f, 2.0f
        ]));

        var shortArgMaxArrayAxis2 = int32Array.ArgMax<short>(2);
        Assert.IsTrue(shortArgMaxArrayAxis2.Shape.SequenceEqual([2, 3]));
        Assert.IsTrue(shortArgMaxArrayAxis2.Strides.SequenceEqual([3, 1]));
        Assert.AreEqual(shortArgMaxArrayAxis2.ValueType, ArrayValueType.Int16);
        Assert.AreEqual(shortArgMaxArrayAxis2.Length, 6);
        Assert.IsTrue(shortArgMaxArrayAxis2.SequenceEqual([
            3,3,3,
            3,3,3
        ]));
    }
}