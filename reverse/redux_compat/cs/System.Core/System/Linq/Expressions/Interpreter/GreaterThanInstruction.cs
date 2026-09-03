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
	internal abstract class GreaterThanInstruction : Instruction // TypeDefIndex: 12265
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
		public override string InstructionName { get; } // 0x00000001817C77D0-0x00000001817C7800 
	
		// Nested types
		private sealed class GreaterThanSByte : GreaterThanInstruction // TypeDefIndex: 12266
		{
			// Constructors
			public GreaterThanSByte(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C98F0-0x00000001817C9A40
		}
	
		private sealed class GreaterThanInt16 : GreaterThanInstruction // TypeDefIndex: 12267
		{
			// Constructors
			public GreaterThanInt16(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C7800-0x00000001817C7950
		}
	
		private sealed class GreaterThanChar : GreaterThanInstruction // TypeDefIndex: 12268
		{
			// Constructors
			public GreaterThanChar(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C66D0-0x00000001817C6820
		}
	
		private sealed class GreaterThanInt32 : GreaterThanInstruction // TypeDefIndex: 12269
		{
			// Constructors
			public GreaterThanInt32(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C7950-0x00000001817C7AA0
		}
	
		private sealed class GreaterThanInt64 : GreaterThanInstruction // TypeDefIndex: 12270
		{
			// Constructors
			public GreaterThanInt64(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C7AA0-0x00000001817C7BF0
		}
	
		private sealed class GreaterThanByte : GreaterThanInstruction // TypeDefIndex: 12271
		{
			// Constructors
			public GreaterThanByte(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C6580-0x00000001817C66D0
		}
	
		private sealed class GreaterThanUInt16 : GreaterThanInstruction // TypeDefIndex: 12272
		{
			// Constructors
			public GreaterThanUInt16(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C9B90-0x00000001817C9CE0
		}
	
		private sealed class GreaterThanUInt32 : GreaterThanInstruction // TypeDefIndex: 12273
		{
			// Constructors
			public GreaterThanUInt32(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C9CE0-0x00000001817C9E30
		}
	
		private sealed class GreaterThanUInt64 : GreaterThanInstruction // TypeDefIndex: 12274
		{
			// Constructors
			public GreaterThanUInt64(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C9E30-0x00000001817C9F80
		}
	
		private sealed class GreaterThanSingle : GreaterThanInstruction // TypeDefIndex: 12275
		{
			// Constructors
			public GreaterThanSingle(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C9A40-0x00000001817C9B90
		}
	
		private sealed class GreaterThanDouble : GreaterThanInstruction // TypeDefIndex: 12276
		{
			// Constructors
			public GreaterThanDouble(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C6820-0x00000001817C6970
		}
	
		// Constructors
		private GreaterThanInstruction(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public static Instruction Create(Type type, bool liftedToNull = false /* Metadata: 0x006A25C1 */); // 0x00000001817C6970-0x00000001817C77D0
	}
}
