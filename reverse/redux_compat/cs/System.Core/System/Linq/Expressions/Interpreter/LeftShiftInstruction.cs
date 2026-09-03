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
	internal abstract class LeftShiftInstruction : Instruction // TypeDefIndex: 12311
	{
		// Fields
		private static Instruction s_SByte; // 0x00
		private static Instruction s_Int16; // 0x08
		private static Instruction s_Int32; // 0x10
		private static Instruction s_Int64; // 0x18
		private static Instruction s_Byte; // 0x20
		private static Instruction s_UInt16; // 0x28
		private static Instruction s_UInt32; // 0x30
		private static Instruction s_UInt64; // 0x38
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180476390-0x00000001804763A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817D2320-0x00000001817D2350 
	
		// Nested types
		private sealed class LeftShiftSByte : LeftShiftInstruction // TypeDefIndex: 12312
		{
			// Constructors
			public LeftShiftSByte(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D2730-0x00000001817D28D0
		}
	
		private sealed class LeftShiftInt16 : LeftShiftInstruction // TypeDefIndex: 12313
		{
			// Constructors
			public LeftShiftInt16(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D2350-0x00000001817D2470
		}
	
		private sealed class LeftShiftInt32 : LeftShiftInstruction // TypeDefIndex: 12314
		{
			// Constructors
			public LeftShiftInt32(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D2470-0x00000001817D2580
		}
	
		private sealed class LeftShiftInt64 : LeftShiftInstruction // TypeDefIndex: 12315
		{
			// Constructors
			public LeftShiftInt64(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D2580-0x00000001817D2730
		}
	
		private sealed class LeftShiftByte : LeftShiftInstruction // TypeDefIndex: 12316
		{
			// Constructors
			public LeftShiftByte(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D1D80-0x00000001817D1EA0
		}
	
		private sealed class LeftShiftUInt16 : LeftShiftInstruction // TypeDefIndex: 12317
		{
			// Constructors
			public LeftShiftUInt16(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D28D0-0x00000001817D29F0
		}
	
		private sealed class LeftShiftUInt32 : LeftShiftInstruction // TypeDefIndex: 12318
		{
			// Constructors
			public LeftShiftUInt32(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D29F0-0x00000001817D2BA0
		}
	
		private sealed class LeftShiftUInt64 : LeftShiftInstruction // TypeDefIndex: 12319
		{
			// Constructors
			public LeftShiftUInt64(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D2BA0-0x00000001817D2D50
		}
	
		// Constructors
		private LeftShiftInstruction(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817D1EA0-0x00000001817D2320
	}
}
