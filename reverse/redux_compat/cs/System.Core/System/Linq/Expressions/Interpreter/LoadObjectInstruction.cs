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
	internal sealed class LoadObjectInstruction : Instruction // TypeDefIndex: 12488
	{
		// Fields
		private readonly object _value; // 0x10
	
		// Properties
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817F3B90-0x00000001817F3BC0 
	
		// Constructors
		internal LoadObjectInstruction(object value); // 0x00000001802E7420-0x00000001802E7460
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817F3A70-0x00000001817F3B00
		public override string ToString(); // 0x00000001817F3B00-0x00000001817F3B90
	}
}
