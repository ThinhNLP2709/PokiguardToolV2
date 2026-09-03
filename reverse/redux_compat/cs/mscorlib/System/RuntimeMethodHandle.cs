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
	public struct RuntimeMethodHandle : ISerializable // TypeDefIndex: 2482
	{
		// Fields
		private IntPtr value; // 0x00
	
		// Properties
		public IntPtr Value { get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
		// Constructors
		internal RuntimeMethodHandle(IntPtr v); // 0x0000000180CBE820-0x0000000180CBE830
		private RuntimeMethodHandle(SerializationInfo info, StreamingContext context); // 0x0000000181659220-0x00000001816593B0
	
		// Methods
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001816590A0-0x0000000181659220
		private static IntPtr GetFunctionPointer(IntPtr m); // 0x0000000181659090-0x00000001816590A0
		public IntPtr GetFunctionPointer(); // 0x0000000181659080-0x0000000181659090
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public override bool Equals(object obj); // 0x0000000181658FB0-0x0000000181659080
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		internal static string ConstructInstantiation(RuntimeMethodInfo method, TypeNameFormatFlags format); // 0x0000000181658E60-0x0000000181658FB0
		internal bool IsNullHandle(); // 0x0000000180E87410-0x0000000180E87420
	}
}
