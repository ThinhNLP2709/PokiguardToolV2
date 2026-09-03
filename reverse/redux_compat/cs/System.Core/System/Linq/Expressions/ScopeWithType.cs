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
	internal sealed class ScopeWithType : ScopeN // TypeDefIndex: 12060
	{
		// Fields
		[CompilerGenerated]
		private readonly Type _Type_k__BackingField; // 0x20
	
		// Properties
		public sealed override Type Type { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		internal ScopeWithType(IReadOnlyList<ParameterExpression> variables, IReadOnlyList<Expression> expressions, Type type); // 0x00000001817C0590-0x00000001817C05D0
	
		// Methods
		internal override BlockExpression Rewrite(ReadOnlyCollection<ParameterExpression> variables, Expression[] args); // 0x00000001817C0440-0x00000001817C0590
	}
}
