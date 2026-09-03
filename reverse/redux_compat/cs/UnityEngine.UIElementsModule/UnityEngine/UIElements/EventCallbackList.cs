/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class EventCallbackList // TypeDefIndex: 4019
	{
		// Fields
		public static readonly EventCallbackList EmptyList; // 0x00
		private EventCallbackInternal[] m_Array; // 0x10
		private int m_Count; // 0x18
	
		// Properties
		public Span<EventCallbackInternal> Span { get; } // 0x0000000182471970-0x00000001824719D0 
		public ref EventCallbackInternal this[int index] { get => default; } // 0x00000001810F0FA0-0x00000001810F0FD0 
	
		// Constructors
		public EventCallbackList(); // 0x00000001824718E0-0x0000000182471970
		static EventCallbackList(); // 0x0000000182471870-0x00000001824718E0
	
		// Methods
		public int FindGroup(EventCallbackInternal callback); // 0x00000001824716F0-0x0000000182471750
		public int Find(EventCallbackInternal callback); // 0x00000001824716F0-0x0000000182471750
		public int Find(Delegate callback, long eventTypeId); // 0x0000000182471750-0x0000000182471810
		public bool RemoveGroupAt(int i, int count); // 0x0000000182471810-0x0000000182471870
		public void RemoveAt(int i); // 0x000000018246EBA0-0x000000018246EE60
		public void Add(EventCallbackInternal item); // 0x00000001824715F0-0x00000001824716F0
		public void AddRange(EventCallbackInternal[] list, int count); // 0x0000000182471500-0x00000001824715C0
		public void AddRange(EventCallbackList list); // 0x00000001824715C0-0x00000001824715F0
		public void Clear(); // 0x0000000181652A80-0x0000000181652AB0
	}
}
