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
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class ClickDetector // TypeDefIndex: 3869
	{
		// Fields
		private List<ButtonClickStatus> m_ClickStatus; // 0x10
		[CompilerGenerated]
		private static int _s_DoubleClickTime_k__BackingField; // 0x00
	
		// Properties
		internal static int s_DoubleClickTime { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182383630-0x0000000182383680 0x0000000182383680-0x00000001823836E0
	
		// Nested types
		private class ButtonClickStatus // TypeDefIndex: 3870
		{
			// Fields
			public VisualElement m_Target; // 0x10
			public Vector3 m_PointerDownPosition; // 0x18
			public long m_LastPointerDownTime; // 0x28
			public int m_ClickCount; // 0x30
	
			// Constructors
			public ButtonClickStatus(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Reset(); // 0x00000001823818C0-0x0000000182381910
		}
	
		// Constructors
		public ClickDetector(); // 0x00000001823833D0-0x0000000182383630
		static ClickDetector(); // 0x0000000182383390-0x00000001823833D0
	
		// Methods
		private void StartClickTracking(EventBase evt); // 0x00000001823831C0-0x0000000182383390
		private void SendClickEvent(EventBase evt); // 0x0000000182382FA0-0x00000001823831C0
		private void CancelClickTracking(EventBase evt); // 0x0000000182382BC0-0x0000000182382C80
		public void ProcessEvent<TEvent>(PointerEventBase<TEvent> evt)
			where TEvent : PointerEventBase<TEvent>, new();
		private static bool ContainsPointer(VisualElement element, IPointerEvent pe); // 0x0000000182382DB0-0x0000000182382FA0
		internal void Cleanup(List<VisualElement> elements); // 0x0000000182382C80-0x0000000182382DB0
	}
}
