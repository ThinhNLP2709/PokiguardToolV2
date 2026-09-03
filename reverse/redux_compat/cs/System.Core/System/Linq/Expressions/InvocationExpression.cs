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
	[DebuggerTypeProxy(typeof(InvocationExpressionProxy))]
	public class InvocationExpression : Expression, IArgumentProvider // TypeDefIndex: 12084
	{
		// Fields
		[CompilerGenerated]
		private readonly Type _Type_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly Expression _Expression_k__BackingField; // 0x18
	
		// Properties
		public sealed override Type Type { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public sealed override ExpressionType NodeType { get; } // 0x0000000181777F20-0x0000000181777F30 
		public Expression Expression { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		[ExcludeFromCodeCoverage]
		public virtual int ArgumentCount { get; } // 0x00000001817BD130-0x00000001817BD160 
	
		// Constructors
		internal InvocationExpression(Expression expression, Type returnType); // 0x00000001817BD0A0-0x00000001817BD130
	
		// Methods
		[ExcludeFromCodeCoverage]
		public virtual Expression GetArgument(int index); // 0x00000001817BD040-0x00000001817BD070
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817BD010-0x00000001817BD040
		[ExcludeFromCodeCoverage]
		internal virtual InvocationExpression Rewrite(Expression lambda, Expression[] arguments); // 0x00000001817BD070-0x00000001817BD0A0
	}
}
