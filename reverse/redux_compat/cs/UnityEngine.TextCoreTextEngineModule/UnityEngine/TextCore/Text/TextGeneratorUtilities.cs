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
using UnityEngine.TextCore;
using UnityEngine.TextCore.LowLevel;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal static class TextGeneratorUtilities // TypeDefIndex: 12701
	{
		// Fields
		public static readonly Vector2 largePositiveVector2; // 0x00
		public static readonly Vector2 largeNegativeVector2; // 0x08
		private static readonly HashSet<uint> k_EmojiLookup; // 0x10
		private static readonly HashSet<uint> k_EmojiPresentationFormLookup; // 0x18
	
		// Constructors
		static TextGeneratorUtilities(); // 0x000000018233EEC0-0x000000018233F060
	
		// Methods
		public static bool Approximately(float a, float b); // 0x00000001820EC330-0x00000001820EC360
		public static Color32 HexCharsToColor(char[] hexChars, int startIndex, int tagCount); // 0x000000018233D600-0x000000018233DA10
		public static uint HexToInt(char hex); // 0x00000001820F0390-0x00000001820F04B0
		public static float ConvertToFloat(char[] chars, int startIndex, int length); // 0x000000018233B5A0-0x000000018233B620
		public static float ConvertToFloat(char[] chars, int startIndex, int length, out int lastIndex); // 0x000000018233B410-0x000000018233B5A0
		public static void ResizeInternalArray<T>(ref ref T[] array);
		public static void ResizeInternalArray<T>(ref ref T[] array, int size);
		internal static void InsertOpeningTextStyle(TextStyle style, ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings); // 0x000000018233DCE0-0x000000018233DDD0
		internal static void InsertClosingTextStyle(TextStyle style, ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings); // 0x000000018233DB00-0x000000018233DBF0
		public static bool ReplaceOpeningStyleTag(ref TextBackingContainer sourceText, int srcIndex, out int srcOffset, ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings); // 0x000000018233E7B0-0x000000018233E990
		private static bool ReplaceOpeningStyleTag(ref uint[] sourceText, int srcIndex, out int srcOffset, ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings); // 0x000000018233E990-0x000000018233EB70
		public static void ReplaceClosingStyleTag(ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings); // 0x000000018233E6B0-0x000000018233E7B0
		internal static void InsertOpeningStyleTag(TextStyle style, ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings); // 0x000000018233DBF0-0x000000018233DCE0
		internal static void InsertClosingStyleTag(ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings); // 0x000000018233DA10-0x000000018233DB00
		private static void InsertTextStyleInTextProcessingArray(ref TextProcessingElement[] charBuffer, ref int writeIndex, uint[] styleDefinition, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings); // 0x000000018233DDD0-0x000000018233E330
		public static TextStyle GetStyle(TextGenerationSettings generationSetting, int hashCode); // 0x000000018233CF70-0x000000018233D020
		public static int GetStyleHashCode(ref uint[] text, int index, out int closeIndex); // 0x000000018233CE70-0x000000018233CF70
		public static int GetStyleHashCode(ref TextBackingContainer text, int index, out int closeIndex); // 0x000000018233CD70-0x000000018233CE70
		public static uint GetUTF16(uint[] text, int i); // 0x000000018233D130-0x000000018233D220
		public static uint GetUTF16(TextBackingContainer text, int i); // 0x000000018233D020-0x000000018233D130
		public static uint GetUTF32(uint[] text, int i); // 0x000000018233D220-0x000000018233D3C0
		public static uint GetUTF32(TextBackingContainer text, int i); // 0x000000018233D3C0-0x000000018233D5B0
		public static void FillCharacterVertexBuffers(int i, bool convertToLinearSpace, TextGenerationSettings generationSettings, TextInfo textInfo, bool needToRound); // 0x000000018233B620-0x000000018233C050
		public static void FillSpriteVertexBuffers(int i, bool convertToLinearSpace, TextGenerationSettings generationSettings, TextInfo textInfo); // 0x000000018233C050-0x000000018233C9B0
		public static void AdjustLineOffset(int startIndex, int endIndex, float offset, TextInfo textInfo); // 0x000000018233B090-0x000000018233B410
		public static void ResizeLineExtents(int size, TextInfo textInfo); // 0x000000018233EB70-0x000000018233EDA0
		public static FontStyles LegacyStyleToNewStyle(FontStyle fontStyle); // 0x000000018233E680-0x000000018233E6B0
		public static TextAlignment LegacyAlignmentToNewAlignment(TextAnchor anchor); // 0x000000018233E600-0x000000018233E680
		[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
		internal static HorizontalAlignment GetHorizontalAlignment(TextAnchor anchor); // 0x000000018233CB20-0x000000018233CB70
		[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
		internal static VerticalAlignment GetVerticalAlignment(TextAnchor anchor); // 0x000000018233D5B0-0x000000018233D600
		public static uint ConvertToUTF32(uint highSurrogate, uint lowSurrogate); // 0x00000001820D0740-0x00000001820D0750
		public static int GetMarkupTagHashCode(TextBackingContainer styleDefinition, int readIndex); // 0x000000018233CC70-0x000000018233CD70
		public static int GetMarkupTagHashCode(uint[] styleDefinition, int readIndex); // 0x000000018233CB70-0x000000018233CC70
		public static char ToUpperASCIIFast(char c); // 0x000000018233EDA0-0x000000018233EE00
		public static uint ToUpperASCIIFast(uint c); // 0x000000018233EE00-0x000000018233EE60
		public static char ToUpperFast(char c); // 0x000000018233EE60-0x000000018233EEC0
		public static int GetAttributeParameters(char[] chars, int startIndex, int length, ref float[] parameters); // 0x000000018233CA30-0x000000018233CB20
		public static bool IsBitmapRendering(GlyphRenderMode glyphRenderMode); // 0x000000018233E330-0x000000018233E360
		public static bool IsBaseGlyph(uint c); // 0x00000001820D08A0-0x00000001820D09B0
		internal static Color32 GammaToLinear(Color32 c); // 0x000000018233C9B0-0x000000018233CA30
		private static byte GammaToLinear(byte value); // 0x00000001820F4540-0x00000001820F45F0
		public static bool IsValidUTF16(TextBackingContainer text, int index); // 0x000000018233E520-0x000000018233E590
		public static bool IsValidUTF32(TextBackingContainer text, int index); // 0x000000018233E590-0x000000018233E600
		internal static bool IsEmoji(uint c); // 0x000000018233E4A0-0x000000018233E520
		internal static bool IsEmojiPresentationForm(uint c); // 0x000000018233E420-0x000000018233E4A0
		internal static bool IsHangul(uint c); // 0x00000001820D0BE0-0x00000001820D0C40
		internal static bool IsCJK(uint c); // 0x000000018233E360-0x000000018233E420
	
		// Extension methods
		public static Color MinAlpha(this Color c1, Color c2); // 0x00000001820F47D0-0x00000001820F4800
	}
}
