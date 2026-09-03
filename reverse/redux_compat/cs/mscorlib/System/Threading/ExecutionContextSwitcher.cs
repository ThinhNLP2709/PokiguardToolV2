/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	internal struct ExecutionContextSwitcher // TypeDefIndex: 2576
	{
		// Fields
		internal ExecutionContext.Reader outerEC; // 0x00
		internal bool outerECBelongsToScope; // 0x08
		internal object hecsw; // 0x10
		internal Thread thread; // 0x18
	
		// Methods
		[HandleProcessCorruptedStateExceptions]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal bool UndoNoThrow(); // 0x000000018166DCD0-0x000000018166DCF0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal void Undo(); // 0x000000018166DCF0-0x000000018166DDA0
	}
}
