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
	internal class KeyboardTextEditorEventHandler : TextEditorEventHandler // TypeDefIndex: 3894
	{
		// Fields
		internal bool m_Changed; // 0x20
		internal bool m_ShouldInvokeUpdateValue; // 0x21
		internal string m_compositionString; // 0x28
	
		// Constructors
		public KeyboardTextEditorEventHandler(TextElement textElement, TextEditingUtilities editingUtilities); // 0x00000001823A0BE0-0x00000001823A0CA0
	
		// Methods
		public override void HandleEventBubbleUp(EventBase evt); // 0x000000018239F7C0-0x000000018239FC60
		private void OnFocus(FocusEvent _); // 0x000000018239FF10-0x000000018239FFF0
		private void OnBlur(BlurEvent _); // 0x000000018239FC60-0x000000018239FD30
		private void OnIMEInput(IMEEvent e); // 0x000000018239FFF0-0x00000001823A0080
		private void OnKeyDown(KeyDownEvent evt); // 0x00000001823A0080-0x00000001823A0730
		private void ApplyTextIfNeeded(); // 0x000000018239F740-0x000000018239F7C0
		private void UpdateLabel(bool generatePreview); // 0x00000001823A08D0-0x00000001823A0BE0
		private void OnValidateCommandEvent(ValidateCommandEvent evt); // 0x00000001823A0730-0x00000001823A08D0
		private void OnExecuteCommandEvent(ExecuteCommandEvent evt); // 0x000000018239FD30-0x000000018239FF10
		private void OnNavigationEvent<TEvent>(NavigationEventBase<TEvent> evt)
			where TEvent : NavigationEventBase<TEvent>, new();
	}
}
