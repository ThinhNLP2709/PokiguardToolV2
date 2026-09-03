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
	internal sealed class VisualTreeAuthoringUpdater : BaseVisualTreeUpdater // TypeDefIndex: 3801
	{
		// Fields
		private static readonly ProfilerMarker s_UpdateProfilerMarker; // 0x00
		private static readonly ProfilerMarker s_UpdateChangeProfilerMarker; // 0x08
		private readonly List<IVisualElementChangeProcessor> m_RegisteredProcessors; // 0x28
		private readonly List<IVisualElementChangeProcessor> m_ProcessorRegistrationList; // 0x30
		private readonly List<IVisualElementChangeProcessor> m_ProcessorUnregistrationList; // 0x38
		private BaseVisualElementPanel m_AttachedPanel; // 0x40
		private readonly AuthoringChanges m_Changes1; // 0x48
		private readonly AuthoringChanges m_Changes2; // 0x50
		private AuthoringChanges m_Accumulator; // 0x58
		private AuthoringChanges m_Notifier; // 0x60
		private bool m_AccumulatingChanges; // 0x68
	
		// Properties
		public override ProfilerMarker profilerMarker { get; } // 0x0000000182394BF0-0x0000000182394C40 
		private bool shouldUpdate { get; } // 0x0000000182394C40-0x0000000182394C70 
	
		// Constructors
		public VisualTreeAuthoringUpdater(); // 0x0000000182394A50-0x0000000182394BF0
		static VisualTreeAuthoringUpdater(); // 0x00000001823949A0-0x0000000182394A50
	
		// Methods
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType); // 0x0000000182394240-0x0000000182394400
		public override void Update(); // 0x0000000182394470-0x00000001823949A0
		private void OnPanelChanged(BaseVisualElementPanel p); // 0x0000000182394150-0x0000000182394240
		protected override void Dispose(bool disposing); // 0x0000000182393A60-0x0000000182393DE0
		private void OnHierarchyChange(VisualElement ve, HierarchyChangeType type, IReadOnlyList<VisualElement> additionalContext = null); // 0x0000000182393DE0-0x0000000182394150
		private void SwapBuffers(); // 0x0000000182394400-0x0000000182394470
	}
}
