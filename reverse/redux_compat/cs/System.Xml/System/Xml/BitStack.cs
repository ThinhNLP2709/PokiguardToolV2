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
	internal class BitStack // TypeDefIndex: 6696
	{
		// Fields
		private uint[] bitStack; // 0x10
		private int stackPos; // 0x18
		private uint curr; // 0x1C
	
		// Constructors
		public BitStack(); // 0x0000000181942560-0x0000000181942580
	
		// Methods
		public void PushBit(bool bit); // 0x0000000181942380-0x0000000181942480
		public bool PopBit(); // 0x00000001819422E0-0x0000000181942340
		public bool PeekBit(); // 0x00000001819422D0-0x00000001819422E0
		private void PushCurr(); // 0x0000000181942480-0x0000000181942560
		private void PopCurr(); // 0x0000000181942340-0x0000000181942380
	}
}
