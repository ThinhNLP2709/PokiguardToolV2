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
	internal sealed class QuoteInstruction : Instruction // TypeDefIndex: 12527
	{
		// Fields
		private readonly Expression _operand; // 0x10
		private readonly Dictionary<ParameterExpression, LocalVariable> _hoistedVariables; // 0x18
	
		// Properties
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817FCBB0-0x00000001817FCBE0 
	
		// Nested types
		private sealed class ExpressionQuoter : ExpressionVisitor // TypeDefIndex: 12528
		{
			// Fields
			private readonly Dictionary<ParameterExpression, LocalVariable> _variables; // 0x10
			private readonly InterpretedFrame _frame; // 0x18
			private readonly Stack<HashSet<ParameterExpression>> _shadowedVars; // 0x20
	
			// Constructors
			internal ExpressionQuoter(Dictionary<ParameterExpression, LocalVariable> hoistedVariables, InterpretedFrame frame); // 0x00000001817EFD40-0x00000001817EFE00
	
			// Methods
			protected internal override Expression VisitLambda<T>(Expression<T> node);
			protected internal override Expression VisitBlock(BlockExpression node); // 0x00000001817EF860-0x00000001817EF9E0
			protected override CatchBlock VisitCatchBlock(CatchBlock node); // 0x00000001817EF9E0-0x00000001817EFB80
			protected internal override Expression VisitParameter(ParameterExpression node); // 0x00000001817EFB80-0x00000001817EFD40
			private IStrongBox GetBox(ParameterExpression variable); // 0x00000001817EF730-0x00000001817EF860
		}
	
		// Constructors
		public QuoteInstruction(Expression operand, Dictionary<ParameterExpression, LocalVariable> hoistedVariables); // 0x000000018150AEB0-0x000000018150AF00
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817FCA70-0x00000001817FCBB0
	}
}
