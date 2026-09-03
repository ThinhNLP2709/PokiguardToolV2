/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class CharEntityEncoderFallbackBuffer : EncoderFallbackBuffer // TypeDefIndex: 6700
	{
		// Fields
		private CharEntityEncoderFallback parent; // 0x30
		private string charEntity; // 0x38
		private int charEntityIndex; // 0x40
	
		// Properties
		public override int Remaining { get; } // 0x0000000181942FB0-0x0000000181942FE0 
	
		// Constructors
		internal CharEntityEncoderFallbackBuffer(CharEntityEncoderFallback parent); // 0x0000000181942F50-0x0000000181942FB0
	
		// Methods
		public override bool Fallback(char charUnknown, int index); // 0x0000000181942940-0x0000000181942BC0
		public override bool Fallback(char charUnknownHigh, char charUnknownLow, int index); // 0x0000000181942BC0-0x0000000181942ED0
		public override char GetNextChar(); // 0x0000000181942ED0-0x0000000181942F20
		public override bool MovePrevious(); // 0x0000000181942F20-0x0000000181942F40
		public override void Reset(); // 0x000000018112ACB0-0x000000018112ACC0
		private int SurrogateCharToUtf32(char highSurrogate, char lowSurrogate); // 0x0000000181942F40-0x0000000181942F50
	}
}
