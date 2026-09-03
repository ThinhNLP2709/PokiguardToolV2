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
using UnityEngine.UIElements.Layout;
using UnityEngine.UIElements.Unmanaged;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[4] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule", "UnityEditor.VectorGraphicsModule", "UnityEditor.GraphToolkitModule" })]
	internal abstract class BaseVisualElementPanel : IPanel // TypeDefIndex: 4277
	{
		// Fields
		[CompilerGenerated]
		private Action<BaseVisualElementPanel> panelDisposed; // 0x10
		internal static readonly Dictionary<UnmanagedDataHandle, BaseVisualElementPanel> PanelsByHandle; // 0x00
		internal readonly Dictionary<UnmanagedDataHandle, VisualElement> MemberElementsByHandle; // 0x18
		private UIElementsBridge m_UIElementsBridge; // 0x20
		private float m_Scale; // 0x28
		private int m_BackdropFilterElementCount; // 0x2C
		internal LayoutConfig layoutConfig; // 0x30
		private float m_PixelsPerPoint; // 0x70
		[CompilerGenerated]
		private float _referenceSpritePixelsPerUnit_k__BackingField; // 0x74
		[CompilerGenerated]
		private PanelClearSettings _clearSettings_k__BackingField; // 0x78
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal IPanelRenderer panelRenderer; // 0x90
		[CompilerGenerated]
		private ICursorManager _cursorManager_k__BackingField; // 0x98
		[CompilerGenerated]
		private ContextualMenuManager _contextualMenuManager_k__BackingField; // 0xA0
		[CompilerGenerated]
		private DataBindingManager _dataBindingManager_k__BackingField; // 0xA8
		private TimerEventScheduler m_Scheduler; // 0xB0
		private TimeFunction m_TimeSinceStartupFunc; // 0xB8
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0xC0
		internal ElementUnderPointer m_TopElementUnderPointers; // 0xC8
		[CompilerGenerated]
		private Action isFlatChanged; // 0xD0
		protected bool m_DrawsInCameras; // 0xD8
		[CompilerGenerated]
		private Action atlasChanged; // 0xE0
		[CompilerGenerated]
		private HierarchyEvent hierarchyChanged; // 0xE8
		[CompilerGenerated]
		private Action<IPanel> beforeUpdate; // 0xF0
		internal static readonly Vector2 s_OutsidePanelCoordinates; // 0x08
		public readonly Lazy<HashSet<TextElement>> textElementRegistry; // 0xF8
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal Func<AbstractGenericMenu> CreateMenuFunctor; // 0x100
		[CompilerGenerated]
		private Action<bool> OnIsEnteringTextChanged; // 0x108
		internal Action<Vector2> OnCursorPositonChanged; // 0x110
	
		// Properties
		public abstract EventInterests IMGUIEventInterests { get; set; }
		public abstract ScriptableObject ownerObject { get; protected set; }
		public abstract SavePersistentViewData saveViewData { get; }
		public abstract GetViewDataDictionary getViewDataDictionary { get; }
		public abstract FocusController focusController { get; set; }
		internal ref PanelTransformFlags transformFlags { get; } // 0x00000001824D4230-0x00000001824D4240 
		internal UIElementsBridge uiElementsBridge { get; } // 0x00000001824D4240-0x00000001824D42A0 
		internal bool hasBackdropFilterElements { get; } // 0x00000001824D4030-0x00000001824D4040 
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal float scale { get; set; } // 0x0000000180F99790-0x0000000180F997A0 0x00000001824D45E0-0x00000001824D46C0
		public float scaledPixelsPerPoint { get; } // 0x00000001824D40B0-0x00000001824D40C0 
		public float referenceSpritePixelsPerUnit { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181F63F10-0x0000000181F63F20 0x0000000181F64900-0x0000000181F64910
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal PanelClearSettings clearSettings { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001824D3FF0-0x00000001824D4010 0x00000001824D44B0-0x00000001824D44D0
		public bool duringLayoutPhase { get; set; } // 0x00000001824D4010-0x00000001824D4030 0x00000001824D44D0-0x00000001824D4550
		public bool isDirty { get; } // 0x00000001824D4040-0x00000001824D4090 
		internal abstract uint version { [VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })] get; }
		internal abstract uint repaintVersion { get; }
		internal abstract uint hierarchyVersion { get; }
		internal virtual ICursorManager cursorManager { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x00000001806CCE20-0x00000001806CCE40
		public ContextualMenuManager contextualMenuManager { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal virtual DataBindingManager dataBindingManager { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D510-0x000000018033D520 0x000000018033EAB0-0x000000018033EAD0
		public abstract VisualElement visualTree { get; }
		public abstract EventDispatcher dispatcher { get; set; }
		internal TimerEventScheduler scheduler { [VisibleToOtherModules(new string[1] {"UnityEditor.GraphToolkitModule" })] get; } // 0x00000001824D40C0-0x00000001824D4230 
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal abstract IStylePropertyAnimationSystem styleAnimationSystem { [VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })] get; set; }
		public abstract ContextType contextType { get; }
		internal TimeFunction TimeSinceStartupFunc { get; } // 0x00000001806CCB90-0x00000001806CCBA0 
		internal bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018183E570-0x000000018183E580 0x0000000181F64A30-0x0000000181F64A40
		public bool isFlat { get; set; } // 0x00000001824D4090-0x00000001824D40B0 0x00000001824D4550-0x00000001824D45E0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal bool drawsInCameras { get; } // 0x0000000180665200-0x0000000180665210 
		public abstract AtlasBase atlas { get; set; }
	
		// Events
		internal event Action isFlatChanged {
			add; // 0x00000001824D3F40-0x00000001824D3FF0
			remove; // 0x00000001824D4400-0x00000001824D44B0
		}
		internal event Action atlasChanged {
			add; // 0x00000001824D3DE0-0x00000001824D3E90
			remove; // 0x00000001824D42A0-0x00000001824D4350
		}
		internal event HierarchyEvent hierarchyChanged {
			add; // 0x00000001824D3E90-0x00000001824D3F40
			remove; // 0x00000001824D4350-0x00000001824D4400
		}
	
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 4278
		{
			// Fields
			public static LayoutMeasureFunction _0___Measure; // 0x00
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4279
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<bool> __9__26_0; // 0x08
			public static Action<Vector2> __9__26_1; // 0x10
	
			// Constructors
			static __c(); // 0x00000001824DF100-0x00000001824DF170
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _.ctor_b__26_0(bool isEnteringText); // 0x00000001824DEE20-0x00000001824DEE70
			internal void _.ctor_b__26_1(Vector2 v2); // 0x00000001824DEE70-0x00000001824DEED0
		}
	
		// Constructors
		protected BaseVisualElementPanel(); // 0x00000001824D3970-0x00000001824D3DE0
		static BaseVisualElementPanel(); // 0x00000001824D3880-0x00000001824D3970
	
		// Methods
		public void Dispose(); // 0x00000001824D24A0-0x00000001824D2510
		protected virtual void Dispose(bool disposing); // 0x00000001824D2510-0x00000001824D26E0
		internal static BaseVisualElementPanel GetPanelFromHandle(UnmanagedDataHandle panelHandle); // 0x00000001824D28A0-0x00000001824D2920
		internal static bool TryGetPanelFromHandle(UnmanagedDataHandle panelHandle, out BaseVisualElementPanel panel); // 0x00000001824D34F0-0x00000001824D3580
		internal VisualElement GetMemberElementFromHandle(UnmanagedDataHandle elementHandle); // 0x00000001824D26E0-0x00000001824D2740
		internal static VisualElement GetPanelElementFromHandle(UnmanagedDataHandle elementHandle); // 0x00000001824D2740-0x00000001824D28A0
		public abstract void Repaint();
		public abstract void ValidateLayout();
		public abstract void TickSchedulingUpdaters();
		protected abstract void UpdateForRepaint();
		public abstract void UpdateAnimations();
		public abstract void UpdateBindings();
		public abstract void UpdateDataBinding();
		public abstract void ApplyStyles();
		internal void IncrementBackdropFilterCount(); // 0x00000001824D2950-0x00000001824D2960
		internal void DecrementBackdropFilterCount(); // 0x00000001824D2410-0x00000001824D2490
		private void OnScaledPixelsPerPointChanged(); // 0x00000001824D2A00-0x00000001824D2A90
		internal abstract void OnVersionChanged(VisualElement ele, VersionChangeType changeTypeFlag);
		internal abstract void SetUpdater(IVisualTreeUpdater updater, VisualTreeUpdatePhase phase);
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void SendEvent(EventBase e, DispatchMode dispatchMode = DispatchMode.Default /* Metadata: 0x006606DD */); // 0x00000001824D2F90-0x00000001824D3090
		public long TimeSinceStartupMs(); // 0x00000001824D3220-0x00000001824D33A0
		public double TimeSinceStartupSeconds(); // 0x00000001824D33A0-0x00000001824D34F0
		internal static double DefaultTimeSinceStartup(); // 0x00000001824D2490-0x00000001824D24A0
		public abstract VisualElement Pick(Vector2 point, int pointerId);
		public abstract VisualElement PickAll(Vector2 point, List<VisualElement> picked);
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal abstract IVisualTreeUpdater GetUpdater(VisualTreeUpdatePhase phase);
		internal VisualElement GetTopElementUnderPointer(int pointerId); // 0x00000001824D2920-0x00000001824D2950
		internal void RemoveElementFromPointerCache(VisualElement e); // 0x00000001824D2F10-0x00000001824D2F40
		internal void SetTopElementUnderPointer(int pointerId, VisualElement element, EventBase triggerEvent); // 0x00000001824D31E0-0x00000001824D3220
		internal void SetTopElementUnderPointer(int pointerId, VisualElement element, Vector2 position); // 0x00000001824D31A0-0x00000001824D31E0
		internal VisualElement RecomputeTopElementUnderPointer(int pointerId, Vector2 pointerPos, EventBase triggerEvent); // 0x00000001824D2C70-0x00000001824D2F10
		internal void ClearCachedElementUnderPointer(int pointerId, EventBase triggerEvent); // 0x00000001824D2350-0x00000001824D2390
		internal bool CommitElementUnderPointers(); // 0x00000001824D2390-0x00000001824D2410
		internal void SetSpecializedHierarchyFlagsUpdater(); // 0x00000001824D3090-0x00000001824D31A0
		protected void InvokeAtlasChanged(); // 0x00000001824D2960-0x00000001824D2980
		internal void InvokeHierarchyChanged(VisualElement ve, HierarchyChangeType changeType, IReadOnlyList<VisualElement> additionalContext = null); // 0x00000001824D29A0-0x00000001824D29D0
		internal void InvokeBeforeUpdate(); // 0x00000001824D2980-0x00000001824D29A0
		internal bool UpdateElementUnderPointers(); // 0x00000001824D3580-0x00000001824D3880
		public virtual void Render(); // 0x00000001824D2F40-0x00000001824D2F90
		internal void OnIsEnteringTextChanged_internal(bool isEnteringtext); // 0x00000001824D29D0-0x00000001824D2A00
		internal void PointerLeavesPanel(int pointerId, EventBase triggerEvent = null); // 0x00000001824D2B40-0x00000001824D2C70
		internal void PointerEntersPanel(int pointerId, Vector3 position); // 0x00000001824D2A90-0x00000001824D2B40
	}
}
