/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	public class Expression<TDelegate> : LambdaExpression // TypeDefIndex: 12095
	{
		// Properties
		internal sealed override Type TypeCore { get; }
		internal override Type PublicType { get; }
	
		// Constructors
		internal Expression(Expression body);
	
		// Methods
		public TDelegate Compile();
		public TDelegate Compile(bool preferInterpretation);
		[ExcludeFromCodeCoverage]
		internal virtual Expression<TDelegate> Rewrite(Expression body, ParameterExpression[] parameters);
		protected internal override Expression Accept(ExpressionVisitor visitor);
	}
}
