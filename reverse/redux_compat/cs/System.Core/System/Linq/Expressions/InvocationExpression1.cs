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
	internal sealed class InvocationExpression1 : InvocationExpression // TypeDefIndex: 12087
	{
		// Fields
		private object _arg0; // 0x20
	
		// Properties
		public override int ArgumentCount { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		public InvocationExpression1(Expression lambda, Type returnType, Expression arg0); // 0x00000001817BC580-0x00000001817BC5C0
	
		// Methods
		public override Expression GetArgument(int index); // 0x00000001817BC440-0x00000001817BC4E0
		internal override InvocationExpression Rewrite(Expression lambda, Expression[] arguments); // 0x00000001817BC4E0-0x00000001817BC580
	}
}
