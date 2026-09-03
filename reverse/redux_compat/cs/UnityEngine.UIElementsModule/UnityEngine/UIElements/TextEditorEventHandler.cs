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
	internal class TextEditorEventHandler // TypeDefIndex: 3895
	{
		// Fields
		protected TextElement textElement; // 0x10
		protected TextEditingUtilities editingUtilities; // 0x18
	
		// Constructors
		protected TextEditorEventHandler(TextElement textElement, TextEditingUtilities editingUtilities); // 0x0000000180CB0730-0x0000000180CB0780
	
		// Methods
		public virtual void RegisterCallbacksOnTarget(VisualElement target); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void UnregisterCallbacksFromTarget(VisualElement target); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void HandleEventBubbleUp(EventBase evt); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
