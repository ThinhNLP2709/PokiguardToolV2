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
	internal abstract class SubOvfInstruction : Instruction // TypeDefIndex: 12501
	{
		// Fields
		private static Instruction s_Int16; // 0x00
		private static Instruction s_Int32; // 0x08
		private static Instruction s_Int64; // 0x10
		private static Instruction s_UInt16; // 0x18
		private static Instruction s_UInt32; // 0x20
		private static Instruction s_UInt64; // 0x28
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180476390-0x00000001804763A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817FF890-0x00000001817FF8C0 
	
		// Nested types
		private sealed class SubOvfInt16 : SubOvfInstruction // TypeDefIndex: 12502
		{
			// Constructors
			public SubOvfInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FF8C0-0x00000001817FFAB0
		}
	
		private sealed class SubOvfInt32 : SubOvfInstruction // TypeDefIndex: 12503
		{
			// Constructors
			public SubOvfInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FFAB0-0x00000001817FFC50
		}
	
		private sealed class SubOvfInt64 : SubOvfInstruction // TypeDefIndex: 12504
		{
			// Constructors
			public SubOvfInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FFC50-0x00000001817FFE40
		}
	
		private sealed class SubOvfUInt16 : SubOvfInstruction // TypeDefIndex: 12505
		{
			// Constructors
			public SubOvfUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FFE40-0x0000000181800030
		}
	
		private sealed class SubOvfUInt32 : SubOvfInstruction // TypeDefIndex: 12506
		{
			// Constructors
			public SubOvfUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x0000000181800030-0x0000000181800200
		}
	
		private sealed class SubOvfUInt64 : SubOvfInstruction // TypeDefIndex: 12507
		{
			// Constructors
			public SubOvfUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x0000000181800200-0x00000001818003C0
		}
	
		// Constructors
		private SubOvfInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817FF4F0-0x00000001817FF890
	}
}
