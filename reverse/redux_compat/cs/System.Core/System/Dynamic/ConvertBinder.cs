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
	public abstract class ConvertBinder : DynamicMetaObjectBinder // TypeDefIndex: 12558
	{
		// Fields
		[CompilerGenerated]
		private readonly Type _Type_k__BackingField; // 0x18
	
		// Properties
		public Type Type { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Methods
		public DynamicMetaObject FallbackConvert(DynamicMetaObject target); // 0x0000000181429E80-0x0000000181429EA0
		public abstract DynamicMetaObject FallbackConvert(DynamicMetaObject target, DynamicMetaObject errorSuggestion);
		public sealed override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args); // 0x00000001817EA060-0x00000001817EA110
	}
}
