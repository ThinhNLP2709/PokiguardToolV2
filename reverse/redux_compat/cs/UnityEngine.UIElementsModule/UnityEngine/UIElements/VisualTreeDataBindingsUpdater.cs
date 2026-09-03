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
	internal class VisualTreeDataBindingsUpdater : BaseVisualTreeUpdater // TypeDefIndex: 3860
	{
		// Fields
		private static readonly ProfilerMarker s_UpdateProfilerMarker; // 0x00
		private static readonly ProfilerMarker s_ProcessBindingRequestsProfilerMarker; // 0x08
		private static readonly ProfilerMarker s_ProcessDataSourcesProfilerMarker; // 0x10
		private static readonly ProfilerMarker s_ShouldUpdateBindingProfilerMarker; // 0x18
		private static readonly ProfilerMarker s_UpdateBindingProfilerMarker; // 0x20
		private readonly BindingUpdater m_Updater; // 0x28
		private readonly List<VisualElement> m_BindingRegistrationRequests; // 0x30
		private readonly HashSet<VisualElement> m_DataSourceChangedRequests; // 0x38
		private readonly HashSet<VisualElement> m_RemovedElements; // 0x40
		private readonly List<VisualElement> m_BoundsElement; // 0x48
		private readonly List<VersionInfo> m_VersionChanges; // 0x50
		private readonly HashSet<object> m_TrackedObjects; // 0x58
		private readonly HashSet<Binding> m_RanUpdate; // 0x60
		private readonly HashSet<object> m_KnownSources; // 0x68
		private readonly HashSet<Binding> m_DirtyBindings; // 0x70
		private BaseVisualElementPanel m_AttachedPanel; // 0x78
	
		// Properties
		private DataBindingManager bindingManager { get; } // 0x00000001823995F0-0x0000000182399620 
		public override ProfilerMarker profilerMarker { get; } // 0x0000000182399620-0x0000000182399670 
	
		// Nested types
		[IsReadOnly]
		private struct VersionInfo // TypeDefIndex: 3861
		{
			// Fields
			public readonly object source; // 0x00
			public readonly long version; // 0x08
	
			// Constructors
			public VersionInfo(object source, long version); // 0x000000018150CD00-0x000000018150CD30
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3862
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Predicate<VisualElement> __9__29_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182393450-0x00000001823934C0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _ProcessDataSourceChangedRequests_b__29_0(VisualElement e); // 0x0000000182392DC0-0x0000000182392DF0
		}
	
		// Constructors
		public VisualTreeDataBindingsUpdater(); // 0x0000000182399320-0x00000001823995F0
		static VisualTreeDataBindingsUpdater(); // 0x00000001823991B0-0x0000000182399320
	
		// Methods
		protected void OnHierarchyChange(VisualElement ve, HierarchyChangeType type, IReadOnlyList<VisualElement> additionalContext = null); // 0x0000000182396CC0-0x0000000182397130
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType); // 0x0000000182397220-0x0000000182397300
		private void CacheAndLogBindingResult(bool appliedOnUiCache, [IsReadOnly] in DataBindingManager.BindingData bindingData, [IsReadOnly] in BindingResult result); // 0x0000000182396470-0x0000000182396740
		private void LogResult([IsReadOnly] in BindingResult result); // 0x0000000182396BA0-0x0000000182396CC0
		public override void Update(); // 0x0000000182397FB0-0x00000001823991B0
		private ValueTuple<bool, long> GetDataSourceVersion(object source); // 0x0000000182396870-0x0000000182396A10
		private bool IsPrefix([IsReadOnly] in PropertyPath prefix, [IsReadOnly] in PropertyPath path); // 0x0000000182396A10-0x0000000182396BA0
		private void ProcessDataSourceChangedRequests(); // 0x00000001823974D0-0x0000000182397740
		private void OnPanelChanged(BaseVisualElementPanel p); // 0x0000000182397130-0x0000000182397220
		protected override void Dispose(bool disposing); // 0x0000000182396740-0x0000000182396870
		private void ProcessAllBindingRequests(); // 0x0000000182397300-0x0000000182397480
		private void ProcessBindingRequests(VisualElement element); // 0x0000000182397480-0x00000001823974D0
		private void ProcessPropertyChangedEvents(HashSet<Binding> ranUpdate); // 0x0000000182397740-0x0000000182397FB0
	}
}
