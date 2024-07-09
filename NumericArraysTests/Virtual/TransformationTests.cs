namespace NumericArrays.Virtual.Transformations.Tests;

using System;

using NumericArrays.Types;

using static NumericArrays.Extensions.LinqExtensions;

[TestClass()]
public class TransformationTests {
    [TestMethod()]
    public void AsTypeArrayTest() {
        int[] testValues = Enumerable.Range(0, 24).Select(a => a % 2 == 0 ? a : -a).ToArray();

        var int32Array = NA.Construct<int>([2, 3, 4], testValues);
        Assert.IsTrue(int32Array.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(int32Array.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(int32Array.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(int32Array.Length, 24);
        Assert.IsTrue(int32Array.SequenceEqual(testValues));

        var int32ArrayAsSingle = new AsTypeArray<float>(int32Array);
        Assert.IsTrue(int32ArrayAsSingle.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(int32ArrayAsSingle.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(int32ArrayAsSingle.ValueType, ArrayValueType.Single);
        Assert.AreEqual(int32ArrayAsSingle.Length, 24);
        Assert.IsTrue(int32ArrayAsSingle.SequenceEqual(testValues.Select(a => (float)a)));
        Assert.IsTrue(int32Array.SequenceEqual(int32ArrayAsSingle));

        var int64Array = NA.Construct<long>([2, 3, 4], testValues.Select(a => (long)a).ToArray());
        Assert.IsTrue(int64Array.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(int64Array.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(int64Array.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(int64Array.Length, 24);
        Assert.IsTrue(int64Array.SequenceEqual(testValues.Select(a => (long)a)));

        var int64ArrayAsBool = new AsTypeArray<bool>(int64Array);
        Assert.IsTrue(int64ArrayAsBool.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(int64ArrayAsBool.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(int64ArrayAsBool.ValueType, ArrayValueType.Boolean);
        Assert.AreEqual(int64ArrayAsBool.Length, 24);
        Assert.IsTrue(int64ArrayAsBool.SequenceEqual(testValues.Select(a => Convert.ToBoolean(a))));
    }

    [TestMethod()]
    public void BroadcastingArrayTest() {
        var array_2_3_4 = NA.ARange<int>(1, 24, 1);
        array_2_3_4.Reshape([2, 3, 4]);

        INumericArray<int> array_3_4 = NA.ARange<int>(1, 12, 1);
        array_3_4.Reshape([3, 4]);

        var broadcast_2_3_4_with_3_4 = new BroadcastingArray<int>(array_2_3_4, array_3_4.Shape);
        Assert.IsTrue(broadcast_2_3_4_with_3_4.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(broadcast_2_3_4_with_3_4.SequenceEqual([
            1, 2, 3, 4,
        5, 6, 7, 8,
        9, 10, 11, 12,
        13, 14, 15, 16,
        17, 18, 19, 20,
        21, 22, 23, 24
        ]));

        var broadcast_3_4_with_2_3_4 = new BroadcastingArray<int>(array_3_4, array_2_3_4.Shape);
        Assert.IsTrue(broadcast_3_4_with_2_3_4.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(broadcast_3_4_with_2_3_4.SequenceEqual([
            1, 2, 3, 4,
        5, 6, 7, 8,
        9, 10, 11, 12,

        1, 2, 3, 4,
        5, 6, 7, 8,
        9, 10, 11, 12
        ]));

        var array_1 = NA.Ones<int>([1]);
        Console.WriteLine(array_1);

        var broadcast_2_3_4_with_1 = new BroadcastingArray<int>(array_2_3_4, array_1.Shape);
        Assert.IsTrue(broadcast_2_3_4_with_1.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(broadcast_2_3_4_with_1.SequenceEqual([
            1, 2, 3, 4,
        5, 6, 7, 8,
        9, 10, 11, 12,
        13, 14, 15, 16,
        17, 18, 19, 20,
        21, 22, 23, 24
        ]));

        var broadcast_1_with_2_3_4 = new BroadcastingArray<int>(array_1, array_2_3_4.Shape);
        Assert.IsTrue(broadcast_1_with_2_3_4.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(broadcast_1_with_2_3_4.SequenceEqual([
            1, 1, 1, 1,
        1, 1, 1, 1,
        1, 1, 1, 1,
        1, 1, 1, 1,
        1, 1, 1, 1,
        1, 1, 1, 1
        ]));
    }

    [TestMethod()]
    public void TestSlicingArrays() {
        var sourceArray = NA.ARange<int>(1, 24, 1);
        sourceArray.Reshape([2, 3, 4]);

        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":")).SequenceEqual(Enumerable.Range(1, 24)));
        Assert.IsTrue((new SlicingArray<int>(sourceArray, "0")).SequenceEqual(Enumerable.Range(1, 12)));
        Assert.IsTrue((new SlicingArray<int>(sourceArray, "1")).SequenceEqual(Enumerable.Range(13, 12)));

        Assert.IsTrue((new SlicingArray<int>(sourceArray, "0:2")).SequenceEqual(Enumerable.Range(1, 24)));

        Assert.IsTrue((new SlicingArray<int>(sourceArray, "-1")).SequenceEqual(Enumerable.Range(13, 12)));
        Assert.IsTrue((new SlicingArray<int>(sourceArray, "-2")).SequenceEqual(Enumerable.Range(1, 12)));

        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,0")).SequenceEqual([1, 2, 3, 4, 13, 14, 15, 16]));
        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,1")).SequenceEqual([5, 6, 7, 8, 17, 18, 19, 20]));
        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,2")).SequenceEqual([9, 10, 11, 12, 21, 22, 23, 24]));

        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,0:2,:")).SequenceEqual([1, 2, 3, 4, 5, 6, 7, 8, 13, 14, 15, 16, 17, 18, 19, 20]));

        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,-1")).SequenceEqual([9, 10, 11, 12, 21, 22, 23, 24]));
        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,-2")).SequenceEqual([5, 6, 7, 8, 17, 18, 19, 20]));
        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,-3")).SequenceEqual([1, 2, 3, 4, 13, 14, 15, 16]));

        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,:,0")).SequenceEqual([1, 5, 9, 13, 17, 21]));
        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,:,1")).SequenceEqual([2, 6, 10, 14, 18, 22]));
        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,:,2")).SequenceEqual([3, 7, 11, 15, 19, 23]));
        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,:,3")).SequenceEqual([4, 8, 12, 16, 20, 24]));

        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,:,0:2")).SequenceEqual([1, 2, 5, 6, 9, 10, 13, 14, 17, 18, 21, 22]));
        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,:,1:2")).SequenceEqual([2, 6, 10, 14, 18, 22]));

        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,:,-1")).SequenceEqual([4, 8, 12, 16, 20, 24]));
        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,:,-2")).SequenceEqual([3, 7, 11, 15, 19, 23]));
        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,:,-3")).SequenceEqual([2, 6, 10, 14, 18, 22]));
        Assert.IsTrue((new SlicingArray<int>(sourceArray, ":,:,-4")).SequenceEqual([1, 5, 9, 13, 17, 21]));
    }

    [TestMethod()]
    public void TestTransposingArray() {
        var sourceArray = NA.Construct<int>([2, 3, 4]);
        sourceArray.Fill(Enumerable.Range(1, 24).ToArray());
        Console.WriteLine(sourceArray);

        var transposedArray021 = new TransposingArray<int>(sourceArray, [0, 2, 1]);
        Assert.IsTrue(transposedArray021.Shape.SequenceEqual([2, 4, 3]));
        Assert.IsTrue(transposedArray021.SequenceEqual([
            1,5,9,
            2,6,10,
            3,7,11,
            4,8,12,

            13,17,21,
            14,18,22,
            15,19,23,
            16,20,24
        ]));

        var transposedArray102 = new TransposingArray<int>(sourceArray, [1, 0, 2]);
        Assert.IsTrue(transposedArray102.Shape.SequenceEqual([3, 2, 4]));
        Assert.IsTrue(transposedArray102.SequenceEqual([
            1,2,3,4,
            13,14,15,16,

            5,6,7,8,
            17,18,19,20,

            9,10,11,12,
            21,22,23,24
        ]));

        var transposedArray120 = new TransposingArray<int>(sourceArray, [1, 2, 0]);
        Assert.IsTrue(transposedArray120.Shape.SequenceEqual([3, 4, 2]));
        Assert.IsTrue(transposedArray120.SequenceEqual([
            1,13,
            2,14,
            3,15,
            4,16,

            5,17,
            6,18,
            7,19,
            8,20,

            9,21,
            10,22,
            11,23,
            12,24
        ]));

        var transposedArray201 = new TransposingArray<int>(sourceArray, [2, 0, 1]);
        Assert.IsTrue(transposedArray201.Shape.SequenceEqual([4, 2, 3]));
        Assert.IsTrue(transposedArray201.SequenceEqual([
            1,5,9,
            13,17,21,

            2,6,10,
            14,18,22,

            3,7,11,
            15,19,23,

            4,8,12,
            16,20,24
        ]));

        var transposedArray210 = new TransposingArray<int>(sourceArray, [2, 1, 0]);
        Assert.IsTrue(transposedArray210.Shape.SequenceEqual([4, 3, 2]));
        Assert.IsTrue(transposedArray210.SequenceEqual([
            1,13,
            5,17,
            9,21,

            2,14,
            6,18,
            10,22,

            3,15,
            7,19,
            11,23,

            4,16,
            8,20,
            12,24
        ]));
    }

    [TestMethod()]
    public void ValueExpandingArrayTest() {
        int[] testValues = Enumerable.Repeat(1, 24).ToArray();

        var int32Array = new ValueExpandingArray<int>(1, [2, 3, 4]);
        Assert.IsTrue(int32Array.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(int32Array.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(int32Array.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(int32Array.Length, 24);
        Assert.IsTrue(int32Array.SequenceEqual(testValues));

        var singleArray = new ValueExpandingArray<float>(1.0f, [2, 3, 4]);
        Assert.IsTrue(singleArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(singleArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(singleArray.ValueType, ArrayValueType.Single);
        Assert.AreEqual(singleArray.Length, 24);
        Assert.IsTrue(singleArray.SequenceEqual(int32Array));

        var int64Array = new ValueExpandingArray<long>(1, [2, 3, 4]);
        Assert.IsTrue(int64Array.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(int64Array.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(int64Array.ValueType, ArrayValueType.Int64);
        Assert.AreEqual(int64Array.Length, 24);
        Assert.IsTrue(int64Array.SequenceEqual(testValues.Select(a => (long)a)));

        var boolArray = new ValueExpandingArray<bool>(true, [2, 3, 4]);
        Assert.IsTrue(boolArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(boolArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(boolArray.ValueType, ArrayValueType.Boolean);
        Assert.AreEqual(boolArray.Length, 24);
        Assert.IsTrue(boolArray.SequenceEqual(testValues.Select(a => Convert.ToBoolean(a))));
    }
}
