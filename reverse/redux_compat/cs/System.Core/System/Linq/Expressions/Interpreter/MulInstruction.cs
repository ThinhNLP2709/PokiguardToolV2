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
	internal abstract class MulInstruction : Instruction // TypeDefIndex: 12400
	{
		// Fields
		private static Instruction s_Int16; // 0x00
		private static Instruction s_Int32; // 0x08
		private static Instruction s_Int64; // 0x10
		private static Instruction s_UInt16; // 0x18
		private static Instruction s_UInt32; // 0x20
		private static Instruction s_UInt64; // 0x28
		private static Instruction s_Single; // 0x30
		private static Instruction s_Double; // 0x38
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180476390-0x00000001804763A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817F5EC0-0x00000001817F5EF0 
	
		// Nested types
		private sealed class MulInt16 : MulInstruction // TypeDefIndex: 12401
		{
			// Constructors
			public MulInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F5EF0-0x00000001817F6030
		}
	
		private sealed class MulInt32 : MulInstruction // TypeDefIndex: 12402
		{
			// Constructors
			public MulInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F6030-0x00000001817F6170
		}
	
		private sealed class MulInt64 : MulInstruction // TypeDefIndex: 12403
		{
			// Constructors
			public MulInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F6170-0x00000001817F62B0
		}
	
		private sealed class MulUInt16 : MulInstruction // TypeDefIndex: 12404
		{
			// Constructors
			public MulUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F72E0-0x00000001817F7420
		}
	
		private sealed class MulUInt32 : MulInstruction // TypeDefIndex: 12405
		{
			// Constructors
			public MulUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F7420-0x00000001817F7560
		}
	
		private sealed class MulUInt64 : MulInstruction // TypeDefIndex: 12406
		{
			// Constructors
			public MulUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F7560-0x00000001817F76A0
		}
	
		private sealed class MulSingle : MulInstruction // TypeDefIndex: 12407
		{
			// Constructors
			public MulSingle(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F71A0-0x00000001817F72E0
		}
	
		private sealed class MulDouble : MulInstruction // TypeDefIndex: 12408
		{
			// Constructors
			public MulDouble(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F5900-0x00000001817F5A40
		}
	
		// Constructors
		private MulInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817F5A40-0x00000001817F5EC0
	}
}
