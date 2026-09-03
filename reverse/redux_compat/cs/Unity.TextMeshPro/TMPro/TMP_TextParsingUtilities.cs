/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public static class TMP_TextParsingUtilities // TypeDefIndex: 11910
	{
		// Fields
		private const string k_LookupStringL = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-"; // Metadata: 0x006A22F8
		private const string k_LookupStringU = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-"; // Metadata: 0x006A237A
		private static readonly HashSet<uint> k_EmojiLookup; // 0x00
		private static readonly HashSet<uint> k_EmojiPresentationFormLookup; // 0x08
	
		// Constructors
		static TMP_TextParsingUtilities(); // 0x00000001820B1FD0-0x00000001820BEF40
	
		// Methods
		public static int GetHashCode(string s); // 0x00000001820D07B0-0x00000001820D08A0
		public static int GetHashCodeCaseSensitive(string s); // 0x00000001820D0750-0x00000001820D07B0
		public static char ToLowerASCIIFast(char c); // 0x00000001820D0CB0-0x00000001820D0D10
		public static char ToUpperASCIIFast(char c); // 0x00000001820D0DD0-0x00000001820D0E30
		public static uint ToUpperASCIIFast(uint c); // 0x00000001820D0D70-0x00000001820D0DD0
		public static uint ToLowerASCIIFast(uint c); // 0x00000001820D0D10-0x00000001820D0D70
		public static bool IsHighSurrogate(uint c); // 0x00000001820D0C40-0x00000001820D0C60
		public static bool IsLowSurrogate(uint c); // 0x00000001820D0C90-0x00000001820D0CB0
		internal static uint ConvertToUTF32(uint highSurrogate, uint lowSurrogate); // 0x00000001820D0740-0x00000001820D0750
		internal static bool IsDiacriticalMark(uint c); // 0x00000001820D0A90-0x00000001820D0AE0
		internal static bool IsBaseGlyph(uint c); // 0x00000001820D08A0-0x00000001820D09B0
		internal static bool IsIgnorableForLigature(uint cp); // 0x00000001820D0C60-0x00000001820D0C90
		internal static bool IsEmoji(uint c); // 0x00000001820D0B60-0x00000001820D0BE0
		internal static bool IsEmojiPresentationForm(uint c); // 0x00000001820D0AE0-0x00000001820D0B60
		internal static bool IsHangul(uint c); // 0x00000001820D0BE0-0x00000001820D0C40
		internal static bool IsCJK(uint c); // 0x00000001820D09B0-0x00000001820D0A90
	}
}
