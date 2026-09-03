/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	[DebuggerTypeProxy(typeof(BlockExpressionProxy))]
	public class BlockExpression : Expression // TypeDefIndex: 12051
	{
		// Properties
		public ReadOnlyCollection<Expression> Expressions { get; } // 0x00000001817AAE10-0x00000001817AAE30 
		public ReadOnlyCollection<ParameterExpression> Variables { get; } // 0x000000018159E100-0x000000018159E120 
		public sealed override ExpressionType NodeType { get; } // 0x00000001817AAE30-0x00000001817AAE40 
		public override Type Type { get; } // 0x00000001817AAE40-0x00000001817AAEA0 
		[ExcludeFromCodeCoverage]
		internal virtual int ExpressionCount { get; } // 0x00000001817AADE0-0x00000001817AAE10 
	
		// Constructors
		internal BlockExpression(); // 0x00000001817AAD90-0x00000001817AADE0
	
		// Methods
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817AAB30-0x00000001817AAB60
		[ExcludeFromCodeCoverage]
		internal virtual Expression GetExpression(int index); // 0x00000001817AAB60-0x00000001817AAB90
		[ExcludeFromCodeCoverage]
		internal virtual ReadOnlyCollection<Expression> GetOrMakeExpressions(); // 0x00000001817AAB90-0x00000001817AABC0
		internal virtual ReadOnlyCollection<ParameterExpression> GetOrMakeVariables(); // 0x00000001817AABC0-0x00000001817AAC10
		[ExcludeFromCodeCoverage]
		internal virtual BlockExpression Rewrite(ReadOnlyCollection<ParameterExpression> variables, Expression[] args); // 0x00000001817AAD60-0x00000001817AAD90
		internal static ReadOnlyCollection<Expression> ReturnReadOnlyExpressions(BlockExpression provider, ref object collection); // 0x00000001817AAC10-0x00000001817AAD60
	}
}
