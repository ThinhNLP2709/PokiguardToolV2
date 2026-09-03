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
	internal sealed class EnterTryCatchFinallyInstruction : IndexedBranchInstruction // TypeDefIndex: 12192
	{
		// Fields
		private readonly bool _hasFinally; // 0x18
		private TryCatchFinallyHandler _tryHandler; // 0x20
	
		// Properties
		internal TryCatchFinallyHandler Handler { get; } // 0x00000001802F8630-0x00000001802F8640 
		public override int ProducedContinuations { get; } // 0x00000001817AB540-0x00000001817AB550 
		public override string InstructionName { get; } // 0x00000001817AFB00-0x00000001817AFB50 
	
		// Constructors
		private EnterTryCatchFinallyInstruction(int targetIndex, bool hasFinally); // 0x00000001817AFAC0-0x00000001817AFB00
	
		// Methods
		internal void SetTryHandler(TryCatchFinallyHandler tryHandler); // 0x000000018033E830-0x000000018033E840
		internal static EnterTryCatchFinallyInstruction CreateTryFinally(int labelIndex); // 0x00000001817AF560-0x00000001817AF5C0
		internal static EnterTryCatchFinallyInstruction CreateTryCatch(); // 0x00000001817AF510-0x00000001817AF560
		public override int Run(InterpretedFrame frame); // 0x00000001817AF5C0-0x00000001817AFA40
		public override string ToString(); // 0x00000001817AFA40-0x00000001817AFAC0
	}
}
