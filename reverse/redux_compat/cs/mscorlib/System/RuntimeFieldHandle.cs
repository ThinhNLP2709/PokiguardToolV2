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
	public struct RuntimeFieldHandle : ISerializable // TypeDefIndex: 2481
	{
		// Fields
		private IntPtr value; // 0x00
	
		// Properties
		public IntPtr Value { get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
		// Constructors
		internal RuntimeFieldHandle(IntPtr v); // 0x0000000180CBE820-0x0000000180CBE830
		private RuntimeFieldHandle(SerializationInfo info, StreamingContext context); // 0x0000000181658CD0-0x0000000181658E60
	
		// Methods
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181658B30-0x0000000181658CB0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public override bool Equals(object obj); // 0x0000000181658A60-0x0000000181658B30
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		private static void SetValueInternal(FieldInfo fi, object obj, object value); // 0x0000000181658CC0-0x0000000181658CD0
		internal static void SetValue(RuntimeFieldInfo field, object obj, object value, RuntimeType fieldType, FieldAttributes fieldAttr, RuntimeType declaringType, ref bool domainInitialized); // 0x0000000181658CC0-0x0000000181658CD0
		internal static unsafe void SetValueDirect(RuntimeFieldInfo field, RuntimeType fieldType, void* pTypedRef, object value, RuntimeType contextType); // 0x0000000181658CB0-0x0000000181658CC0
	}
}
