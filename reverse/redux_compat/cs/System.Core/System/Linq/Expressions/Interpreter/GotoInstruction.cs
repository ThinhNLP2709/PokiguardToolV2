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
	internal sealed class GotoInstruction : IndexedBranchInstruction // TypeDefIndex: 12191
	{
		// Fields
		private static readonly GotoInstruction[] s_cache; // 0x00
		private readonly bool _hasResult; // 0x18
		private readonly bool _hasValue; // 0x19
		private readonly bool _labelTargetGetsValue; // 0x1A
	
		// Properties
		public override string InstructionName { get; } // 0x00000001817BB670-0x00000001817BB6A0 
		public override int ConsumedStack { get; } // 0x00000001817AB500-0x00000001817AB510 
		public override int ProducedStack { get; } // 0x00000001817AB540-0x00000001817AB550 
	
		// Constructors
		private GotoInstruction(int targetIndex, bool hasResult, bool hasValue, bool labelTargetGetsValue); // 0x00000001817BB620-0x00000001817BB670
		static GotoInstruction(); // 0x00000001817BB5B0-0x00000001817BB620
	
		// Methods
		internal static GotoInstruction Create(int labelIndex, bool hasResult, bool hasValue, bool labelTargetGetsValue); // 0x00000001817BB360-0x00000001817BB4C0
		public override int Run(InterpretedFrame frame); // 0x00000001817BB4C0-0x00000001817BB5B0
	}
}
