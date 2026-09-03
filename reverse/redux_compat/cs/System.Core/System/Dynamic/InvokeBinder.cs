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
	public abstract class InvokeBinder : DynamicMetaObjectBinder // TypeDefIndex: 12580
	{
		// Methods
		public DynamicMetaObject FallbackInvoke(DynamicMetaObject target, DynamicMetaObject[] args); // 0x00000001817E75B0-0x00000001817E75E0
		public abstract DynamicMetaObject FallbackInvoke(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject errorSuggestion);
		public sealed override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args); // 0x0000000181804F20-0x0000000181805010
	}
}
