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
	internal abstract class ExclusiveOrInstruction : Instruction // TypeDefIndex: 12250
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
		private static Instruction s_Boolean; // 0x40
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180476390-0x00000001804763A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817B6E60-0x00000001817B6E90 
	
		// Nested types
		private sealed class ExclusiveOrSByte : ExclusiveOrInstruction // TypeDefIndex: 12251
		{
			// Constructors
			public ExclusiveOrSByte(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B70D0-0x00000001817B7190
		}
	
		private sealed class ExclusiveOrInt16 : ExclusiveOrInstruction // TypeDefIndex: 12252
		{
			// Constructors
			public ExclusiveOrInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B6E90-0x00000001817B6F50
		}
	
		private sealed class ExclusiveOrInt32 : ExclusiveOrInstruction // TypeDefIndex: 12253
		{
			// Constructors
			public ExclusiveOrInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B6F50-0x00000001817B7010
		}
	
		private sealed class ExclusiveOrInt64 : ExclusiveOrInstruction // TypeDefIndex: 12254
		{
			// Constructors
			public ExclusiveOrInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817B7010-0x00000001817B70D0
		}
	
		private sealed class ExclusiveOrByte : ExclusiveOrInstruction // TypeDefIndex: 12255
		{
			// Constructors
			public ExclusiveOrByte(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C5F60-0x00000001817C6070
		}
	
		private sealed class ExclusiveOrUInt16 : ExclusiveOrInstruction // TypeDefIndex: 12256
		{
			// Constructors
			public ExclusiveOrUInt16(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C6070-0x00000001817C6180
		}
	
		private sealed class ExclusiveOrUInt32 : ExclusiveOrInstruction // TypeDefIndex: 12257
		{
			// Constructors
			public ExclusiveOrUInt32(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C6180-0x00000001817C6330
		}
	
		private sealed class ExclusiveOrUInt64 : ExclusiveOrInstruction // TypeDefIndex: 12258
		{
			// Constructors
			public ExclusiveOrUInt64(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C6330-0x00000001817C64E0
		}
	
		private sealed class ExclusiveOrBoolean : ExclusiveOrInstruction // TypeDefIndex: 12259
		{
			// Constructors
			public ExclusiveOrBoolean(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C5E50-0x00000001817C5F60
		}
	
		// Constructors
		private ExclusiveOrInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817B6960-0x00000001817B6E60
	}
}
