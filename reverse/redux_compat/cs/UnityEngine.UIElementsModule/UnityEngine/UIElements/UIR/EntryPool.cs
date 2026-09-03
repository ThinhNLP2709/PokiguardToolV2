/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class EntryPool // TypeDefIndex: 5052
	{
		// Fields
		private Stack<Entry>[] m_ThreadEntries; // 0x10
		private ImplicitPool<Entry> m_SharedPool; // 0x18
		[NoAutoStaticsCleanup]
		private static readonly Func<Entry> k_CreateAction; // 0x00
		[NoAutoStaticsCleanup]
		private static readonly Action<Entry> k_ResetAction; // 0x08
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5053
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x000000018241E860-0x000000018241E8D0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Entry _.cctor_b__8_0(); // 0x000000018241E690-0x000000018241E6E0
			internal void _.cctor_b__8_1(Entry e); // 0x000000018241E6E0-0x000000018241E7F0
		}
	
		// Constructors
		public EntryPool(int maxCapacity = 1024 /* Metadata: 0x00660A23 */); // 0x000000018240B740-0x000000018240B960
		static EntryPool(); // 0x000000018240B5F0-0x000000018240B740
	
		// Methods
		public Entry Get(); // 0x000000018240B2C0-0x000000018240B540
		public void ReturnAll(); // 0x000000018240B540-0x000000018240B5F0
	}
}
