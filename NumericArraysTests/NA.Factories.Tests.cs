namespace NumericArrays.Tests;

using System;

using NumericArrays.Types;

using static NumericArrays.Extensions.LinqExtensions;

[TestClass()]
public class NAFactoriesTests {
    [TestMethod()]
    public void ConstructConcreteArrayTest() {
        var genericInt32Array = NA.Construct<int>([2, 3, 4]);
        Assert.IsTrue(genericInt32Array.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(genericInt32Array.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(genericInt32Array.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(genericInt32Array.Length, 24);
        Assert.IsTrue(genericInt32Array.SequenceEqual(Enumerable.Repeat<int>(0, 24)));

        var nonGenericSingleArray = NA.Construct(ArrayValueType.Single, [2, 3, 4]);
        Assert.IsTrue(nonGenericSingleArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(nonGenericSingleArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(nonGenericSingleArray.ValueType, ArrayValueType.Single);
        Assert.AreEqual(nonGenericSingleArray.Length, 24);

        Assert.IsTrue(nonGenericSingleArray.SequenceEqual(genericInt32Array));

        genericInt32Array = NA.Construct<int>([2, 3, 4], Enumerable.Range(1, 24));
        Assert.IsTrue(genericInt32Array.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(genericInt32Array.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(genericInt32Array.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(genericInt32Array.Length, 24);
        Assert.IsTrue(genericInt32Array.SequenceEqual(Enumerable.Range(1, 24)));

        nonGenericSingleArray = NA.Construct(ArrayValueType.Single, [2, 3, 4], Enumerable.Range(1, 24).Select(a => (ValueType)Convert.ToSingle(a)));
        Assert.IsTrue(nonGenericSingleArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(nonGenericSingleArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(nonGenericSingleArray.ValueType, ArrayValueType.Single);
        Assert.AreEqual(nonGenericSingleArray.Length, 24);

        Assert.IsTrue(nonGenericSingleArray.SequenceEqual(genericInt32Array));
    }

    [TestMethod()]
    public void ZerosTest() {
        var genericInt32Array = NA.Zeros<int>([2, 3, 4]);
        Assert.IsTrue(genericInt32Array.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(genericInt32Array.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(genericInt32Array.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(genericInt32Array.Length, 24);
        Assert.IsTrue(genericInt32Array.SequenceEqual(Enumerable.Repeat(0, 24)));

        var nonGenericSingleArray = NA.Zeros(ArrayValueType.Single, [2, 3, 4]);
        Assert.IsTrue(nonGenericSingleArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(nonGenericSingleArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(nonGenericSingleArray.ValueType, ArrayValueType.Single);
        Assert.AreEqual(nonGenericSingleArray.Length, 24);

        Assert.IsTrue(nonGenericSingleArray.SequenceEqual(genericInt32Array));
    }

    [TestMethod()]
    public void OnesTest() {
        var genericInt32Array = NA.Ones<int>([2, 3, 4]);
        Assert.IsTrue(genericInt32Array.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(genericInt32Array.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(genericInt32Array.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(genericInt32Array.Length, 24);
        Assert.IsTrue(genericInt32Array.SequenceEqual(Enumerable.Repeat(1, 24)));

        var nonGenericSingleArray = NA.Ones(ArrayValueType.Single, [2, 3, 4]);
        Assert.IsTrue(nonGenericSingleArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(nonGenericSingleArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(nonGenericSingleArray.ValueType, ArrayValueType.Single);
        Assert.AreEqual(nonGenericSingleArray.Length, 24);

        Assert.IsTrue(nonGenericSingleArray.SequenceEqual(genericInt32Array));
    }

    [TestMethod()]
    public void FullTest() {
        var genericInt32Array = NA.Full<int>([2, 3, 4], 5);
        Assert.IsTrue(genericInt32Array.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(genericInt32Array.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(genericInt32Array.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(genericInt32Array.Length, 24);
        Assert.IsTrue(genericInt32Array.SequenceEqual(Enumerable.Repeat(5, 24)));

        var nonGenericSingleArray = NA.Full(ArrayValueType.Single, [2, 3, 4], 5);
        Assert.IsTrue(nonGenericSingleArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(nonGenericSingleArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(nonGenericSingleArray.ValueType, ArrayValueType.Single);
        Assert.AreEqual(nonGenericSingleArray.Length, 24);

        Assert.IsTrue(nonGenericSingleArray.SequenceEqual(genericInt32Array));
    }

    [TestMethod()]
    public void ARangeTest() {
        var genericInt32Array = NA.ARange<int>(0, 10, 2);
        Assert.IsTrue(genericInt32Array.Shape.SequenceEqual([6]));
        Assert.IsTrue(genericInt32Array.Strides.SequenceEqual([1]));
        Assert.AreEqual(genericInt32Array.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(genericInt32Array.Length, 6);
        Assert.IsTrue(genericInt32Array.SequenceEqual([0, 2, 4, 6, 8, 10]));

        var nonGenericSingleArray = NA.ARange(ArrayValueType.Single, 0, 10, 2);
        Assert.IsTrue(nonGenericSingleArray.Shape.SequenceEqual([6]));
        Assert.IsTrue(nonGenericSingleArray.Strides.SequenceEqual([1]));
        Assert.AreEqual(nonGenericSingleArray.ValueType, ArrayValueType.Single);
        Assert.AreEqual(nonGenericSingleArray.Length, 6);

        Assert.IsTrue(nonGenericSingleArray.SequenceEqual(genericInt32Array));
    }

    [TestMethod()]
    public void LinspaceTest() {
        var genericInt32Array = NA.Linspace<int>(0, 10, 6);
        Assert.IsTrue(genericInt32Array.Shape.SequenceEqual([6]));
        Assert.IsTrue(genericInt32Array.Strides.SequenceEqual([1]));
        Assert.AreEqual(genericInt32Array.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(genericInt32Array.Length, 6);
        Assert.IsTrue(genericInt32Array.SequenceEqual([0, 2, 4, 6, 8, 10 ]));

        var nonGenericSingleArray = NA.Linspace(ArrayValueType.Single, 0, 10, 6);
        Assert.IsTrue(nonGenericSingleArray.Shape.SequenceEqual([6]));
        Assert.IsTrue(nonGenericSingleArray.Strides.SequenceEqual([1]));
        Assert.AreEqual(nonGenericSingleArray.ValueType, ArrayValueType.Single);
        Assert.AreEqual(nonGenericSingleArray.Length, 6);

        Assert.IsTrue(nonGenericSingleArray.SequenceEqual(genericInt32Array));
    }

    [TestMethod()]
    public void EyeTest() {
        var genericInt32Array = NA.Eye<int>(3);
        Console.WriteLine(genericInt32Array);
        Assert.IsTrue(genericInt32Array.Shape.SequenceEqual([3,3]));
        Assert.IsTrue(genericInt32Array.Strides.SequenceEqual([3,1]));
        Assert.AreEqual(genericInt32Array.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(genericInt32Array.Length, 9);
        Assert.IsTrue(genericInt32Array.SequenceEqual([1, 0, 0, 0, 1, 0, 0, 0, 1]));

        var nonGenericSingleArray = NA.Eye(ArrayValueType.Single, 3);
        Assert.IsTrue(nonGenericSingleArray.Shape.SequenceEqual([3,3]));
        Assert.IsTrue(nonGenericSingleArray.Strides.SequenceEqual([3,1]));
        Assert.AreEqual(nonGenericSingleArray.ValueType, ArrayValueType.Single);
        Assert.AreEqual(nonGenericSingleArray.Length, 9);

        Assert.IsTrue(nonGenericSingleArray.SequenceEqual(genericInt32Array));

        genericInt32Array = NA.Eye<int>(3,3);
        Assert.IsTrue(genericInt32Array.Shape.SequenceEqual([3, 3, 3]));
        Assert.IsTrue(genericInt32Array.Strides.SequenceEqual([9, 3, 1]));
        Assert.AreEqual(genericInt32Array.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(genericInt32Array.Length, 27);
        Assert.IsTrue(genericInt32Array.SequenceEqual([
            1, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 1, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 1
        ]));

        nonGenericSingleArray = NA.Eye(ArrayValueType.Single, 3, 3);
        Assert.IsTrue(nonGenericSingleArray.Shape.SequenceEqual([3, 3, 3]));
        Assert.IsTrue(nonGenericSingleArray.Strides.SequenceEqual([9, 3, 1]));
        Assert.AreEqual(nonGenericSingleArray.ValueType, ArrayValueType.Single);
        Assert.AreEqual(nonGenericSingleArray.Length, 27);

        Assert.IsTrue(nonGenericSingleArray.SequenceEqual(genericInt32Array));
    }
}