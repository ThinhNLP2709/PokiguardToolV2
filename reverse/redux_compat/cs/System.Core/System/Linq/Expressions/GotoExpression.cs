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
	[DebuggerTypeProxy(typeof(GotoExpressionProxy))]
	public sealed class GotoExpression : Expression // TypeDefIndex: 12080
	{
		// Fields
		[CompilerGenerated]
		private readonly Type _Type_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly Expression _Value_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly LabelTarget _Target_k__BackingField; // 0x20
		[CompilerGenerated]
		private readonly GotoExpressionKind _Kind_k__BackingField; // 0x28
	
		// Properties
		public sealed override Type Type { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public sealed override ExpressionType NodeType { get; } // 0x00000001817BB350-0x00000001817BB360 
		public Expression Value { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public LabelTarget Target { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
		public GotoExpressionKind Kind { [CompilerGenerated] get; } // 0x0000000180377930-0x0000000180377940 
	
		// Constructors
		internal GotoExpression(GotoExpressionKind kind, LabelTarget target, Expression value, Type type); // 0x00000001817BB2A0-0x00000001817BB350
	
		// Methods
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817BB1B0-0x00000001817BB1E0
		public GotoExpression Update(LabelTarget target, Expression value); // 0x00000001817BB1E0-0x00000001817BB2A0
	}
}
