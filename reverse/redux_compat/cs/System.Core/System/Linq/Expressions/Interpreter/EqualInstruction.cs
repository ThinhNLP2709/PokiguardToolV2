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
	internal abstract class EqualInstruction : Instruction // TypeDefIndex: 12224
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
		private static Instruction s_BooleanLiftedToNull; // 0x68
		private static Instruction s_SByteLiftedToNull; // 0x70
		private static Instruction s_Int16LiftedToNull; // 0x78
		private static Instruction s_CharLiftedToNull; // 0x80
		private static Instruction s_Int32LiftedToNull; // 0x88
		private static Instruction s_Int64LiftedToNull; // 0x90
		private static Instruction s_ByteLiftedToNull; // 0x98
		private static Instruction s_UInt16LiftedToNull; // 0xA0
		private static Instruction s_UInt32LiftedToNull; // 0xA8
		private static Instruction s_UInt64LiftedToNull; // 0xB0
		private static Instruction s_SingleLiftedToNull; // 0xB8
		private static Instruction s_DoubleLiftedToNull; // 0xC0
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180476390-0x00000001804763A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817B1060-0x00000001817B1090 
	
		// Nested types
		private sealed class EqualBoolean : EqualInstruction // TypeDefIndex: 12225
		{
			// Constructors
			public EqualBoolean(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817AFF20-0x00000001817AFFD0
		}
	
		private sealed class EqualSByte : EqualInstruction // TypeDefIndex: 12226
		{
			// Constructors
			public EqualSByte(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B1600-0x00000001817B16B0
		}
	
		private sealed class EqualInt16 : EqualInstruction // TypeDefIndex: 12227
		{
			// Constructors
			public EqualInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B1150-0x00000001817B1200
		}
	
		private sealed class EqualChar : EqualInstruction // TypeDefIndex: 12228
		{
			// Constructors
			public EqualChar(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B0200-0x00000001817B02B0
		}
	
		private sealed class EqualInt32 : EqualInstruction // TypeDefIndex: 12229
		{
			// Constructors
			public EqualInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B12C0-0x00000001817B1370
		}
	
		private sealed class EqualInt64 : EqualInstruction // TypeDefIndex: 12230
		{
			// Constructors
			public EqualInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B1430-0x00000001817B14E0
		}
	
		private sealed class EqualByte : EqualInstruction // TypeDefIndex: 12231
		{
			// Constructors
			public EqualByte(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B0090-0x00000001817B0140
		}
	
		private sealed class EqualUInt16 : EqualInstruction // TypeDefIndex: 12232
		{
			// Constructors
			public EqualUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B1920-0x00000001817B19D0
		}
	
		private sealed class EqualUInt32 : EqualInstruction // TypeDefIndex: 12233
		{
			// Constructors
			public EqualUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B1A90-0x00000001817B1B40
		}
	
		private sealed class EqualUInt64 : EqualInstruction // TypeDefIndex: 12234
		{
			// Constructors
			public EqualUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B1C00-0x00000001817B1CB0
		}
	
		private sealed class EqualSingle : EqualInstruction // TypeDefIndex: 12235
		{
			// Constructors
			public EqualSingle(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B17A0-0x00000001817B1860
		}
	
		private sealed class EqualDouble : EqualInstruction // TypeDefIndex: 12236
		{
			// Constructors
			public EqualDouble(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B03A0-0x00000001817B0460
		}
	
		private sealed class EqualReference : EqualInstruction // TypeDefIndex: 12237
		{
			// Constructors
			public EqualReference(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B14E0-0x00000001817B1540
		}
	
		private sealed class EqualBooleanLiftedToNull : EqualInstruction // TypeDefIndex: 12238
		{
			// Constructors
			public EqualBooleanLiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817AFE60-0x00000001817AFF20
		}
	
		private sealed class EqualSByteLiftedToNull : EqualInstruction // TypeDefIndex: 12239
		{
			// Constructors
			public EqualSByteLiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B1540-0x00000001817B1600
		}
	
		private sealed class EqualInt16LiftedToNull : EqualInstruction // TypeDefIndex: 12240
		{
			// Constructors
			public EqualInt16LiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B1090-0x00000001817B1150
		}
	
		private sealed class EqualCharLiftedToNull : EqualInstruction // TypeDefIndex: 12241
		{
			// Constructors
			public EqualCharLiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B0140-0x00000001817B0200
		}
	
		private sealed class EqualInt32LiftedToNull : EqualInstruction // TypeDefIndex: 12242
		{
			// Constructors
			public EqualInt32LiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B1200-0x00000001817B12C0
		}
	
		private sealed class EqualInt64LiftedToNull : EqualInstruction // TypeDefIndex: 12243
		{
			// Constructors
			public EqualInt64LiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B1370-0x00000001817B1430
		}
	
		private sealed class EqualByteLiftedToNull : EqualInstruction // TypeDefIndex: 12244
		{
			// Constructors
			public EqualByteLiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817AFFD0-0x00000001817B0090
		}
	
		private sealed class EqualUInt16LiftedToNull : EqualInstruction // TypeDefIndex: 12245
		{
			// Constructors
			public EqualUInt16LiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B1860-0x00000001817B1920
		}
	
		private sealed class EqualUInt32LiftedToNull : EqualInstruction // TypeDefIndex: 12246
		{
			// Constructors
			public EqualUInt32LiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B19D0-0x00000001817B1A90
		}
	
		private sealed class EqualUInt64LiftedToNull : EqualInstruction // TypeDefIndex: 12247
		{
			// Constructors
			public EqualUInt64LiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B1B40-0x00000001817B1C00
		}
	
		private sealed class EqualSingleLiftedToNull : EqualInstruction // TypeDefIndex: 12248
		{
			// Constructors
			public EqualSingleLiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B16B0-0x00000001817B17A0
		}
	
		private sealed class EqualDoubleLiftedToNull : EqualInstruction // TypeDefIndex: 12249
		{
			// Constructors
			public EqualDoubleLiftedToNull(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B02B0-0x00000001817B03A0
		}
	
		// Constructors
		private EqualInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type, bool liftedToNull); // 0x00000001817B0460-0x00000001817B1060
	}
}
