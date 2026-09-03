/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions.Interpreter
{
	internal sealed class LocalVariables // TypeDefIndex: 12389
	{
		// Fields
		private readonly HybridReferenceDictionary<ParameterExpression, VariableScope> _variables; // 0x10
		private Dictionary<ParameterExpression, LocalVariable> _closureVariables; // 0x18
		private int _localCount; // 0x20
		private int _maxLocalCount; // 0x24
	
		// Properties
		public int LocalCount { get; } // 0x0000000180D17D10-0x0000000180D17D20 
		internal Dictionary<ParameterExpression, LocalVariable> ClosureVariables { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Nested types
		private sealed class VariableScope // TypeDefIndex: 12390
		{
			// Fields
			public readonly int Start; // 0x10
			public int Stop; // 0x14
			public readonly LocalVariable Variable; // 0x18
			public readonly VariableScope Parent; // 0x20
			public List<VariableScope> ChildScopes; // 0x28
	
			// Constructors
			public VariableScope(LocalVariable variable, int start, VariableScope parent); // 0x00000001818028A0-0x0000000181802B80
		}
	
		// Constructors
		public LocalVariables(); // 0x00000001817F46B0-0x00000001817F4720
	
		// Methods
		public LocalDefinition DefineLocal(ParameterExpression variable, int start); // 0x00000001817F4220-0x00000001817F44E0
		public void UndefineLocal(LocalDefinition definition, int end); // 0x00000001817F45D0-0x00000001817F46B0
		internal void Box(ParameterExpression variable, InstructionList instructions); // 0x00000001817F40E0-0x00000001817F4220
		public bool TryGetLocalOrClosure(ParameterExpression var, out LocalVariable local); // 0x00000001817F44E0-0x00000001817F45D0
		internal LocalVariable AddClosureVariable(ParameterExpression variable); // 0x00000001817F3FE0-0x00000001817F40E0
	}
}
