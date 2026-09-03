/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	public struct CustomAttributeTypedArgument // TypeDefIndex: 3334
	{
		// Fields
		[CompilerGenerated]
		private readonly Type _ArgumentType_k__BackingField; // 0x00
		[CompilerGenerated]
		private readonly object _Value_k__BackingField; // 0x08
	
		// Properties
		public Type ArgumentType { [CompilerGenerated] [IsReadOnly] get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public object Value { [CompilerGenerated] [IsReadOnly] get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
	
		// Constructors
		public CustomAttributeTypedArgument(object value); // 0x0000000181527950-0x0000000181527A60
		public CustomAttributeTypedArgument(Type argumentType, object value); // 0x0000000181527650-0x0000000181527950
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181526F70-0x0000000181526FA0
		public override int GetHashCode(); // 0x0000000181526FA0-0x0000000181526FD0
		public static bool operator ==(CustomAttributeTypedArgument left, CustomAttributeTypedArgument right); // 0x0000000181527A60-0x0000000181527AC0
		public static bool operator !=(CustomAttributeTypedArgument left, CustomAttributeTypedArgument right); // 0x0000000181527AC0-0x0000000181527B20
		public override string ToString(); // 0x0000000181527640-0x0000000181527650
		internal string ToString(bool typed); // 0x0000000181526FD0-0x0000000181527640
		private static object CanonicalizeValue(object value); // 0x0000000181526EE0-0x0000000181526F70
	}
}
