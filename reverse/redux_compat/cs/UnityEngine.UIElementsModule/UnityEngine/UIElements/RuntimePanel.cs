/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class RuntimePanel : BaseRuntimePanel, IRuntimePanel // TypeDefIndex: 4199
	{
		// Fields
		internal static readonly EventDispatcher s_EventDispatcher; // 0x00
		private readonly PanelSettings m_PanelSettings; // 0x230
		private static readonly List<IPanelComponent> s_EmptyPanelComponentList; // 0x08
		private static Dictionary<Action, EventCallbackWrapper> registeredCallback; // 0x10
	
		// Properties
		public PanelSettings panelSettings { get; } // 0x000000018033D490-0x000000018033D4A0 
		bool IRuntimePanel.isFlat { get; } // 0x00000001824BD880-0x00000001824BD890 
		internal List<IPanelComponent> panelComponents { get; } // 0x00000001824BDEA0-0x00000001824BDF20 
		bool IRuntimePanel.disposed { get; } // 0x000000018183E570-0x000000018183E580 
		int IRuntimePanel.targetDisplay { get; } // 0x000000018183FF90-0x000000018183FFA0 
		float IRuntimePanel.sortingPriority { get; } // 0x00000001823A9B70-0x00000001823A9B80 
		int IRuntimePanel.resolvedSortingIndex { get; } // 0x00000001824BD890-0x00000001824BD8A0 
		IEventHandler IRuntimePanel.visualTree_as_IEventHandler { get; } // 0x0000000181A5CE10-0x0000000181A5CE30 
		string IRuntimePanel.name { get; } // 0x0000000181C2D460-0x0000000181C2D470 
	
		// Nested types
		[Nullable(0)]
		[NullableContext(1)]
		private class EventCallbackWrapper : IEquatable<EventCallbackWrapper> // TypeDefIndex: 4200
		{
			// Fields
			[Nullable(0)]
			public readonly EventCallback<FocusEvent> WrappedCallback; // 0x10
	
			// Properties
			[CompilerGenerated]
			protected virtual Type EqualityContract { [CompilerGenerated] get; } // 0x00000001824AE960-0x00000001824AE9A0 
	
			// Nested types
			[CompilerGenerated]
			private sealed class __c__DisplayClass2_0 // TypeDefIndex: 4201
			{
				// Fields
				[Nullable(0)]
				public Action a; // 0x10
	
				// Constructors
				public __c__DisplayClass2_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				[NullableContext(0)]
				internal void _.ctor_b__0(FocusEvent e); // 0x00000001804EAA20-0x00000001804EAA50
			}
	
			// Constructors
			[NullableContext(0)]
			internal EventCallbackWrapper(Action a); // 0x00000001824AE890-0x00000001824AE960
	
			// Methods
			[CompilerGenerated]
			public override string ToString(); // 0x00000001824AE7B0-0x00000001824AE890
			[CompilerGenerated]
			protected virtual bool PrintMembers(StringBuilder builder); // 0x00000001824AE740-0x00000001824AE7B0
			[CompilerGenerated]
			public override int GetHashCode(); // 0x00000001824AE670-0x00000001824AE740
			[CompilerGenerated]
			[NullableContext(2)]
			public override bool Equals(object obj); // 0x00000001824AE5E0-0x00000001824AE670
			[CompilerGenerated]
			[NullableContext(2)]
			public virtual bool Equals(EventCallbackWrapper other); // 0x00000001824AE4D0-0x00000001824AE5E0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4202
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<AbstractGenericMenu> __9__25_0; // 0x08
			public static EventCallback<FocusEvent, RuntimePanel> __9__25_1; // 0x10
	
			// Constructors
			static __c(); // 0x00000001824BE650-0x00000001824BE6C0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AbstractGenericMenu _.ctor_b__25_0(); // 0x00000001824BE4A0-0x00000001824BE4F0
			internal void _.ctor_b__25_1(FocusEvent e, RuntimePanel p); // 0x00000001824BE4F0-0x00000001824BE570
		}
	
		// Constructors
		protected RuntimePanel(ScriptableObject ownerObject); // 0x00000001824BDA20-0x00000001824BDEA0
		static RuntimePanel(); // 0x00000001824BD930-0x00000001824BDA20
	
		// Methods
		IEventHandler IRuntimePanel.Pick(Vector2 point, int pointerId); // 0x00000001824BC6A0-0x00000001824BC6C0
		public static RuntimePanel Create(ScriptableObject ownerObject); // 0x00000001824BC4F0-0x00000001824BC550
		protected internal override PanelSettings GetLinkedPanelSettings(); // 0x00000001824BC550-0x00000001824BC5D0
		internal override void Update(); // 0x00000001824BD8A0-0x00000001824BD930
		private void OnElementFocus(FocusEvent evt); // 0x00000001824BC5D0-0x00000001824BC640
		void IRuntimePanel.Blur(); // 0x00000001824BC640-0x00000001824BC650
		void IRuntimePanel.SetTopElementUnderPointer(int pointerId, IEventHandler element, Vector2 position); // 0x00000001824BD6B0-0x00000001824BD760
		void IRuntimePanel.PointerEntersPanel(int pointerId, Vector3 position); // 0x00000001824BC6C0-0x00000001824BC6F0
		void IRuntimePanel.PointerLeavesPanel(int pointerId); // 0x00000001824BC6F0-0x00000001824BC700
		void IRuntimePanel.CommitElementUnderPointers(); // 0x00000001824BC650-0x00000001824BC660
		void IRuntimePanel.Focus(); // 0x00000001824BC660-0x00000001824BC670
		bool IRuntimePanel.ScreenToPanel(Vector2 screenPosition, Vector2 screenDelta, out Vector3 panelPosition, bool allowOutside); // 0x00000001824BC920-0x00000001824BC940
		void IRuntimePanel.RegisterRootFocusCallback(Action callback); // 0x00000001824BC700-0x00000001824BC920
		void IRuntimePanel.UnregisterRootFocusCallback(Action callback); // 0x00000001824BD760-0x00000001824BD880
		IEventHandler IRuntimePanel.GetLeafFocusedElement(); // 0x00000001824BC670-0x00000001824BC6A0
		private void UpdatePointerEventTarget<TPointerEvent>(TPointerEvent e, IPointerEvent eventData, IEventHandler target, IEventHandler underPointer)
			where TPointerEvent : PointerEventBase<TPointerEvent>, new();
		bool IRuntimePanel.SendPointerMoveEvent(IPointerEvent eventData, IEventHandler target, IEventHandler elementUnderPointer); // 0x00000001824BD220-0x00000001824BD370
		bool IRuntimePanel.SendPointerDownEvent(IPointerEvent eventData, IEventHandler target, IEventHandler elementUnderPointer, Camera camera); // 0x00000001824BCFF0-0x00000001824BD220
		bool IRuntimePanel.SendPointerUpEvent(IPointerEvent eventData, IEventHandler target, IEventHandler elementUnderPointer); // 0x00000001824BD370-0x00000001824BD540
		bool IRuntimePanel.SendPointerCancelEvent(IPointerEvent eventData, IEventHandler target, IEventHandler elementUnderPointer); // 0x00000001824BCE20-0x00000001824BCFF0
		bool IRuntimePanel.SendWheelEvent(Vector2 uitkScrollDelta, IPointerEvent eventData); // 0x00000001824BD540-0x00000001824BD6B0
		bool IRuntimePanel.SendNavigationEvent(NavigationEventType eventType, IEventHandler target, NavigationDeviceType deviceType, EventModifiers modifiers, Vector2 moveVector, NavigationMoveDirection moveDirection); // 0x00000001824BCC00-0x00000001824BCE20
		bool IRuntimePanel.SendKeyboardEvent(bool isKeyDown, char character, KeyCode keyCode, EventModifiers modifiers, IEventHandler target); // 0x00000001824BCAA0-0x00000001824BCC00
		bool IRuntimePanel.SendIMEEvent(string compositionString, IEventHandler target); // 0x00000001824BC940-0x00000001824BCAA0
	}
}
