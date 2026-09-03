/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[NativeHeader("Modules/TextCoreTextEngine/Native/TextSelectionService.h")]
	[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "Unity.UIElements.PlayModeTests" })]
	internal class TextSelectionService // TypeDefIndex: 12706
	{
		// Methods
		[NativeMethod(Name = "TextSelectionService::PreviousCodePointIndex")]
		internal static int PreviousCodePointIndex(IntPtr textGenerationInfo, int currentIndex); // 0x0000000182348700-0x0000000182348740
		[NativeMethod(Name = "TextSelectionService::NextCodePointIndex")]
		internal static int NextCodePointIndex(IntPtr textGenerationInfo, int currentIndex); // 0x00000001823486C0-0x0000000182348700
		[NativeMethod(Name = "TextSelectionService::GetCursorLogicalIndexFromPosition")]
		internal static int GetCursorLogicalIndexFromPosition(IntPtr textGenerationInfo, Vector2 position); // 0x0000000182347B80-0x0000000182347BC0
		[NativeMethod(Name = "TextSelectionService::GetCursorPositionFromLogicalIndex")]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static Vector2 GetCursorPositionFromLogicalIndex(IntPtr textGenerationInfo, int logicalIndex); // 0x0000000182347CB0-0x0000000182347D10
		[NativeMethod(Name = "TextSelectionService::GetCursorPositionFromCursorIndex")]
		internal static Vector2 GetCursorPositionFromCursorIndex(IntPtr textGenerationInfo); // 0x0000000182347C10-0x0000000182347C60
		[NativeMethod(Name = "TextSelectionService::GetHighlightRectangles")]
		internal static Rect[] GetHighlightRectangles(IntPtr textGenerationInfo, int cursorIndex, int selectIndex); // 0x0000000182347DF0-0x0000000182347EF0
		[NativeMethod(Name = "TextSelectionService::GetCharacterHeightFromIndex")]
		internal static float GetCharacterHeightFromIndex(IntPtr textGenerationInfo, int index); // 0x0000000182347A70-0x0000000182347AB0
		[NativeMethod(Name = "TextSelectionService::GetStartOfNextWord")]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static int GetStartOfNextWord(IntPtr textGenerationInfo, int currentIndex); // 0x0000000182348140-0x0000000182348180
		[NativeMethod(Name = "TextSelectionService::GetEndOfPreviousWord")]
		internal static int GetEndOfPreviousWord(IntPtr textGenerationInfo, int currentIndex); // 0x0000000182347D50-0x0000000182347D90
		[NativeMethod(Name = "TextSelectionService::GetLineNumberFromLogicalIndex")]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static int GetLineNumber(IntPtr textGenerationInfo, int logicalIndex); // 0x0000000182347F30-0x0000000182347F70
		[NativeMethod(Name = "TextSelectionService::GetValidPointIndex")]
		internal static int GetValidPointIndex(IntPtr textGenerationInfo, int index); // 0x0000000182348180-0x00000001823481C0
		[NativeMethod(Name = "TextSelectionService::GetCursorIndex")]
		internal static int GetCursorIndex(IntPtr textGenerationInfo); // 0x0000000182347AF0-0x0000000182347B30
		[NativeMethod(Name = "TextSelectionService::SetCursorIndex")]
		internal static bool SetCursorIndex(IntPtr textGenerationInfo, int value); // 0x0000000182348C50-0x0000000182348C90
		[NativeMethod(Name = "TextSelectionService::GetCursorIndexNoValidation")]
		internal static int GetCursorIndexNoValidation(IntPtr textGenerationInfo); // 0x0000000182347AB0-0x0000000182347AF0
		[NativeMethod(Name = "TextSelectionService::GetSelectIndex")]
		internal static int GetSelectIndex(IntPtr textGenerationInfo); // 0x0000000182347FF0-0x0000000182348030
		[NativeMethod(Name = "TextSelectionService::SetSelectIndex")]
		internal static bool SetSelectIndex(IntPtr textGenerationInfo, int value); // 0x0000000182348DB0-0x0000000182348DF0
		[NativeMethod(Name = "TextSelectionService::GetSelectIndexNoValidation")]
		internal static int GetSelectIndexNoValidation(IntPtr textGenerationInfo); // 0x0000000182347FB0-0x0000000182347FF0
		[NativeMethod(Name = "TextSelectionService::GetRevealCursor")]
		internal static bool GetRevealCursor(IntPtr textGenerationInfo); // 0x0000000182347F70-0x0000000182347FB0
		[NativeMethod(Name = "TextSelectionService::SetRevealCursor")]
		internal static bool SetRevealCursor(IntPtr textGenerationInfo, bool value); // 0x0000000182348D60-0x0000000182348DB0
		[NativeMethod(Name = "TextSelectionService::GetIAltCursorPos")]
		internal static int GetIAltCursorPos(IntPtr textGenerationInfo); // 0x0000000182347EF0-0x0000000182347F30
		[NativeMethod(Name = "TextSelectionService::SetIAltCursorPos")]
		internal static void SetIAltCursorPos(IntPtr textGenerationInfo, int value); // 0x0000000182348D20-0x0000000182348D60
		[NativeMethod(Name = "TextSelectionService::GetSelectedText")]
		internal static string GetSelectedText(IntPtr textGenerationInfo); // 0x0000000182348080-0x0000000182348140
		[NativeMethod(Name = "TextSelectionService::ClearCursorPos")]
		internal static void ClearCursorPos(IntPtr textGenerationInfo); // 0x00000001823479B0-0x00000001823479F0
		[NativeMethod(Name = "TextSelectionService::SelectAll")]
		internal static int SelectAll(IntPtr textGenerationInfo); // 0x0000000182348740-0x0000000182348780
		[NativeMethod(Name = "TextSelectionService::SelectNone")]
		internal static int SelectNone(IntPtr textGenerationInfo); // 0x0000000182348900-0x0000000182348940
		[NativeMethod(Name = "TextSelectionService::SelectLeft")]
		internal static int SelectLeft(IntPtr textGenerationInfo); // 0x00000001823488C0-0x0000000182348900
		[NativeMethod(Name = "TextSelectionService::SelectRight")]
		internal static int SelectRight(IntPtr textGenerationInfo); // 0x00000001823489C0-0x0000000182348A00
		[NativeMethod(Name = "TextSelectionService::SelectUp")]
		internal static int SelectUp(IntPtr textGenerationInfo); // 0x0000000182348B90-0x0000000182348BD0
		[NativeMethod(Name = "TextSelectionService::SelectDown")]
		internal static int SelectDown(IntPtr textGenerationInfo); // 0x0000000182348800-0x0000000182348840
		[NativeMethod(Name = "TextSelectionService::SelectTextStart")]
		internal static int SelectTextStart(IntPtr textGenerationInfo); // 0x0000000182348A40-0x0000000182348A80
		[NativeMethod(Name = "TextSelectionService::SelectTextEnd")]
		internal static int SelectTextEnd(IntPtr textGenerationInfo); // 0x0000000182348A00-0x0000000182348A40
		[NativeMethod(Name = "TextSelectionService::SelectToStartOfNextWord")]
		internal static int SelectToStartOfNextWord(IntPtr textGenerationInfo); // 0x0000000182348B50-0x0000000182348B90
		[NativeMethod(Name = "TextSelectionService::SelectToEndOfPreviousWord")]
		internal static int SelectToEndOfPreviousWord(IntPtr textGenerationInfo); // 0x0000000182348A80-0x0000000182348AC0
		[NativeMethod(Name = "TextSelectionService::SelectWordRight")]
		internal static int SelectWordRight(IntPtr textGenerationInfo); // 0x0000000182348C10-0x0000000182348C50
		[NativeMethod(Name = "TextSelectionService::SelectWordLeft")]
		internal static int SelectWordLeft(IntPtr textGenerationInfo); // 0x0000000182348BD0-0x0000000182348C10
		[NativeMethod(Name = "TextSelectionService::SelectGraphicalLineStart")]
		internal static int SelectGraphicalLineStart(IntPtr textGenerationInfo); // 0x0000000182348880-0x00000001823488C0
		[NativeMethod(Name = "TextSelectionService::SelectGraphicalLineEnd")]
		internal static int SelectGraphicalLineEnd(IntPtr textGenerationInfo); // 0x0000000182348840-0x0000000182348880
		[NativeMethod(Name = "TextSelectionService::SelectParagraphForward")]
		internal static int SelectParagraphForward(IntPtr textGenerationInfo); // 0x0000000182348980-0x00000001823489C0
		[NativeMethod(Name = "TextSelectionService::SelectParagraphBackward")]
		internal static int SelectParagraphBackward(IntPtr textGenerationInfo); // 0x0000000182348940-0x0000000182348980
		[NativeMethod(Name = "TextSelectionService::SelectCurrentWord")]
		internal static int SelectCurrentWord(IntPtr textGenerationInfo); // 0x00000001823487C0-0x0000000182348800
		[NativeMethod(Name = "TextSelectionService::SelectCurrentParagraph")]
		internal static int SelectCurrentParagraph(IntPtr textGenerationInfo); // 0x0000000182348780-0x00000001823487C0
		[NativeMethod(Name = "TextSelectionService::MoveLeft")]
		internal static int MoveLeft(IntPtr textGenerationInfo); // 0x0000000182348380-0x00000001823483C0
		[NativeMethod(Name = "TextSelectionService::MoveRight")]
		internal static int MoveRight(IntPtr textGenerationInfo); // 0x00000001823484C0-0x0000000182348500
		[NativeMethod(Name = "TextSelectionService::MoveUp")]
		internal static int MoveUp(IntPtr textGenerationInfo); // 0x0000000182348600-0x0000000182348640
		[NativeMethod(Name = "TextSelectionService::MoveDown")]
		internal static int MoveDown(IntPtr textGenerationInfo); // 0x00000001823482C0-0x0000000182348300
		[NativeMethod(Name = "TextSelectionService::MoveLineStart")]
		internal static int MoveLineStart(IntPtr textGenerationInfo); // 0x0000000182348400-0x0000000182348440
		[NativeMethod(Name = "TextSelectionService::MoveLineEnd")]
		internal static int MoveLineEnd(IntPtr textGenerationInfo); // 0x00000001823483C0-0x0000000182348400
		[NativeMethod(Name = "TextSelectionService::MoveGraphicalLineStart")]
		internal static int MoveGraphicalLineStart(IntPtr textGenerationInfo); // 0x0000000182348340-0x0000000182348380
		[NativeMethod(Name = "TextSelectionService::MoveGraphicalLineEnd")]
		internal static int MoveGraphicalLineEnd(IntPtr textGenerationInfo); // 0x0000000182348300-0x0000000182348340
		[NativeMethod(Name = "TextSelectionService::MoveTextStart")]
		internal static int MoveTextStart(IntPtr textGenerationInfo); // 0x0000000182348540-0x0000000182348580
		[NativeMethod(Name = "TextSelectionService::MoveTextEnd")]
		internal static int MoveTextEnd(IntPtr textGenerationInfo); // 0x0000000182348500-0x0000000182348540
		[NativeMethod(Name = "TextSelectionService::MoveParagraphForward")]
		internal static int MoveParagraphForward(IntPtr textGenerationInfo); // 0x0000000182348480-0x00000001823484C0
		[NativeMethod(Name = "TextSelectionService::MoveParagraphBackward")]
		internal static int MoveParagraphBackward(IntPtr textGenerationInfo); // 0x0000000182348440-0x0000000182348480
		[NativeMethod(Name = "TextSelectionService::MoveWordRight")]
		internal static int MoveWordRight(IntPtr textGenerationInfo); // 0x0000000182348680-0x00000001823486C0
		[NativeMethod(Name = "TextSelectionService::MoveWordLeft")]
		internal static int MoveWordLeft(IntPtr textGenerationInfo); // 0x0000000182348640-0x0000000182348680
		[NativeMethod(Name = "TextSelectionService::MoveToStartOfNextWord")]
		internal static int MoveToStartOfNextWord(IntPtr textGenerationInfo); // 0x00000001823485C0-0x0000000182348600
		[NativeMethod(Name = "TextSelectionService::MoveToEndOfPreviousWord")]
		internal static int MoveToEndOfPreviousWord(IntPtr textGenerationInfo); // 0x0000000182348580-0x00000001823485C0
		[NativeMethod(Name = "TextSelectionService::ExpandSelectGraphicalLineStart")]
		internal static int ExpandSelectGraphicalLineStart(IntPtr textGenerationInfo); // 0x0000000182347A30-0x0000000182347A70
		[NativeMethod(Name = "TextSelectionService::ExpandSelectGraphicalLineEnd")]
		internal static int ExpandSelectGraphicalLineEnd(IntPtr textGenerationInfo); // 0x00000001823479F0-0x0000000182347A30
		[NativeMethod(Name = "TextSelectionService::MouseDragSelectsWholeWords")]
		internal static void MouseDragSelectsWholeWords(IntPtr textGenerationInfo, bool on); // 0x00000001823481C0-0x0000000182348210
		[NativeMethod(Name = "TextSelectionService::GetDblClickSnap")]
		internal static int GetDblClickSnap(IntPtr textGenerationInfo); // 0x0000000182347D10-0x0000000182347D50
		[NativeMethod(Name = "TextSelectionService::SetDblClickSnap")]
		internal static void SetDblClickSnap(IntPtr textGenerationInfo, int snap); // 0x0000000182348C90-0x0000000182348CD0
		[NativeMethod(Name = "TextSelectionService::SetHasHorizontalCursorPos")]
		internal static void SetHasHorizontalCursorPos(IntPtr textGenerationInfo, bool value); // 0x0000000182348CD0-0x0000000182348D20
		[NativeMethod(Name = "TextSelectionService::MoveCursorToPosition")]
		internal static int MoveCursorToPosition(IntPtr textGenerationInfo, Vector2 position, bool shift); // 0x0000000182348270-0x00000001823482C0
		[NativeMethod(Name = "TextSelectionService::SelectToPosition")]
		internal static int SelectToPosition(IntPtr textGenerationInfo, Vector2 position); // 0x0000000182348B10-0x0000000182348B50
		private static int GetCursorLogicalIndexFromPosition_Injected(IntPtr textGenerationInfo, in Vector2 position); // 0x0000000182347B30-0x0000000182347B80
		private static void GetCursorPositionFromLogicalIndex_Injected(IntPtr textGenerationInfo, int logicalIndex, ); // 0x0000000182347C60-0x0000000182347CB0
		private static void GetCursorPositionFromCursorIndex_Injected(IntPtr textGenerationInfo, ); // 0x0000000182347BC0-0x0000000182347C10
		private static void GetHighlightRectangles_Injected(IntPtr textGenerationInfo, int cursorIndex, int selectIndex, ); // 0x0000000182347D90-0x0000000182347DF0
		private static void GetSelectedText_Injected(IntPtr textGenerationInfo, ); // 0x0000000182348030-0x0000000182348080
		private static int MoveCursorToPosition_Injected(IntPtr textGenerationInfo, in Vector2 position, bool shift); // 0x0000000182348210-0x0000000182348270
		private static int SelectToPosition_Injected(IntPtr textGenerationInfo, in Vector2 position); // 0x0000000182348AC0-0x0000000182348B10
	}
}
