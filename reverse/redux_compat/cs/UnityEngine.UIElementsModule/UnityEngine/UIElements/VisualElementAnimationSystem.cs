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
using UnityEngine.UIElements.Experimental;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class VisualElementAnimationSystem : BaseVisualTreeUpdater // TypeDefIndex: 4966
	{
		// Fields
		private HashSet<IValueAnimationUpdate> m_Animations; // 0x28
		private List<IValueAnimationUpdate> m_IterationList; // 0x30
		private List<UIAnimationBinder> m_AnimationBinders; // 0x38
		private bool m_HasNewAnimations; // 0x40
		private bool m_IterationListDirty; // 0x41
		private static readonly string s_Description; // 0x00
		private static readonly ProfilerMarker s_ProfilerMarker; // 0x08
		private static readonly string s_StylePropertyAnimationDescription; // 0x10
		private static readonly ProfilerMarker s_StylePropertyAnimationProfilerMarker; // 0x18
		private HashSet<VisualElement> m_DirtyElements; // 0x48
		private double lastUpdate; // 0x50
	
		// Properties
		public override ProfilerMarker profilerMarker { get; } // 0x00000001824033C0-0x0000000182403410 
		private static ProfilerMarker stylePropertyAnimationProfilerMarker { get; } // 0x0000000182403410-0x0000000182403460 
		internal bool hasActiveAnimationBinders { get; } // 0x00000001824033A0-0x00000001824033C0 
	
		// Constructors
		public VisualElementAnimationSystem(); // 0x00000001824032E0-0x00000001824033A0
		static VisualElementAnimationSystem(); // 0x00000001824031B0-0x00000001824032E0
	
		// Methods
		public void UnregisterAnimation(IValueAnimationUpdate anim); // 0x0000000182402B60-0x0000000182402C30
		public void UnregisterAnimations(List<IValueAnimationUpdate> anims); // 0x0000000182402C30-0x0000000182402D70
		public void RegisterAnimation(IValueAnimationUpdate anim); // 0x0000000182402930-0x00000001824029D0
		public void RegisterAnimations(List<IValueAnimationUpdate> anims); // 0x00000001824029D0-0x0000000182402B10
		private void RegisterAnimationBinder(UIAnimationBinder binder); // 0x0000000182402830-0x0000000182402930
		private void UnregisterAnimationBinder(UIAnimationBinder binder); // 0x0000000182402B10-0x0000000182402B60
		private void RebuildIterationList(); // 0x00000001824027B0-0x0000000182402830
		public override void Update(); // 0x0000000182402D70-0x00000001824031B0
		internal void ReapplyAnimationBinderValues(); // 0x0000000182402750-0x00000001824027B0
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType); // 0x0000000182402690-0x0000000182402750
		private void ForwardDirtyElementsToStyleAnimation(IStylePropertyAnimationSystem styleAnim, double now); // 0x00000001824023D0-0x00000001824025E0
		internal void MarkElementClipDirty(VisualElement ve); // 0x00000001824025E0-0x0000000182402690
	}
}
