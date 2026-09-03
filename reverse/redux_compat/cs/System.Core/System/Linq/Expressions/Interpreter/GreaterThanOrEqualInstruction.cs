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
	internal abstract class GreaterThanOrEqualInstruction : Instruction // TypeDefIndex: 12277
	{
		// Fields
		private readonly object _nullValue; // 0x10
		private static Instruction s_SByte; // 0x00
		private static Instruction s_Int16; // 0x08
		private static Instruction s_Char; // 0x10
		private static Instruction s_Int32; // 0x18
		private static Instruction s_Int64; // 0x20
		private static Instruction s_Byte; // 0x28
		private static Instruction s_UInt16; // 0x30
		private static Instruction s_UInt32; // 0x38
		private static Instruction s_UInt64; // 0x40
		private static Instruction s_Single; // 0x48
		private static Instruction s_Double; // 0x50
		private static Instruction s_liftedToNullSByte; // 0x58
		private static Instruction s_liftedToNullInt16; // 0x60
		private static Instruction s_liftedToNullChar; // 0x68
		private static Instruction s_liftedToNullInt32; // 0x70
		private static Instruction s_liftedToNullInt64; // 0x78
		private static Instruction s_liftedToNullByte; // 0x80
		private static Instruction s_liftedToNullUInt16; // 0x88
		private static Instruction s_liftedToNullUInt32; // 0x90
		private static Instruction s_liftedToNullUInt64; // 0x98
		private static Instruction s_liftedToNullSingle; // 0xA0
		private static Instruction s_liftedToNullDouble; // 0xA8
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180476390-0x00000001804763A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817C8E40-0x00000001817C8E70 
	
		// Nested types
		private sealed class GreaterThanOrEqualSByte : GreaterThanOrEqualInstruction // TypeDefIndex: 12278
		{
			// Constructors
			public GreaterThanOrEqualSByte(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C9260-0x00000001817C93B0
		}
	
		private sealed class GreaterThanOrEqualInt16 : GreaterThanOrEqualInstruction // TypeDefIndex: 12279
		{
			// Constructors
			public GreaterThanOrEqualInt16(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C8E70-0x00000001817C8FC0
		}
	
		private sealed class GreaterThanOrEqualChar : GreaterThanOrEqualInstruction // TypeDefIndex: 12280
		{
			// Constructors
			public GreaterThanOrEqualChar(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C7D40-0x00000001817C7E90
		}
	
		private sealed class GreaterThanOrEqualInt32 : GreaterThanOrEqualInstruction // TypeDefIndex: 12281
		{
			// Constructors
			public GreaterThanOrEqualInt32(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C8FC0-0x00000001817C9110
		}
	
		private sealed class GreaterThanOrEqualInt64 : GreaterThanOrEqualInstruction // TypeDefIndex: 12282
		{
			// Constructors
			public GreaterThanOrEqualInt64(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C9110-0x00000001817C9260
		}
	
		private sealed class GreaterThanOrEqualByte : GreaterThanOrEqualInstruction // TypeDefIndex: 12283
		{
			// Constructors
			public GreaterThanOrEqualByte(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C7BF0-0x00000001817C7D40
		}
	
		private sealed class GreaterThanOrEqualUInt16 : GreaterThanOrEqualInstruction // TypeDefIndex: 12284
		{
			// Constructors
			public GreaterThanOrEqualUInt16(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C9500-0x00000001817C9650
		}
	
		private sealed class GreaterThanOrEqualUInt32 : GreaterThanOrEqualInstruction // TypeDefIndex: 12285
		{
			// Constructors
			public GreaterThanOrEqualUInt32(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C9650-0x00000001817C97A0
		}
	
		private sealed class GreaterThanOrEqualUInt64 : GreaterThanOrEqualInstruction // TypeDefIndex: 12286
		{
			// Constructors
			public GreaterThanOrEqualUInt64(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C97A0-0x00000001817C98F0
		}
	
		private sealed class GreaterThanOrEqualSingle : GreaterThanOrEqualInstruction // TypeDefIndex: 12287
		{
			// Constructors
			public GreaterThanOrEqualSingle(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C93B0-0x00000001817C9500
		}
	
		private sealed class GreaterThanOrEqualDouble : GreaterThanOrEqualInstruction // TypeDefIndex: 12288
		{
			// Constructors
			public GreaterThanOrEqualDouble(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C7E90-0x00000001817C7FE0
		}
	
		// Constructors
		private GreaterThanOrEqualInstruction(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public static Instruction Create(Type type, bool liftedToNull = false /* Metadata: 0x006A25C2 */); // 0x00000001817C7FE0-0x00000001817C8E40
	}
}
