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
	[UxmlElement]
	public class IMGUIContainer : VisualElement, IDisposable // TypeDefIndex: 4215
	{
		// Fields
		internal static readonly BindingId cullingEnabledProperty; // 0x00
		internal static readonly BindingId contextTypeProperty; // 0x98
		private Action m_OnGUIHandler; // 0x1A8
		private ObjectGUIState m_ObjectGUIState; // 0x1B0
		internal bool useOwnerObjectGUIState; // 0x1B8
		[CompilerGenerated]
		private Rect _lastWorldClip_k__BackingField; // 0x1BC
		private bool m_CullingEnabled; // 0x1CC
		private bool m_IsFocusDelegated; // 0x1CD
		private bool m_RefreshCachedLayout; // 0x1CE
		private int m_OnGUIExecutionCount; // 0x1D0
		private GUILayoutUtility.LayoutCache m_Cache; // 0x1D8
		private Rect m_CachedClippingRect; // 0x1E0
		private Matrix4x4 m_CachedTransform; // 0x1F0
		private ContextType m_ContextType; // 0x230
		private bool lostFocus; // 0x234
		private bool receivedFocus; // 0x235
		private FocusChangeDirection focusChangeDirection; // 0x238
		private bool hasFocusableControls; // 0x240
		private int newKeyboardFocusControlID; // 0x244
		[CompilerGenerated]
		private bool _focusOnlyIfHasFocusableControls_k__BackingField; // 0x248
		public static readonly string ussClassName; // 0x130
		internal static readonly UniqueStyleString ussClassNameUnique; // 0x138
		internal static readonly string ussFoldoutChildDepthClassName; // 0x140
		internal static readonly int ussFoldoutMaxDepth; // 0x148
		internal static readonly List<UniqueStyleString> ussFoldoutChildDepthClassNames; // 0x150
		private GUIGlobals m_GUIGlobals; // 0x24C
		private static readonly ProfilerMarker k_OnGUIMarker; // 0x158
		private static readonly ProfilerMarker k_ImmediateCallbackMarker; // 0x160
		private static Stack<Event> s_EventCurrentBackupPool; // 0x168
		private static int s_HandleIMGUIEventDepth; // 0x170
		private static Event s_DefaultMeasureEvent; // 0x178
		private static Event s_MeasureEvent; // 0x180
		private static Event s_CurrentEvent; // 0x188
		private static Stack<IMGUIContainer> s_ContainerStack; // 0x190
	
		// Properties
		public Action onGUIHandler { get; } // 0x0000000180E224F0-0x0000000180E22500 
		internal ObjectGUIState guiState { get; } // 0x00000001824B2C30-0x00000001824B2CF0 
		internal Rect lastWorldClip { [CompilerGenerated] get; } // 0x00000001824B2CF0-0x00000001824B2D00 
		[CreateProperty]
		public bool cullingEnabled { get; set; } // 0x00000001824B2C20-0x00000001824B2C30 0x00000001824B2DE0-0x00000001824B2E70
		private GUILayoutUtility.LayoutCache cache { get; } // 0x00000001824B2BA0-0x00000001824B2C20 
		private float layoutMeasuredWidth { get; } // 0x00000001824B2D30-0x00000001824B2D60 
		private float layoutMeasuredHeight { get; } // 0x00000001824B2D00-0x00000001824B2D30 
		[CreateProperty]
		public ContextType contextType { get; set; } // 0x00000001823C0910-0x00000001823C0920 0x00000001824B2D60-0x00000001824B2DE0
		internal bool focusOnlyIfHasFocusableControls { [CompilerGenerated] get; } // 0x0000000180517740-0x0000000180517750 
	
		// Nested types
		private struct GUIGlobals // TypeDefIndex: 4216
		{
			// Fields
			public Matrix4x4 matrix; // 0x00
			public Color color; // 0x40
			public Color contentColor; // 0x50
			public Color backgroundColor; // 0x60
			public bool enabled; // 0x70
			public bool changed; // 0x71
			public int displayIndex; // 0x74
			public float pixelsPerPoint; // 0x78
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4217
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824BE7A0-0x00000001824BE810
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _.cctor_b__50_0(Exception exception); // 0x00000001824BE000-0x00000001824BE130
			internal void _.cctor_b__50_1(); // 0x00000001824BE130-0x00000001824BE210
		}
	
		// Constructors
		static IMGUIContainer(); // 0x00000001824B2190-0x00000001824B2BA0
	
		// Methods
		private void SaveGlobals(); // 0x00000001824B1AE0-0x00000001824B1C60
		private void RestoreGlobals(); // 0x00000001824B1920-0x00000001824B1AE0
		private void DoOnGUI(Event evt, Matrix4x4 parentTransform, Rect clippingRect, bool isComputingLayout, Rect layoutSize, Action onGUIHandler, bool canAffectFocus = true /* Metadata: 0x0066063E */); // 0x00000001824AED40-0x00000001824AFEC0
		public void MarkDirtyLayout(); // 0x00000001824B1900-0x00000001824B1920
		internal bool SendEventToIMGUI(EventBase evt, bool canAffectFocus = true /* Metadata: 0x0066063F */, bool verifyBounds = true /* Metadata: 0x00660640 */); // 0x00000001824B1D50-0x00000001824B1FE0
		private bool SendEventToIMGUIRaw(EventBase evt, bool canAffectFocus, bool verifyBounds); // 0x00000001824B1C60-0x00000001824B1D50
		private bool VerifyBounds(EventBase evt); // 0x00000001824B1FF0-0x00000001824B2190
		private bool IsContainerCapturingTheMouse(); // 0x00000001824B1210-0x00000001824B1350
		private bool IsLocalEvent(EventBase evt); // 0x00000001824B1570-0x00000001824B1860
		private bool IsEventInsideLocalWindow(EventBase evt); // 0x00000001824B1350-0x00000001824B1570
		private static bool IsDockAreaMouseUp(EventBase evt); // 0x00000001802E7840-0x00000001802E7850
		internal bool HandleIMGUIEvent(Event e, bool canAffectFocus); // 0x00000001824B0BF0-0x00000001824B0D80
		internal bool HandleIMGUIEvent(Event e, Action onGUIHandler, bool canAffectFocus); // 0x00000001824B0A50-0x00000001824B0BF0
		private bool HandleIMGUIEvent(Event e, Matrix4x4 worldTransform, Rect clippingRect, Action onGUIHandler, bool canAffectFocus); // 0x00000001824B0D80-0x00000001824B1210
		private bool HandleIMGUIEventInternal(Event e, Matrix4x4 worldTransform, Rect clippingRect, Action onGUIHandler, bool canAffectFocus); // 0x00000001824B03D0-0x00000001824B0A50
		private Rect GetCurrentClipRect(); // 0x00000001824B0250-0x00000001824B02E0
		private static void GetCurrentTransformAndClip(IMGUIContainer container, out Matrix4x4 transform, out Rect clipRect); // 0x00000001824B02E0-0x00000001824B03D0
		public void Dispose(); // 0x00000001824AECB0-0x00000001824AED20
		protected virtual void Dispose(bool disposeManaged); // 0x00000001824AED20-0x00000001824AED40
		private static bool EndContainerGUIFromException(Exception exception); // 0x00000001824AFEC0-0x00000001824AFFB0
		internal static void MakeCurrentIMGUIContainerDirty(); // 0x00000001824B1860-0x00000001824B1900
		internal static void BeginContainerGUI(GUILayoutUtility.LayoutCache cache, Event evt, IMGUIContainer container); // 0x00000001824AE9A0-0x00000001824AECB0
		internal static void EndContainerGUI(Event evt, Rect layoutSize); // 0x00000001824AFFB0-0x00000001824B0250
		[CompilerGenerated]
		private void _DoOnGUI_b__59_0(); // 0x00000001824B1FE0-0x00000001824B1FF0
	}
}
