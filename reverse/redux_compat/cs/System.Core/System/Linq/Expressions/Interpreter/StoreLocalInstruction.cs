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
	internal sealed class StoreLocalInstruction : LocalAccessInstruction, IBoxableInstruction // TypeDefIndex: 12372
	{
		// Properties
		public override int ConsumedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817FEB10-0x00000001817FEB40 
	
		// Constructors
		internal StoreLocalInstruction(int index); // 0x0000000181380310-0x0000000181380340
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817FEA70-0x00000001817FEB10
		public Instruction BoxIfIndexMatches(int index); // 0x00000001817FEA00-0x00000001817FEA70
	}
}
