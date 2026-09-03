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
	internal abstract class LessThanOrEqualInstruction : Instruction // TypeDefIndex: 12332
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
		public override string InstructionName { get; } // 0x00000001817D5610-0x00000001817D5640 
	
		// Nested types
		private sealed class LessThanOrEqualSByte : LessThanOrEqualInstruction // TypeDefIndex: 12333
		{
			// Constructors
			public LessThanOrEqualSByte(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D5A30-0x00000001817D5B80
		}
	
		private sealed class LessThanOrEqualInt16 : LessThanOrEqualInstruction // TypeDefIndex: 12334
		{
			// Constructors
			public LessThanOrEqualInt16(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D5640-0x00000001817D5790
		}
	
		private sealed class LessThanOrEqualChar : LessThanOrEqualInstruction // TypeDefIndex: 12335
		{
			// Constructors
			public LessThanOrEqualChar(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D4510-0x00000001817D4660
		}
	
		private sealed class LessThanOrEqualInt32 : LessThanOrEqualInstruction // TypeDefIndex: 12336
		{
			// Constructors
			public LessThanOrEqualInt32(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D5790-0x00000001817D58E0
		}
	
		private sealed class LessThanOrEqualInt64 : LessThanOrEqualInstruction // TypeDefIndex: 12337
		{
			// Constructors
			public LessThanOrEqualInt64(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D58E0-0x00000001817D5A30
		}
	
		private sealed class LessThanOrEqualByte : LessThanOrEqualInstruction // TypeDefIndex: 12338
		{
			// Constructors
			public LessThanOrEqualByte(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D43C0-0x00000001817D4510
		}
	
		private sealed class LessThanOrEqualUInt16 : LessThanOrEqualInstruction // TypeDefIndex: 12339
		{
			// Constructors
			public LessThanOrEqualUInt16(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D5CD0-0x00000001817D5E20
		}
	
		private sealed class LessThanOrEqualUInt32 : LessThanOrEqualInstruction // TypeDefIndex: 12340
		{
			// Constructors
			public LessThanOrEqualUInt32(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D5E20-0x00000001817D5F70
		}
	
		private sealed class LessThanOrEqualUInt64 : LessThanOrEqualInstruction // TypeDefIndex: 12341
		{
			// Constructors
			public LessThanOrEqualUInt64(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D5F70-0x00000001817D60C0
		}
	
		private sealed class LessThanOrEqualSingle : LessThanOrEqualInstruction // TypeDefIndex: 12342
		{
			// Constructors
			public LessThanOrEqualSingle(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D5B80-0x00000001817D5CD0
		}
	
		private sealed class LessThanOrEqualDouble : LessThanOrEqualInstruction // TypeDefIndex: 12343
		{
			// Constructors
			public LessThanOrEqualDouble(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817D4660-0x00000001817D47B0
		}
	
		// Constructors
		private LessThanOrEqualInstruction(object nullValue); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public static Instruction Create(Type type, bool liftedToNull = false /* Metadata: 0x006A25D0 */); // 0x00000001817D47B0-0x00000001817D5610
	}
}
