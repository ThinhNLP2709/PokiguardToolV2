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
	[DebuggerTypeProxy(typeof(UnaryExpressionProxy))]
	public sealed class UnaryExpression : Expression // TypeDefIndex: 12145
	{
		// Fields
		[CompilerGenerated]
		private readonly Type _Type_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly ExpressionType _NodeType_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly Expression _Operand_k__BackingField; // 0x20
		[CompilerGenerated]
		private readonly MethodInfo _Method_k__BackingField; // 0x28
	
		// Properties
		public sealed override Type Type { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public sealed override ExpressionType NodeType { [CompilerGenerated] get; } // 0x0000000180B23260-0x0000000180B23270 
		public Expression Operand { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
		public MethodInfo Method { [CompilerGenerated] get; } // 0x000000018033D240-0x000000018033D250 
		public bool IsLifted { get; } // 0x00000001817C4660-0x00000001817C48B0 
		public bool IsLiftedToNull { get; } // 0x00000001817C45E0-0x00000001817C4660 
		public override bool CanReduce { get; } // 0x00000001817C45B0-0x00000001817C45E0 
		private bool IsPrefix { get; } // 0x00000001817C48B0-0x00000001817C4900 
	
		// Constructors
		internal UnaryExpression(ExpressionType nodeType, Expression expression, Type type, MethodInfo method); // 0x00000001817C4500-0x00000001817C45B0
	
		// Methods
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817C31C0-0x00000001817C31F0
		public override Expression Reduce(); // 0x00000001817C43B0-0x00000001817C4430
		private UnaryExpression FunctionalOp(Expression operand); // 0x00000001817C31F0-0x00000001817C3340
		private Expression ReduceVariable(); // 0x00000001817C4080-0x00000001817C43B0
		private Expression ReduceMember(); // 0x00000001817C3AB0-0x00000001817C4080
		private Expression ReduceIndex(); // 0x00000001817C3340-0x00000001817C3AB0
		public UnaryExpression Update(Expression operand); // 0x00000001817C4430-0x00000001817C4500
	}
}
