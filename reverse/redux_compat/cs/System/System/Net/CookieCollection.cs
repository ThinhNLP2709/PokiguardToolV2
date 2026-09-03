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
using System.Runtime.Serialization;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	[Serializable]
	public class CookieCollection : ICollection // TypeDefIndex: 9088
	{
		// Fields
		internal int m_version; // 0x10
		private ArrayList m_list; // 0x18
		private DateTime m_TimeStamp; // 0x20
		private bool m_has_other_versions; // 0x28
		[OptionalField]
		private bool m_IsReadOnly; // 0x29
	
		// Properties
		public Cookie this[int index] { get => default; } // 0x0000000181BFCF50-0x0000000181BFD050 
		public int Count { get; } // 0x0000000181480EC0-0x0000000181480EF0 
		public bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public object SyncRoot { get; } // 0x0000000180370C60-0x0000000180370C70 
		internal bool IsOtherVersionSeen { get; } // 0x0000000180327270-0x0000000180327280 
	
		// Nested types
		internal enum Stamp // TypeDefIndex: 9089
		{
			Check = 0,
			Set = 1,
			SetToUnused = 2,
			SetToMaxUsed = 3
		}
	
		private class CookieCollectionEnumerator : IEnumerator // TypeDefIndex: 9090
		{
			// Fields
			private CookieCollection m_cookies; // 0x10
			private int m_count; // 0x18
			private int m_index; // 0x1C
			private int m_version; // 0x20
	
			// Properties
			object IEnumerator.Current { get; } // 0x0000000181BFC140-0x0000000181BFC240 
	
			// Constructors
			internal CookieCollectionEnumerator(CookieCollection cookies); // 0x0000000181BFC240-0x0000000181BFC2B0
	
			// Methods
			bool IEnumerator.MoveNext(); // 0x0000000181BFC090-0x0000000181BFC140
			void IEnumerator.Reset(); // 0x0000000181BA3750-0x0000000181BA3760
		}
	
		// Constructors
		public CookieCollection(); // 0x0000000181BFCEA0-0x0000000181BFCF50
	
		// Methods
		public void Add(Cookie cookie); // 0x0000000181BFC2B0-0x0000000181BFC380
		public void Add(CookieCollection cookies); // 0x0000000181BFC380-0x0000000181BFC6E0
		public void CopyTo(Array array, int index); // 0x0000000181BFC6E0-0x0000000181BFC710
		internal DateTime TimeStamp(Stamp how); // 0x0000000181BFCDA0-0x0000000181BFCEA0
		internal int InternalAdd(Cookie cookie, bool isStrict); // 0x0000000181BFCA10-0x0000000181BFCD70
		internal int IndexOf(Cookie cookie); // 0x0000000181BFC7B0-0x0000000181BFCA10
		internal void RemoveAt(int idx); // 0x0000000181BFCD70-0x0000000181BFCDA0
		public IEnumerator GetEnumerator(); // 0x0000000181BFC710-0x0000000181BFC7B0
	}
}
