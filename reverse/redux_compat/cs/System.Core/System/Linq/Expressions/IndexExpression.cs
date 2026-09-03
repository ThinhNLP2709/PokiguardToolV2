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
	[DebuggerTypeProxy(typeof(IndexExpressionProxy))]
	public sealed class IndexExpression : Expression, IArgumentProvider // TypeDefIndex: 12083
	{
		// Fields
		private IReadOnlyList<Expression> _arguments; // 0x10
		[CompilerGenerated]
		private readonly Expression _Object_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly PropertyInfo _Indexer_k__BackingField; // 0x20
	
		// Properties
		public sealed override ExpressionType NodeType { get; } // 0x00000001817BB8B0-0x00000001817BB8C0 
		public sealed override Type Type { get; } // 0x00000001817BB8C0-0x00000001817BB940 
		public Expression Object { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public PropertyInfo Indexer { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
		public int ArgumentCount { get; } // 0x00000001817BB860-0x00000001817BB8B0 
	
		// Constructors
		internal IndexExpression(Expression instance, PropertyInfo indexer, IReadOnlyList<Expression> arguments); // 0x00000001817BB7B0-0x00000001817BB860
	
		// Methods
		public Expression GetArgument(int index); // 0x00000001817BB6D0-0x00000001817BB730
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817BB6A0-0x00000001817BB6D0
		internal Expression Rewrite(Expression instance, Expression[] arguments); // 0x00000001817BB730-0x00000001817BB7B0
	}
}
