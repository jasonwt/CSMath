namespace NumericArrays.Concrete.Tests {
    using static NumericArrays.Extensions.LinqExtensions;

    [TestClass()]
    public class BinaryDiskArrayTests {
        [TestMethod()]
        public void ConstructTest() {
            var newArray = new BinaryFileArray<int>([2, 3, 4]);
            Assert.AreEqual(3, newArray.Rank);
            Assert.AreEqual(24, newArray.Length);
            Assert.AreEqual(newArray.ValueType, Types.ArrayValueType.Int32);
            Assert.IsTrue(newArray.Shape.SequenceEqual([2, 3, 4]));
            Assert.IsTrue(newArray.Strides.SequenceEqual([12, 4, 1]));

            newArray.Fill(Enumerable.Range(0, 24).Select(x => (int)x).ToArray());

            Assert.IsTrue(newArray.SequenceEqual(Enumerable.Range(0, 24).Select(x => (int)x)));
            Assert.IsTrue(((INumericArray)newArray).SequenceEqual(Enumerable.Range(0, 24).Select(x => (int)x).Cast<ValueType>()));
        }

        //[TestMethod()]
        //public void CloneTest() {
        //    var newArray = new BinaryDiskArray<int>([2, 3, 4]);
        //    newArray.Fill(Enumerable.Range(0, 24).Select(x => (int)x).ToArray());
        //    Assert.IsTrue(newArray.SequenceEqual(Enumerable.Range(0, 24).Select(x => (int)x)));
        //    Assert.IsTrue(((INumericArray)newArray).SequenceEqual(Enumerable.Range(0, 24).Select(x => (int)x).Cast<ValueType>()));

        //    var clonedArray = newArray.Clone();
        //    Assert.AreEqual(3, clonedArray.Rank);
        //    Assert.AreEqual(24, clonedArray.Length);
        //    Assert.AreEqual(clonedArray.ValueType, Types.ArrayValueType.Int32);
        //    Assert.IsTrue(clonedArray.Shape.SequenceEqual([2, 3, 4]));
        //    Assert.IsTrue(clonedArray.Strides.SequenceEqual([12, 4, 1]));

        //    Assert.IsTrue(clonedArray.SequenceEqual(newArray));
        //}
    }
}