namespace NumericArrays.Virtual.Reductions.Tests;

using System;

using NumericArrays.Types;

using static NumericArrays.Extensions.LinqExtensions;

[TestClass()]
public class ReductionTests {
    [TestMethod()]
    public void MinArrayTest() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleMinArrayNoAxis = new MinArray<double>(int32Array, null);
        Assert.IsTrue(doubleMinArrayNoAxis.Shape.SequenceEqual([1]));
        Assert.IsTrue(doubleMinArrayNoAxis.Strides.SequenceEqual([1]));
        Assert.AreEqual(doubleMinArrayNoAxis.ValueType, ArrayValueType.Double);
        Assert.AreEqual(doubleMinArrayNoAxis.Length, 1);
        Assert.IsTrue(doubleMinArrayNoAxis.SequenceEqual([1.0]));
        
        var longMinArrayAxis0 = new MinArray<long>(int32Array, 0);
        Assert.IsTrue(longMinArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longMinArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longMinArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMinArrayAxis0.Length, 12);
        Assert.IsTrue(longMinArrayAxis0.SequenceEqual([
            1, 2, 3, 4,
            5, 6, 7, 8,
            9, 10, 11, 12
        ]));

        var floatMinArrayAxis1 = new MinArray<float>(int32Array, 1);
        Console.WriteLine(floatMinArrayAxis1);
        Assert.IsTrue(floatMinArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatMinArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatMinArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatMinArrayAxis1.Length, 8);
        Assert.IsTrue(floatMinArrayAxis1.SequenceEqual([
            1.0f, 2.0f, 3.0f, 4.0f,
            13.0f, 14.0f, 15.0f, 16.0f
        ]));

        var shortMinArrayAxis2 = new MinArray<short>(int32Array, 2);
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
    public void MaxArrayTest() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleMaxArrayNoAxis = new MaxArray<double>(int32Array, null);
        Assert.IsTrue(doubleMaxArrayNoAxis.Shape.SequenceEqual([1]));
        Assert.IsTrue(doubleMaxArrayNoAxis.Strides.SequenceEqual([1]));
        Assert.AreEqual(doubleMaxArrayNoAxis.ValueType, ArrayValueType.Double);
        Assert.AreEqual(doubleMaxArrayNoAxis.Length, 1);
        Assert.IsTrue(doubleMaxArrayNoAxis.SequenceEqual([24.0]));

        var longMaxArrayAxis0 = new MaxArray<long>(int32Array, 0);
        Assert.IsTrue(longMaxArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longMaxArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longMaxArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMaxArrayAxis0.Length, 12);
        Assert.IsTrue(longMaxArrayAxis0.SequenceEqual([
            13, 14, 15, 16,
            17, 18, 19, 20,
            21, 22, 23, 24
        ]));

        var floatMaxArrayAxis1 = new MaxArray<float>(int32Array, 1);
        Console.WriteLine(floatMaxArrayAxis1);
        Assert.IsTrue(floatMaxArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatMaxArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatMaxArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatMaxArrayAxis1.Length, 8);
        Assert.IsTrue(floatMaxArrayAxis1.SequenceEqual([
            9.0f, 10.0f, 11.0f, 12.0f,
            21.0f, 22.0f, 23.0f, 24.0f
        ]));

        var shortMaxArrayAxis2 = new MaxArray<short>(int32Array, 2);
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
    public void MeanArrayTest() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleMeanArrayNoAxis = new MeanArray<double>(int32Array, null);
        Assert.IsTrue(doubleMeanArrayNoAxis.Shape.SequenceEqual([1]));
        Assert.IsTrue(doubleMeanArrayNoAxis.Strides.SequenceEqual([1]));
        Assert.AreEqual(doubleMeanArrayNoAxis.ValueType, ArrayValueType.Double);
        Assert.AreEqual(doubleMeanArrayNoAxis.Length, 1);
        Assert.IsTrue(doubleMeanArrayNoAxis.SequenceEqual([12.5]));

        var longMeanArrayAxis0 = new MeanArray<long>(int32Array, 0);
        Assert.IsTrue(longMeanArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longMeanArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longMeanArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMeanArrayAxis0.Length, 12);
        Assert.IsTrue(longMeanArrayAxis0.SequenceEqual([
            7, 8, 9, 10,
            11, 12, 13, 14,
            15, 16, 17, 18
        ]));

        var floatMeanArrayAxis1 = new MeanArray<float>(int32Array, 1);
        Assert.IsTrue(floatMeanArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatMeanArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatMeanArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatMeanArrayAxis1.Length, 8);
        Assert.IsTrue(floatMeanArrayAxis1.SequenceEqual([
            5.0f, 6.0f, 7.0f, 8.0f,
            17.0f, 18.0f, 19.0f, 20.0f
        ]));

        var shortMeanArrayAxis2 = new MeanArray<short>(int32Array, 2);
        Console.WriteLine(shortMeanArrayAxis2);
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
    public void MedianArrayTest() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleMeanArrayNoAxis = new MedianArray<double>(int32Array, null);
        Assert.IsTrue(doubleMeanArrayNoAxis.Shape.SequenceEqual([1]));
        Assert.IsTrue(doubleMeanArrayNoAxis.Strides.SequenceEqual([1]));
        Assert.AreEqual(doubleMeanArrayNoAxis.ValueType, ArrayValueType.Double);
        Assert.AreEqual(doubleMeanArrayNoAxis.Length, 1);
        Assert.IsTrue(doubleMeanArrayNoAxis.SequenceEqual([12.5]));

        var longMeanArrayAxis0 = new MedianArray<long>(int32Array, 0);
        Assert.IsTrue(longMeanArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longMeanArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longMeanArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMeanArrayAxis0.Length, 12);
        Assert.IsTrue(longMeanArrayAxis0.SequenceEqual([
            7, 8, 9, 10,
            11, 12, 13, 14,
            15, 16, 17, 18
        ]));

        var floatMeanArrayAxis1 = new MedianArray<float>(int32Array, 1);
        Assert.IsTrue(floatMeanArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatMeanArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatMeanArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatMeanArrayAxis1.Length, 8);
        Assert.IsTrue(floatMeanArrayAxis1.SequenceEqual([
            5.0f, 6.0f, 7.0f, 8.0f,
            17.0f, 18.0f, 19.0f, 20.0f
        ]));

        var shortMeanArrayAxis2 = new MedianArray<short>(int32Array, 2);
        Console.WriteLine(shortMeanArrayAxis2);
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
    public void SumArrayTest() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleMeanArrayNoAxis = new SumArray<double>(int32Array, null);
        Assert.IsTrue(doubleMeanArrayNoAxis.Shape.SequenceEqual([1]));
        Assert.IsTrue(doubleMeanArrayNoAxis.Strides.SequenceEqual([1]));
        Assert.AreEqual(doubleMeanArrayNoAxis.ValueType, ArrayValueType.Double);
        Assert.AreEqual(doubleMeanArrayNoAxis.Length, 1);
        Assert.IsTrue(doubleMeanArrayNoAxis.SequenceEqual([300.0]));

        var longMeanArrayAxis0 = new SumArray<long>(int32Array, 0);
        Assert.IsTrue(longMeanArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longMeanArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longMeanArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMeanArrayAxis0.Length, 12);
        Assert.IsTrue(longMeanArrayAxis0.SequenceEqual([
            14, 16, 18, 20,
            22, 24, 26, 28,
            30, 32, 34, 36
        ]));

        var floatMeanArrayAxis1 = new SumArray<float>(int32Array, 1);
        Assert.IsTrue(floatMeanArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatMeanArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatMeanArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatMeanArrayAxis1.Length, 8);
        Assert.IsTrue(floatMeanArrayAxis1.SequenceEqual([
            15.0f, 18.0f, 21.0f, 24.0f,
            51.0f, 54.0f, 57.0f, 60.0f
        ]));

        var shortMeanArrayAxis2 = new SumArray<short>(int32Array, 2);
        Console.WriteLine(shortMeanArrayAxis2);
        Assert.IsTrue(shortMeanArrayAxis2.Shape.SequenceEqual([2, 3]));
        Assert.IsTrue(shortMeanArrayAxis2.Strides.SequenceEqual([3, 1]));
        Assert.AreEqual(shortMeanArrayAxis2.ValueType, ArrayValueType.Int16);
        Assert.AreEqual(shortMeanArrayAxis2.Length, 6);
        Assert.IsTrue(shortMeanArrayAxis2.SequenceEqual([
            10, 26, 42,
            58, 74, 90
        ]));
    }

    [TestMethod()]
    public void ProductArrayTest() {
        int[] testValues = Enumerable.Range(1, 6).ToArray();
        var int32Array = NA.Construct<int>([2, 3], testValues);

        var doubleMeanArrayNoAxis = new ProductArray<double>(int32Array, null);
        Assert.IsTrue(doubleMeanArrayNoAxis.Shape.SequenceEqual([1]));
        Assert.IsTrue(doubleMeanArrayNoAxis.Strides.SequenceEqual([1]));
        Assert.AreEqual(doubleMeanArrayNoAxis.ValueType, ArrayValueType.Double);
        Assert.AreEqual(doubleMeanArrayNoAxis.Length, 1);
        Assert.IsTrue(doubleMeanArrayNoAxis.SequenceEqual([720]));

        var longMeanArrayAxis0 = new ProductArray<long>(int32Array, 0);
        Assert.IsTrue(longMeanArrayAxis0.Shape.SequenceEqual([3]));
        Assert.IsTrue(longMeanArrayAxis0.Strides.SequenceEqual([1]));
        Assert.AreEqual(longMeanArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMeanArrayAxis0.Length, 3);
        Assert.IsTrue(longMeanArrayAxis0.SequenceEqual([
            4, 10, 18
        ]));

        var floatMeanArrayAxis1 = new ProductArray<float>(int32Array, 1);
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
    public void StandardDeviationArrayTest() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleMeanArrayNoAxis = new StandardDeviationArray<double>(int32Array, null);
        Assert.IsTrue(doubleMeanArrayNoAxis.Shape.SequenceEqual([1]));
        Assert.IsTrue(doubleMeanArrayNoAxis.Strides.SequenceEqual([1]));
        Assert.AreEqual(doubleMeanArrayNoAxis.ValueType, ArrayValueType.Double);
        Assert.AreEqual(doubleMeanArrayNoAxis.Length, 1);
        Assert.IsTrue(doubleMeanArrayNoAxis.SequenceEqual([6.922186552431729]));

        var longMeanArrayAxis0 = new StandardDeviationArray<long>(int32Array, 0);
        Assert.IsTrue(longMeanArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longMeanArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longMeanArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMeanArrayAxis0.Length, 12);
        Assert.IsTrue(longMeanArrayAxis0.SequenceEqual([
            6, 6, 6, 6,
            6, 6, 6, 6,
            6, 6, 6, 6
        ]));

        var floatMeanArrayAxis1 = new StandardDeviationArray<float>(int32Array, 1);
        Assert.IsTrue(floatMeanArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatMeanArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatMeanArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatMeanArrayAxis1.Length, 8);
        Assert.IsTrue(floatMeanArrayAxis1.SequenceEqual([
            3.265986323710904f, 3.265986323710904f, 3.265986323710904f, 3.265986323710904f,
            3.265986323710904f, 3.265986323710904f, 3.265986323710904f, 3.265986323710904f
        ]));

        var shortMeanArrayAxis2 = new StandardDeviationArray<short>(int32Array, 2);
        Assert.IsTrue(shortMeanArrayAxis2.Shape.SequenceEqual([2, 3]));
        Assert.IsTrue(shortMeanArrayAxis2.Strides.SequenceEqual([3, 1]));
        Assert.AreEqual(shortMeanArrayAxis2.ValueType, ArrayValueType.Int16);
        Assert.AreEqual(shortMeanArrayAxis2.Length, 6);
        Assert.IsTrue(shortMeanArrayAxis2.SequenceEqual([
            1,1,1,
            1,1,1
        ]));
    }

    [TestMethod()]
    public void VarianceArrayTest() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleMeanArrayNoAxis = new VarianceArray<double>(int32Array, null);
        Assert.IsTrue(doubleMeanArrayNoAxis.Shape.SequenceEqual([1]));
        Assert.IsTrue(doubleMeanArrayNoAxis.Strides.SequenceEqual([1]));
        Assert.AreEqual(doubleMeanArrayNoAxis.ValueType, ArrayValueType.Double);
        Assert.AreEqual(doubleMeanArrayNoAxis.Length, 1);
        Assert.IsTrue(doubleMeanArrayNoAxis.SequenceEqual([47.916666666666664]));

        var longMeanArrayAxis0 = new VarianceArray<long>(int32Array, 0);
        Assert.IsTrue(longMeanArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longMeanArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longMeanArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMeanArrayAxis0.Length, 12);
        Assert.IsTrue(longMeanArrayAxis0.SequenceEqual([
            36, 36, 36, 36,
            36, 36, 36, 36,
            36, 36, 36, 36
        ]));

        var floatMeanArrayAxis1 = new VarianceArray<float>(int32Array, 1);
        Assert.IsTrue(floatMeanArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatMeanArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatMeanArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatMeanArrayAxis1.Length, 8);
        Assert.IsTrue(floatMeanArrayAxis1.SequenceEqual([
            10.666666666666666f, 10.666666666666666f, 10.666666666666666f, 10.666666666666666f,
            10.666666666666666f, 10.666666666666666f, 10.666666666666666f, 10.666666666666666f
        ]));

        var shortMeanArrayAxis2 = new VarianceArray<short>(int32Array, 2);
        Assert.IsTrue(shortMeanArrayAxis2.Shape.SequenceEqual([2, 3]));
        Assert.IsTrue(shortMeanArrayAxis2.Strides.SequenceEqual([3, 1]));
        Assert.AreEqual(shortMeanArrayAxis2.ValueType, ArrayValueType.Int16);
        Assert.AreEqual(shortMeanArrayAxis2.Length, 6);
        Assert.IsTrue(shortMeanArrayAxis2.SequenceEqual([
            1,1,1,
            1,1,1
        ]));
    }

    [TestMethod()]
    public void ArgMinArrayTest() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleMeanArrayNoAxis = new ArgMinArray<double>(int32Array, null);
        Assert.IsTrue(doubleMeanArrayNoAxis.Shape.SequenceEqual([1]));
        Assert.IsTrue(doubleMeanArrayNoAxis.Strides.SequenceEqual([1]));
        Assert.AreEqual(doubleMeanArrayNoAxis.ValueType, ArrayValueType.Double);
        Assert.AreEqual(doubleMeanArrayNoAxis.Length, 1);
        Assert.IsTrue(doubleMeanArrayNoAxis.SequenceEqual([0.0]));

        var longMeanArrayAxis0 = new ArgMinArray<long>(int32Array, 0);
        Assert.IsTrue(longMeanArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longMeanArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longMeanArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMeanArrayAxis0.Length, 12);
        Assert.IsTrue(longMeanArrayAxis0.SequenceEqual([
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0
        ]));

        var floatMeanArrayAxis1 = new ArgMinArray<float>(int32Array, 1);
        Assert.IsTrue(floatMeanArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatMeanArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatMeanArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatMeanArrayAxis1.Length, 8);
        Assert.IsTrue(floatMeanArrayAxis1.SequenceEqual([
            0.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 0.0f
        ]));

        var shortMeanArrayAxis2 = new ArgMinArray<short>(int32Array, 2);
        Assert.IsTrue(shortMeanArrayAxis2.Shape.SequenceEqual([2, 3]));
        Assert.IsTrue(shortMeanArrayAxis2.Strides.SequenceEqual([3, 1]));
        Assert.AreEqual(shortMeanArrayAxis2.ValueType, ArrayValueType.Int16);
        Assert.AreEqual(shortMeanArrayAxis2.Length, 6);
        Assert.IsTrue(shortMeanArrayAxis2.SequenceEqual([
            0, 0, 0,
            0, 0, 0
        ]));
    }

    [TestMethod()]
    public void ArgMaxArrayTest() {
        int[] testValues = Enumerable.Range(1, 24).ToArray();
        var int32Array = NA.Construct<int>([2, 3, 4], testValues);

        var doubleMeanArrayNoAxis = new ArgMaxArray<double>(int32Array, null);
        Assert.IsTrue(doubleMeanArrayNoAxis.Shape.SequenceEqual([1]));
        Assert.IsTrue(doubleMeanArrayNoAxis.Strides.SequenceEqual([1]));
        Assert.AreEqual(doubleMeanArrayNoAxis.ValueType, ArrayValueType.Double);
        Assert.AreEqual(doubleMeanArrayNoAxis.Length, 1);
        Assert.IsTrue(doubleMeanArrayNoAxis.SequenceEqual([23.0]));

        var longMeanArrayAxis0 = new ArgMaxArray<long>(int32Array, 0);
        Assert.IsTrue(longMeanArrayAxis0.Shape.SequenceEqual([3, 4]));
        Assert.IsTrue(longMeanArrayAxis0.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(longMeanArrayAxis0.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(longMeanArrayAxis0.Length, 12);
        Assert.IsTrue(longMeanArrayAxis0.SequenceEqual([
            1, 1, 1, 1,
            1, 1, 1, 1,
            1, 1, 1, 1
        ]));

        var floatMeanArrayAxis1 = new ArgMaxArray<float>(int32Array, 1);
        Assert.IsTrue(floatMeanArrayAxis1.Shape.SequenceEqual([2, 4]));
        Assert.IsTrue(floatMeanArrayAxis1.Strides.SequenceEqual([4, 1]));
        Assert.AreEqual(floatMeanArrayAxis1.ValueType, ArrayValueType.Single);
        Assert.AreEqual(floatMeanArrayAxis1.Length, 8);
        Assert.IsTrue(floatMeanArrayAxis1.SequenceEqual([
            2.0f, 2.0f, 2.0f, 2.0f,
            2.0f, 2.0f, 2.0f, 2.0f
        ]));

        var shortMeanArrayAxis2 = new ArgMaxArray<short>(int32Array, 2);
        Assert.IsTrue(shortMeanArrayAxis2.Shape.SequenceEqual([2, 3]));
        Assert.IsTrue(shortMeanArrayAxis2.Strides.SequenceEqual([3, 1]));
        Assert.AreEqual(shortMeanArrayAxis2.ValueType, ArrayValueType.Int16);
        Assert.AreEqual(shortMeanArrayAxis2.Length, 6);
        Assert.IsTrue(shortMeanArrayAxis2.SequenceEqual([
            3, 3, 3,
            3, 3, 3
        ]));
    }
}