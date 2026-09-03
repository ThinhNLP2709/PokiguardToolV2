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
	[DebuggerTypeProxy(typeof(ConstantExpressionProxy))]
	public class ConstantExpression : Expression // TypeDefIndex: 12070
	{
		// Fields
		[CompilerGenerated]
		private readonly object _Value_k__BackingField; // 0x10
	
		// Properties
		public override Type Type { get; } // 0x00000001817AD400-0x00000001817AD450 
		public sealed override ExpressionType NodeType { get; } // 0x00000001815FCAC0-0x00000001815FCAD0 
		public object Value { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		internal ConstantExpression(object value); // 0x00000001817AD390-0x00000001817AD400
	
		// Methods
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817AD360-0x00000001817AD390
	}
}
