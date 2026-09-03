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
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class VisualTreeBindingsUpdater : BaseVisualTreeHierarchyTrackerUpdater // TypeDefIndex: 3858
	{
		// Fields
		private static readonly PropertyName s_BindingRequestObjectVEPropertyName; // 0x00
		private static readonly PropertyName s_AdditionalBindingObjectVEPropertyName; // 0x04
		private static readonly string s_Description; // 0x08
		private static readonly ProfilerMarker s_ProfilerMarker; // 0x10
		private static readonly ProfilerMarker s_ProfilerBindingRequestsMarker; // 0x18
		private static ProfilerMarker s_MarkerUpdate; // 0x20
		private static ProfilerMarker s_MarkerPoll; // 0x28
		[CompilerGenerated]
		private static bool _disableBindingsThrottling_k__BackingField; // 0x30
		private readonly HashSet<VisualElement> m_ElementsWithBindings; // 0x40
		private readonly HashSet<VisualElement> m_ElementsToAdd; // 0x48
		private readonly HashSet<VisualElement> m_ElementsToRemove; // 0x50
		private long m_LastUpdateTime; // 0x58
		private HashSet<VisualElement> m_ElementsToBind; // 0x60
		[CompilerGenerated]
		private Dictionary<object, object> _temporaryObjectCache_k__BackingField; // 0x68
		private List<IBinding> updatedBindings; // 0x70
	
		// Properties
		public override ProfilerMarker profilerMarker { get; } // 0x0000000182396420-0x0000000182396470 
		public static bool disableBindingsThrottling { [CompilerGenerated] get; } // 0x00000001823963D0-0x0000000182396420 
		public Dictionary<object, object> temporaryObjectCache { [CompilerGenerated] get; } // 0x0000000180316960-0x0000000180316970 
	
		// Constructors
		public VisualTreeBindingsUpdater(); // 0x0000000182396240-0x00000001823963D0
		static VisualTreeBindingsUpdater(); // 0x0000000182396070-0x0000000182396240
	
		// Methods
		private IBinding GetBindingObjectFromElement(VisualElement ve); // 0x0000000182394D40-0x0000000182394E60
		private void StartTracking(VisualElement ve); // 0x00000001823953A0-0x0000000182395420
		private void StopTracking(VisualElement ve); // 0x0000000182395540-0x00000001823955C0
		public static IBinding GetAdditionalBinding(VisualElement ve); // 0x0000000182394CB0-0x0000000182394D40
		private void StartTrackingRecursive(VisualElement ve); // 0x0000000182395270-0x00000001823953A0
		private void StopTrackingRecursive(VisualElement ve); // 0x0000000182395420-0x0000000182395540
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType); // 0x0000000182394E80-0x0000000182394F70
		protected override void OnHierarchyChange(VisualElement ve, HierarchyChangeType type); // 0x0000000182394E60-0x0000000182394E80
		private long CurrentTime(); // 0x0000000182394C70-0x0000000182394C90
		public bool ShouldProcessBindings(long startTime); // 0x00000001823951A0-0x0000000182395270
		public void PerformTrackingOperations(); // 0x0000000182394F70-0x00000001823951A0
		public override void Update(); // 0x0000000182395AC0-0x0000000182396070
		private void UpdateBindings(); // 0x00000001823955C0-0x0000000182395AC0
		protected override void Dispose(bool disposing); // 0x0000000182394C90-0x0000000182394CB0
	}
}
