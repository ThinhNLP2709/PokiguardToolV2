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
	[VisibleToOtherModules(new string[3] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule", "UnityEditor.GraphToolkitModule" })]
	internal class Panel : BaseVisualElementPanel // TypeDefIndex: 4285
	{
		// Fields
		private VisualElement m_RootContainer; // 0x118
		private VisualTreeUpdater m_VisualTreeUpdater; // 0x120
		private IStylePropertyAnimationSystem m_StylePropertyAnimationSystem; // 0x128
		private string m_PanelName; // 0x130
		private uint m_Version; // 0x138
		private uint m_RepaintVersion; // 0x13C
		private uint m_HierarchyVersion; // 0x140
		private uint m_NameVersion; // 0x144
		private uint m_LastTickedHierarchyVersion; // 0x148
		private uint m_PendingHierarchyVersionChanges; // 0x14C
		private uint m_PendingRepaintVersionChanges; // 0x150
		private ProfilerMarker m_MarkerPrepareRepaint; // 0x158
		private ProfilerMarker m_MarkerRender; // 0x160
		private ProfilerMarker m_MarkerValidateLayout; // 0x168
		private ProfilerMarker m_MarkerTickScheduledActions; // 0x170
		protected ProfilerMarker m_MarkerTickScheduledActionsPreLayout; // 0x178
		protected ProfilerMarker m_MarkerTickScheduledActionsPostLayout; // 0x180
		private ProfilerMarker m_MarkerPanelChangeReceiver; // 0x188
		private static ProfilerMarker s_MarkerPickAll; // 0x00
		[CompilerGenerated]
		private EventDispatcher _dispatcher_k__BackingField; // 0x190
		[CompilerGenerated]
		private ScriptableObject _ownerObject_k__BackingField; // 0x198
		[CompilerGenerated]
		private readonly ContextType _contextType_k__BackingField; // 0x1A0
		[CompilerGenerated]
		private SavePersistentViewData _saveViewData_k__BackingField; // 0x1A8
		[CompilerGenerated]
		private GetViewDataDictionary _getViewDataDictionary_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private FocusController _focusController_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private EventInterests _IMGUIEventInterests_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private static LoadResourceFunction _loadResourceFunc_k__BackingField; // 0x08
		private bool m_JustReceivedFocus; // 0x1C3
		private IDebugPanelChangeReceiver m_PanelChangeReceiver; // 0x1C8
		[CompilerGenerated]
		private static TimeMsFunction _TimeSinceStartup_k__BackingField; // 0x10
		private AtlasBase m_Atlas; // 0x1D0
		private Dictionary<VisualElement, UIAnimationBinder> m_ElementBinders; // 0x1D8
		private bool m_ValidatingLayout; // 0x1E0
		[CompilerGenerated]
		private static Action<Panel> beforeTickingAnyScheduledPanel; // 0x18
		[CompilerGenerated]
		private static Action<Panel> beforeAnyRepaint; // 0x20
		[CompilerGenerated]
		private static Action<Panel> afterRepaint; // 0x28
	
		// Properties
		public sealed override VisualElement visualTree { get; } // 0x000000018171E0D0-0x000000018171E0E0 
		public sealed override EventDispatcher dispatcher { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		internal override IStylePropertyAnimationSystem styleAnimationSystem { get; [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] set; } // 0x0000000181CE5BD0-0x0000000181CE5BE0 0x00000001824DACC0-0x00000001824DADD0
		public override ScriptableObject ownerObject { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2A40-0x0000000181CC2A50 0x0000000181CC2A60-0x0000000181CC2A80
		public override ContextType contextType { [CompilerGenerated] get; } // 0x000000018033D610-0x000000018033D620 
		public override SavePersistentViewData saveViewData { [CompilerGenerated] get; } // 0x0000000180E224F0-0x0000000180E22500 
		public override GetViewDataDictionary getViewDataDictionary { [CompilerGenerated] get; } // 0x0000000181CB22F0-0x0000000181CB2300 
		public sealed override FocusController focusController { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
		public override EventInterests IMGUIEventInterests { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001824DAA50-0x00000001824DAA70 0x00000001824DAB30-0x00000001824DAB50
		private static LoadResourceFunction loadResourceFunc { [CompilerGenerated] get; } // 0x00000001824DAAD0-0x00000001824DAB20 
		internal string name { get; set; } // 0x0000000181C2D460-0x0000000181C2D470 0x00000001824DABE0-0x00000001824DAC10
		public IDebugPanelChangeReceiver panelChangeReceiver { get; set; } // 0x0000000181CB2300-0x0000000181CB2310 0x00000001824DAC10-0x00000001824DACC0
		[Obsolete("Use the non-static TimeSinceStartupFunc instead")]
		[VisibleToOtherModules(new string[1] {"UnityEditor.GraphToolkitModule" })]
		internal static TimeMsFunction TimeSinceStartup { [CompilerGenerated] get; } // 0x00000001824DAA70-0x00000001824DAAC0 
		internal override uint version { [VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x0000000181C0F6C0-0x0000000181C0F6D0 
		internal override uint repaintVersion { get; } // 0x00000001824DAB20-0x00000001824DAB30 
		internal override uint hierarchyVersion { get; } // 0x00000001824DAAC0-0x00000001824DAAD0 
		public override AtlasBase atlas { get; set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x00000001824DAB50-0x00000001824DABE0
	
		// Constructors
		public Panel(ScriptableObject ownerObject, ContextType contextType, EventDispatcher dispatcher); // 0x00000001824DA6B0-0x00000001824DAA50
		static Panel(); // 0x00000001824DA640-0x00000001824DA6B0
	
		// Methods
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal static UnityEngine.Object LoadResource(string pathName, Type type, float dpiScaling); // 0x00000001824D9100-0x00000001824D9240
		internal void Focus(); // 0x00000001824D8F30-0x00000001824D8F40
		internal void Blur(); // 0x00000001824D87F0-0x00000001824D8820
		public void ValidateFocus(); // 0x00000001824DA4A0-0x00000001824DA4E0
		private void CreateMarkers(); // 0x00000001824D8910-0x00000001824D8B60
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal UIAnimationBinder GetOrCreateElementBinder(VisualElement element); // 0x00000001824D8F40-0x00000001824D90D0
		internal void DestroyElementBinder(VisualElement element); // 0x00000001824D8D30-0x00000001824D8E30
		internal void DestroyAllElementBinders(); // 0x00000001824D8B60-0x00000001824D8D30
		protected override void Dispose(bool disposing); // 0x00000001824D8E30-0x00000001824D8F30
		internal static VisualElement PickAll(VisualElement root, Vector2 point, List<VisualElement> picked = null, bool includeIgnoredElement = false /* Metadata: 0x006606DE */); // 0x00000001824D98B0-0x00000001824D9A80
		private static VisualElement PerformPickNative(VisualElement root, Vector2 point, List<VisualElement> picked = null, bool includeIgnoredElement = false /* Metadata: 0x006606DF */); // 0x00000001824D93E0-0x00000001824D97E0
		public override VisualElement PickAll(Vector2 point, List<VisualElement> picked); // 0x00000001824D97E0-0x00000001824D98B0
		public override VisualElement Pick(Vector2 point, int pointerId); // 0x00000001824D9A80-0x00000001824D9C10
		public override void ValidateLayout(); // 0x00000001824DA4E0-0x00000001824DA640
		public override void UpdateAnimations(); // 0x00000001824DA320-0x00000001824DA350
		public override void UpdateBindings(); // 0x00000001824DA350-0x00000001824DA380
		public override void UpdateDataBinding(); // 0x00000001824DA380-0x00000001824DA3B0
		public override void TickSchedulingUpdaters(); // 0x00000001824D9F50-0x00000001824DA320
		public override void ApplyStyles(); // 0x00000001824D87C0-0x00000001824D87F0
		protected override void UpdateForRepaint(); // 0x00000001824DA3B0-0x00000001824DA4A0
		public override void Repaint(); // 0x00000001824D9CF0-0x00000001824D9F20
		public override void Render(); // 0x00000001824D9C10-0x00000001824D9CF0
		internal void ConsumePendingProfilerMetrics(out uint hierarchyVersionChanges, out uint repaintVersionChanges, out int visualElementCount); // 0x00000001824D8820-0x00000001824D8910
		internal override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType); // 0x00000001824D9240-0x00000001824D93E0
		internal override void SetUpdater(IVisualTreeUpdater updater, VisualTreeUpdatePhase phase); // 0x00000001824D9F20-0x00000001824D9F50
		internal override IVisualTreeUpdater GetUpdater(VisualTreeUpdatePhase phase); // 0x00000001824D90D0-0x00000001824D9100
		[CompilerGenerated]
		internal static Vector2Int _Pick_g__PixelOf_100_0(Vector2 p); // 0x00000001821FC0D0-0x00000001821FC1B0
	}
}
