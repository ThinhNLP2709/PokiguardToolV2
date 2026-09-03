/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 45: UnityEngine.UnityWebRequestModule.dll - Assembly: UnityEngine.UnityWebRequestModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15315-15336

namespace UnityEngine
{
	[VisibleToOtherModules(new string[1] {"UnityEngine.UnityWebRequestWWWModule" })]
	internal class WWWTranscoder // TypeDefIndex: 15320
	{
		// Fields
		private static readonly byte[] ucHexChars; // 0x00
		private static readonly byte[] lcHexChars; // 0x08
		private static readonly byte urlEscapeChar; // 0x10
		private static readonly byte[] urlSpace; // 0x18
		private static readonly byte[] dataSpace; // 0x20
		private static readonly byte[] urlForbidden; // 0x28
		private static readonly byte qpEscapeChar; // 0x30
		private static readonly byte[] qpSpace; // 0x38
		private static readonly byte[] qpForbidden; // 0x40
	
		// Constructors
		static WWWTranscoder(); // 0x00000001825D0750-0x00000001825D0A70
	
		// Methods
		private static byte Hex2Byte(byte[] b, int offset); // 0x00000001825D05E0-0x00000001825D0660
		private static void Byte2Hex(byte b, byte[] hexChars, out byte byte0, out byte byte1); // 0x00000001825CFD20-0x00000001825CFD60
		public static byte[] URLEncode(byte[] toEncode); // 0x00000001825D06D0-0x00000001825D0750
		public static byte[] Encode(byte[] input, byte escapeChar, byte[] space, byte[] forbidden, bool uppercase); // 0x00000001825D01B0-0x00000001825D05E0
		private static bool ByteArrayContains(byte[] array, byte b); // 0x00000001825CFD60-0x00000001825CFDB0
		public static byte[] URLDecode(byte[] toEncode); // 0x00000001825D0660-0x00000001825D06D0
		private static bool ByteSubArrayEquals(byte[] array, int index, byte[] comperand); // 0x00000001825CFDB0-0x00000001825CFE40
		public static byte[] Decode(byte[] input, byte escapeChar, byte[] space); // 0x00000001825CFE40-0x00000001825D01B0
	}
}
