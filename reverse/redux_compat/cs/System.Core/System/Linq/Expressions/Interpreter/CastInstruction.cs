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
	internal abstract class CastInstruction : Instruction // TypeDefIndex: 12520
	{
		// Fields
		private static CastInstruction s_Boolean; // 0x00
		private static CastInstruction s_Byte; // 0x08
		private static CastInstruction s_Char; // 0x10
		private static CastInstruction s_DateTime; // 0x18
		private static CastInstruction s_Decimal; // 0x20
		private static CastInstruction s_Double; // 0x28
		private static CastInstruction s_Int16; // 0x30
		private static CastInstruction s_Int32; // 0x38
		private static CastInstruction s_Int64; // 0x40
		private static CastInstruction s_SByte; // 0x48
		private static CastInstruction s_Single; // 0x50
		private static CastInstruction s_String; // 0x58
		private static CastInstruction s_UInt16; // 0x60
		private static CastInstruction s_UInt32; // 0x68
		private static CastInstruction s_UInt64; // 0x70
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817E8AE0-0x00000001817E8B10 
	
		// Nested types
		private sealed class CastInstructionT<T> : CastInstruction // TypeDefIndex: 12521
		{
			// Constructors
			public CastInstructionT();
	
			// Methods
			public override int Run(InterpretedFrame frame);
		}
	
		private abstract class CastInstructionNoT : CastInstruction // TypeDefIndex: 12522
		{
			// Fields
			private readonly Type _t; // 0x10
	
			// Nested types
			private sealed class Ref : CastInstructionNoT // TypeDefIndex: 12523
			{
				// Constructors
				public Ref(Type t); // 0x00000001802E7420-0x00000001802E7460
	
				// Methods
				protected override void ConvertNull(InterpretedFrame frame); // 0x00000001817FD3D0-0x00000001817FD400
			}
	
			private sealed class Value : CastInstructionNoT // TypeDefIndex: 12524
			{
				// Constructors
				public Value(Type t); // 0x00000001802E7420-0x00000001802E7460
	
				// Methods
				protected override void ConvertNull(InterpretedFrame frame); // 0x0000000181802860-0x00000001818028A0
			}
	
			// Constructors
			protected CastInstructionNoT(Type t); // 0x00000001802E7420-0x00000001802E7460
	
			// Methods
			public static new CastInstruction Create(Type t); // 0x00000001817E8050-0x00000001817E8110
			public override int Run(InterpretedFrame frame); // 0x00000001817E8110-0x00000001817E82A0
			protected abstract void ConvertNull(InterpretedFrame frame);
		}
	
		// Constructors
		protected CastInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type t); // 0x00000001817E82A0-0x00000001817E8AE0
	}
}
