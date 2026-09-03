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
	internal sealed class TryCatchFinallyHandler // TypeDefIndex: 12346
	{
		// Fields
		internal readonly int TryStartIndex; // 0x10
		internal readonly int TryEndIndex; // 0x14
		internal readonly int FinallyStartIndex; // 0x18
		internal readonly int FinallyEndIndex; // 0x1C
		internal readonly int GotoEndTargetIndex; // 0x20
		private readonly ExceptionHandler[] _handlers; // 0x28
	
		// Properties
		internal bool IsFinallyBlockExist { get; } // 0x00000001817E69C0-0x00000001817E69D0 
		internal ExceptionHandler[] Handlers { get; } // 0x000000018033D240-0x000000018033D250 
		internal bool IsCatchBlockExist { get; } // 0x000000018149AE40-0x000000018149AE50 
	
		// Constructors
		internal TryCatchFinallyHandler(int tryStart, int tryEnd, int gotoEndTargetIndex, ExceptionHandler[] handlers); // 0x00000001817E6950-0x00000001817E69C0
		internal TryCatchFinallyHandler(int tryStart, int tryEnd, int gotoEndLabelIndex, int finallyStart, int finallyEnd, ExceptionHandler[] handlers); // 0x00000001817E68E0-0x00000001817E6950
	
		// Methods
		internal bool HasHandler(InterpretedFrame frame, Exception exception, out ExceptionHandler handler, out object unwrappedException); // 0x00000001817E6750-0x00000001817E68E0
		private static bool FilterPasses(InterpretedFrame frame, ref object exception, ExceptionFilter filter); // 0x00000001817E6500-0x00000001817E6750
	}
}
