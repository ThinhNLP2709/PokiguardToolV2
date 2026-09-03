/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class SelectorAccelerationCache // TypeDefIndex: 4785
	{
		// Fields
		public static SelectorAccelerationCache shared; // 0x00
		internal static readonly MemoryLabel s_MemoryLabel; // 0x08
		private static ProfilerMarker s_MarkerBuild; // 0x18
		private static ProfilerMarker s_MarkerClean; // 0x20
		private readonly Dictionary<EntityId, SelectorAccelerationCacheEntry> m_Cache; // 0x10
		[TupleElementNames(new string[2] {"dependency", "dependent" })]
		private readonly List<ValueTuple<EntityId, EntityId>> m_DependencyList; // 0x18
		private readonly DependencyComparer m_DependencyComparer; // 0x20
	
		// Nested types
		private class DependencyComparer : IComparer<ValueTuple<EntityId, EntityId>> // TypeDefIndex: 4786
		{
			// Constructors
			public DependencyComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public int Compare([TupleElementNames(new string[2] {"dependency", "dependent" })] ValueTuple<EntityId, EntityId> x, [TupleElementNames(new string[2] {"dependency", "dependent" })] ValueTuple<EntityId, EntityId> y); // 0x000000018255DC60-0x000000018255DCA0
		}
	
		// Constructors
		static SelectorAccelerationCache(); // 0x0000000182561830-0x0000000182561AC0
		public SelectorAccelerationCache(); // 0x0000000182561AC0-0x0000000182561BC0
	
		// Methods
		private static void Shutdown(); // 0x00000001825616B0-0x0000000182561710
		internal void Clear(); // 0x0000000182560EC0-0x00000001825610B0
		private bool TryRemoveAndDisposeEntry(EntityId entityId); // 0x0000000182561710-0x0000000182561830
		public void Remove(StyleSheet styleSheet); // 0x00000001825614D0-0x00000001825616A0
		private void RemovedStyleSheetFromMainCache(EntityId entityId, StyleSheet styleSheet = null); // 0x00000001825616A0-0x00000001825616B0
		public SelectorAccelerationCacheEntry GetOrCreate(StyleSheet styleSheet); // 0x00000001825610B0-0x00000001825614D0
	}
}
