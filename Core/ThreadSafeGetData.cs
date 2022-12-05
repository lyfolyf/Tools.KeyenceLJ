using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.PrimKeyenceLJ
{
    /// <summary>
	/// Thread-safe class for array storage
	/// </summary>
	public static class ThreadSafeGetData
    {
        #region Field
        /// <summary>Data buffer</summary>
        private static List<int[]>[] _buffer = new List<int[]>[NativeMethods.DeviceCount];
        /// <summary>Buffer for the amount of data</summary>
        private static uint[] _count = new uint[NativeMethods.DeviceCount];
        /// <summary>Object for exclusive control</summary>
        private static object[] _syncObjectData = new object[NativeMethods.DeviceCount];
        private static object[] _syncObjectCount = new object[NativeMethods.DeviceCount];
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        static ThreadSafeGetData()
        {
            for (int i = 0; i < NativeMethods.DeviceCount; i++)
            {
                _buffer[i] = new List<int[]>();
                _syncObjectData[i] = new object();
                _syncObjectCount[i] = new object();
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// Get buffer data count
        /// </summary>
        /// <returns>buffer data count</returns>
        public static int GetDataCount(int index)
        {
            return _buffer[index].Count;
        }

        /// <summary>
        /// Element addition
        /// </summary>
        /// <param name="index">User information set when high-speed communication was initialized</param>
        /// <param name="value">Additional element</param>
        public static void Add(int index, List<int[]> value)
        {
            lock (_syncObjectData[index])
            {
                _buffer[index].AddRange(value);
            }
            lock (_syncObjectCount[index])
            {
                _count[index] += (uint)value.Count;
            }
        }
        /// <summary>
        /// Element addition
        /// </summary>
        /// <param name="index">User information set when high-speed communication was initialized</param>
        /// <param name="value">Additional element</param>
        public static void Add(int index, int[] value)
        {
            lock (_syncObjectData[index])
            {
                _buffer[index].Add(value);
            }
            lock (_syncObjectCount[index])
            {
                _count[index] += 1;
            }
        }
        /// <summary>
        /// Clear elements.
        /// </summary>
        /// <param name="index">Device ID</param>
        public static void Clear(int index)
        {
            lock (_syncObjectData[index])
            {
                _buffer[index].Clear();
            }
        }

        /// <summary>
        /// Clear the buffer.
        /// </summary>
        /// <param name="index">Device ID</param>
        public static void ClearBuffer(int index)
        {
            Clear(index);
            ClearCount(index);
        }

        /// <summary>
        /// Get element.
        /// </summary>
        /// <param name="index">Device ID</param>
        /// <returns>Element</returns>
        public static List<int[]> Get(int index)
        {
            //lock (_syncObjectData[index])
            {
                return _buffer[index];
            }
        }

        /// <summary>
        /// Get the count
        /// </summary>
        /// <param name="index">Device ID</param>
        /// <returns></returns>
        internal static uint GetCount(int index)
        {
            lock (_syncObjectCount[index])
            {
                return _count[index];
            }
        }

        /// <summary>
        /// Clear the number of elements.
        /// </summary>
        /// <param name="index">Device ID</param>
        private static void ClearCount(int index)
        {
            lock (_syncObjectCount[index])
            {
                _count[index] = 0;
            }
        }
        #endregion
    }
}
