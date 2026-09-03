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
	[DebuggerTypeProxy(typeof(LoopExpressionProxy))]
	public sealed class LoopExpression : Expression // TypeDefIndex: 12104
	{
		// Fields
		[CompilerGenerated]
		private readonly Expression _Body_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly LabelTarget _BreakLabel_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly LabelTarget _ContinueLabel_k__BackingField; // 0x20
	
		// Properties
		public sealed override Type Type { get; } // 0x00000001817BDA60-0x00000001817BDAC0 
		public sealed override ExpressionType NodeType { get; } // 0x00000001817BDA50-0x00000001817BDA60 
		public Expression Body { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public LabelTarget BreakLabel { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public LabelTarget ContinueLabel { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		internal LoopExpression(Expression body, LabelTarget @break, LabelTarget @continue); // 0x00000001817BD9B0-0x00000001817BDA50
	
		// Methods
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817BD8F0-0x00000001817BD920
		public LoopExpression Update(LabelTarget breakLabel, LabelTarget continueLabel, Expression body); // 0x00000001817BD920-0x00000001817BD9B0
	}
}
