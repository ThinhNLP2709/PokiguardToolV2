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
	[DebuggerTypeProxy(typeof(TypeBinaryExpressionProxy))]
	public sealed class TypeBinaryExpression : Expression // TypeDefIndex: 12144
	{
		// Fields
		[CompilerGenerated]
		private readonly ExpressionType _NodeType_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly Expression _Expression_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly Type _TypeOperand_k__BackingField; // 0x20
	
		// Properties
		public sealed override Type Type { get; } // 0x00000001817A6860-0x00000001817A68A0 
		public sealed override ExpressionType NodeType { [CompilerGenerated] get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public Expression Expression { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public Type TypeOperand { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		internal TypeBinaryExpression(Expression expression, Type typeOperand, ExpressionType nodeType); // 0x00000001817C2EB0-0x00000001817C2F50
	
		// Methods
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817C2DC0-0x00000001817C2DF0
		public TypeBinaryExpression Update(Expression expression); // 0x00000001817C2DF0-0x00000001817C2EB0
	}
}
