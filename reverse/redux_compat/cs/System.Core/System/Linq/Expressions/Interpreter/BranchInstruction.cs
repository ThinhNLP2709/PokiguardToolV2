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
	internal class BranchInstruction : OffsetInstruction // TypeDefIndex: 12189
	{
		// Fields
		private static Instruction[][][] s_caches; // 0x00
		internal readonly bool _hasResult; // 0x18
		internal readonly bool _hasValue; // 0x19
	
		// Properties
		public override Instruction[] Cache { get; } // 0x00000001817AB240-0x00000001817AB500 
		public override string InstructionName { get; } // 0x00000001817AB510-0x00000001817AB540 
		public override int ConsumedStack { get; } // 0x00000001817AB500-0x00000001817AB510 
		public override int ProducedStack { get; } // 0x00000001817AB540-0x00000001817AB550 
	
		// Constructors
		internal BranchInstruction(); // 0x00000001817AB1D0-0x00000001817AB200
		public BranchInstruction(bool hasResult, bool hasValue); // 0x00000001817AB200-0x00000001817AB240
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001802E64B0-0x00000001802E64C0
	}
}
