/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	internal sealed class MethodCallExpression5 : MethodCallExpression, IArgumentProvider // TypeDefIndex: 12123
	{
		// Fields
		private object _arg0; // 0x18
		private readonly Expression _arg1; // 0x20
		private readonly Expression _arg2; // 0x28
		private readonly Expression _arg3; // 0x30
		private readonly Expression _arg4; // 0x38
	
		// Properties
		public override int ArgumentCount { get; } // 0x0000000180A32630-0x0000000180A32640 
	
		// Constructors
		public MethodCallExpression5(MethodInfo method, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4); // 0x00000001817BEA30-0x00000001817BEB10
	
		// Methods
		public override Expression GetArgument(int index); // 0x00000001817BE7C0-0x00000001817BE8B0
		internal override MethodCallExpression Rewrite(Expression instance, IReadOnlyList<Expression> args); // 0x00000001817BE8B0-0x00000001817BEA30
	}
}
