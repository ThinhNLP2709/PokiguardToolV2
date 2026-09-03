/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	internal sealed class Block4 : BlockExpression // TypeDefIndex: 12054
	{
		// Fields
		private object _arg0; // 0x10
		private readonly Expression _arg1; // 0x18
		private readonly Expression _arg2; // 0x20
		private readonly Expression _arg3; // 0x28
	
		// Properties
		internal override int ExpressionCount { get; } // 0x00000001804CB980-0x00000001804CB990 
	
		// Constructors
		internal Block4(Expression arg0, Expression arg1, Expression arg2, Expression arg3); // 0x00000001817AA1E0-0x00000001817AA2A0
	
		// Methods
		internal override Expression GetExpression(int index); // 0x00000001817A9FF0-0x00000001817AA0B0
		internal override ReadOnlyCollection<Expression> GetOrMakeExpressions(); // 0x00000001817A9C10-0x00000001817A9C20
		internal override BlockExpression Rewrite(ReadOnlyCollection<ParameterExpression> variables, Expression[] args); // 0x00000001817AA0B0-0x00000001817AA1E0
	}
}
