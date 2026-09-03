/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class TextEventHandler // TypeDefIndex: 4836
	{
		// Fields
		private TextElement m_TextElement; // 0x10
		private EventCallback<PointerDownEvent> m_LinkTagOnPointerDown; // 0x18
		private EventCallback<PointerUpEvent> m_LinkTagOnPointerUp; // 0x20
		private EventCallback<PointerMoveEvent> m_LinkTagOnPointerMove; // 0x28
		private EventCallback<PointerOutEvent> m_LinkTagOnPointerOut; // 0x30
		private EventCallback<PointerUpEvent> m_ATagOnPointerUp; // 0x38
		private EventCallback<PointerMoveEvent> m_ATagOnPointerMove; // 0x40
		private EventCallback<PointerOverEvent> m_ATagOnPointerOver; // 0x48
		private EventCallback<PointerOutEvent> m_ATagOnPointerOut; // 0x50
		internal bool isOverridingCursor; // 0x58
		internal int currentLinkIDHash; // 0x5C
		internal bool hasLinkTag; // 0x60
		internal bool hasATag; // 0x61
	
		// Properties
		private TextInfo textInfo { get; } // 0x00000001823C6E40-0x00000001823C6E70 
	
		// Constructors
		public TextEventHandler(TextElement textElement); // 0x00000001823C6E00-0x00000001823C6E40
	
		// Methods
		public void OnDestroy(); // 0x00000001823C6C70-0x00000001823C6E00
		private bool HasAllocatedLinkCallbacks(); // 0x0000000180DAB6D0-0x0000000180DAB6E0
		private void AllocateLinkCallbacks(); // 0x00000001823C5450-0x00000001823C55C0
		private bool HasAllocatedATagCallbacks(); // 0x00000001805DFAC0-0x00000001805DFAD0
		private void AllocateATagCallbacks(); // 0x00000001823C52E0-0x00000001823C5450
		private void ATagOnPointerUp(PointerUpEvent pue); // 0x00000001823C50B0-0x00000001823C52E0
		private void ATagOnPointerOver(PointerOverEvent _); // 0x0000000181F6E4B0-0x0000000181F6E4C0
		private void ATagOnPointerMove(PointerMoveEvent pme); // 0x00000001823C4D50-0x00000001823C50B0
		private void ATagOnPointerOut(PointerOutEvent evt); // 0x0000000181F6E4B0-0x0000000181F6E4C0
		private void LinkTagOnPointerDown(PointerDownEvent pde); // 0x00000001823C5E60-0x00000001823C61D0
		private void LinkTagOnPointerUp(PointerUpEvent pue); // 0x00000001823C6900-0x00000001823C6C70
		private void LinkTagOnPointerMove(PointerMoveEvent pme); // 0x00000001823C61D0-0x00000001823C67A0
		private void LinkTagOnPointerOut(PointerOutEvent poe); // 0x00000001823C67A0-0x00000001823C6900
		internal void HandleLinkAndATagCallbacks(); // 0x00000001823C56F0-0x00000001823C5D30
		internal void HandleLinkTag(); // 0x00000001823C5D30-0x00000001823C5E60
		internal void HandleATag(); // 0x00000001823C55C0-0x00000001823C56F0
	}
}
