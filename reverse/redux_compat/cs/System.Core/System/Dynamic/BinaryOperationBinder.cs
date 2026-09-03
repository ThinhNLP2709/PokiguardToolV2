/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Dynamic
{
	public abstract class BinaryOperationBinder : DynamicMetaObjectBinder // TypeDefIndex: 12549
	{
		// Fields
		[CompilerGenerated]
		private readonly ExpressionType _Operation_k__BackingField; // 0x18
	
		// Properties
		public ExpressionType Operation { [CompilerGenerated] get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Methods
		public DynamicMetaObject FallbackBinaryOperation(DynamicMetaObject target, DynamicMetaObject arg); // 0x00000001817E75B0-0x00000001817E75E0
		public abstract DynamicMetaObject FallbackBinaryOperation(DynamicMetaObject target, DynamicMetaObject arg, DynamicMetaObject errorSuggestion);
		public sealed override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args); // 0x00000001817E74D0-0x00000001817E75B0
	}
}
