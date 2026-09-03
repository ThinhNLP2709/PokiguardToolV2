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
	public abstract class DeleteIndexBinder : DynamicMetaObjectBinder // TypeDefIndex: 12560
	{
		// Methods
		public sealed override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args); // 0x00000001817EB6E0-0x00000001817EB790
		public DynamicMetaObject FallbackDeleteIndex(DynamicMetaObject target, DynamicMetaObject[] indexes); // 0x00000001817E75B0-0x00000001817E75E0
		public abstract DynamicMetaObject FallbackDeleteIndex(DynamicMetaObject target, DynamicMetaObject[] indexes, DynamicMetaObject errorSuggestion);
	}
}
