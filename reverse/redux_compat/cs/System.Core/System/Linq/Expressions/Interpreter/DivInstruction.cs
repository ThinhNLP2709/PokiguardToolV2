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
	internal abstract class DivInstruction : Instruction // TypeDefIndex: 12215
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
		public override string InstructionName { get; } // 0x00000001817AE590-0x00000001817AE5C0 
	
		// Nested types
		private sealed class DivInt16 : DivInstruction // TypeDefIndex: 12216
		{
			// Constructors
			public DivInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817AE5C0-0x00000001817AE700
		}
	
		private sealed class DivInt32 : DivInstruction // TypeDefIndex: 12217
		{
			// Constructors
			public DivInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817AE700-0x00000001817AE840
		}
	
		private sealed class DivInt64 : DivInstruction // TypeDefIndex: 12218
		{
			// Constructors
			public DivInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817AE840-0x00000001817AE980
		}
	
		private sealed class DivUInt16 : DivInstruction // TypeDefIndex: 12219
		{
			// Constructors
			public DivUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817AEAC0-0x00000001817AEC00
		}
	
		private sealed class DivUInt32 : DivInstruction // TypeDefIndex: 12220
		{
			// Constructors
			public DivUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817AEC00-0x00000001817AED40
		}
	
		private sealed class DivUInt64 : DivInstruction // TypeDefIndex: 12221
		{
			// Constructors
			public DivUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817AED40-0x00000001817AEE80
		}
	
		private sealed class DivSingle : DivInstruction // TypeDefIndex: 12222
		{
			// Constructors
			public DivSingle(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817AE980-0x00000001817AEAC0
		}
	
		private sealed class DivDouble : DivInstruction // TypeDefIndex: 12223
		{
			// Constructors
			public DivDouble(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817ADFD0-0x00000001817AE110
		}
	
		// Constructors
		private DivInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817AE110-0x00000001817AE590
	}
}
