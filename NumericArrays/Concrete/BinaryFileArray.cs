namespace NumericArrays.Concrete {
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using NumericArrays.Types;

    public class BinaryFileArray<T> : ConcreteArray<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T> {

        #region Private Fields
        private string _fileName;
        private int _fullyAllocatedFileSize;
        //private int _sizeOfTInBytes;
        private FileStream _fileStream;
        #endregion

        #region Public Constructors
        public BinaryFileArray(int[] shape) :
            base(shape) {

            _fileName = Path.GetTempFileName();
            //_sizeOfTInBytes = ArrayValueTypes.SizeOf(ValueType);
            _fullyAllocatedFileSize = sizeof(double) * _length;
            _fileStream = new FileStream(_fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            _fileStream.SetLength(_fullyAllocatedFileSize);
        }
        #endregion

        #region Public Properties
        public override T this[int linearIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                Debug.Assert(linearIndex >= 0 && linearIndex <= Length);

                int filePosition = sizeof(double) * linearIndex;

                if (_fileStream.Length < (sizeof(double) * linearIndex)) 
                {
                    return default;
                }

                if (_fileStream.Position != filePosition)
                {
                    _ = _fileStream.Seek(filePosition, SeekOrigin.Begin);
                }

                byte[] valueBytes = new byte[sizeof(double)];

                if (_fileStream.Read(valueBytes, 0, sizeof(double)) != sizeof(double)) {
                    throw new InvalidOperationException("Could not read the value from the file.");
                }

                return (T) BitConverter.ToDouble(valueBytes, 0).CastToArrayValueType(ValueType);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                Debug.Assert(linearIndex >= 0 && linearIndex <= Length);
                int filePosition = sizeof(double) * linearIndex;

                _ = _fileStream.Seek(filePosition, SeekOrigin.Begin);

                byte[] valueBytes = BitConverter.GetBytes(value.ToDouble(null));

                try
                { 
                    _fileStream.Write(valueBytes, 0, sizeof(double));
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Could not write the value to the file.", ex);
                }
            }
        }
        #endregion

        #region Protected Methods
        protected override void Dispose(bool disposing) {
            if (disposing) 
            {
                _fileStream.Close();
                _fileStream.Dispose();
                File.Delete(_fileName);
            }

            base.Dispose(disposing);
        }
        #endregion

        #region Public Methods
        public override INumericArray<T> Clone() {
            var newBinaryDiskArray = new BinaryFileArray<T>(Shape);

            throw new NotImplementedException();

            return newBinaryDiskArray;
        }
        #endregion
    }
}