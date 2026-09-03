/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	[DebuggerTypeProxy(typeof(NewArrayExpressionProxy))]
	public class NewArrayExpression : Expression // TypeDefIndex: 12128
	{
		// Fields
		[CompilerGenerated]
		private readonly Type _Type_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly ReadOnlyCollection<Expression> _Expressions_k__BackingField; // 0x18
	
		// Properties
		public sealed override Type Type { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public ReadOnlyCollection<Expression> Expressions { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		internal NewArrayExpression(Type type, ReadOnlyCollection<Expression> expressions); // 0x00000001817BF560-0x00000001817BF5F0
	
		// Methods
		internal static NewArrayExpression Make(ExpressionType nodeType, Type type, ReadOnlyCollection<Expression> expressions); // 0x00000001817BF370-0x00000001817BF3F0
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817BF340-0x00000001817BF370
		public NewArrayExpression Update(IEnumerable<Expression> expressions); // 0x00000001817BF3F0-0x00000001817BF560
	}
}
