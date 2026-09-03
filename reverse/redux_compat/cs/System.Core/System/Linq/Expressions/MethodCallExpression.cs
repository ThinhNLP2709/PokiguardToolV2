/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	[DebuggerTypeProxy(typeof(MethodCallExpressionProxy))]
	public class MethodCallExpression : Expression, IArgumentProvider // TypeDefIndex: 12114
	{
		// Fields
		[CompilerGenerated]
		private readonly MethodInfo _Method_k__BackingField; // 0x10
	
		// Properties
		public sealed override ExpressionType NodeType { get; } // 0x0000000180A32610-0x0000000180A32620 
		public sealed override Type Type { get; } // 0x00000001817BECF0-0x00000001817BED20 
		public MethodInfo Method { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public Expression Object { get; } // 0x00000001817AAE10-0x00000001817AAE30 
		[ExcludeFromCodeCoverage]
		public virtual int ArgumentCount { get; } // 0x00000001817BECC0-0x00000001817BECF0 
	
		// Constructors
		internal MethodCallExpression(MethodInfo method); // 0x00000001817BDE20-0x00000001817BDE90
	
		// Methods
		internal virtual Expression GetInstance(); // 0x00000001802E7860-0x00000001802E7870
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817BEC30-0x00000001817BEC60
		[ExcludeFromCodeCoverage]
		internal virtual MethodCallExpression Rewrite(Expression instance, IReadOnlyList<Expression> args); // 0x00000001817BEC90-0x00000001817BECC0
		[ExcludeFromCodeCoverage]
		public virtual Expression GetArgument(int index); // 0x00000001817BEC60-0x00000001817BEC90
	}
}
