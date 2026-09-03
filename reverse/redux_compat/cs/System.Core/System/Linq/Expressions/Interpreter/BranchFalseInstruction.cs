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
	internal sealed class BranchFalseInstruction : OffsetInstruction // TypeDefIndex: 12186
	{
		// Fields
		private static Instruction[] s_cache; // 0x00
	
		// Properties
		public override Instruction[] Cache { get; } // 0x00000001817AB110-0x00000001817AB1A0 
		public override string InstructionName { get; } // 0x00000001817AB1A0-0x00000001817AB1D0 
		public override int ConsumedStack { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		public BranchFalseInstruction(); // 0x00000001817AB100-0x00000001817AB110
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817AB0A0-0x00000001817AB100
	}
}
