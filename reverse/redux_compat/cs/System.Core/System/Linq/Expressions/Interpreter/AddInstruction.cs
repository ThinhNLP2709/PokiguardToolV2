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
	internal abstract class AddInstruction : Instruction // TypeDefIndex: 12147
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
		public override string InstructionName { get; } // 0x00000001817A7630-0x00000001817A7660 
	
		// Nested types
		private sealed class AddInt16 : AddInstruction // TypeDefIndex: 12148
		{
			// Constructors
			public AddInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A7660-0x00000001817A77A0
		}
	
		private sealed class AddInt32 : AddInstruction // TypeDefIndex: 12149
		{
			// Constructors
			public AddInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A77A0-0x00000001817A78E0
		}
	
		private sealed class AddInt64 : AddInstruction // TypeDefIndex: 12150
		{
			// Constructors
			public AddInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A78E0-0x00000001817A7A20
		}
	
		private sealed class AddUInt16 : AddInstruction // TypeDefIndex: 12151
		{
			// Constructors
			public AddUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A89E0-0x00000001817A8B20
		}
	
		private sealed class AddUInt32 : AddInstruction // TypeDefIndex: 12152
		{
			// Constructors
			public AddUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A8B20-0x00000001817A8C60
		}
	
		private sealed class AddUInt64 : AddInstruction // TypeDefIndex: 12153
		{
			// Constructors
			public AddUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A8C60-0x00000001817A8DA0
		}
	
		private sealed class AddSingle : AddInstruction // TypeDefIndex: 12154
		{
			// Constructors
			public AddSingle(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A88A0-0x00000001817A89E0
		}
	
		private sealed class AddDouble : AddInstruction // TypeDefIndex: 12155
		{
			// Constructors
			public AddDouble(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A7070-0x00000001817A71B0
		}
	
		// Constructors
		private AddInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817A71B0-0x00000001817A7630
	}
}
