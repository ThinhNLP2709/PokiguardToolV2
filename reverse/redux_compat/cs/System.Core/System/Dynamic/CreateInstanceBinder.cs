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
	public abstract class CreateInstanceBinder : DynamicMetaObjectBinder // TypeDefIndex: 12559
	{
		// Methods
		public DynamicMetaObject FallbackCreateInstance(DynamicMetaObject target, DynamicMetaObject[] args); // 0x00000001817E75B0-0x00000001817E75E0
		public abstract DynamicMetaObject FallbackCreateInstance(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject errorSuggestion);
		public sealed override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args); // 0x00000001817EA340-0x00000001817EA3F0
	}
}
