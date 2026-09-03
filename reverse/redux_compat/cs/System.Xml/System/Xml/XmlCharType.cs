/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal struct XmlCharType // TypeDefIndex: 6866
	{
		// Fields
		private static object s_Lock; // 0x00
		private static byte[] s_CharProperties; // 0x08
		internal byte[] charProperties; // 0x00
	
		// Properties
		private static object StaticLock { get; } // 0x0000000181A9A3D0-0x0000000181A9A460 
		public static XmlCharType Instance { get; } // 0x0000000181A9A350-0x0000000181A9A3D0 
	
		// Constructors
		private XmlCharType(byte[] charProperties); // 0x0000000180E02C90-0x0000000180E02CA0
	
		// Methods
		private static void InitInstance(); // 0x0000000181A99600-0x0000000181A99BF0
		private static void SetProperties(byte[] chProps, string ranges, byte value); // 0x0000000181A9A240-0x0000000181A9A310
		public bool IsWhiteSpace(char ch); // 0x0000000181A9A200-0x0000000181A9A240
		public bool IsNCNameSingleChar(char ch); // 0x0000000181A99CD0-0x0000000181A99D10
		public bool IsStartNCNameSingleChar(char ch); // 0x0000000181A9A170-0x0000000181A9A1B0
		public bool IsNameSingleChar(char ch); // 0x0000000181A99D50-0x0000000181A99D90
		public bool IsCharData(char ch); // 0x0000000181A99BF0-0x0000000181A99C30
		public bool IsPubidChar(char ch); // 0x0000000181A99FF0-0x0000000181A9A070
		internal bool IsTextChar(char ch); // 0x0000000181A9A1C0-0x0000000181A9A200
		public bool IsLetter(char ch); // 0x0000000181A99C40-0x0000000181A99C80
		public bool IsNCNameCharXml4e(char ch); // 0x0000000181A99C90-0x0000000181A99CD0
		public bool IsStartNCNameCharXml4e(char ch); // 0x0000000181A9A130-0x0000000181A9A170
		public bool IsNameCharXml4e(char ch); // 0x0000000181A99D10-0x0000000181A99D50
		public static bool IsDigit(char ch); // 0x00000001815E8E80-0x00000001815E8E90
		internal static bool IsHighSurrogate(int ch); // 0x0000000181A99C30-0x0000000181A99C40
		internal static bool IsLowSurrogate(int ch); // 0x0000000181A99C80-0x0000000181A99C90
		internal static bool IsSurrogate(int ch); // 0x0000000181A9A1B0-0x0000000181A9A1C0
		internal static int CombineSurrogateChar(int lowChar, int highChar); // 0x0000000181A995E0-0x0000000181A99600
		internal static void SplitSurrogateChar(int combinedChar, out char lowChar, out char highChar); // 0x0000000181A9A310-0x0000000181A9A350
		internal bool IsOnlyWhitespace(string str); // 0x0000000181A99F60-0x0000000181A99FF0
		internal int IsOnlyWhitespaceWithPos(string str); // 0x0000000181A99EE0-0x0000000181A99F60
		internal int IsOnlyCharData(string str); // 0x0000000181A99D90-0x0000000181A99E60
		internal static bool IsOnlyDigits(string str, int startPos, int len); // 0x0000000181A99E60-0x0000000181A99EE0
		internal int IsPublicId(string str); // 0x0000000181A9A070-0x0000000181A9A130
		private static bool InRange(int value, int start, int end); // 0x0000000181474180-0x0000000181474190
	}
}
