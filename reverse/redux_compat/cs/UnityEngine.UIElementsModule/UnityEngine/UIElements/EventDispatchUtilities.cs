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
	internal static class EventDispatchUtilities // TypeDefIndex: 4027
	{
		// Methods
		private static void PropagateEvent(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel, [JetBrains.Annotations.NotNull] VisualElement target, bool isCapturingTarget); // 0x0000000182475630-0x0000000182475750
		public static void SendEventDirectlyToTarget(EventBase evt, BaseVisualElementPanel panel, [JetBrains.Annotations.NotNull] VisualElement target); // 0x0000000182475BE0-0x0000000182475C50
		public static void HandleEventAtTargetAndDefaultPhase(EventBase evt, BaseVisualElementPanel panel, VisualElement target); // 0x0000000182474E90-0x0000000182475310
		private static void HandleEventAcrossPropagationPath(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel, [JetBrains.Annotations.NotNull] VisualElement target, bool isCapturingTarget); // 0x0000000182474760-0x0000000182474E90
		private static void HandleEventAcrossPropagationPathWithCompatibilityEvent(EventBase evt, [JetBrains.Annotations.NotNull] EventBase compatibilityEvt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel, [JetBrains.Annotations.NotNull] VisualElement target, bool isCapturingTarget); // 0x0000000182473A70-0x0000000182474760
		private static void HandleEvent_DefaultActionAtTarget(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel, [JetBrains.Annotations.NotNull] VisualElement element, bool disabled); // 0x00000001824753B0-0x00000001824754A0
		private static void HandleEvent_DefaultAction(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel, [JetBrains.Annotations.NotNull] VisualElement element, bool disabled); // 0x00000001824754A0-0x0000000182475590
		private static void HandleEvent_TrickleDownCallbacks(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel, [JetBrains.Annotations.NotNull] VisualElement element); // 0x0000000182475590-0x00000001824755D0
		private static void HandleEvent_BubbleUpCallbacks(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel, [JetBrains.Annotations.NotNull] VisualElement element); // 0x0000000182475310-0x0000000182475350
		private static void HandleEvent_TrickleDownHandleEvent(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel, [JetBrains.Annotations.NotNull] VisualElement element, bool disabled); // 0x00000001824755D0-0x0000000182475630
		private static void HandleEvent_BubbleUpHandleEvent(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel, [JetBrains.Annotations.NotNull] VisualElement element, bool disabled); // 0x0000000182475350-0x00000001824753B0
		private static void HandleEvent_BubbleUpAllDefaultActions(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel, [JetBrains.Annotations.NotNull] VisualElement element, bool disabled, bool isCapturingTarget); // 0x000000018246EE60-0x000000018246F7D0
		private static bool Disabled([JetBrains.Annotations.NotNull] EventBase evt, [JetBrains.Annotations.NotNull] VisualElement target); // 0x0000000182473080-0x00000001824730C0
		public static void DispatchToFocusedElementOrPanelRoot(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel); // 0x0000000182473740-0x00000001824739F0
		public static void DispatchToElementUnderPointerOrPanelRoot(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel, int pointerId, Vector2 position); // 0x0000000182473610-0x0000000182473740
		public static void DispatchToAssignedTarget(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel); // 0x00000001824730C0-0x0000000182473170
		public static void DefaultDispatch(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel); // 0x0000000182473000-0x0000000182473080
		public static void DispatchToCapturingElementOrElementUnderPointer(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel, int pointerId, Vector2 position); // 0x0000000182473170-0x0000000182473440
		private static bool DispatchToCapturingElement(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel, int pointerId); // 0x0000000182473440-0x0000000182473610
		internal static void DispatchToPanelRoot(EventBase evt, [JetBrains.Annotations.NotNull] BaseVisualElementPanel panel); // 0x00000001824739F0-0x0000000182473A70
		internal static void PropagateToRemainingIMGUIContainers(EventBase evt, [JetBrains.Annotations.NotNull] VisualElement root); // 0x0000000182475B70-0x0000000182475BE0
		private static void PropagateToRemainingIMGUIContainerRecursive(EventBase evt, [JetBrains.Annotations.NotNull] VisualElement root); // 0x0000000182475750-0x0000000182475B70
	}
}
