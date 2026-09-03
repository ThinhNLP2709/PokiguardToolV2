/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	internal static class EncodingTable // TypeDefIndex: 3445
	{
		// Fields
		internal static InternalEncodingDataItem[] encodingDataPtr; // 0x00
		internal static InternalCodePageDataItem[] codePageDataPtr; // 0x08
		private static int lastEncodingItem; // 0x10
		private static Dictionary<string, int> hashByName; // 0x18
		private static Dictionary<int, CodePageDataItem> hashByCodePage; // 0x20
	
		// Constructors
		static EncodingTable(); // 0x0000000181579910-0x0000000181584080
	
		// Methods
		private static int GetNumEncodingItems(); // 0x0000000181579870-0x00000001815798D0
		private static InternalEncodingDataItem ENC(string name, ushort cp); // 0x0000000181579330-0x0000000181579370
		private static InternalCodePageDataItem MapCodePageDataItem(ushort cp, ushort fcp, string names, uint flags); // 0x00000001815798D0-0x0000000181579910
		private static int internalGetCodePageFromName(string name); // 0x0000000181584080-0x00000001815842C0
		internal static int GetCodePageFromName(string name); // 0x0000000181579640-0x0000000181579870
		internal static CodePageDataItem GetCodePageDataItem(int codepage); // 0x0000000181579370-0x0000000181579640
	}
}
