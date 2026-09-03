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
	internal class ScopeN : ScopeExpression // TypeDefIndex: 12059
	{
		// Fields
		private IReadOnlyList<Expression> _body; // 0x18
	
		// Properties
		protected IReadOnlyList<Expression> Body { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		internal override int ExpressionCount { get; } // 0x00000001817C03F0-0x00000001817C0440 
	
		// Constructors
		internal ScopeN(IReadOnlyList<ParameterExpression> variables, IReadOnlyList<Expression> body); // 0x00000001817A9D00-0x00000001817A9D90
	
		// Methods
		internal override Expression GetExpression(int index); // 0x00000001817C0200-0x00000001817C0260
		internal override ReadOnlyCollection<Expression> GetOrMakeExpressions(); // 0x00000001817C0260-0x00000001817C02A0
		internal override BlockExpression Rewrite(ReadOnlyCollection<ParameterExpression> variables, Expression[] args); // 0x00000001817C02A0-0x00000001817C03F0
	}
}
