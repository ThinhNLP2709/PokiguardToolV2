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
	internal class NewInstruction : Instruction // TypeDefIndex: 12426
	{
		// Fields
		protected readonly ConstructorInfo _constructor; // 0x10
		protected readonly int _argumentCount; // 0x18
	
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180B23260-0x0000000180B23270 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817F8880-0x00000001817F88B0 
	
		// Constructors
		public NewInstruction(ConstructorInfo constructor, int argumentCount); // 0x00000001802E74A0-0x00000001802E74F0
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817F85F0-0x00000001817F8710
		protected object[] GetArgs(InterpretedFrame frame, int first); // 0x00000001817F8480-0x00000001817F85F0
		public override string ToString(); // 0x00000001817F8710-0x00000001817F8880
	}
}
