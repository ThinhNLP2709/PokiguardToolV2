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
	internal sealed class LeaveExceptionHandlerInstruction : IndexedBranchInstruction // TypeDefIndex: 12201
	{
		// Fields
		private static readonly LeaveExceptionHandlerInstruction[] s_cache; // 0x00
		private readonly bool _hasValue; // 0x18
	
		// Properties
		public override string InstructionName { get; } // 0x00000001817BD700-0x00000001817BD730 
		public override int ConsumedStack { get; } // 0x00000001817AB540-0x00000001817AB550 
		public override int ProducedStack { get; } // 0x00000001817AB540-0x00000001817AB550 
	
		// Constructors
		private LeaveExceptionHandlerInstruction(int labelIndex, bool hasValue); // 0x00000001817AFAC0-0x00000001817AFB00
		static LeaveExceptionHandlerInstruction(); // 0x00000001817BD690-0x00000001817BD700
	
		// Methods
		internal static LeaveExceptionHandlerInstruction Create(int labelIndex, bool hasValue); // 0x00000001817BD520-0x00000001817BD640
		public override int Run(InterpretedFrame frame); // 0x00000001817BD640-0x00000001817BD690
	}
}
