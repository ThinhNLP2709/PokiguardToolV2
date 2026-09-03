/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	public class TextEditor // TypeDefIndex: 13955
	{
		// Fields
		private readonly GUIContent m_Content; // 0x10
		private TextSelectingUtilities m_TextSelecting; // 0x18
		internal TextEditingUtilities m_TextEditing; // 0x20
		internal IMGUITextHandle m_TextHandle; // 0x28
		public TouchScreenKeyboard keyboardOnScreen; // 0x30
		public int controlID; // 0x38
		public GUIStyle style; // 0x40
		public Vector2 scrollOffset; // 0x48
		private bool focus; // 0x50
		private string m_TextWithWhitespace; // 0x58
		[CompilerGenerated]
		private Rect _position_k__BackingField; // 0x60
		public Vector2 graphicalCursorPos; // 0x70
		private Vector2 lastCursorPos; // 0x78
		private Vector2 previousContentSize; // 0x80
		private string oldText; // 0x88
		private int oldPos; // 0x90
		private int oldSelectPos; // 0x94
	
		// Properties
		public bool isMultiline { set; } // 0x00000001822A2800-0x00000001822A2820
		public bool showCursor { get; } // 0x00000001822A2780-0x00000001822A27A0 
		internal bool m_HasFocus { get; set; } // 0x0000000180377920-0x0000000180377930 0x00000001803780E0-0x00000001803780F0
		public string text { get; set; } // 0x00000001822A27E0-0x00000001822A2800 0x00000001822A2860-0x00000001822A2940
		private string emptyString { get; } // 0x00000001822A26C0-0x00000001822A2760 
		internal string textWithWhitespace { get; set; } // 0x00000001822A27A0-0x00000001822A27E0 0x00000001822A2820-0x00000001822A2860
		public Rect position { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001816A56A0-0x00000001816A56B0 0x000000018172A480-0x000000018172A490
		public int cursorIndex { get; } // 0x00000001822A26A0-0x00000001822A26C0 
		public int selectIndex { get; } // 0x00000001822A2760-0x00000001822A2780 
	
		// Nested types
		public enum DblClickSnapping : byte // TypeDefIndex: 13956
		{
			WORDS = 0,
			PARAGRAPHS = 1
		}
	
		// Constructors
		[RequiredByNativeCode]
		public TextEditor(); // 0x00000001822A21D0-0x00000001822A26A0
	
		// Methods
		private void OnTextChangedHandle(); // 0x00000001822A18B0-0x00000001822A1940
		private void OnContentTextChangedHandle(); // 0x00000001822A1680-0x00000001822A17B0
		public void OnFocus(); // 0x00000001822A1880-0x00000001822A18B0
		public void OnLostFocus(); // 0x00000001805FB020-0x00000001805FB030
		public bool HandleKeyEvent(Event e); // 0x00000001822A14B0-0x00000001822A1550
		public void ReplaceSelection(string replace); // 0x00000001822A1940-0x00000001822A1960
		public void Insert(char c); // 0x00000001822A1550-0x00000001822A1570
		public void MoveCursorToPosition(Vector2 cursorPosition); // 0x00000001822A15E0-0x00000001822A1680
		protected internal void MoveCursorToPosition_Internal(Vector2 cursorPosition, bool shift); // 0x00000001822A1590-0x00000001822A15E0
		public void SelectToPosition(Vector2 cursorPosition); // 0x00000001822A1A10-0x00000001822A1A40
		private Vector2 GetLocalCursorPosition(Vector2 cursorPosition); // 0x00000001822A1380-0x00000001822A14B0
		public void MouseDragSelectsWholeWords(bool on); // 0x00000001822A1570-0x00000001822A1590
		public void DblClickSnap(DblClickSnapping snapping); // 0x00000001822A0EF0-0x00000001822A0F10
		public void SelectCurrentWord(); // 0x00000001822A19F0-0x00000001822A1A10
		public void SelectCurrentParagraph(); // 0x00000001822A19D0-0x00000001822A19F0
		public void UpdateScrollOffsetIfNeeded(Event evt); // 0x00000001822A1A40-0x00000001822A1A90
		internal void UpdateTextHandle(); // 0x00000001822A1F90-0x00000001822A21D0
		[VisibleToOtherModules]
		internal void UpdateScrollOffset(); // 0x00000001822A1A90-0x00000001822A1F90
		public void DrawCursor(string newText); // 0x00000001822A0F10-0x00000001822A1380
		public void SaveBackup(); // 0x00000001822A1960-0x00000001822A19D0
		public void DetectFocusChange(); // 0x00000001816197C0-0x00000001816197E0
		internal virtual void OnDetectFocusChange(); // 0x00000001822A17C0-0x00000001822A1880
		internal virtual void OnCursorIndexChange(); // 0x00000001822A17B0-0x00000001822A17C0
		internal virtual void OnSelectIndexChange(); // 0x00000001822A17B0-0x00000001822A17C0
	}
}
