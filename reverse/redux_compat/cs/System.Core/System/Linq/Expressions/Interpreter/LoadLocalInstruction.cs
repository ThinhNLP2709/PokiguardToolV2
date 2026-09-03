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
	internal sealed class LoadLocalInstruction : LocalAccessInstruction, IBoxableInstruction // TypeDefIndex: 12367
	{
		// Properties
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817F3A40-0x00000001817F3A70 
	
		// Constructors
		internal LoadLocalInstruction(int index); // 0x0000000181380310-0x0000000181380340
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817F3990-0x00000001817F3A40
		public Instruction BoxIfIndexMatches(int index); // 0x00000001817F3920-0x00000001817F3990
	}
}
