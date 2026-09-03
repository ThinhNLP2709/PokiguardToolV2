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
	internal class BlockN : BlockExpression // TypeDefIndex: 12056
	{
		// Fields
		private IReadOnlyList<Expression> _expressions; // 0x10
	
		// Properties
		internal override int ExpressionCount { get; } // 0x00000001817AB050-0x00000001817AB0A0 
	
		// Constructors
		internal BlockN(IReadOnlyList<Expression> expressions); // 0x00000001817AAFE0-0x00000001817AB050
	
		// Methods
		internal override Expression GetExpression(int index); // 0x00000001817AAEA0-0x00000001817AAF00
		internal override ReadOnlyCollection<Expression> GetOrMakeExpressions(); // 0x00000001817AAF00-0x00000001817AAF40
		internal override BlockExpression Rewrite(ReadOnlyCollection<ParameterExpression> variables, Expression[] args); // 0x00000001817AAF40-0x00000001817AAFE0
	}
}
