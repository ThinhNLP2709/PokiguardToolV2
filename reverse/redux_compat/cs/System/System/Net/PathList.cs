/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	[Serializable]
	internal class PathList // TypeDefIndex: 9093
	{
		// Fields
		private SortedList m_list; // 0x10
	
		// Properties
		public int Count { get; } // 0x0000000181592BB0-0x0000000181592BE0 
		public ICollection Values { get; } // 0x0000000181501A10-0x0000000181501A40 
		public object this[string s] { get => default; set {} } // 0x0000000181BD4BC0-0x0000000181BD4BF0 0x0000000181C10F60-0x0000000181C11070
		public object SyncRoot { get; } // 0x0000000181465D40-0x0000000181465D70 
	
		// Nested types
		[Serializable]
		private class PathListComparer : IComparer // TypeDefIndex: 9094
		{
			// Fields
			internal static readonly PathListComparer StaticInstance; // 0x00
	
			// Constructors
			public PathListComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static PathListComparer(); // 0x0000000181C10AE0-0x0000000181C10B50
	
			// Methods
			int IComparer.Compare(object ol, object or); // 0x0000000181C108B0-0x0000000181C10AE0
		}
	
		// Constructors
		public PathList(); // 0x0000000181C10EA0-0x0000000181C10F60
	
		// Methods
		public int GetCookiesCount(); // 0x0000000181C10B50-0x0000000181C10EA0
		public IEnumerator GetEnumerator(); // 0x0000000181411FF0-0x0000000181412020
	}
}
