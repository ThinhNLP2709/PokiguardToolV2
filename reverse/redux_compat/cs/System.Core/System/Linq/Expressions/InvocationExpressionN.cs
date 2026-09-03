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
	internal sealed class InvocationExpressionN : InvocationExpression // TypeDefIndex: 12085
	{
		// Fields
		private IReadOnlyList<Expression> _arguments; // 0x20
	
		// Properties
		public override int ArgumentCount { get; } // 0x00000001817BCFC0-0x00000001817BD010 
	
		// Constructors
		public InvocationExpressionN(Expression lambda, IReadOnlyList<Expression> arguments, Type returnType); // 0x00000001817BCF80-0x00000001817BCFC0
	
		// Methods
		public override Expression GetArgument(int index); // 0x00000001817BCEB0-0x00000001817BCF10
		internal override InvocationExpression Rewrite(Expression lambda, Expression[] arguments); // 0x00000001817BCF10-0x00000001817BCF80
	}
}
