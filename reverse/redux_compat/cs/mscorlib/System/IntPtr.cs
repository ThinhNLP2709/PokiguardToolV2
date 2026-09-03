/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[ComVisible(true)]
	[IsReadOnly]
	public struct IntPtr : ISerializable, IEquatable<IntPtr> // TypeDefIndex: 2468
	{
		// Fields
		private readonly unsafe void* m_value; // 0x00
		public static readonly IntPtr Zero; // 0x00
	
		// Properties
		public static int Size { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] get; } // 0x0000000180740830-0x0000000180740840 
	
		// Constructors
		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public unsafe IntPtr(int value); // 0x00000001816528A0-0x00000001816528B0
		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public unsafe IntPtr(long value); // 0x0000000180CBE820-0x0000000180CBE830
		[CLSCompliant(false)]
		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public unsafe IntPtr(void* value); // 0x0000000180CBE820-0x0000000180CBE830
		private unsafe IntPtr(SerializationInfo info, StreamingContext context); // 0x00000001816528B0-0x0000000181652910
	
		// Methods
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001816527A0-0x0000000181652840
		public override bool Equals(object obj); // 0x0000000181652750-0x00000001816527A0
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public int ToInt32(); // 0x0000000180732D10-0x0000000180732D20
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public long ToInt64(); // 0x0000000180A45A40-0x0000000180A45A50
		[CLSCompliant(false)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public unsafe void* ToPointer(); // 0x00000001808BADD0-0x00000001808BADE0
		public override string ToString(); // 0x0000000181652870-0x00000001816528A0
		public string ToString(string format); // 0x0000000181652840-0x0000000181652870
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static bool operator ==(IntPtr value1, IntPtr value2); // 0x0000000180A29AB0-0x0000000180A29AC0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static bool operator !=(IntPtr value1, IntPtr value2); // 0x000000018126B560-0x000000018126B570
		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static explicit operator IntPtr(int value); // 0x00000001815678B0-0x00000001815678C0
		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static explicit operator IntPtr(long value); // 0x0000000180370C60-0x0000000180370C70
		[CLSCompliant(false)]
		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static unsafe explicit operator IntPtr(void* value); // 0x0000000180370C60-0x0000000180370C70
		public static explicit operator int(IntPtr value); // 0x0000000180815D70-0x0000000180815D80
		public static explicit operator long(IntPtr value); // 0x0000000181652910-0x0000000181652920
		[CLSCompliant(false)]
		public static unsafe explicit operator void*(IntPtr value); // 0x0000000180370C60-0x0000000180370C70
		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static IntPtr operator +(IntPtr pointer, int offset); // 0x0000000180A2D970-0x0000000180A2D980
		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static IntPtr operator -(IntPtr pointer, int offset); // 0x0000000181652920-0x0000000181652930
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal bool IsNull(); // 0x0000000180E87410-0x0000000180E87420
		bool IEquatable<IntPtr>.Equals(IntPtr other); // 0x0000000180DF5FE0-0x0000000180DF5FF0
	}
}
