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
	internal abstract class MulOvfInstruction : Instruction // TypeDefIndex: 12409
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
		public override string InstructionName { get; } // 0x00000001817F6650-0x00000001817F6680 
	
		// Nested types
		private sealed class MulOvfInt16 : MulOvfInstruction // TypeDefIndex: 12410
		{
			// Constructors
			public MulOvfInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F6680-0x00000001817F6870
		}
	
		private sealed class MulOvfInt32 : MulOvfInstruction // TypeDefIndex: 12411
		{
			// Constructors
			public MulOvfInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F6870-0x00000001817F6A10
		}
	
		private sealed class MulOvfInt64 : MulOvfInstruction // TypeDefIndex: 12412
		{
			// Constructors
			public MulOvfInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F6A10-0x00000001817F6C30
		}
	
		private sealed class MulOvfUInt16 : MulOvfInstruction // TypeDefIndex: 12413
		{
			// Constructors
			public MulOvfUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F6C30-0x00000001817F6E00
		}
	
		private sealed class MulOvfUInt32 : MulOvfInstruction // TypeDefIndex: 12414
		{
			// Constructors
			public MulOvfUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F6E00-0x00000001817F6FD0
		}
	
		private sealed class MulOvfUInt64 : MulOvfInstruction // TypeDefIndex: 12415
		{
			// Constructors
			public MulOvfUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F6FD0-0x00000001817F71A0
		}
	
		// Constructors
		private MulOvfInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817F62B0-0x00000001817F6650
	}
}
