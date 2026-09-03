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

namespace System.Linq.Expressions
{
	[DebuggerTypeProxy(typeof(Expression.CatchBlockProxy))]
	public sealed class CatchBlock // TypeDefIndex: 12063
	{
		// Fields
		[CompilerGenerated]
		private readonly ParameterExpression _Variable_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly Type _Test_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly Expression _Body_k__BackingField; // 0x20
		[CompilerGenerated]
		private readonly Expression _Filter_k__BackingField; // 0x28
	
		// Properties
		public ParameterExpression Variable { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public Type Test { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public Expression Body { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
		public Expression Filter { [CompilerGenerated] get; } // 0x000000018033D240-0x000000018033D250 
	
		// Constructors
		internal CatchBlock(Type test, ParameterExpression variable, Expression body, Expression filter); // 0x00000001817ACA50-0x00000001817ACAD0
	
		// Methods
		public override string ToString(); // 0x00000001817AC8F0-0x00000001817AC9B0
		public CatchBlock Update(ParameterExpression variable, Expression filter, Expression body); // 0x00000001817AC9B0-0x00000001817ACA50
	}
}
