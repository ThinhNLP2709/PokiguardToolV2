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
	internal sealed class InstanceMethodCallExpression1 : InstanceMethodCallExpression, IArgumentProvider // TypeDefIndex: 12125
	{
		// Fields
		private object _arg0; // 0x20
	
		// Properties
		public override int ArgumentCount { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		public InstanceMethodCallExpression1(MethodInfo method, Expression instance, Expression arg0); // 0x00000001817BBD20-0x00000001817BBD60
	
		// Methods
		public override Expression GetArgument(int index); // 0x00000001817BBBC0-0x00000001817BBC60
		internal override MethodCallExpression Rewrite(Expression instance, IReadOnlyList<Expression> args); // 0x00000001817BBC60-0x00000001817BBD20
	}
}
