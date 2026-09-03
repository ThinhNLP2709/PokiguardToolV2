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
	internal abstract class ModuloInstruction : Instruction // TypeDefIndex: 12391
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
		public override string InstructionName { get; } // 0x00000001817F5000-0x00000001817F5030 
	
		// Nested types
		private sealed class ModuloInt16 : ModuloInstruction // TypeDefIndex: 12392
		{
			// Constructors
			public ModuloInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F5030-0x00000001817F5170
		}
	
		private sealed class ModuloInt32 : ModuloInstruction // TypeDefIndex: 12393
		{
			// Constructors
			public ModuloInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F5170-0x00000001817F52B0
		}
	
		private sealed class ModuloInt64 : ModuloInstruction // TypeDefIndex: 12394
		{
			// Constructors
			public ModuloInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F52B0-0x00000001817F53F0
		}
	
		private sealed class ModuloUInt16 : ModuloInstruction // TypeDefIndex: 12395
		{
			// Constructors
			public ModuloUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F5540-0x00000001817F5680
		}
	
		private sealed class ModuloUInt32 : ModuloInstruction // TypeDefIndex: 12396
		{
			// Constructors
			public ModuloUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F5680-0x00000001817F57C0
		}
	
		private sealed class ModuloUInt64 : ModuloInstruction // TypeDefIndex: 12397
		{
			// Constructors
			public ModuloUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F57C0-0x00000001817F5900
		}
	
		private sealed class ModuloSingle : ModuloInstruction // TypeDefIndex: 12398
		{
			// Constructors
			public ModuloSingle(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F53F0-0x00000001817F5540
		}
	
		private sealed class ModuloDouble : ModuloInstruction // TypeDefIndex: 12399
		{
			// Constructors
			public ModuloDouble(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F4A30-0x00000001817F4B80
		}
	
		// Constructors
		private ModuloInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817F4B80-0x00000001817F5000
	}
}
