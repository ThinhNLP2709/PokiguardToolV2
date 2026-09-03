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
	internal class CharEntityEncoderFallback : EncoderFallback // TypeDefIndex: 6699
	{
		// Fields
		private CharEntityEncoderFallbackBuffer fallbackBuffer; // 0x10
		private int[] textContentMarks; // 0x18
		private int endMarkPos; // 0x20
		private int curMarkPos; // 0x24
		private int startOffset; // 0x28
	
		// Properties
		public override int MaxCharCount { get; } // 0x0000000180740840-0x0000000180740850 
		internal int StartOffset { set; } // 0x0000000180378100-0x0000000180378110
	
		// Constructors
		internal CharEntityEncoderFallback(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override EncoderFallbackBuffer CreateFallbackBuffer(); // 0x0000000181943040-0x00000001819430E0
		internal void Reset(int[] textContentMarks, int endMarkPos); // 0x00000001819430E0-0x0000000181943120
		internal bool CanReplaceAt(int index); // 0x0000000181942FE0-0x0000000181943040
	}
}
