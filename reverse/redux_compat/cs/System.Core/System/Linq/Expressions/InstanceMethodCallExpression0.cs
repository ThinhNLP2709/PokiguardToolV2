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
	internal sealed class InstanceMethodCallExpression0 : InstanceMethodCallExpression, IArgumentProvider // TypeDefIndex: 12124
	{
		// Properties
		public override int ArgumentCount { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		public InstanceMethodCallExpression0(MethodInfo method, Expression instance); // 0x00000001817BBBB0-0x00000001817BBBC0
	
		// Methods
		public override Expression GetArgument(int index); // 0x00000001817BBB00-0x00000001817BBB50
		internal override MethodCallExpression Rewrite(Expression instance, IReadOnlyList<Expression> args); // 0x00000001817BBB50-0x00000001817BBBB0
	}
}
