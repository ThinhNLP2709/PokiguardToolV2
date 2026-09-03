/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Util
{
	internal sealed class Parser // TypeDefIndex: 2756
	{
		// Fields
		private SecurityDocument _doc; // 0x10
		private Tokenizer _t; // 0x18
	
		// Constructors
		private Parser(Tokenizer t); // 0x000000018147FC90-0x000000018147FD40
		internal Parser(string input); // 0x000000018147FB90-0x000000018147FC90
	
		// Methods
		internal SecurityElement GetTopElement(); // 0x000000018147F620-0x000000018147F650
		private void GetRequiredSizes(TokenizerStream stream, ref int index); // 0x000000018147EE50-0x000000018147F620
		private int DetermineFormat(TokenizerStream stream); // 0x000000018147EC10-0x000000018147EE50
		private void ParseContents(); // 0x000000018147F650-0x000000018147FB90
	}
}
