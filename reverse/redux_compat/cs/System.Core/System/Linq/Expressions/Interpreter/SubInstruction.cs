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
	internal abstract class SubInstruction : Instruction // TypeDefIndex: 12492
	{
		// Fields
		private static Instruction s_Int16; // 0x00
		private static Instruction s_Int32; // 0x08
		private static Instruction s_Int64; // 0x10
		private static Instruction s_UInt16; // 0x18
		private static Instruction s_UInt32; // 0x20
		private static Instruction s_UInt64; // 0x28
		private static Instruction s_Single; // 0x30
		private static Instruction s_Double; // 0x38
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180476390-0x00000001804763A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817FF100-0x00000001817FF130 
	
		// Nested types
		private sealed class SubInt16 : SubInstruction // TypeDefIndex: 12493
		{
			// Constructors
			public SubInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FF130-0x00000001817FF270
		}
	
		private sealed class SubInt32 : SubInstruction // TypeDefIndex: 12494
		{
			// Constructors
			public SubInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FF270-0x00000001817FF3B0
		}
	
		private sealed class SubInt64 : SubInstruction // TypeDefIndex: 12495
		{
			// Constructors
			public SubInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FF3B0-0x00000001817FF4F0
		}
	
		private sealed class SubUInt16 : SubInstruction // TypeDefIndex: 12496
		{
			// Constructors
			public SubUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x0000000181800500-0x0000000181800640
		}
	
		private sealed class SubUInt32 : SubInstruction // TypeDefIndex: 12497
		{
			// Constructors
			public SubUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x0000000181800640-0x0000000181800780
		}
	
		private sealed class SubUInt64 : SubInstruction // TypeDefIndex: 12498
		{
			// Constructors
			public SubUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x0000000181800780-0x00000001818008C0
		}
	
		private sealed class SubSingle : SubInstruction // TypeDefIndex: 12499
		{
			// Constructors
			public SubSingle(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001818003C0-0x0000000181800500
		}
	
		private sealed class SubDouble : SubInstruction // TypeDefIndex: 12500
		{
			// Constructors
			public SubDouble(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FEB40-0x00000001817FEC80
		}
	
		// Constructors
		private SubInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817FEC80-0x00000001817FF100
	}
}
