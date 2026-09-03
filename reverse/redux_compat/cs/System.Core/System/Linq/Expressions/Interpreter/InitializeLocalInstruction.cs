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

namespace System.Linq.Expressions.Interpreter
{
	internal abstract class InitializeLocalInstruction : LocalAccessInstruction // TypeDefIndex: 12377
	{
		// Nested types
		internal sealed class Reference : InitializeLocalInstruction, IBoxableInstruction // TypeDefIndex: 12378
		{
			// Properties
			public override string InstructionName { get; } // 0x00000001817FD4C0-0x00000001817FD4F0 
	
			// Constructors
			internal Reference(int index); // 0x0000000181380310-0x0000000181380340
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FD470-0x00000001817FD4C0
			public Instruction BoxIfIndexMatches(int index); // 0x00000001817FD400-0x00000001817FD470
		}
	
		internal sealed class ImmutableValue : InitializeLocalInstruction, IBoxableInstruction // TypeDefIndex: 12379
		{
			// Fields
			private readonly object _defaultValue; // 0x18
	
			// Properties
			public override string InstructionName { get; } // 0x00000001817F04A0-0x00000001817F04D0 
	
			// Constructors
			internal ImmutableValue(int index, object defaultValue); // 0x00000001817F0220-0x00000001817F0260
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F0410-0x00000001817F04A0
			public Instruction BoxIfIndexMatches(int index); // 0x00000001817F0380-0x00000001817F0410
		}
	
		internal sealed class ImmutableBox : InitializeLocalInstruction // TypeDefIndex: 12380
		{
			// Fields
			private readonly object _defaultValue; // 0x18
	
			// Properties
			public override string InstructionName { get; } // 0x00000001817F0260-0x00000001817F0290 
	
			// Constructors
			internal ImmutableBox(int index, object defaultValue); // 0x00000001817F0220-0x00000001817F0260
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F0140-0x00000001817F0220
		}
	
		internal sealed class ImmutableRefBox : InitializeLocalInstruction // TypeDefIndex: 12381
		{
			// Properties
			public override string InstructionName { get; } // 0x00000001817F0350-0x00000001817F0380 
	
			// Constructors
			internal ImmutableRefBox(int index); // 0x0000000181380310-0x0000000181380340
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F0290-0x00000001817F0350
		}
	
		internal sealed class ParameterBox : InitializeLocalInstruction // TypeDefIndex: 12382
		{
			// Properties
			public override string InstructionName { get; } // 0x00000001817FC630-0x00000001817FC660 
	
			// Constructors
			public ParameterBox(int index); // 0x0000000181380310-0x0000000181380340
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FC540-0x00000001817FC630
		}
	
		internal sealed class Parameter : InitializeLocalInstruction, IBoxableInstruction // TypeDefIndex: 12383
		{
			// Properties
			public override string InstructionName { get; } // 0x00000001817FC8D0-0x00000001817FC900 
	
			// Constructors
			internal Parameter(int index); // 0x0000000181380310-0x0000000181380340
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x0000000180472790-0x00000001804727A0
			public Instruction BoxIfIndexMatches(int index); // 0x00000001817FC860-0x00000001817FC8D0
		}
	
		internal sealed class MutableValue : InitializeLocalInstruction, IBoxableInstruction // TypeDefIndex: 12384
		{
			// Fields
			private readonly Type _type; // 0x18
	
			// Properties
			public override string InstructionName { get; } // 0x00000001817F7970-0x00000001817F79A0 
	
			// Constructors
			internal MutableValue(int index, Type type); // 0x00000001817F0220-0x00000001817F0260
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F7890-0x00000001817F7970
			public Instruction BoxIfIndexMatches(int index); // 0x00000001817F7800-0x00000001817F7890
		}
	
		internal sealed class MutableBox : InitializeLocalInstruction // TypeDefIndex: 12385
		{
			// Fields
			private readonly Type _type; // 0x18
	
			// Properties
			public override string InstructionName { get; } // 0x00000001817F77D0-0x00000001817F7800 
	
			// Constructors
			internal MutableBox(int index, Type type); // 0x00000001817F0220-0x00000001817F0260
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F76A0-0x00000001817F77D0
		}
	
		// Constructors
		internal InitializeLocalInstruction(int index); // 0x0000000181380310-0x0000000181380340
	}
}
