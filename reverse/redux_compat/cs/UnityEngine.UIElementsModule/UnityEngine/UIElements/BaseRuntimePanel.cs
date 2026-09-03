/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIToolkitAuthoringModule", "UnityEditor.VectorGraphicsModule" })]
	internal abstract class BaseRuntimePanel : Panel // TypeDefIndex: 4286
	{
		// Fields
		private GameObject m_SelectableGameObject; // 0x1E8
		private static int s_CurrentRuntimePanelCounter; // 0x00
		internal readonly int m_RuntimePanelCreationIndex; // 0x1F0
		private float m_SortingPriority; // 0x1F4
		internal int resolvedSortingIndex; // 0x1F8
		[CompilerGenerated]
		private Action destroyed; // 0x200
		[CompilerGenerated]
		private Action drawsInCamerasChanged; // 0x208
		private float m_PixelsPerUnit; // 0x210
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal RenderTexture targetTexture; // 0x218
		[CompilerGenerated]
		private int _targetDisplay_k__BackingField; // 0x220
		internal static readonly Func<Vector2, Vector3> DefaultScreenToPanelSpace; // 0x08
		private Func<Vector2, Vector3> m_ScreenToPanelSpace; // 0x228
	
		// Properties
		public GameObject selectableGameObject { get; set; } // 0x000000018033D460-0x000000018033D470 0x00000001824D21E0-0x00000001824D2280
		public float sortingPriority { get; set; } // 0x00000001823A9B70-0x00000001823A9B80 0x00000001824D2280-0x00000001824D2340
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal float pixelsPerUnit { get; set; } // 0x0000000180BB3F70-0x0000000180BB3F80 0x00000001824D2140-0x00000001824D2150
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal int targetDisplay { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018183FF90-0x000000018183FFA0 0x00000001824D2340-0x00000001824D2350
		internal int screenRenderingWidth { get; } // 0x00000001824D1F10-0x00000001824D1FE0 
		internal int screenRenderingHeight { get; } // 0x00000001824D1E40-0x00000001824D1F10 
		public Func<Vector2, Vector3> screenToPanelSpace { get; set; } // 0x0000000181CC2900-0x0000000181CC2910 0x00000001824D2150-0x00000001824D21E0
	
		// Events
		public event Action destroyed {
			add; // 0x00000001824D1BC0-0x00000001824D1C70
			remove; // 0x00000001824D1FE0-0x00000001824D2090
		}
		internal event Action drawsInCamerasChanged {
			add; // 0x00000001824D1C70-0x00000001824D1D20
			remove; // 0x00000001824D2090-0x00000001824D2140
		}
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4287
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824DF170-0x00000001824DF1E0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector3 _.cctor_b__47_0(Vector2 p); // 0x00000001824DED00-0x00000001824DED30
		}
	
		// Constructors
		protected BaseRuntimePanel(ScriptableObject ownerObject, EventDispatcher dispatcher = null); // 0x00000001824D1AD0-0x00000001824D1BC0
		static BaseRuntimePanel(); // 0x00000001824D19E0-0x00000001824D1AD0
	
		// Methods
		protected override void Dispose(bool disposing); // 0x00000001824D11B0-0x00000001824D12E0
		protected internal virtual PanelSettings GetLinkedPanelSettings(); // 0x00000001802E7860-0x00000001802E7870
		private void InvokeDrawsInCamerasChanged(); // 0x00000001824D12E0-0x00000001824D1300
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void SetDrawsInCameras(bool value); // 0x00000001824D1920-0x00000001824D19A0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal virtual void Update(); // 0x00000001824D19A0-0x00000001824D19E0
		internal static int getScreenRenderingHeight(int display); // 0x00000001824D1D20-0x00000001824D1DB0
		internal static int getScreenRenderingWidth(int display); // 0x00000001824D1DB0-0x00000001824D1E40
		public override void Render(); // 0x00000001824D1300-0x00000001824D1700
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal Vector3 ScreenToPanel(Vector2 screen); // 0x00000001824D18B0-0x00000001824D1920
		internal bool ScreenToPanel(Vector2 screenPosition, Vector2 screenDelta, out Vector3 panelPosition, bool allowOutside = false /* Metadata: 0x006606E0 */); // 0x00000001824D1700-0x00000001824D18B0
		private void AssignPanelToComponents(BaseRuntimePanel panel); // 0x00000001824D0F00-0x00000001824D11B0
	}
}
