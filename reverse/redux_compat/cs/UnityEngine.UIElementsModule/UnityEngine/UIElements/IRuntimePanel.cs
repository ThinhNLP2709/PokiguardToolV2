/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public interface IRuntimePanel : IPanel // TypeDefIndex: 4194
	{
		// Fields
		[CompilerGenerated]
		private static CodeStrippingSafeUIElementsRuntimeUtility _uIElementsRuntimeUtility_k__BackingField; // 0x00
	
		// Properties
		PanelSettings panelSettings { get; }
		GameObject selectableGameObject { get; set; }
		bool isFlat { get; }
		bool disposed { get; }
		int targetDisplay { get; }
		float sortingPriority { get; }
		int resolvedSortingIndex { get; }
		CodeStrippingSafeUIElementsRuntimeUtility uIElementsRuntimeUtility { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001824B2F00-0x00000001824B2F40 0x00000001824B2F40-0x00000001824B2FA0
		IPointerDeviceState pointerDeviceState { get; } // 0x00000001824B2E70-0x00000001824B2F00 
		IEventHandler visualTree_as_IEventHandler { get; }
		string name { get; }
	
		// Events
		event Action destroyed {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
	
		// Methods
		void Focus();
		void Blur();
		void SetTopElementUnderPointer(int pointerId, IEventHandler element, Vector2 position);
		void PointerEntersPanel(int pointerId, Vector3 position);
		void PointerLeavesPanel(int pointerId);
		void CommitElementUnderPointers();
		bool ScreenToPanel(Vector2 screenPosition, Vector2 screenDelta, out Vector3 panelPosition, bool allowOutside = false /* Metadata: 0x00660584 */);
		IEventHandler Pick(Vector2 point, int pointerId);
		void RegisterRootFocusCallback(Action callback);
		void UnregisterRootFocusCallback(Action callback);
		IEventHandler GetLeafFocusedElement();
		bool SendPointerMoveEvent(IPointerEvent eventData, IEventHandler target, IEventHandler elementUnderPointer);
		bool SendPointerDownEvent(IPointerEvent eventData, IEventHandler target, IEventHandler elementUnderPointer, Camera camera);
		bool SendPointerUpEvent(IPointerEvent eventData, IEventHandler target, IEventHandler elementUnderPointer);
		bool SendPointerCancelEvent(IPointerEvent eventData, IEventHandler target, IEventHandler elementUnderPointer);
		bool SendWheelEvent(Vector2 scrollDelta, IPointerEvent eventData);
		bool SendNavigationEvent(NavigationEventType eventType, IEventHandler target, NavigationDeviceType deviceType, EventModifiers modifiers, Vector2 moveVector = default, NavigationMoveDirection moveDirection = NavigationMoveDirection.None /* Metadata: 0x00660585 */);
		bool SendKeyboardEvent(bool isKeyDown, char character, KeyCode keyCode, EventModifiers modifiers, IEventHandler target);
		bool SendIMEEvent(string compositionString, IEventHandler target);
	}
}
