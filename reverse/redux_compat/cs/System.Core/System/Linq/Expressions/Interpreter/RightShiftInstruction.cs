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
	internal abstract class RightShiftInstruction : Instruction // TypeDefIndex: 12478
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
		public override string InstructionName { get; } // 0x00000001817FDA40-0x00000001817FDA70 
	
		// Nested types
		private sealed class RightShiftSByte : RightShiftInstruction // TypeDefIndex: 12479
		{
			// Constructors
			public RightShiftSByte(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FDCC0-0x00000001817FDD90
		}
	
		private sealed class RightShiftInt16 : RightShiftInstruction // TypeDefIndex: 12480
		{
			// Constructors
			public RightShiftInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FDA70-0x00000001817FDB40
		}
	
		private sealed class RightShiftInt32 : RightShiftInstruction // TypeDefIndex: 12481
		{
			// Constructors
			public RightShiftInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FDB40-0x00000001817FDC00
		}
	
		private sealed class RightShiftInt64 : RightShiftInstruction // TypeDefIndex: 12482
		{
			// Constructors
			public RightShiftInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FDC00-0x00000001817FDCC0
		}
	
		private sealed class RightShiftByte : RightShiftInstruction // TypeDefIndex: 12483
		{
			// Constructors
			public RightShiftByte(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FD4F0-0x00000001817FD5C0
		}
	
		private sealed class RightShiftUInt16 : RightShiftInstruction // TypeDefIndex: 12484
		{
			// Constructors
			public RightShiftUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FDD90-0x00000001817FDE60
		}
	
		private sealed class RightShiftUInt32 : RightShiftInstruction // TypeDefIndex: 12485
		{
			// Constructors
			public RightShiftUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FDE60-0x00000001817FDF20
		}
	
		private sealed class RightShiftUInt64 : RightShiftInstruction // TypeDefIndex: 12486
		{
			// Constructors
			public RightShiftUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FDF20-0x00000001817FDFE0
		}
	
		// Constructors
		private RightShiftInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817FD5C0-0x00000001817FDA40
	}
}
