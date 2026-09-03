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
	internal sealed class InstanceMethodCallExpression3 : InstanceMethodCallExpression, IArgumentProvider // TypeDefIndex: 12127
	{
		// Fields
		private object _arg0; // 0x20
		private readonly Expression _arg1; // 0x28
		private readonly Expression _arg2; // 0x30
	
		// Properties
		public override int ArgumentCount { get; } // 0x000000018071E4A0-0x000000018071E4B0 
	
		// Constructors
		public InstanceMethodCallExpression3(MethodInfo method, Expression instance, Expression arg0, Expression arg1, Expression arg2); // 0x00000001817BC170-0x00000001817BC1D0
	
		// Methods
		public override Expression GetArgument(int index); // 0x00000001817BBF70-0x00000001817BC030
		internal override MethodCallExpression Rewrite(Expression instance, IReadOnlyList<Expression> args); // 0x00000001817BC030-0x00000001817BC170
	}
}
