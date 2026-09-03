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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	internal class CStreamWriter : StreamWriter // TypeDefIndex: 3712
	{
		// Fields
		private TermInfoDriver driver; // 0x70
	
		// Constructors
		public CStreamWriter(Stream stream, Encoding encoding, bool leaveOpen); // 0x00000001815D9910-0x00000001815D9A70
	
		// Methods
		public override void Write(char[] buffer, int index, int count); // 0x00000001815D9510-0x00000001815D9750
		public override void Write(char val); // 0x00000001815D9750-0x00000001815D9860
		public void InternalWriteString(string val); // 0x00000001815D9490-0x00000001815D94B0
		public void InternalWriteChar(char val); // 0x00000001815D9450-0x00000001815D9470
		public void InternalWriteChars(char[] buffer, int n); // 0x00000001815D9470-0x00000001815D9490
		public override void Write(char[] val); // 0x00000001815D98D0-0x00000001815D9910
		public override void Write(string val); // 0x00000001815D9860-0x00000001815D98D0
		public override void WriteLine(string val); // 0x00000001815D94B0-0x00000001815D9510
	}
}
