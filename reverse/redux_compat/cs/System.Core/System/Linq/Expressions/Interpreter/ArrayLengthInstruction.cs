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
	internal sealed class ArrayLengthInstruction : Instruction // TypeDefIndex: 12178
	{
		// Fields
		public static readonly ArrayLengthInstruction Instance; // 0x00
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817A9B50-0x00000001817A9B80 
	
		// Constructors
		private ArrayLengthInstruction(); // 0x00000001802F4070-0x00000001802F4080
		static ArrayLengthInstruction(); // 0x00000001817A9AE0-0x00000001817A9B50
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817A9A60-0x00000001817A9AE0
	}
}
