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
	public abstract class GetMemberBinder : DynamicMetaObjectBinder // TypeDefIndex: 12578
	{
		// Fields
		[CompilerGenerated]
		private readonly string _Name_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly bool _IgnoreCase_k__BackingField; // 0x20
	
		// Properties
		public sealed override Type ReturnType { get; } // 0x0000000181742460-0x00000001817424A0 
		public string Name { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public bool IgnoreCase { [CompilerGenerated] get; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 
		internal sealed override bool IsStandardBinder { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Constructors
		protected GetMemberBinder(string name, bool ignoreCase); // 0x0000000181804E60-0x0000000181804F20
	
		// Methods
		public DynamicMetaObject FallbackGetMember(DynamicMetaObject target); // 0x0000000181429E80-0x0000000181429EA0
		public abstract DynamicMetaObject FallbackGetMember(DynamicMetaObject target, DynamicMetaObject errorSuggestion);
		public sealed override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args); // 0x0000000181804D60-0x0000000181804E60
	}
}
