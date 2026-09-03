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
	internal sealed class MethodCallExpression3 : MethodCallExpression, IArgumentProvider // TypeDefIndex: 12121
	{
		// Fields
		private object _arg0; // 0x18
		private readonly Expression _arg1; // 0x20
		private readonly Expression _arg2; // 0x28
	
		// Properties
		public override int ArgumentCount { get; } // 0x000000018071E4A0-0x000000018071E4B0 
	
		// Constructors
		public MethodCallExpression3(MethodInfo method, Expression arg0, Expression arg1, Expression arg2); // 0x00000001817BE400-0x00000001817BE4C0
	
		// Methods
		public override Expression GetArgument(int index); // 0x00000001817BE220-0x00000001817BE2E0
		internal override MethodCallExpression Rewrite(Expression instance, IReadOnlyList<Expression> args); // 0x00000001817BE2E0-0x00000001817BE400
	}
}
