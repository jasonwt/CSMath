namespace NumericArrays.Virtual.Reductions {
    using System;
    using System.Linq;

    public interface IReductionArray : IVirtualArray {
        public static int[] ComputeShape(INumericArray sourceArray, int? rank) {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            if (rank == null)
            {
                return new int[] { 1 };
            }

            if (rank < 0 || rank >= sourceArray.Rank)
            {
                throw new ArgumentOutOfRangeException(nameof(rank));
            }

            return sourceArray.Shape.Where((shape, index) => index != rank).ToArray();
        }
    }

    public interface IReductionArray<T> : IReductionArray, IVirtualArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {
    }
}
