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
	internal abstract class DecrementInstruction : Instruction // TypeDefIndex: 12205
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
		public override int ConsumedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817ADAA0-0x00000001817ADAD0 
	
		// Nested types
		private sealed class DecrementInt16 : DecrementInstruction // TypeDefIndex: 12206
		{
			// Constructors
			public DecrementInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817ADAD0-0x00000001817ADB50
		}
	
		private sealed class DecrementInt32 : DecrementInstruction // TypeDefIndex: 12207
		{
			// Constructors
			public DecrementInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817ADB50-0x00000001817ADBD0
		}
	
		private sealed class DecrementInt64 : DecrementInstruction // TypeDefIndex: 12208
		{
			// Constructors
			public DecrementInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817ADBD0-0x00000001817ADC50
		}
	
		private sealed class DecrementUInt16 : DecrementInstruction // TypeDefIndex: 12209
		{
			// Constructors
			public DecrementUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817ADCD0-0x00000001817ADD50
		}
	
		private sealed class DecrementUInt32 : DecrementInstruction // TypeDefIndex: 12210
		{
			// Constructors
			public DecrementUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817ADD50-0x00000001817ADDD0
		}
	
		private sealed class DecrementUInt64 : DecrementInstruction // TypeDefIndex: 12211
		{
			// Constructors
			public DecrementUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817ADDD0-0x00000001817ADE50
		}
	
		private sealed class DecrementSingle : DecrementInstruction // TypeDefIndex: 12212
		{
			// Constructors
			public DecrementSingle(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817ADC50-0x00000001817ADCD0
		}
	
		private sealed class DecrementDouble : DecrementInstruction // TypeDefIndex: 12213
		{
			// Constructors
			public DecrementDouble(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817AD5A0-0x00000001817AD620
		}
	
		// Constructors
		private DecrementInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817AD620-0x00000001817ADAA0
	}
}
