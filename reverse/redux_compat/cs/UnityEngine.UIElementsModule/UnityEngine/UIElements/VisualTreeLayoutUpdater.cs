/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
	internal class VisualTreeLayoutUpdater : BaseVisualTreeUpdater // TypeDefIndex: 4972
	{
		// Fields
		private static readonly string s_Description; // 0x00
		private static readonly ProfilerMarker s_ProfilerMarker; // 0x08
		private static readonly ProfilerMarker k_ComputeLayoutMarker; // 0x10
		private static readonly ProfilerMarker k_UpdateSubTreeMarker; // 0x18
		private static readonly ProfilerMarker k_DispatchChangeEventsMarker; // 0x20
		private List<ValueTuple<Rect, Rect, VisualElement>> changeEventsList; // 0x28
		private List<VisualElement> missedHierarchyChangeEventsList; // 0x30
		private TextJobSystem m_TextJobSystem; // 0x38
	
		// Properties
		public override ProfilerMarker profilerMarker { get; } // 0x00000001824061D0-0x0000000182406220 
	
		// Constructors
		public VisualTreeLayoutUpdater(); // 0x00000001824060D0-0x00000001824061D0
		static VisualTreeLayoutUpdater(); // 0x0000000182405F60-0x00000001824060D0
	
		// Methods
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType); // 0x00000001824049F0-0x0000000182404B40
		public override void Update(); // 0x0000000182405850-0x0000000182405F60
		private static bool UpdateHierarchyDisplayed(VisualElement ve, List<ValueTuple<Rect, Rect, VisualElement>> changeEvents, bool inheritedDisplayed = true /* Metadata: 0x0066099D */); // 0x0000000182404B40-0x0000000182404E40
		private void UpdateSubTree(VisualElement ve, List<ValueTuple<Rect, Rect, VisualElement>> changeEvents); // 0x0000000182404E40-0x0000000182405850
		private void DispatchChangeEvents(List<ValueTuple<Rect, Rect, VisualElement>> changeEvents, int currentLayoutPass); // 0x00000001824043E0-0x00000001824046B0
		private void DispatchMissedHierarchyChangeEvents(List<VisualElement> missedHierarchyChangeEvents, int currentLayoutPass); // 0x00000001824046B0-0x00000001824049F0
	}
}
