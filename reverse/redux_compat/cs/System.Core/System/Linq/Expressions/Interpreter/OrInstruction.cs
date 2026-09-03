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
	internal abstract class OrInstruction : Instruction // TypeDefIndex: 12468
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
		public override string InstructionName { get; } // 0x00000001817FBFD0-0x00000001817FC000 
	
		// Nested types
		private sealed class OrSByte : OrInstruction // TypeDefIndex: 12469
		{
			// Constructors
			public OrSByte(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FC240-0x00000001817FC300
		}
	
		private sealed class OrInt16 : OrInstruction // TypeDefIndex: 12470
		{
			// Constructors
			public OrInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FC000-0x00000001817FC0C0
		}
	
		private sealed class OrInt32 : OrInstruction // TypeDefIndex: 12471
		{
			// Constructors
			public OrInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FC0C0-0x00000001817FC180
		}
	
		private sealed class OrInt64 : OrInstruction // TypeDefIndex: 12472
		{
			// Constructors
			public OrInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FC180-0x00000001817FC240
		}
	
		private sealed class OrByte : OrInstruction // TypeDefIndex: 12473
		{
			// Constructors
			public OrByte(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FBA10-0x00000001817FBAD0
		}
	
		private sealed class OrUInt16 : OrInstruction // TypeDefIndex: 12474
		{
			// Constructors
			public OrUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FC300-0x00000001817FC3C0
		}
	
		private sealed class OrUInt32 : OrInstruction // TypeDefIndex: 12475
		{
			// Constructors
			public OrUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FC3C0-0x00000001817FC480
		}
	
		private sealed class OrUInt64 : OrInstruction // TypeDefIndex: 12476
		{
			// Constructors
			public OrUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FC480-0x00000001817FC540
		}
	
		private sealed class OrBoolean : OrInstruction // TypeDefIndex: 12477
		{
			// Constructors
			public OrBoolean(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FB840-0x00000001817FBA10
		}
	
		// Constructors
		private OrInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817FBAD0-0x00000001817FBFD0
	}
}
