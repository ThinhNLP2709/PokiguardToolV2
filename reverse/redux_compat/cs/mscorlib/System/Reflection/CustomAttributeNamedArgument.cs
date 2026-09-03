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
	public struct CustomAttributeNamedArgument // TypeDefIndex: 3333
	{
		// Fields
		[CompilerGenerated]
		private readonly CustomAttributeTypedArgument _TypedValue_k__BackingField; // 0x00
		[CompilerGenerated]
		private readonly bool _IsField_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly string _MemberName_k__BackingField; // 0x18
		private readonly Type _attributeType; // 0x20
		private MemberInfo _lazyMemberInfo; // 0x28
	
		// Properties
		public CustomAttributeTypedArgument TypedValue { [CompilerGenerated] [IsReadOnly] get; } // 0x000000018092E600-0x000000018092E610 
		public bool IsField { [CompilerGenerated] [IsReadOnly] get; } // 0x00000001805625D0-0x00000001805625E0 
		public string MemberName { [CompilerGenerated] [IsReadOnly] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public MemberInfo MemberInfo { get; } // 0x0000000181526CC0-0x0000000181526DE0 
	
		// Constructors
		internal CustomAttributeNamedArgument(Type attributeType, string memberName, bool isField, CustomAttributeTypedArgument typedValue); // 0x0000000181526890-0x0000000181526900
		public CustomAttributeNamedArgument(MemberInfo memberInfo, object value); // 0x0000000181526900-0x0000000181526B70
		public CustomAttributeNamedArgument(MemberInfo memberInfo, CustomAttributeTypedArgument typedArgument); // 0x0000000181526B70-0x0000000181526CC0
	
		// Methods
		public override bool Equals(object obj); // 0x00000001815265E0-0x0000000181526620
		public override int GetHashCode(); // 0x0000000181526620-0x0000000181526660
		public static bool operator ==(CustomAttributeNamedArgument left, CustomAttributeNamedArgument right); // 0x0000000181526DE0-0x0000000181526E60
		public static bool operator !=(CustomAttributeNamedArgument left, CustomAttributeNamedArgument right); // 0x0000000181526E60-0x0000000181526EE0
		public override string ToString(); // 0x0000000181526660-0x0000000181526890
	}
}
