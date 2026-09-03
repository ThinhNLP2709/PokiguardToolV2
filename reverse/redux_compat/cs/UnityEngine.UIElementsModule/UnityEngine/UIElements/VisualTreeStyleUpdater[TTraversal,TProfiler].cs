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
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
	internal class VisualTreeStyleUpdater<TTraversal, TProfiler> : BaseVisualTreeUpdater // TypeDefIndex: 4975
		where TTraversal : VisualTreeStyleUpdaterTraversal<TProfiler>, new()
		where TProfiler : struct, IStyleProfiler
	{
		// Fields
		private HashSet<VisualElement> m_TransitionPropertyUpdateList;
		private uint m_Version;
		private uint m_LastVersion;
		private TTraversal m_StyleContextHierarchyTraversal;
		private static readonly string s_Description;
		private static readonly ProfilerMarker s_ProfilerMarker;
		[CompilerGenerated]
		private bool _disposed_k__BackingField;
	
		// Properties
		public override ProfilerMarker profilerMarker { get; }
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; }
	
		// Constructors
		public VisualTreeStyleUpdater();
		static VisualTreeStyleUpdater();
	
		// Methods
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType);
		public override void Update();
		protected override void Dispose(bool disposing);
		protected void ApplyStyles();
	}
}
