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
using UnityEngine.Bindings;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	internal sealed class DataBindingManager : IDisposable // TypeDefIndex: 3834
	{
		// Fields
		private readonly List<BindingData> m_BindingDataLocalPool; // 0x10
		private static readonly PropertyName k_RequestBindingPropertyName; // 0x00
		private static readonly BindingId k_ClearBindingsToken; // 0x08
		internal static BindingLogLevel globalLogLevel; // 0xA0
		private BindingLogLevel? m_LogLevel; // 0x18
		private static readonly List<BindingData> s_Empty; // 0xA8
		private readonly BaseVisualElementPanel m_Panel; // 0x20
		private readonly HierarchyDataSourceTracker m_DataSourceTracker; // 0x28
		private readonly HierarchyBindingTracker m_BindingsTracker; // 0x30
		private readonly List<ChangesFromUI> m_DetectedChangesFromUI; // 0x38
		private IgnoreUIChangesData m_IgnoreUIChangesData; // 0x40
	
		// Properties
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal BindingLogLevel logLevel { get; set; } // 0x0000000182388B10-0x0000000182388B80 0x000000018169C660-0x000000018169C690
	
		// Nested types
		[IsReadOnly]
		private struct BindingRequest // TypeDefIndex: 3835
		{
			// Fields
			public readonly BindingId bindingId; // 0x00
			public readonly Binding binding; // 0x98
			public readonly bool shouldProcess; // 0xA0
	
			// Constructors
			public BindingRequest([IsReadOnly] in BindingId bindingId, Binding binding, bool shouldProcess = true /* Metadata: 0x00660479 */); // 0x000000018237ED10-0x000000018237EDF0
	
			// Methods
			public BindingRequest CancelRequest(); // 0x000000018237ECB0-0x000000018237ED10
		}
	
		private struct BindingDataCollection : IDisposable // TypeDefIndex: 3836
		{
			// Fields
			private Dictionary<BindingId, BindingData> m_BindingPerId; // 0x00
			private List<BindingData> m_Bindings; // 0x08
	
			// Methods
			public static BindingDataCollection Create(); // 0x000000018237E210-0x000000018237E2D0
			public void AddBindingData(BindingData bindingData); // 0x000000018237E000-0x000000018237E210
			public bool TryGetBindingData([IsReadOnly] in BindingId bindingId, out BindingData data); // 0x000000018237E590-0x000000018237E670
			public bool RemoveBindingData(BindingData bindingData); // 0x000000018237E3D0-0x000000018237E590
			public List<BindingData> GetBindings(); // 0x0000000180C5CF90-0x0000000180C5CFA0
			public int GetBindingCount(); // 0x000000018237E3B0-0x000000018237E3D0
			public void Dispose(); // 0x000000018237E2D0-0x000000018237E3B0
		}
	
		internal class BindingData // TypeDefIndex: 3837
		{
			// Fields
			public long version; // 0x10
			public BindingTarget target; // 0x18
			public Binding binding; // 0xB8
			private DataSourceContext m_LastContext; // 0xC0
			[CompilerGenerated]
			private object _localDataSource_k__BackingField; // 0x158
			public BindingResult? m_SourceToUILastUpdate; // 0x160
			public BindingResult? m_UIToSourceLastUpdate; // 0x178
	
			// Properties
			public object localDataSource { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181F64850-0x0000000181F64860 0x00000001813800B0-0x00000001813800D0
			public DataSourceContext context { set; } // 0x000000018237E730-0x000000018237EA60
	
			// Constructors
			public BindingData(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Reset(); // 0x000000018237E670-0x000000018237E730
		}
	
		[IsReadOnly]
		internal struct ChangesFromUI // TypeDefIndex: 3838
		{
			// Fields
			public readonly long version; // 0x00
			public readonly Binding binding; // 0x08
			public readonly BindingData bindingData; // 0x10
	
			// Properties
			public bool IsValid { get; } // 0x0000000182382420-0x0000000182382460 
	
			// Constructors
			public ChangesFromUI(BindingData bindingData); // 0x00000001823823D0-0x0000000182382420
		}
	
		private class HierarchyBindingTracker : IDisposable // TypeDefIndex: 3839
		{
			// Fields
			private readonly BaseVisualElementPanel m_Panel; // 0x10
			private readonly HierarchicalBindingsSorter m_BindingSorter; // 0x18
			private readonly Dictionary<VisualElement, BindingDataCollection> m_BindingDataPerElement; // 0x20
			private readonly HashSet<VisualElement> m_BoundElements; // 0x28
			private readonly List<VisualElement> m_OrderedBindings; // 0x30
			private bool m_IsDirty; // 0x38
			private EventCallback<PropertyChangedEvent, Dictionary<VisualElement, BindingDataCollection>> m_OnPropertyChanged; // 0x40
	
			// Nested types
			private class HierarchicalBindingsSorter : HierarchyTraversal // TypeDefIndex: 3840
			{
				// Fields
				[CompilerGenerated]
				private HashSet<VisualElement> _boundElements_k__BackingField; // 0x10
				[CompilerGenerated]
				private List<VisualElement> _results_k__BackingField; // 0x18
	
				// Properties
				public HashSet<VisualElement> boundElements { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
				public List<VisualElement> results { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
				// Constructors
				public HierarchicalBindingsSorter(); // 0x00000001802F4070-0x00000001802F4080
	
				// Methods
				public override void TraverseRecursive(VisualElement element, int depth); // 0x000000018238E000-0x000000018238E0B0
			}
	
			// Constructors
			public HierarchyBindingTracker(BaseVisualElementPanel panel); // 0x000000018238F230-0x000000018238F3D0
	
			// Methods
			public int GetTrackedElementsCount(); // 0x000000018238E2E0-0x000000018238E300
			public List<VisualElement> GetBoundElements(); // 0x000000018238E200-0x000000018238E2E0
			public void SetDirty(); // 0x00000001805629E0-0x00000001805629F0
			public bool TryGetBindingCollection(VisualElement element, out BindingDataCollection collection); // 0x000000018238F1C0-0x000000018238F230
			public bool IsTrackingElement(VisualElement element); // 0x000000018238E300-0x000000018238E360
			public void StartTrackingBinding(VisualElement element, BindingData binding); // 0x000000018238E9A0-0x000000018238EDF0
			private void OnPropertyChanged(PropertyChangedEvent evt, Dictionary<VisualElement, BindingDataCollection> bindingCollection); // 0x000000018238E360-0x000000018238E8F0
			public void StopTrackingBinding(VisualElement element, BindingData binding); // 0x000000018238EDF0-0x000000018238F100
			public void StopTrackingElement(VisualElement element); // 0x000000018238F100-0x000000018238F1C0
			public void Dispose(); // 0x000000018238E0B0-0x000000018238E200
			private void OrderBindings(VisualElement root); // 0x000000018238E8F0-0x000000018238E9A0
		}
	
		private class HierarchyDataSourceTracker : IDisposable // TypeDefIndex: 3841
		{
			// Fields
			private readonly List<SourceInfo> m_SourceInfosPool; // 0x10
			private readonly DataBindingManager m_DataBindingManager; // 0x18
			private readonly Dictionary<VisualElement, DataSourceContext> m_ResolvedHierarchicalDataSourceContext; // 0x20
			private readonly Dictionary<Binding, int> m_BindingRefCount; // 0x28
			private readonly Dictionary<object, SourceInfo> m_SourceInfos; // 0x30
			private readonly HashSet<object> m_SourcesToRemove; // 0x38
			private readonly InvalidateDataSourcesTraversal m_InvalidateResolvedDataSources; // 0x40
			private readonly EventHandler<BindablePropertyChangedEventArgs> m_Handler; // 0x48
			private readonly EventCallback<PropertyChangedEvent, VisualElement> m_VisualElementHandler; // 0x50
	
			// Nested types
			private class SourceInfo // TypeDefIndex: 3842
			{
				// Fields
				private HashSet<PropertyPath> m_DetectedChanges; // 0x10
				[CompilerGenerated]
				private long _lastVersion_k__BackingField; // 0x18
				[CompilerGenerated]
				private int _refCount_k__BackingField; // 0x20
	
				// Properties
				public long lastVersion { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001804C2E30-0x00000001804C2E40
				public int refCount { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
				public HashSet<PropertyPath> detectedChanges { get; } // 0x0000000182392B90-0x0000000182392C10 
				public HashSet<PropertyPath> detectedChangesNoAlloc { get; } // 0x0000000180377550-0x0000000180377560 
	
				// Constructors
				public SourceInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
			}
	
			private class InvalidateDataSourcesTraversal : HierarchyTraversal // TypeDefIndex: 3843
			{
				// Fields
				private readonly HierarchyDataSourceTracker m_DataSourceTracker; // 0x10
				private readonly HashSet<VisualElement> m_VisitedElements; // 0x18
	
				// Constructors
				public InvalidateDataSourcesTraversal(HierarchyDataSourceTracker dataSourceTracker); // 0x00000001823922F0-0x0000000182392380
	
				// Methods
				public void Invalidate(List<VisualElement> addedOrMovedElements, HashSet<VisualElement> removedElements); // 0x0000000182392050-0x00000001823921F0
				public override void TraverseRecursive(VisualElement element, int depth); // 0x00000001823921F0-0x00000001823922F0
			}
	
			private class ObjectComparer : IEqualityComparer<object> // TypeDefIndex: 3844
			{
				// Constructors
				public ObjectComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				bool IEqualityComparer<object>.Equals(object x, object y); // 0x0000000182392450-0x0000000182392540
				int IEqualityComparer<object>.GetHashCode(object obj); // 0x000000018171AC90-0x000000018171ACA0
			}
	
			// Constructors
			public HierarchyDataSourceTracker(DataBindingManager manager); // 0x00000001823918B0-0x0000000182391BC0
	
			// Methods
			private SourceInfo GetPooledSourceInfo(); // 0x00000001823902A0-0x0000000182390350
			private void ReleasePooledSourceInfo(SourceInfo info); // 0x00000001823913E0-0x00000001823914C0
			internal void IncreaseBindingRefCount(ref BindingData bindingData); // 0x0000000182390CE0-0x0000000182390E20
			internal void DecreaseBindingRefCount(ref BindingData bindingData); // 0x000000018238F730-0x000000018238F890
			internal void IncreaseRefCount(object dataSource); // 0x0000000182390E20-0x0000000182391040
			private void OnVisualElementPropertyChanged(PropertyChangedEvent evt, VisualElement element); // 0x00000001823912F0-0x00000001823913E0
			internal void DecreaseRefCount(object dataSource); // 0x000000018238F890-0x000000018238FA40
			public int GetTrackedDataSourcesCount(); // 0x0000000181E0F5A0-0x0000000181E0F5C0
			public HashSet<PropertyPath> GetChangesFromSource(object dataSource); // 0x000000018238FAC0-0x000000018238FB50
			public void ClearChangesFromSource(object dataSource); // 0x000000018238F3D0-0x000000018238F460
			public void InvalidateCachedDataSource(HashSet<VisualElement> elements, HashSet<VisualElement> removedElements); // 0x0000000182391040-0x00000001823912F0
			public DataSourceContext GetResolvedDataSourceContext(VisualElement element, BindingData bindingData); // 0x0000000182390350-0x0000000182390CE0
			private void TrackPropertyChanges(object sender, BindablePropertyChangedEventArgs args); // 0x0000000182391520-0x00000001823915E0
			private void TrackPropertyChanges(object sender, PropertyPath propertyPath); // 0x00000001823915E0-0x0000000182391760
			public bool TryGetLastVersion(object source, out long version); // 0x0000000182391760-0x0000000182391810
			public void UpdateVersion(object source, long version); // 0x0000000182391810-0x00000001823918B0
			internal DataSourceContext GetHierarchicalDataSourceContext(VisualElement element); // 0x000000018238FB50-0x00000001823902A0
			internal void RemoveHierarchyDataSourceContextFromElement(VisualElement element); // 0x00000001823914C0-0x0000000182391520
			public void Dispose(); // 0x000000018238FA40-0x000000018238FAC0
			public void ClearSourceCache(); // 0x000000018238F460-0x000000018238F730
		}
	
		private struct IgnoreUIChangesData // TypeDefIndex: 3845
		{
			// Fields
			public VisualElement element; // 0x00
			public Binding binding; // 0x08
			public BindingId bindingId; // 0x10
	
			// Methods
			public bool ShouldIgnoreChange(VisualElement ve, Binding b, BindingId id); // 0x0000000182391BC0-0x0000000182391BF0
		}
	
		public struct IgnoreUIChangesScope : IDisposable // TypeDefIndex: 3846
		{
			// Fields
			private IgnoreUIChangesData m_ScopeData; // 0x00
			private DataBindingManager manager; // 0xA8
	
			// Constructors
			internal IgnoreUIChangesScope(DataBindingManager manager, VisualElement target, BindingId bindingId, Binding binding); // 0x0000000182391D10-0x0000000182392050
	
			// Methods
			public void Dispose(); // 0x0000000182391BF0-0x0000000182391D10
		}
	
		// Constructors
		internal DataBindingManager(BaseVisualElementPanel panel); // 0x0000000182388840-0x0000000182388B10
		static DataBindingManager(); // 0x0000000182388690-0x0000000182388840
	
		// Methods
		internal void ResetLogLevel(); // 0x00000001823875F0-0x0000000182387600
		internal int GetTrackedDataSourcesCount(); // 0x0000000182385D40-0x0000000182385D70
		internal bool TryGetLastVersion(object source, out long version); // 0x0000000182387B90-0x0000000182387C40
		internal void UpdateVersion(object source, long version); // 0x00000001823885F0-0x0000000182388690
		internal void CacheUIBindingResult(BindingData bindingData, BindingResult result); // 0x0000000182384EC0-0x0000000182384F30
		internal bool TryGetLastUIBindingResult(BindingData bindingData, out BindingResult result); // 0x0000000182387B30-0x0000000182387B90
		internal void CacheSourceBindingResult(BindingData bindingData, BindingResult result); // 0x0000000182384E50-0x0000000182384EC0
		internal bool TryGetLastSourceBindingResult(BindingData bindingData, out BindingResult result); // 0x0000000182387AD0-0x0000000182387B30
		internal DataSourceContext GetResolvedDataSourceContext(VisualElement element, BindingData bindingData); // 0x0000000182385C10-0x0000000182385D40
		internal int GetBoundElementsCount(); // 0x0000000182385920-0x0000000182385950
		internal IEnumerable<VisualElement> GetBoundElements(); // 0x0000000182385950-0x0000000182385A30
		public IgnoreUIChangesScope IgnoreChangesScope(VisualElement target, BindingId bindingId, Binding binding); // 0x0000000182385D70-0x00000001823860C0
		internal List<ChangesFromUI> GetChangedDetectedFromUI(); // 0x00000001803272A0-0x00000001803272B0
		internal HashSet<PropertyPath> GetChangedDetectedFromSource(object dataSource); // 0x0000000182385A30-0x0000000182385AC0
		internal void ClearChangesFromSource(object dataSource); // 0x0000000182385180-0x0000000182385210
		internal List<BindingData> GetBindingData(VisualElement element); // 0x0000000182385830-0x0000000182385920
		internal bool TryGetBindingData(VisualElement element, [IsReadOnly] in BindingId bindingId, out BindingData bindingData); // 0x0000000182387800-0x00000001823878E0
		internal void RegisterBinding(VisualElement element, [IsReadOnly] in BindingId bindingId, Binding binding); // 0x0000000182386690-0x0000000182387490
		internal void UnregisterBinding(VisualElement element, [IsReadOnly] in BindingId bindingId); // 0x0000000182387C40-0x00000001823885F0
		internal void TransferBindingRequests(VisualElement element); // 0x0000000182387650-0x0000000182387800
		public void InvalidateCachedDataSource(HashSet<VisualElement> addedOrMovedElements, HashSet<VisualElement> removedElements); // 0x00000001823860C0-0x00000001823860E0
		public void Dispose(); // 0x0000000182385750-0x0000000182385830
		private static void CreateBindingRequest(VisualElement target, [IsReadOnly] in BindingId bindingId, Binding binding, bool isTransferring); // 0x0000000182385230-0x0000000182385730
		public void ProcessBindingRequests(VisualElement element); // 0x00000001823860E0-0x0000000182386690
		private void ClearAllBindings(VisualElement element); // 0x0000000182384F30-0x0000000182385180
		internal static bool AnyPendingBindingRequests(VisualElement element); // 0x0000000182384D90-0x0000000182384E50
		internal static bool TryGetBindingRequest(VisualElement element, [IsReadOnly] in BindingId bindingId, out Binding binding); // 0x00000001823878E0-0x0000000182387AD0
		public void DirtyBindingOrder(); // 0x0000000182385730-0x0000000182385750
		public void TrackDataSource(object previous, object current); // 0x0000000182387600-0x0000000182387650
		public void ClearSourceCache(); // 0x0000000182385210-0x0000000182385230
		public BindingData GetPooledBindingData(BindingTarget target, Binding binding); // 0x0000000182385AC0-0x0000000182385C10
		public void ReleasePoolBindingData(BindingData data); // 0x0000000182387490-0x00000001823875F0
	}
}
