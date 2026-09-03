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
	internal sealed class Block2 : BlockExpression // TypeDefIndex: 12052
	{
		// Fields
		private object _arg0; // 0x10
		private readonly Expression _arg1; // 0x18
	
		// Properties
		internal override int ExpressionCount { get; } // 0x0000000180476390-0x00000001804763A0 
	
		// Constructors
		internal Block2(Expression arg0, Expression arg1); // 0x00000001817A9D00-0x00000001817A9D90
	
		// Methods
		internal override Expression GetExpression(int index); // 0x00000001817A9B80-0x00000001817A9C10
		internal override ReadOnlyCollection<Expression> GetOrMakeExpressions(); // 0x00000001817A9C10-0x00000001817A9C20
		internal override BlockExpression Rewrite(ReadOnlyCollection<ParameterExpression> variables, Expression[] args); // 0x00000001817A9C20-0x00000001817A9D00
	}
}
