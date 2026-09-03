/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions.Interpreter
{
	[DebuggerTypeProxy(typeof(DebugView))]
	[IsReadOnly]
	internal struct InstructionArray // TypeDefIndex: 12299
	{
		// Fields
		internal readonly int MaxStackDepth; // 0x00
		internal readonly int MaxContinuationDepth; // 0x04
		internal readonly Instruction[] Instructions; // 0x08
		internal readonly object[] Objects; // 0x10
		internal readonly RuntimeLabel[] Labels; // 0x18
		internal readonly List<KeyValuePair<int, object>> DebugCookies; // 0x20
	
		// Nested types
		internal sealed class DebugView // TypeDefIndex: 12300
		{
			// Fields
			private readonly InstructionArray _array; // 0x10
	
			// Constructors
			public DebugView(InstructionArray array); // 0x00000001817C5C20-0x00000001817C5CD0
	
			// Methods
			public InstructionList.DebugView.InstructionView[] GetInstructionViews(bool includeDebugCookies = false /* Metadata: 0x006A25C3 */); // 0x00000001817C5B30-0x00000001817C5BF0
			[CompilerGenerated]
			private int _GetInstructionViews_b__4_0(int index); // 0x00000001817C5BF0-0x00000001817C5C20
		}
	
		// Constructors
		internal InstructionArray(int maxStackDepth, int maxContinuationDepth, Instruction[] instructions, object[] objects, RuntimeLabel[] labels, List<KeyValuePair<int, object>> debugCookies); // 0x00000001817CAD90-0x00000001817CADF0
	}
}
