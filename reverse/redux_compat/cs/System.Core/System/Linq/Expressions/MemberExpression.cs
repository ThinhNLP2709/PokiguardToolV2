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
	[DebuggerTypeProxy(typeof(MemberExpressionProxy))]
	public class MemberExpression : Expression // TypeDefIndex: 12108
	{
		// Fields
		[CompilerGenerated]
		private readonly Expression _Expression_k__BackingField; // 0x10
	
		// Properties
		public MemberInfo Member { get; } // 0x000000018152D8E0-0x000000018152D900 
		public Expression Expression { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public sealed override ExpressionType NodeType { get; } // 0x00000001815902A0-0x00000001815902B0 
	
		// Constructors
		internal MemberExpression(Expression expression); // 0x00000001817BDD10-0x00000001817BDD80
	
		// Methods
		internal static PropertyExpression Make(Expression expression, PropertyInfo property); // 0x00000001817BDBD0-0x00000001817BDC80
		internal static FieldExpression Make(Expression expression, FieldInfo field); // 0x00000001817BDB20-0x00000001817BDBD0
		[ExcludeFromCodeCoverage]
		internal virtual MemberInfo GetMember(); // 0x00000001817BDAF0-0x00000001817BDB20
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817BDAC0-0x00000001817BDAF0
		public MemberExpression Update(Expression expression); // 0x00000001817BDC80-0x00000001817BDD10
	}
}
