/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.TextCore.Text;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine
{
	[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
	internal class TextSelectingUtilities // TypeDefIndex: 12619
	{
		// Fields
		private DblClickSnapping m_DblClickSnap; // 0x10
		private int m_IAltCursorPos; // 0x14
		private bool m_HasHorizontalCursorPos; // 0x18
		private bool m_bJustSelected; // 0x19
		private bool m_MouseDragSelectsWholeWords; // 0x1A
		private int m_DblClickInitPosStart; // 0x1C
		private int m_DblClickInitPosEnd; // 0x20
		public TextHandle textHandle; // 0x28
		private bool m_RevealCursor; // 0x30
		private int m_CursorIndex; // 0x34
		internal int m_SelectIndex; // 0x38
		[TupleElementNames(new string[2] {"keyEvent", "operation" })]
		internal static readonly List<ValueTuple<TextEditingUtilities.KeyEvent, TextSelectOp>> s_GlobalKeyMappings; // 0x00
		[TupleElementNames(new string[2] {"keyEvent", "operation" })]
		internal static readonly List<ValueTuple<TextEditingUtilities.KeyEvent, TextSelectOp>> s_MacKeyMappings; // 0x08
		[TupleElementNames(new string[2] {"keyEvent", "operation" })]
		internal static readonly List<ValueTuple<TextEditingUtilities.KeyEvent, TextSelectOp>> s_WindowsLinuxKeyMappings; // 0x10
		public Action OnCursorIndexChange; // 0x40
		public Action OnSelectIndexChange; // 0x48
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal Action OnRevealCursorChange; // 0x50
	
		// Properties
		public DblClickSnapping dblClickSnap { get; set; } // 0x0000000182312800-0x0000000182312850 0x000000018230CBC0-0x000000018230CC20
		public int iAltCursorPos { get; set; } // 0x0000000182312880-0x00000001823128D0 0x0000000182312D40-0x0000000182312DA0
		public bool hasHorizontalCursorPos { set; } // 0x0000000182312CE0-0x0000000182312D40
		private bool useAdvancedText { get; } // 0x0000000182312B90-0x0000000182312BB0 
		private IntPtr tgi { get; } // 0x0000000182312B70-0x0000000182312B90 
		public bool hasSelection { get; } // 0x0000000182312850-0x0000000182312880 
		public bool revealCursor { get; set; } // 0x0000000182312920-0x0000000182312970 0x0000000182312DA0-0x0000000182312E20
		private int m_CharacterCount { get; } // 0x00000001823128D0-0x00000001823128F0 
		private int characterCount { get; } // 0x0000000182312660-0x0000000182312730 
		private TextElementInfo[] m_TextElementInfos { get; } // 0x00000001823128F0-0x0000000182312920 
		public int cursorIndex { get; set; } // 0x0000000182312780-0x0000000182312800 0x0000000182312C60-0x0000000182312CE0
		[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
		internal int cursorIndexNoValidation { get; set; } // 0x0000000182312730-0x0000000182312780 0x0000000182312BB0-0x0000000182312C60
		public int selectIndex { get; set; } // 0x00000001823129C0-0x0000000182312A40 0x0000000182312ED0-0x0000000182312F80
		[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
		internal int selectIndexNoValidation { get; set; } // 0x0000000182312970-0x00000001823129C0 0x0000000182312E20-0x0000000182312ED0
		public string selectedText { get; } // 0x0000000182312A40-0x0000000182312B70 
	
		// Nested types
		public enum DblClickSnapping : byte // TypeDefIndex: 12620
		{
			WORDS = 0,
			PARAGRAPHS = 1
		}
	
		private enum CharacterType // TypeDefIndex: 12621
		{
			LetterLike = 0,
			Symbol = 1,
			Symbol2 = 2,
			WhiteSpace = 3,
			NewLine = 4
		}
	
		private enum Direction // TypeDefIndex: 12622
		{
			Forward = 0,
			Backward = 1
		}
	
		// Constructors
		public TextSelectingUtilities(TextHandle textHandle); // 0x0000000182312620-0x0000000182312660
		static TextSelectingUtilities(); // 0x00000001823114C0-0x0000000182312620
	
		// Methods
		internal void SetCursorIndexWithoutNotify(int index); // 0x00000001823110D0-0x0000000182311130
		internal void SetSelectIndexWithoutNotify(int index); // 0x0000000182311130-0x0000000182311190
		public bool HandleKeyEvent(KeyCode key, EventModifiers modifiers); // 0x000000018230D850-0x000000018230D900
		private bool PerformOperation(TextSelectOp operation); // 0x000000018230EC40-0x000000018230F8C0
		internal static TextSelectOp? TextSelectOpFromEnum(KeyCode key, EventModifiers modifiers, bool IsMacOsFamily); // 0x0000000182311220-0x00000001823114C0
		internal void NotifyFromFlags(int flags); // 0x000000018230EB30-0x000000018230EC10
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal void SyncStateToNative(); // 0x0000000182311190-0x0000000182311220
		public void ClearCursorPos(); // 0x000000018230C970-0x000000018230CA30
		public void OnFocus(bool selectAll = true /* Metadata: 0x006A4883 */); // 0x000000018230EC10-0x000000018230EC40
		public void SelectAll(); // 0x000000018230F930-0x000000018230F9B0
		public void SelectNone(); // 0x0000000182310240-0x00000001823102C0
		public void SelectLeft(); // 0x0000000182310120-0x0000000182310240
		public void SelectRight(); // 0x0000000182310530-0x0000000182310610
		public void SelectUp(); // 0x0000000182310D80-0x0000000182310E10
		public void SelectDown(); // 0x000000018230FF70-0x0000000182310000
		public void SelectTextEnd(); // 0x0000000182310610-0x0000000182310680
		public void SelectTextStart(); // 0x0000000182310680-0x00000001823106F0
		public void SelectToStartOfNextWord(); // 0x0000000182310CF0-0x0000000182310D80
		public void SelectToEndOfPreviousWord(); // 0x00000001823106F0-0x0000000182310780
		public void SelectWordRight(); // 0x0000000182310F70-0x00000001823110D0
		public void SelectWordLeft(); // 0x0000000182310E10-0x0000000182310F70
		public void SelectGraphicalLineStart(); // 0x0000000182310090-0x0000000182310120
		public void SelectGraphicalLineEnd(); // 0x0000000182310000-0x0000000182310090
		public void SelectParagraphForward(); // 0x0000000182310400-0x0000000182310530
		public void SelectParagraphBackward(); // 0x00000001823102C0-0x0000000182310400
		public void SelectCurrentWord(); // 0x000000018230FAD0-0x000000018230FF70
		public void SelectCurrentParagraph(); // 0x000000018230F9B0-0x000000018230FAD0
		public void MoveRight(); // 0x000000018230E350-0x000000018230E450
		public void MoveLeft(); // 0x000000018230DDA0-0x000000018230DEA0
		public void MoveUp(); // 0x000000018230E6F0-0x000000018230E800
		public void MoveDown(); // 0x000000018230DB00-0x000000018230DC20
		public void MoveLineStart(); // 0x000000018230DFF0-0x000000018230E120
		public void MoveLineEnd(); // 0x000000018230DEA0-0x000000018230DFF0
		public void MoveGraphicalLineStart(); // 0x000000018230DCE0-0x000000018230DDA0
		public void MoveGraphicalLineEnd(); // 0x000000018230DC20-0x000000018230DCE0
		public void MoveTextStart(); // 0x000000018230E4E0-0x000000018230E550
		public void MoveTextEnd(); // 0x000000018230E450-0x000000018230E4E0
		public void MoveParagraphForward(); // 0x000000018230E240-0x000000018230E350
		public void MoveParagraphBackward(); // 0x000000018230E120-0x000000018230E240
		public void MoveWordRight(); // 0x000000018230E8E0-0x000000018230EAC0
		public void MoveToStartOfNextWord(); // 0x000000018230E620-0x000000018230E6F0
		public void MoveToEndOfPreviousWord(); // 0x000000018230E550-0x000000018230E620
		public void MoveWordLeft(); // 0x000000018230E800-0x000000018230E8E0
		public void MouseDragSelectsWholeWords(bool on); // 0x000000018230D950-0x000000018230DA20
		public void ExpandSelectGraphicalLineStart(); // 0x000000018230CD30-0x000000018230CE40
		public void ExpandSelectGraphicalLineEnd(); // 0x000000018230CC20-0x000000018230CD30
		public void DblClickSnap(DblClickSnapping snapping); // 0x000000018230CBC0-0x000000018230CC20
		protected internal void MoveCursorToPosition_Internal(Vector2 cursorPosition, bool shift); // 0x000000018230DA20-0x000000018230DB00
		public void SelectToPosition(Vector2 cursorPosition); // 0x0000000182310780-0x0000000182310CF0
		private int FindNextSeperator(int startPos); // 0x000000018230D220-0x000000018230D340
		private int FindPrevSeperator(int startPos); // 0x000000018230D340-0x000000018230D510
		public int FindStartOfNextWord(int p); // 0x000000018230D510-0x000000018230D810
		public int FindEndOfPreviousWord(int p); // 0x000000018230D020-0x000000018230D220
		private int FindEndOfClassification(int p, Direction dir); // 0x000000018230CE40-0x000000018230D020
		private int ClampTextIndex(int index); // 0x000000018230C7D0-0x000000018230C850
		private int IndexOfEndOfLine(int startIndex); // 0x000000018230D900-0x000000018230D950
		public int PreviousCodePointIndex(int index); // 0x000000018230F8C0-0x000000018230F930
		public int NextCodePointIndex(int index); // 0x000000018230EAC0-0x000000018230EB30
		private int GetGraphicalLineStart(int p); // 0x000000018230D830-0x000000018230D850
		private int GetGraphicalLineEnd(int p); // 0x000000018230D810-0x000000018230D830
		public void Copy(); // 0x000000018230CA30-0x000000018230CBC0
		private CharacterType ClassifyChar(int index); // 0x000000018230C850-0x000000018230C970
	}
}
