namespace NumericArrays {
    using System;
    using System.Text;

    public abstract partial class NumericArray<T> : INumericArray<T>
        where T : struct, IConvertible, IComparable, IComparable<T>, IEquatable<T> {

        #region Public Methods
        
        #region ToString Override
        public override string ToString() {
            var sb = new StringBuilder();

            _ = sb.AppendLine($"{GetType().Name}<{ValueType}>");
            //_ = sb.AppendLine($"\tCPU Memory Usage In Bytes: " + SystemMemoryUsageInBytes);
            _ = sb.AppendLine($"\tShape   : [{string.Join(",", _shape)}]");
            _ = sb.AppendLine($"\tStrides : [{string.Join(",", _strides)}]");
            _ = sb.AppendLine($"\tLength  : {_length}");

            _ = sb.AppendLine($"\tValues  :\n");

            _ = sb.Append("\t[");
            for (int i = 0; i < _length; i++)
            {
                int newLineCnt = 0;

                int[] currentDimensionalIndex = ComputeIndices(i);

                for (int j = 0; j < currentDimensionalIndex.Length - 1; j++)
                {
                    if (i % _strides[j] == 0)
                    {
                        if (j == 0 && i > 0)
                        {
                            _ = sb.Append("\t ");
                        }

                        _ = sb.Append("[");
                    }
                    else if (currentDimensionalIndex[^1] == 0)
                    {
                        if (j == 0)
                        {
                            _ = sb.Append("\t ");
                        }

                        _ = sb.Append(" ");
                    }
                }

                _ = sb.Append(this[ComputeLinearIndex(currentDimensionalIndex)]);

                if (currentDimensionalIndex[^1] < _shape[^1] - 1)
                {
                    _ = sb.Append(" ");
                }

                for (int j = 0; j < currentDimensionalIndex.Length - 1; j++)
                {
                    if (i % _strides[j] == _strides[j] - 1)
                    {
                        _ = sb.Append("]");
                        newLineCnt++;
                    }
                }

                for (int j = 0; i < _length - 1 && j < newLineCnt; j++)
                {
                    _ = sb.Append("\n");
                }
            }

            _ = sb.Append("]\n");

            return sb.ToString();
        }
        #endregion

        #endregion
    }
}
