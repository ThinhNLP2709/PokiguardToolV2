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
	internal abstract class NullableMethodCallInstruction : Instruction // TypeDefIndex: 12512
	{
		// Fields
		private static NullableMethodCallInstruction s_hasValue; // 0x00
		private static NullableMethodCallInstruction s_value; // 0x08
		private static NullableMethodCallInstruction s_equals; // 0x10
		private static NullableMethodCallInstruction s_getHashCode; // 0x18
		private static NullableMethodCallInstruction s_getValueOrDefault1; // 0x20
		private static NullableMethodCallInstruction s_toString; // 0x28
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817FB550-0x00000001817FB580 
	
		// Nested types
		private sealed class HasValue : NullableMethodCallInstruction // TypeDefIndex: 12513
		{
			// Constructors
			public HasValue(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F0100-0x00000001817F0140
		}
	
		private sealed class GetValue : NullableMethodCallInstruction // TypeDefIndex: 12514
		{
			// Constructors
			public GetValue(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817F00B0-0x00000001817F0100
		}
	
		private sealed class GetValueOrDefault : NullableMethodCallInstruction // TypeDefIndex: 12515
		{
			// Fields
			private readonly Type _defaultValueType; // 0x10
	
			// Constructors
			public GetValueOrDefault(MethodInfo mi); // 0x00000001817F0050-0x00000001817F00B0
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817EFFF0-0x00000001817F0050
		}
	
		private sealed class GetValueOrDefault1 : NullableMethodCallInstruction // TypeDefIndex: 12516
		{
			// Properties
			public override int ConsumedStack { get; } // 0x0000000180476390-0x00000001804763A0 
	
			// Constructors
			public GetValueOrDefault1(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817EFF90-0x00000001817EFFF0
		}
	
		private sealed class EqualsClass : NullableMethodCallInstruction // TypeDefIndex: 12517
		{
			// Properties
			public override int ConsumedStack { get; } // 0x0000000180476390-0x00000001804763A0 
	
			// Constructors
			public EqualsClass(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817ED300-0x00000001817ED3E0
		}
	
		private sealed class ToStringClass : NullableMethodCallInstruction // TypeDefIndex: 12518
		{
			// Constructors
			public ToStringClass(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x0000000181800DD0-0x0000000181800E50
		}
	
		private sealed class GetHashCodeClass : NullableMethodCallInstruction // TypeDefIndex: 12519
		{
			// Constructors
			public GetHashCodeClass(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override int Run(InterpretedFrame frame); // 0x00000001817EFF30-0x00000001817EFF90
		}
	
		// Constructors
		private NullableMethodCallInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static Instruction Create(string method, int argCount, MethodInfo mi); // 0x00000001817FB140-0x00000001817FB550
		public static Instruction CreateGetValue(); // 0x00000001817FB0A0-0x00000001817FB140
	}
}
