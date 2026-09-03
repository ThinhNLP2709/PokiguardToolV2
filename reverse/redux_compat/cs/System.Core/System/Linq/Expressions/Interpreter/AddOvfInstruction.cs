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
	internal abstract class AddOvfInstruction : Instruction // TypeDefIndex: 12156
	{
		// Fields
		private static Instruction s_Int16; // 0x00
		private static Instruction s_Int32; // 0x08
		private static Instruction s_Int64; // 0x10
		private static Instruction s_UInt16; // 0x18
		private static Instruction s_UInt32; // 0x20
		private static Instruction s_UInt64; // 0x28
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180476390-0x00000001804763A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817A7DC0-0x00000001817A7DF0 
	
		// Nested types
		private sealed class AddOvfInt16 : AddOvfInstruction // TypeDefIndex: 12157
		{
			// Constructors
			public AddOvfInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A7DF0-0x00000001817A7FE0
		}
	
		private sealed class AddOvfInt32 : AddOvfInstruction // TypeDefIndex: 12158
		{
			// Constructors
			public AddOvfInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A7FE0-0x00000001817A8180
		}
	
		private sealed class AddOvfInt64 : AddOvfInstruction // TypeDefIndex: 12159
		{
			// Constructors
			public AddOvfInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A8180-0x00000001817A8370
		}
	
		private sealed class AddOvfUInt16 : AddOvfInstruction // TypeDefIndex: 12160
		{
			// Constructors
			public AddOvfUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A8370-0x00000001817A8500
		}
	
		private sealed class AddOvfUInt32 : AddOvfInstruction // TypeDefIndex: 12161
		{
			// Constructors
			public AddOvfUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A8500-0x00000001817A86D0
		}
	
		private sealed class AddOvfUInt64 : AddOvfInstruction // TypeDefIndex: 12162
		{
			// Constructors
			public AddOvfUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817A86D0-0x00000001817A88A0
		}
	
		// Constructors
		private AddOvfInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817A7A20-0x00000001817A7DC0
	}
}
