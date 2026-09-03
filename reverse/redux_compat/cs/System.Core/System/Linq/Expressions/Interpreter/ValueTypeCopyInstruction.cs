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
	internal sealed class ValueTypeCopyInstruction : Instruction // TypeDefIndex: 12376
	{
		// Fields
		public static readonly ValueTypeCopyInstruction Instruction; // 0x00
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x0000000181802830-0x0000000181802860 
	
		// Constructors
		public ValueTypeCopyInstruction(); // 0x00000001802F4070-0x00000001802F4080
		static ValueTypeCopyInstruction(); // 0x00000001818027C0-0x0000000181802830
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x0000000181802770-0x00000001818027C0
	}
}
