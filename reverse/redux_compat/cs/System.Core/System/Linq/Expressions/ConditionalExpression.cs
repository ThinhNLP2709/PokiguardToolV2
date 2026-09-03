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
	[DebuggerTypeProxy(typeof(ConditionalExpressionProxy))]
	public class ConditionalExpression : Expression // TypeDefIndex: 12067
	{
		// Fields
		[CompilerGenerated]
		private readonly Expression _Test_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly Expression _IfTrue_k__BackingField; // 0x18
	
		// Properties
		public sealed override ExpressionType NodeType { get; } // 0x0000000180740830-0x0000000180740840 
		public override Type Type { get; } // 0x0000000181789720-0x0000000181789750 
		public Expression Test { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public Expression IfTrue { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public Expression IfFalse { get; } // 0x000000018152D8E0-0x000000018152D900 
	
		// Constructors
		internal ConditionalExpression(Expression test, Expression ifTrue); // 0x00000001817ACF20-0x00000001817ACFB0
	
		// Methods
		internal static ConditionalExpression Make(Expression test, Expression ifTrue, Expression ifFalse, Type type); // 0x00000001817ACC60-0x00000001817ACE50
		internal virtual Expression GetFalse(); // 0x00000001817ACC00-0x00000001817ACC60
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817ACBD0-0x00000001817ACC00
		public ConditionalExpression Update(Expression test, Expression ifTrue, Expression ifFalse); // 0x00000001817ACE50-0x00000001817ACF20
	}
}
