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
	public abstract class DeleteMemberBinder : DynamicMetaObjectBinder // TypeDefIndex: 12561
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
		public DynamicMetaObject FallbackDeleteMember(DynamicMetaObject target); // 0x0000000181429E80-0x0000000181429EA0
		public abstract DynamicMetaObject FallbackDeleteMember(DynamicMetaObject target, DynamicMetaObject errorSuggestion);
		public sealed override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args); // 0x00000001817EB790-0x00000001817EB840
	}
}
