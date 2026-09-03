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
	internal abstract class NotInstruction : Instruction // TypeDefIndex: 12453
	{
		// Fields
		public static Instruction s_Boolean; // 0x00
		public static Instruction s_Int64; // 0x08
		public static Instruction s_Int32; // 0x10
		public static Instruction s_Int16; // 0x18
		public static Instruction s_UInt64; // 0x20
		public static Instruction s_UInt32; // 0x28
		public static Instruction s_UInt16; // 0x30
		public static Instruction s_Byte; // 0x38
		public static Instruction s_SByte; // 0x40
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817FABE0-0x00000001817FAC10 
	
		// Nested types
		private sealed class NotBoolean : NotInstruction // TypeDefIndex: 12454
		{
			// Constructors
			public NotBoolean(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F88B0-0x00000001817F8930
		}
	
		private sealed class NotInt64 : NotInstruction // TypeDefIndex: 12455
		{
			// Constructors
			public NotInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FAD10-0x00000001817FAD90
		}
	
		private sealed class NotInt32 : NotInstruction // TypeDefIndex: 12456
		{
			// Constructors
			public NotInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FAC90-0x00000001817FAD10
		}
	
		private sealed class NotInt16 : NotInstruction // TypeDefIndex: 12457
		{
			// Constructors
			public NotInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FAC10-0x00000001817FAC90
		}
	
		private sealed class NotUInt64 : NotInstruction // TypeDefIndex: 12458
		{
			// Constructors
			public NotUInt64(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FAF10-0x00000001817FAF90
		}
	
		private sealed class NotUInt32 : NotInstruction // TypeDefIndex: 12459
		{
			// Constructors
			public NotUInt32(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FAE90-0x00000001817FAF10
		}
	
		private sealed class NotUInt16 : NotInstruction // TypeDefIndex: 12460
		{
			// Constructors
			public NotUInt16(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FAE10-0x00000001817FAE90
		}
	
		private sealed class NotByte : NotInstruction // TypeDefIndex: 12461
		{
			// Constructors
			public NotByte(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F8930-0x00000001817F89B0
		}
	
		private sealed class NotSByte : NotInstruction // TypeDefIndex: 12462
		{
			// Constructors
			public NotSByte(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817FAD90-0x00000001817FAE10
		}
	
		// Constructors
		private NotInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(Type type); // 0x00000001817FA6E0-0x00000001817FABE0
	}
}
