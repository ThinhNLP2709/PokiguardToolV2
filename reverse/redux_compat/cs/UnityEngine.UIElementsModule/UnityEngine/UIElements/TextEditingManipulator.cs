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
	internal class TextEditingManipulator // TypeDefIndex: 4831
	{
		// Fields
		private readonly TextElement m_TextElement; // 0x10
		private TextEditorEventHandler m_TouchScreenEditingEventHandler; // 0x18
		private TextEditorEventHandler m_KeyboardEditingEventHandler; // 0x20
		internal TextEditingUtilities editingUtilities; // 0x28
		private IVisualElementScheduledItem m_HardwareKeyboardPoller; // 0x30
	
		// Properties
		internal TextEditorEventHandler touchScreenEditingEventHandler { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001823BCE40-0x00000001823BCEC0
		internal TextEditorEventHandler keyboardEditingEventHandler { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x00000001823BCDC0-0x00000001823BCE40
		private bool touchScreenTextFieldChanged { get; } // 0x00000001823BCCD0-0x00000001823BCDC0 
		private bool touchScreenCanBeUsed { get; } // 0x00000001823BCC60-0x00000001823BCCD0 
		private bool keyboardCanBeUsed { get; } // 0x00000001823BCBF0-0x00000001823BCC60 
	
		// Constructors
		public TextEditingManipulator(TextElement textElement); // 0x00000001823BCAF0-0x00000001823BCBF0
	
		// Methods
		public void Reset(); // 0x00000001823BC860-0x00000001823BC920
		private void UpdateTextEditorEventHandler(); // 0x00000001823BC970-0x00000001823BCAF0
		internal void HandleEventBubbleUp(EventBase evt); // 0x00000001823BC2E0-0x00000001823BC5A0
		private void OnFocusInEvent(); // 0x00000001823BC5A0-0x00000001823BC800
		private void OnFocusOutEvent(); // 0x00000001823BC800-0x00000001823BC860
		[CompilerGenerated]
		private void _OnFocusInEvent_b__21_0(); // 0x00000001823BC920-0x00000001823BC970
	}
}
