/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	[CLSCompliant(false)]
	public sealed class Pointer : ISerializable // TypeDefIndex: 3314
	{
		// Fields
		private readonly unsafe void* _ptr; // 0x10
		private readonly Type _ptrType; // 0x18
	
		// Constructors
		private unsafe Pointer(void* ptr, Type ptrType); // 0x0000000181533F60-0x0000000181533FB0
	
		// Methods
		public static unsafe object Box(void* ptr, Type type); // 0x0000000181533D50-0x0000000181533F20
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181533F20-0x0000000181533F60
	}
}
