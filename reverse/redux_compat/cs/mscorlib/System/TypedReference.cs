/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[CLSCompliant(false)]
	[ComVisible(true)]
	[IsByRefLike]
	[NonVersionable]
	public struct TypedReference // TypeDefIndex: 2437
	{
		// Fields
		private RuntimeTypeHandle type; // 0x00
		private IntPtr Value; // 0x08
		private IntPtr Type; // 0x10
	
		// Properties
		internal bool IsNull { get; } // 0x00000001816619D0-0x00000001816619F0 
	
		// Methods
		[CLSCompliant(false)]
		public static TypedReference MakeTypedReference(object target, FieldInfo[] flds); // 0x00000001816613C0-0x0000000181661980
		private static unsafe void InternalMakeTypedReference(void* result, object target, IntPtr[] flds, RuntimeType lastFieldType); // 0x00000001816613B0-0x00000001816613C0
		public override int GetHashCode(); // 0x0000000181661340-0x00000001816613B0
		public override bool Equals(object o); // 0x00000001816612E0-0x0000000181661340
		[CLSCompliant(false)]
		public static void SetTypedReference(TypedReference target, object value); // 0x0000000181661980-0x00000001816619D0
	}
}
