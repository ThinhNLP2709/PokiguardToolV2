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
	internal abstract class NotEqualInstruction : Instruction // TypeDefIndex: 12428
	{
		// Fields
		private static Instruction s_reference; // 0x00
		private static Instruction s_Boolean; // 0x08
		private static Instruction s_SByte; // 0x10
		private static Instruction s_Int16; // 0x18
		private static Instruction s_Char; // 0x20
		private static Instruction s_Int32; // 0x28
		private static Instruction s_Int64; // 0x30
		private static Instruction s_Byte; // 0x38
		private static Instruction s_UInt16; // 0x40
		private static Instruction s_UInt32; // 0x48
		private static Instruction s_UInt64; // 0x50
		private static Instruction s_Single; // 0x58
		private static Instruction s_Double; // 0x60
		private static Instruction s_SByteLiftedToNull; // 0x68
		private static Instruction s_Int16LiftedToNull; // 0x70
		private static Instruction s_CharLiftedToNull; // 0x78
		private static Instruction s_Int32LiftedToNull; // 0x80
		private static Instruction s_Int64LiftedToNull; // 0x88
		private static Instruction s_ByteLiftedToNull; // 0x90
		private static Instruction s_UInt16LiftedToNull; // 0x98
		private static Instruction s_UInt32LiftedToNull; // 0xA0
		private static Instruction s_UInt64LiftedToNull; // 0xA8
		private static Instruction s_SingleLiftedToNull; // 0xB0
		private static Instruction s_DoubleLiftedToNull; // 0xB8
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180476390-0x00000001804763A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817F9A90-0x00000001817F9AC0 
	
		// Nested types
		private sealed class NotEqualBoolean : NotEqualInstruction // TypeDefIndex: 12429
		{
			// Constructors
			public NotEqualBoolean(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F89B0-0x00000001817F8A60
		}
	
		private sealed class NotEqualSByte : NotEqualInstruction // TypeDefIndex: 12430
		{
			// Constructors
			public NotEqualSByte(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FA030-0x00000001817FA0E0
		}
	
		private sealed class NotEqualInt16 : NotEqualInstruction // TypeDefIndex: 12431
		{
			// Constructors
			public NotEqualInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F9B80-0x00000001817F9C30
		}
	
		private sealed class NotEqualChar : NotEqualInstruction // TypeDefIndex: 12432
		{
			// Constructors
			public NotEqualChar(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F8C90-0x00000001817F8D40
		}
	
		private sealed class NotEqualInt32 : NotEqualInstruction // TypeDefIndex: 12433
		{
			// Constructors
			public NotEqualInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F9CF0-0x00000001817F9DA0
		}
	
		private sealed class NotEqualInt64 : NotEqualInstruction // TypeDefIndex: 12434
		{
			// Constructors
			public NotEqualInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F9E60-0x00000001817F9F10
		}
	
		private sealed class NotEqualByte : NotEqualInstruction // TypeDefIndex: 12435
		{
			// Constructors
			public NotEqualByte(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F8B20-0x00000001817F8BD0
		}
	
		private sealed class NotEqualUInt16 : NotEqualInstruction // TypeDefIndex: 12436
		{
			// Constructors
			public NotEqualUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FA350-0x00000001817FA400
		}
	
		private sealed class NotEqualUInt32 : NotEqualInstruction // TypeDefIndex: 12437
		{
			// Constructors
			public NotEqualUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FA4C0-0x00000001817FA570
		}
	
		private sealed class NotEqualUInt64 : NotEqualInstruction // TypeDefIndex: 12438
		{
			// Constructors
			public NotEqualUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FA630-0x00000001817FA6E0
		}
	
		private sealed class NotEqualSingle : NotEqualInstruction // TypeDefIndex: 12439
		{
			// Constructors
			public NotEqualSingle(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FA1D0-0x00000001817FA290
		}
	
		private sealed class NotEqualDouble : NotEqualInstruction // TypeDefIndex: 12440
		{
			// Constructors
			public NotEqualDouble(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F8E30-0x00000001817F8EF0
		}
	
		private sealed class NotEqualReference : NotEqualInstruction // TypeDefIndex: 12441
		{
			// Constructors
			public NotEqualReference(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F9F10-0x00000001817F9F70
		}
	
		private sealed class NotEqualSByteLiftedToNull : NotEqualInstruction // TypeDefIndex: 12442
		{
			// Constructors
			public NotEqualSByteLiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F9F70-0x00000001817FA030
		}
	
		private sealed class NotEqualInt16LiftedToNull : NotEqualInstruction // TypeDefIndex: 12443
		{
			// Constructors
			public NotEqualInt16LiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F9AC0-0x00000001817F9B80
		}
	
		private sealed class NotEqualCharLiftedToNull : NotEqualInstruction // TypeDefIndex: 12444
		{
			// Constructors
			public NotEqualCharLiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F8BD0-0x00000001817F8C90
		}
	
		private sealed class NotEqualInt32LiftedToNull : NotEqualInstruction // TypeDefIndex: 12445
		{
			// Constructors
			public NotEqualInt32LiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F9C30-0x00000001817F9CF0
		}
	
		private sealed class NotEqualInt64LiftedToNull : NotEqualInstruction // TypeDefIndex: 12446
		{
			// Constructors
			public NotEqualInt64LiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F9DA0-0x00000001817F9E60
		}
	
		private sealed class NotEqualByteLiftedToNull : NotEqualInstruction // TypeDefIndex: 12447
		{
			// Constructors
			public NotEqualByteLiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F8A60-0x00000001817F8B20
		}
	
		private sealed class NotEqualUInt16LiftedToNull : NotEqualInstruction // TypeDefIndex: 12448
		{
			// Constructors
			public NotEqualUInt16LiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FA290-0x00000001817FA350
		}
	
		private sealed class NotEqualUInt32LiftedToNull : NotEqualInstruction // TypeDefIndex: 12449
		{
			// Constructors
			public NotEqualUInt32LiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FA400-0x00000001817FA4C0
		}
	
		private sealed class NotEqualUInt64LiftedToNull : NotEqualInstruction // TypeDefIndex: 12450
		{
			// Constructors
			public NotEqualUInt64LiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FA570-0x00000001817FA630
		}
	
		private sealed class NotEqualSingleLiftedToNull : NotEqualInstruction // TypeDefIndex: 12451
		{
			// Constructors
			public NotEqualSingleLiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FA0E0-0x00000001817FA1D0
		}
	
		private sealed class NotEqualDoubleLiftedToNull : NotEqualInstruction // TypeDefIndex: 12452
		{
			// Constructors
			public NotEqualDoubleLiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F8D40-0x00000001817F8E30
		}
	
		// Constructors
		private NotEqualInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type, bool liftedToNull); // 0x00000001817F8EF0-0x00000001817F9A90
	}
}
