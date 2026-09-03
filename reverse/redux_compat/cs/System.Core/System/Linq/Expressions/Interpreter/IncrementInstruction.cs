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
	internal abstract class IncrementInstruction : Instruction // TypeDefIndex: 12289
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
		public override string InstructionName { get; } // 0x00000001817CA560-0x00000001817CA590 
	
		// Nested types
		private sealed class IncrementInt16 : IncrementInstruction // TypeDefIndex: 12290
		{
			// Constructors
			public IncrementInt16(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817CA590-0x00000001817CA660
		}
	
		private sealed class IncrementInt32 : IncrementInstruction // TypeDefIndex: 12291
		{
			// Constructors
			public IncrementInt32(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817CA660-0x00000001817CA770
		}
	
		private sealed class IncrementInt64 : IncrementInstruction // TypeDefIndex: 12292
		{
			// Constructors
			public IncrementInt64(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817CA770-0x00000001817CA8C0
		}
	
		private sealed class IncrementUInt16 : IncrementInstruction // TypeDefIndex: 12293
		{
			// Constructors
			public IncrementUInt16(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817CAA20-0x00000001817CAAF0
		}
	
		private sealed class IncrementUInt32 : IncrementInstruction // TypeDefIndex: 12294
		{
			// Constructors
			public IncrementUInt32(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817CAAF0-0x00000001817CAC40
		}
	
		private sealed class IncrementUInt64 : IncrementInstruction // TypeDefIndex: 12295
		{
			// Constructors
			public IncrementUInt64(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817CAC40-0x00000001817CAD90
		}
	
		private sealed class IncrementSingle : IncrementInstruction // TypeDefIndex: 12296
		{
			// Constructors
			public IncrementSingle(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817CA8C0-0x00000001817CAA20
		}
	
		private sealed class IncrementDouble : IncrementInstruction // TypeDefIndex: 12297
		{
			// Constructors
			public IncrementDouble(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817C9F80-0x00000001817CA0E0
		}
	
		// Constructors
		private IncrementInstruction(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817CA0E0-0x00000001817CA560
	}
}
