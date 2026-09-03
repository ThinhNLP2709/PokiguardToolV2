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
	internal abstract class NegateInstruction : Instruction // TypeDefIndex: 12416
	{
		// Fields
		private static Instruction s_Int16; // 0x00
		private static Instruction s_Int32; // 0x08
		private static Instruction s_Int64; // 0x10
		private static Instruction s_Single; // 0x18
		private static Instruction s_Double; // 0x20
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817F8250-0x00000001817F8280 
	
		// Nested types
		private sealed class NegateInt16 : NegateInstruction // TypeDefIndex: 12417
		{
			// Constructors
			public NegateInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F8280-0x00000001817F8300
		}
	
		private sealed class NegateInt32 : NegateInstruction // TypeDefIndex: 12418
		{
			// Constructors
			public NegateInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F8300-0x00000001817F8380
		}
	
		private sealed class NegateInt64 : NegateInstruction // TypeDefIndex: 12419
		{
			// Constructors
			public NegateInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F8380-0x00000001817F8400
		}
	
		private sealed class NegateSingle : NegateInstruction // TypeDefIndex: 12420
		{
			// Constructors
			public NegateSingle(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F8400-0x00000001817F8480
		}
	
		private sealed class NegateDouble : NegateInstruction // TypeDefIndex: 12421
		{
			// Constructors
			public NegateDouble(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F7EB0-0x00000001817F7F30
		}
	
		// Constructors
		private NegateInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817F7F30-0x00000001817F8250
	}
}
