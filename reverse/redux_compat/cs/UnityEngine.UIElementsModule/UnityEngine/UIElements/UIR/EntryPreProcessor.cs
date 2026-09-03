/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class EntryPreProcessor // TypeDefIndex: 5054
	{
		// Fields
		private int m_ChildrenIndex; // 0x10
		private List<AllocSize> m_Allocs; // 0x18
		private List<AllocSize> m_HeadAllocs; // 0x20
		private List<AllocSize> m_TailAllocs; // 0x28
		private List<Entry> m_FlattenedEntries; // 0x30
		private AllocSize m_Pending; // 0x38
		private Stack<AllocSize> m_Mask; // 0x40
		private bool m_IsPushingMask; // 0x48
	
		// Properties
		public int childrenIndex { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public List<AllocSize> headAllocs { get; } // 0x00000001802F8630-0x00000001802F8640 
		public List<AllocSize> tailAllocs { get; } // 0x000000018033D240-0x000000018033D250 
		public List<Entry> flattenedEntries { get; } // 0x000000018031E110-0x000000018031E120 
	
		// Nested types
		public struct AllocSize // TypeDefIndex: 5055
		{
			// Fields
			public int vertexCount; // 0x00
			public int indexCount; // 0x04
		}
	
		// Constructors
		public EntryPreProcessor(); // 0x000000018240BEF0-0x000000018240C040
	
		// Methods
		public void PreProcess(Entry root); // 0x000000018240BDD0-0x000000018240BEF0
		public void ClearReferences(); // 0x0000000181C663C0-0x0000000181C66400
		private void DoEvaluate(Entry entry); // 0x000000018240BA40-0x000000018240BD30
		private void Add(int vertexCount, int indexCount); // 0x000000018240B960-0x000000018240BA40
		private void Flush(); // 0x000000018240BD30-0x000000018240BDD0
	}
}
