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
	[DebuggerTypeProxy(typeof(LabelExpressionProxy))]
	public sealed class LabelExpression : Expression // TypeDefIndex: 12092
	{
		// Fields
		[CompilerGenerated]
		private readonly LabelTarget _Target_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly Expression _DefaultValue_k__BackingField; // 0x18
	
		// Properties
		public sealed override Type Type { get; } // 0x00000001814C98E0-0x00000001814C9900 
		public sealed override ExpressionType NodeType { get; } // 0x0000000180A2FBF0-0x0000000180A2FC00 
		public LabelTarget Target { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public Expression DefaultValue { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		internal LabelExpression(LabelTarget label, Expression defaultValue); // 0x00000001817BD220-0x00000001817BD2B0
	
		// Methods
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817BD160-0x00000001817BD190
		public LabelExpression Update(LabelTarget target, Expression defaultValue); // 0x00000001817BD190-0x00000001817BD220
	}
}
