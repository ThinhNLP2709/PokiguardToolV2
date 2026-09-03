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
	internal class TouchScreenTextEditorEventHandler : TextEditorEventHandler // TypeDefIndex: 3905
	{
		// Fields
		private IVisualElementScheduledItem m_TouchKeyboardPoller; // 0x20
		private bool m_IsClicking; // 0x28
		[CompilerGenerated]
		private static long _Frame_k__BackingField; // 0x00
		[CompilerGenerated]
		private static TouchScreenKeyboard _activeTouchScreenKeyboard_k__BackingField; // 0x08
	
		// Properties
		internal static long Frame { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001823B0D20-0x00000001823B0D60 0x00000001823B0D60-0x00000001823B0DA0
		private static TouchScreenKeyboard activeTouchScreenKeyboard { [CompilerGenerated] set; } // 0x00000001823B0DA0-0x00000001823B0E00
	
		// Constructors
		public TouchScreenTextEditorEventHandler(TextElement textElement, TextEditingUtilities editingUtilities); // 0x0000000180CB0730-0x0000000180CB0780
	
		// Methods
		private void PollTouchScreenKeyboard(); // 0x00000001823B0AB0-0x00000001823B0BD0
		private void DoPollTouchScreenKeyboard(); // 0x00000001823AF830-0x00000001823AFE50
		private void UpdateStringPositionFromKeyboard(); // 0x00000001823B0BD0-0x00000001823B0D20
		private void CloseTouchScreenKeyboard(); // 0x00000001823AF740-0x00000001823AF830
		private void OpenTouchScreenKeyboard(); // 0x00000001823B07A0-0x00000001823B0AB0
		public override void HandleEventBubbleUp(EventBase evt); // 0x00000001823AFE50-0x00000001823B0170
		private void OnPointerDownEvent(); // 0x00000001823B0640-0x00000001823B0780
		private void OnPointerUpEvent(PointerUpEvent evt); // 0x00000001823B0780-0x00000001823B07A0
		private void OnFocusInEvent(); // 0x00000001823B0170-0x00000001823B0360
		private void OnFocusOutEvent(FocusOutEvent evt); // 0x00000001823B0360-0x00000001823B0640
	}
}
