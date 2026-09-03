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
	[DebuggerTypeProxy(typeof(DefaultExpressionProxy))]
	public sealed class DefaultExpression : Expression // TypeDefIndex: 12073
	{
		// Fields
		[CompilerGenerated]
		private readonly Type _Type_k__BackingField; // 0x10
	
		// Properties
		public sealed override Type Type { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public sealed override ExpressionType NodeType { get; } // 0x00000001817ADEF0-0x00000001817ADF00 
	
		// Constructors
		internal DefaultExpression(Type type); // 0x00000001817ADE80-0x00000001817ADEF0
	
		// Methods
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817ADE50-0x00000001817ADE80
	}
}
