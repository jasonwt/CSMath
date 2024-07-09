namespace NumericArrays.Extensions.Tests;

using System;
using System.Linq;

using NumericArrays.Types;

using static NumericArrays.Extensions.LinqExtensions;

[TestClass()]
public class UnaryMathematicsExtentionsTests {
    [TestMethod()]
    public void SquareRootArrayTest() {
        int[] testValues = Enumerable.Range(0, 24).ToArray();

        var int32Array = NA.Construct<int>([2, 3, 4], testValues);
        Console.WriteLine(int32Array);

        var int32SquareRootArray = int32Array.Sqrt();
        Assert.IsTrue(int32SquareRootArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(int32SquareRootArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(int32SquareRootArray.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(int32SquareRootArray.Length, 24);
        Assert.IsTrue(int32SquareRootArray.SequenceEqual(testValues.Select(a => Convert.ToInt32(Math.Truncate(Math.Sqrt(a))))));

        var singleSquareRootArray = int32Array.Sqrt<float>();
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

        var int32NegationArray = int32Array.Negate<int>();
        Assert.IsTrue(int32NegationArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(int32NegationArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(int32NegationArray.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(int32NegationArray.Length, 24);
        Assert.IsTrue(int32NegationArray.SequenceEqual(testValues.Select(a => -a)));

        var singleNegationArray = int32Array.Negate<float>();
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

        var int32AbsoluteValueArray = int32Array.Abs<int>();
        Assert.IsTrue(int32AbsoluteValueArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(int32AbsoluteValueArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(int32AbsoluteValueArray.ValueType, ArrayValueType.Int32);
        Assert.AreEqual(int32AbsoluteValueArray.Length, 24);
        Assert.IsTrue(int32AbsoluteValueArray.SequenceEqual(testValues.Select(a => (int)Math.Abs(a))));

        var singleAbsoluteValueArray = int32Array.Abs<float>();
        Assert.IsTrue(singleAbsoluteValueArray.Shape.SequenceEqual([2, 3, 4]));
        Assert.IsTrue(singleAbsoluteValueArray.Strides.SequenceEqual([12, 4, 1]));
        Assert.AreEqual(singleAbsoluteValueArray.ValueType, ArrayValueType.Single);
        Assert.AreEqual(singleAbsoluteValueArray.Length, 24);
        Assert.IsTrue(singleAbsoluteValueArray.SequenceEqual(testValues.Select(a => (float)Math.Abs(a))));
    }
}