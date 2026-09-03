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
	internal sealed class MethodCallExpression1 : MethodCallExpression, IArgumentProvider // TypeDefIndex: 12119
	{
		// Fields
		private object _arg0; // 0x18
	
		// Properties
		public override int ArgumentCount { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		public MethodCallExpression1(MethodInfo method, Expression arg0); // 0x00000001817BC300-0x00000001817BC390
	
		// Methods
		public override Expression GetArgument(int index); // 0x00000001817BDE90-0x00000001817BDF30
		internal override MethodCallExpression Rewrite(Expression instance, IReadOnlyList<Expression> args); // 0x00000001817BDF30-0x00000001817BDFE0
	}
}
