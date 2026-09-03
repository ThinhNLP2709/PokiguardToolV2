/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
	internal class TextSelectingManipulator // TypeDefIndex: 4838
	{
		// Fields
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal TextSelectingUtilities m_SelectingUtilities; // 0x10
		private bool selectAllOnMouseUp; // 0x18
		private TextElement m_TextElement; // 0x20
		private Vector2 m_ClickStartPosition; // 0x28
		private bool m_Dragged; // 0x30
		private bool m_IsClicking; // 0x31
		private int m_ConsecutiveMouseDownCount; // 0x34
		private long m_LastMouseDownTimeStamp; // 0x38
	
		// Properties
		internal bool isClicking { get; private set; } // 0x0000000180634F10-0x0000000180634F20 0x00000001823C88D0-0x00000001823C88E0
		internal int cursorIndex { get; set; } // 0x00000001823C8890-0x00000001823C88B0 0x000000018230C5E0-0x000000018230C600
		internal int selectIndex { get; set; } // 0x00000001823C88B0-0x00000001823C88D0 0x000000018230C6E0-0x000000018230C700
	
		// Constructors
		public TextSelectingManipulator(TextElement textElement); // 0x00000001823C85C0-0x00000001823C8890
	
		// Methods
		private void OnRevealCursor(); // 0x00000001823C82C0-0x00000001823C82F0
		private void OnSelectIndexChange(); // 0x00000001823C82F0-0x00000001823C8400
		private void OnCursorIndexChange(); // 0x00000001823C79E0-0x00000001823C7AF0
		internal bool RevealCursor(); // 0x00000001823C85A0-0x00000001823C85C0
		internal bool HasSelection(); // 0x00000001823C7930-0x00000001823C7950
		internal bool HasFocus(); // 0x00000001823C78C0-0x00000001823C7930
		internal void HandleEventBubbleUp(EventBase evt); // 0x00000001823C7190-0x00000001823C78C0
		private void OnFocusEvent(); // 0x00000001823C7C20-0x00000001823C7CC0
		private void OnBlurEvent(); // 0x00000001823C7990-0x00000001823C79E0
		private void OnKeyDown(KeyDownEvent evt); // 0x00000001823C7CC0-0x00000001823C7D60
		private void OnPointerDownEvent(PointerDownEvent evt); // 0x00000001823C7D60-0x00000001823C80A0
		internal void ResetClickCount(); // 0x00000001802E8710-0x00000001802E8720
		private void OnPointerMoveEvent(PointerMoveEvent evt); // 0x00000001823C80A0-0x00000001823C8240
		private void OnPointerUpEvent(PointerUpEvent evt); // 0x00000001823C8240-0x00000001823C82C0
		private void OnValidateCommandEvent(ValidateCommandEvent evt); // 0x00000001823C8400-0x00000001823C85A0
		private void OnExecuteCommandEvent(ExecuteCommandEvent evt); // 0x00000001823C7AF0-0x00000001823C7C20
		private bool MoveDistanceQualifiesForDrag(Vector2 start, Vector2 current); // 0x00000001823C7950-0x00000001823C7990
	}
}
