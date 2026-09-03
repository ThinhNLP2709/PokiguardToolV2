/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	internal struct DisableMediaInsertionPrompt : IDisposable // TypeDefIndex: 3636
	{
		// Fields
		private bool _disableSuccess; // 0x00
		private uint _oldMode; // 0x04
		private static bool useUWPFallback; // 0x00
	
		// Methods
		public static DisableMediaInsertionPrompt Create(); // 0x00000001815A7670-0x00000001815A76F0
		public void Dispose(); // 0x00000001815A76F0-0x00000001815A7720
	}
}
