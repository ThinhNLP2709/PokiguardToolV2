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
	internal sealed class Block5 : BlockExpression // TypeDefIndex: 12055
	{
		// Fields
		private object _arg0; // 0x10
		private readonly Expression _arg1; // 0x18
		private readonly Expression _arg2; // 0x20
		private readonly Expression _arg3; // 0x28
		private readonly Expression _arg4; // 0x30
	
		// Properties
		internal override int ExpressionCount { get; } // 0x0000000180A32630-0x0000000180A32640 
	
		// Constructors
		internal Block5(Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4); // 0x00000001817AA4D0-0x00000001817AA5A0
	
		// Methods
		internal override Expression GetExpression(int index); // 0x00000001817AA2A0-0x00000001817AA370
		internal override ReadOnlyCollection<Expression> GetOrMakeExpressions(); // 0x00000001817A9C10-0x00000001817A9C20
		internal override BlockExpression Rewrite(ReadOnlyCollection<ParameterExpression> variables, Expression[] args); // 0x00000001817AA370-0x00000001817AA4D0
	}
}
