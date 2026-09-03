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
	internal sealed class DebugInfo // TypeDefIndex: 12349
	{
		// Fields
		public int StartLine; // 0x10
		public int EndLine; // 0x14
		public int Index; // 0x18
		public string FileName; // 0x20
		public bool IsClear; // 0x28
		private static readonly DebugInfoComparer s_debugComparer; // 0x00
	
		// Nested types
		private class DebugInfoComparer : IComparer<DebugInfo> // TypeDefIndex: 12350
		{
			// Constructors
			public DebugInfoComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			int IComparer<DebugInfo>.Compare(DebugInfo d1, DebugInfo d2); // 0x00000001817C5320-0x00000001817C5360
		}
	
		// Constructors
		public DebugInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static DebugInfo(); // 0x00000001817C56E0-0x00000001817C5760
	
		// Methods
		public static DebugInfo GetMatchingDebugInfo(DebugInfo[] debugInfos, int index); // 0x00000001817C5360-0x00000001817C5450
		public override string ToString(); // 0x00000001817C5450-0x00000001817C56E0
	}
}
