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
	internal sealed class Expression0<TDelegate> : Expression<TDelegate> // TypeDefIndex: 12097
	{
		// Properties
		internal override int ParameterCount { get; }
	
		// Constructors
		public Expression0(Expression body);
	
		// Methods
		internal override ParameterExpression GetParameter(int index);
		internal override Expression<TDelegate> Rewrite(Expression body, ParameterExpression[] parameters);
	}
}
