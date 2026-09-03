/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class ATGTextEventHandler // TypeDefIndex: 4822
	{
		// Fields
		private static readonly Regex s_ATagRegex; // 0x00
		private static readonly Regex s_LinkTagRegex; // 0x08
		private TextElement m_TextElement; // 0x10
		private EventCallback<PointerDownEvent> m_LinkTagOnPointerDown; // 0x18
		private EventCallback<PointerUpEvent> m_LinkTagOnPointerUp; // 0x20
		private EventCallback<PointerMoveEvent> m_LinkTagOnPointerMove; // 0x28
		private EventCallback<PointerOutEvent> m_LinkTagOnPointerOut; // 0x30
		private EventCallback<PointerUpEvent> m_HyperlinkOnPointerUp; // 0x38
		private EventCallback<PointerMoveEvent> m_HyperlinkOnPointerMove; // 0x40
		private EventCallback<PointerOverEvent> m_HyperlinkOnPointerOver; // 0x48
		private EventCallback<PointerOutEvent> m_HyperlinkOnPointerOut; // 0x50
		[CompilerGenerated]
		private static Action<Dictionary<string, string>> onComplexHyperlinkClicked; // 0x10
		internal bool isOverridingCursor; // 0x58
		internal int currentLinkIDHash; // 0x5C
	
		// Constructors
		public ATGTextEventHandler(TextElement textElement); // 0x00000001823B4850-0x00000001823B4900
		static ATGTextEventHandler(); // 0x00000001823B4770-0x00000001823B4850
	
		// Methods
		public void OnDestroy(); // 0x00000001823B3FB0-0x00000001823B3FD0
		private bool HasAllocatedLinkCallbacks(); // 0x0000000180DAB6D0-0x0000000180DAB6E0
		private void AllocateLinkCallbacks(); // 0x00000001823B28B0-0x00000001823B2A20
		private bool HasAllocatedHyperlinkCallbacks(); // 0x00000001805DFAC0-0x00000001805DFAD0
		private void AllocateHyperlinkCallbacks(); // 0x00000001823B2740-0x00000001823B28B0
		private void EnsureTextGenerationInfoIsValid(); // 0x00000001823B2A20-0x00000001823B2A90
		private void HyperlinkOnPointerUp(PointerUpEvent pue); // 0x00000001823B2E50-0x00000001823B3090
		private static bool IsComplexHyperLink(string link, out Dictionary<string, string> hyperLinkData); // 0x00000001823B3090-0x00000001823B3450
		private void HyperlinkOnPointerOver(PointerOverEvent _); // 0x00000001823B2E40-0x00000001823B2E50
		private void HyperlinkOnPointerMove(PointerMoveEvent pme); // 0x00000001823B2A90-0x00000001823B2E40
		private void HyperlinkOnPointerOut(PointerOutEvent evt); // 0x00000001823B2E40-0x00000001823B2E50
		private void ResetHoveredTag(); // 0x00000001823B44B0-0x00000001823B4540
		private void LinkTagOnPointerDown(PointerDownEvent pde); // 0x00000001823B3450-0x00000001823B36E0
		private void LinkTagOnPointerUp(PointerUpEvent pue); // 0x00000001823B3D20-0x00000001823B3FB0
		private void LinkTagOnPointerMove(PointerMoveEvent pme); // 0x00000001823B36E0-0x00000001823B3BC0
		private void LinkTagOnPointerOut(PointerOutEvent poe); // 0x00000001823B3BC0-0x00000001823B3D20
		internal void RegisterLinkTagCallbacks(); // 0x00000001823B4260-0x00000001823B44B0
		internal void UnRegisterLinkTagCallbacks(); // 0x00000001823B4680-0x00000001823B4770
		internal void RegisterHyperlinkCallbacks(); // 0x00000001823B3FD0-0x00000001823B4260
		internal void UnRegisterHyperlinkCallbacks(); // 0x00000001823B4540-0x00000001823B4680
	}
}
