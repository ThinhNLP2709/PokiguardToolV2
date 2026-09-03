/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Dynamic
{
	public abstract class InvokeMemberBinder : DynamicMetaObjectBinder // TypeDefIndex: 12581
	{
		// Fields
		[CompilerGenerated]
		private readonly string _Name_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly bool _IgnoreCase_k__BackingField; // 0x20
	
		// Properties
		public string Name { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public bool IgnoreCase { [CompilerGenerated] get; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 
	
		// Methods
		public sealed override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args); // 0x0000000181805010-0x0000000181805100
		public DynamicMetaObject FallbackInvokeMember(DynamicMetaObject target, DynamicMetaObject[] args); // 0x00000001817E75B0-0x00000001817E75E0
		public abstract DynamicMetaObject FallbackInvokeMember(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject errorSuggestion);
		public abstract DynamicMetaObject FallbackInvoke(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject errorSuggestion);
	}
}
