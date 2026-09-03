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
	internal sealed class EnterTryFaultInstruction : IndexedBranchInstruction // TypeDefIndex: 12193
	{
		// Fields
		private TryFaultHandler _tryHandler; // 0x18
	
		// Properties
		public override string InstructionName { get; } // 0x00000001817AFE30-0x00000001817AFE60 
		public override int ProducedContinuations { get; } // 0x0000000180472790-0x00000001804727A0 
		internal TryFaultHandler Handler { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		internal EnterTryFaultInstruction(int targetIndex); // 0x0000000181380310-0x0000000181380340
	
		// Methods
		internal void SetTryHandler(TryFaultHandler tryHandler); // 0x00000001802FAF70-0x00000001802FAF80
		public override int Run(InterpretedFrame frame); // 0x00000001817AFB50-0x00000001817AFE30
	}
}
