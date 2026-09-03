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
	internal abstract class AndInstruction : Instruction // TypeDefIndex: 12163
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
		public override string InstructionName { get; } // 0x00000001817A94F0-0x00000001817A9520 
	
		// Nested types
		private sealed class AndSByte : AndInstruction // TypeDefIndex: 12164
		{
			// Constructors
			public AndSByte(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A9760-0x00000001817A9820
		}
	
		private sealed class AndInt16 : AndInstruction // TypeDefIndex: 12165
		{
			// Constructors
			public AndInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A9520-0x00000001817A95E0
		}
	
		private sealed class AndInt32 : AndInstruction // TypeDefIndex: 12166
		{
			// Constructors
			public AndInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A95E0-0x00000001817A96A0
		}
	
		private sealed class AndInt64 : AndInstruction // TypeDefIndex: 12167
		{
			// Constructors
			public AndInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A96A0-0x00000001817A9760
		}
	
		private sealed class AndByte : AndInstruction // TypeDefIndex: 12168
		{
			// Constructors
			public AndByte(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A8F30-0x00000001817A8FF0
		}
	
		private sealed class AndUInt16 : AndInstruction // TypeDefIndex: 12169
		{
			// Constructors
			public AndUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A9820-0x00000001817A98E0
		}
	
		private sealed class AndUInt32 : AndInstruction // TypeDefIndex: 12170
		{
			// Constructors
			public AndUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A98E0-0x00000001817A99A0
		}
	
		private sealed class AndUInt64 : AndInstruction // TypeDefIndex: 12171
		{
			// Constructors
			public AndUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A99A0-0x00000001817A9A60
		}
	
		private sealed class AndBoolean : AndInstruction // TypeDefIndex: 12172
		{
			// Constructors
			public AndBoolean(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A8DA0-0x00000001817A8F30
		}
	
		// Constructors
		private AndInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817A8FF0-0x00000001817A94F0
	}
}
