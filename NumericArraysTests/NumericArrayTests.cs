namespace NumericArrays.Tests {

    [TestClass()]
    public class NumericArrayTests {
        [TestMethod()]
        public void TestSlicingArrays() {
            var sourceArray = NA.ARange<int>(1, 24, 1);
            sourceArray.Reshape([2, 3, 4]);

            Assert.IsTrue((sourceArray[":"]).SequenceEqual(Enumerable.Range(1, 24)));
            Assert.IsTrue((sourceArray["0"]).SequenceEqual(Enumerable.Range(1, 12)));
            Assert.IsTrue((sourceArray["1"]).SequenceEqual(Enumerable.Range(13, 12)));

            Assert.IsTrue((sourceArray["0:2"]).SequenceEqual(Enumerable.Range(1, 24)));

            Assert.IsTrue((sourceArray["-1"]).SequenceEqual(Enumerable.Range(13, 12)));
            Assert.IsTrue((sourceArray["-2"]).SequenceEqual(Enumerable.Range(1, 12)));

            Assert.IsTrue((sourceArray[":,0"]).SequenceEqual([1, 2, 3, 4, 13, 14, 15, 16]));
            Assert.IsTrue((sourceArray[":,1"]).SequenceEqual([5, 6, 7, 8, 17, 18, 19, 20]));
            Assert.IsTrue((sourceArray[":,2"]).SequenceEqual([9, 10, 11, 12, 21, 22, 23, 24]));

            Assert.IsTrue((sourceArray[":,0:2,:"]).SequenceEqual([1, 2, 3, 4, 5, 6, 7, 8, 13, 14, 15, 16, 17, 18, 19, 20]));

            Assert.IsTrue((sourceArray[":,-1"]).SequenceEqual([9, 10, 11, 12, 21, 22, 23, 24]));
            Assert.IsTrue((sourceArray[":,-2"]).SequenceEqual([5, 6, 7, 8, 17, 18, 19, 20]));
            Assert.IsTrue((sourceArray[":,-3"]).SequenceEqual([1, 2, 3, 4, 13, 14, 15, 16]));

            Assert.IsTrue((sourceArray[":,:,0"]).SequenceEqual([1, 5, 9, 13, 17, 21]));
            Assert.IsTrue((sourceArray[":,:,1"]).SequenceEqual([2, 6, 10, 14, 18, 22]));
            Assert.IsTrue((sourceArray[":,:,2"]).SequenceEqual([3, 7, 11, 15, 19, 23]));
            Assert.IsTrue((sourceArray[":,:,3"]).SequenceEqual([4, 8, 12, 16, 20, 24]));

            Assert.IsTrue((sourceArray[":,:,0:2"]).SequenceEqual([1, 2, 5, 6, 9, 10, 13, 14, 17, 18, 21, 22]));
            Assert.IsTrue((sourceArray[":,:,1:2"]).SequenceEqual([2, 6, 10, 14, 18, 22]));

            Assert.IsTrue((sourceArray[":,:,-1"]).SequenceEqual([4, 8, 12, 16, 20, 24]));
            Assert.IsTrue((sourceArray[":,:,-2"]).SequenceEqual([3, 7, 11, 15, 19, 23]));
            Assert.IsTrue((sourceArray[":,:,-3"]).SequenceEqual([2, 6, 10, 14, 18, 22]));
            Assert.IsTrue((sourceArray[":,:,-4"]).SequenceEqual([1, 5, 9, 13, 17, 21]));
        }
    }
}