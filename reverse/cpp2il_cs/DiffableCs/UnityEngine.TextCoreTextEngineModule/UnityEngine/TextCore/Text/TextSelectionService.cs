namespace UnityEngine.TextCore.Text;

[NativeHeader("Modules/TextCoreTextEngine/Native/TextSelectionService.h")]
[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule", "Unity.UIElements.PlayModeTests"})]
internal class TextSelectionService
{

	[NativeMethod(Name = "TextSelectionService::GetCharacterHeightFromIndex")]
	internal static float GetCharacterHeightFromIndex(IntPtr textGenerationInfo, int index) { }

	[NativeMethod(Name = "TextSelectionService::GetCursorLogicalIndexFromPosition")]
	internal static int GetCursorLogicalIndexFromPosition(IntPtr textGenerationInfo, Vector2 position) { }

	private static int GetCursorLogicalIndexFromPosition_Injected(IntPtr textGenerationInfo, in Vector2 position) { }

	[NativeMethod(Name = "TextSelectionService::GetCursorPositionFromLogicalIndex")]
	internal static Vector2 GetCursorPositionFromLogicalIndex(IntPtr textGenerationInfo, int logicalIndex) { }

	private static void GetCursorPositionFromLogicalIndex_Injected(IntPtr textGenerationInfo, int logicalIndex, out Vector2 ret) { }

	[NativeMethod(Name = "TextSelectionService::GetEndOfPreviousWord")]
	internal static int GetEndOfPreviousWord(IntPtr textGenerationInfo, int currentIndex) { }

	[NativeMethod(Name = "TextSelectionService::GetFirstCharacterIndexOnLine")]
	internal static int GetFirstCharacterIndexOnLine(IntPtr textGenerationInfo, int currentIndex) { }

	[NativeMethod(Name = "TextSelectionService::GetHighlightRectangles")]
	internal static Rect[] GetHighlightRectangles(IntPtr textGenerationInfo, int cursorIndex, int selectIndex) { }

	private static void GetHighlightRectangles_Injected(IntPtr textGenerationInfo, int cursorIndex, int selectIndex, out BlittableArrayWrapper ret) { }

	[NativeMethod(Name = "TextSelectionService::GetLastCharacterIndexOnLine")]
	internal static int GetLastCharacterIndexOnLine(IntPtr textGenerationInfo, int currentIndex) { }

	[NativeMethod(Name = "TextSelectionService::GetLineHeight")]
	internal static float GetLineHeight(IntPtr textGenerationInfo, int lineIndex) { }

	[NativeMethod(Name = "TextSelectionService::GetLineNumberFromLogicalIndex")]
	internal static int GetLineNumber(IntPtr textGenerationInfo, int logicalIndex) { }

	[NativeMethod(Name = "TextSelectionService::GetStartOfNextWord")]
	internal static int GetStartOfNextWord(IntPtr textGenerationInfo, int currentIndex) { }

	[NativeMethod(Name = "TextSelectionService::LineDownCharacterPosition")]
	internal static int LineDownCharacterPosition(IntPtr textGenerationInfo, int originalPos) { }

	[NativeMethod(Name = "TextSelectionService::LineUpCharacterPosition")]
	internal static int LineUpCharacterPosition(IntPtr textGenerationInfo, int originalPos) { }

	[NativeMethod(Name = "TextSelectionService::NextCodePointIndex")]
	internal static int NextCodePointIndex(IntPtr textGenerationInfo, int currentIndex) { }

	[NativeMethod(Name = "TextSelectionService::PreviousCodePointIndex")]
	internal static int PreviousCodePointIndex(IntPtr textGenerationInfo, int currentIndex) { }

	[NativeMethod(Name = "TextSelectionService::SelectCurrentParagraph")]
	internal static void SelectCurrentParagraph(IntPtr textGenerationInfo, ref int cursorIndex, ref int selectIndex) { }

	[NativeMethod(Name = "TextSelectionService::SelectCurrentWord")]
	internal static void SelectCurrentWord(IntPtr textGenerationInfo, int currentIndex, ref int startIndex, ref int endIndex) { }

	[NativeMethod(Name = "TextSelectionService::SelectToEndOfParagraph")]
	internal static void SelectToEndOfParagraph(IntPtr textGenerationInfo, ref int cursorIndex) { }

	[NativeMethod(Name = "TextSelectionService::SelectToNextParagraph")]
	internal static void SelectToNextParagraph(IntPtr textGenerationInfo, ref int cursorIndex) { }

	[NativeMethod(Name = "TextSelectionService::SelectToPreviousParagraph")]
	internal static void SelectToPreviousParagraph(IntPtr textGenerationInfo, ref int cursorIndex) { }

	[NativeMethod(Name = "TextSelectionService::SelectToStartOfParagraph")]
	internal static void SelectToStartOfParagraph(IntPtr textGenerationInfo, ref int cursorIndex) { }

	[NativeMethod(Name = "TextSelectionService::Substring")]
	internal static string Substring(IntPtr textGenerationInfo, int startIndex, int endIndex) { }

	private static void Substring_Injected(IntPtr textGenerationInfo, int startIndex, int endIndex, out ManagedSpanWrapper ret) { }

}

