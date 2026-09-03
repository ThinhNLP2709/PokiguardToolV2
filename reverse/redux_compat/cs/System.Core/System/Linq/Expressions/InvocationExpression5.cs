/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	internal sealed class InvocationExpression5 : InvocationExpression // TypeDefIndex: 12091
	{
		// Fields
		private object _arg0; // 0x20
		private readonly Expression _arg1; // 0x28
		private readonly Expression _arg2; // 0x30
		private readonly Expression _arg3; // 0x38
		private readonly Expression _arg4; // 0x40
	
		// Properties
		public override int ArgumentCount { get; } // 0x0000000180A32630-0x0000000180A32640 
	
		// Constructors
		public InvocationExpression5(Expression lambda, Type returnType, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4); // 0x00000001817BCE30-0x00000001817BCEB0
	
		// Methods
		public override Expression GetArgument(int index); // 0x00000001817BCC10-0x00000001817BCD00
		internal override InvocationExpression Rewrite(Expression lambda, Expression[] arguments); // 0x00000001817BCD00-0x00000001817BCE30
	}
}
