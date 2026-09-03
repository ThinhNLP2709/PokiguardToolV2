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

namespace System
{
	[Serializable]
	[CLSCompliant(false)]
	[ComVisible(true)]
	[IsReadOnly]
	public struct UIntPtr : ISerializable, IEquatable<UIntPtr> // TypeDefIndex: 2503
	{
		// Fields
		public static readonly UIntPtr Zero; // 0x00
		private readonly unsafe void* _pointer; // 0x00
	
		// Properties
		public static int Size { get; } // 0x0000000180740830-0x0000000180740840 
	
		// Constructors
		public unsafe UIntPtr(ulong value); // 0x0000000181678FF0-0x0000000181679000
		public unsafe UIntPtr(uint value); // 0x0000000181678FE0-0x0000000181678FF0
		[CLSCompliant(false)]
		public unsafe UIntPtr(void* value); // 0x0000000180CBE820-0x0000000180CBE830
		static UIntPtr(); // 0x0000000181678FC0-0x0000000181678FE0
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181678EB0-0x0000000181678F00
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		[CLSCompliant(false)]
		public unsafe void* ToPointer(); // 0x00000001808BADD0-0x00000001808BADE0
		public override string ToString(); // 0x0000000181678FA0-0x0000000181678FC0
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181678F00-0x0000000181678FA0
		public static bool operator ==(UIntPtr value1, UIntPtr value2); // 0x0000000180A29AB0-0x0000000180A29AC0
		public static bool operator !=(UIntPtr value1, UIntPtr value2); // 0x000000018126B560-0x000000018126B570
		public static explicit operator UIntPtr(ulong value); // 0x0000000181652910-0x0000000181652920
		[CLSCompliant(false)]
		public static unsafe explicit operator void*(UIntPtr value); // 0x0000000180370C60-0x0000000180370C70
		public static explicit operator UIntPtr(uint value); // 0x0000000180815D70-0x0000000180815D80
		bool IEquatable<UIntPtr>.Equals(UIntPtr other); // 0x0000000180DF5FE0-0x0000000180DF5FF0
	}
}
