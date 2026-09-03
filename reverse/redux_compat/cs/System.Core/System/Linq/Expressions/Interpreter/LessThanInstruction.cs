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
	internal abstract class LessThanInstruction : Instruction // TypeDefIndex: 12320
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
		public override string InstructionName { get; } // 0x00000001817D3FA0-0x00000001817D3FD0 
	
		// Nested types
		private sealed class LessThanSByte : LessThanInstruction // TypeDefIndex: 12321
		{
			// Constructors
			public LessThanSByte(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D60C0-0x00000001817D6210
		}
	
		private sealed class LessThanInt16 : LessThanInstruction // TypeDefIndex: 12322
		{
			// Constructors
			public LessThanInt16(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D3FD0-0x00000001817D4120
		}
	
		private sealed class LessThanChar : LessThanInstruction // TypeDefIndex: 12323
		{
			// Constructors
			public LessThanChar(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D2EA0-0x00000001817D2FF0
		}
	
		private sealed class LessThanInt32 : LessThanInstruction // TypeDefIndex: 12324
		{
			// Constructors
			public LessThanInt32(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D4120-0x00000001817D4270
		}
	
		private sealed class LessThanInt64 : LessThanInstruction // TypeDefIndex: 12325
		{
			// Constructors
			public LessThanInt64(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D4270-0x00000001817D43C0
		}
	
		private sealed class LessThanByte : LessThanInstruction // TypeDefIndex: 12326
		{
			// Constructors
			public LessThanByte(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D2D50-0x00000001817D2EA0
		}
	
		private sealed class LessThanUInt16 : LessThanInstruction // TypeDefIndex: 12327
		{
			// Constructors
			public LessThanUInt16(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D6360-0x00000001817D64B0
		}
	
		private sealed class LessThanUInt32 : LessThanInstruction // TypeDefIndex: 12328
		{
			// Constructors
			public LessThanUInt32(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D64B0-0x00000001817D6600
		}
	
		private sealed class LessThanUInt64 : LessThanInstruction // TypeDefIndex: 12329
		{
			// Constructors
			public LessThanUInt64(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D6600-0x00000001817D6750
		}
	
		private sealed class LessThanSingle : LessThanInstruction // TypeDefIndex: 12330
		{
			// Constructors
			public LessThanSingle(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D6210-0x00000001817D6360
		}
	
		private sealed class LessThanDouble : LessThanInstruction // TypeDefIndex: 12331
		{
			// Constructors
			public LessThanDouble(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D2FF0-0x00000001817D3140
		}
	
		// Constructors
		private LessThanInstruction(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public static Instruction Create(Type type, bool liftedToNull = false /* Metadata: 0x006A25CF */); // 0x00000001817D3140-0x00000001817D3FA0
	}
}
