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
	internal sealed class InstanceMethodCallExpressionN : InstanceMethodCallExpression, IArgumentProvider // TypeDefIndex: 12117
	{
		// Fields
		private IReadOnlyList<Expression> _arguments; // 0x20
	
		// Properties
		public override int ArgumentCount { get; } // 0x00000001817BC2B0-0x00000001817BC300 
	
		// Constructors
		public InstanceMethodCallExpressionN(MethodInfo method, Expression instance, IReadOnlyList<Expression> args); // 0x00000001817BBD20-0x00000001817BBD60
	
		// Methods
		public override Expression GetArgument(int index); // 0x00000001817BC1D0-0x00000001817BC230
		internal override MethodCallExpression Rewrite(Expression instance, IReadOnlyList<Expression> args); // 0x00000001817BC230-0x00000001817BC2B0
	}
}
