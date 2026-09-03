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
	internal abstract class NegateCheckedInstruction : Instruction // TypeDefIndex: 12422
	{
		// Fields
		private static Instruction s_Int16; // 0x00
		private static Instruction s_Int32; // 0x08
		private static Instruction s_Int64; // 0x10
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817F7BA0-0x00000001817F7BD0 
	
		// Nested types
		private sealed class NegateCheckedInt32 : NegateCheckedInstruction // TypeDefIndex: 12423
		{
			// Constructors
			public NegateCheckedInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F7CE0-0x00000001817F7DB0
		}
	
		private sealed class NegateCheckedInt16 : NegateCheckedInstruction // TypeDefIndex: 12424
		{
			// Constructors
			public NegateCheckedInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F7BD0-0x00000001817F7CE0
		}
	
		private sealed class NegateCheckedInt64 : NegateCheckedInstruction // TypeDefIndex: 12425
		{
			// Constructors
			public NegateCheckedInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F7DB0-0x00000001817F7EB0
		}
	
		// Constructors
		private NegateCheckedInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817F79A0-0x00000001817F7BA0
	}
}
