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
	internal sealed class MethodCallExpression0 : MethodCallExpression, IArgumentProvider // TypeDefIndex: 12118
	{
		// Properties
		public override int ArgumentCount { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		public MethodCallExpression0(MethodInfo method); // 0x00000001817BDE20-0x00000001817BDE90
	
		// Methods
		public override Expression GetArgument(int index); // 0x00000001817BDD80-0x00000001817BDDD0
		internal override MethodCallExpression Rewrite(Expression instance, IReadOnlyList<Expression> args); // 0x00000001817BDDD0-0x00000001817BDE20
	}
}
