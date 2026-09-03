/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	internal sealed class Scope1 : ScopeExpression // TypeDefIndex: 12058
	{
		// Fields
		private object _body; // 0x18
	
		// Properties
		internal override int ExpressionCount { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		internal Scope1(IReadOnlyList<ParameterExpression> variables, Expression body); // 0x00000001817C0120-0x00000001817C0130
		private Scope1(IReadOnlyList<ParameterExpression> variables, object body); // 0x00000001817A9D00-0x00000001817A9D90
	
		// Methods
		internal override Expression GetExpression(int index); // 0x00000001817BFF60-0x00000001817BFFE0
		internal override ReadOnlyCollection<Expression> GetOrMakeExpressions(); // 0x00000001817BFFE0-0x00000001817BFFF0
		internal override BlockExpression Rewrite(ReadOnlyCollection<ParameterExpression> variables, Expression[] args); // 0x00000001817BFFF0-0x00000001817C0120
	}
}
