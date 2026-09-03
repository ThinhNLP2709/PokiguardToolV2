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
	internal class ScopeExpression : BlockExpression // TypeDefIndex: 12057
	{
		// Fields
		private IReadOnlyList<ParameterExpression> _variables; // 0x10
	
		// Properties
		protected IReadOnlyList<ParameterExpression> VariablesList { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		internal ScopeExpression(IReadOnlyList<ParameterExpression> variables); // 0x00000001817AAFE0-0x00000001817AB050
	
		// Methods
		internal override ReadOnlyCollection<ParameterExpression> GetOrMakeVariables(); // 0x00000001817C0130-0x00000001817C0170
		internal IReadOnlyList<ParameterExpression> ReuseOrValidateVariables(ReadOnlyCollection<ParameterExpression> variables); // 0x00000001817C0170-0x00000001817C0200
	}
}
