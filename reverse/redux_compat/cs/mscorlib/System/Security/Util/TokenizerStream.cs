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

namespace System.Security.Util
{
	internal sealed class TokenizerStream // TypeDefIndex: 2764
	{
		// Fields
		private int m_countTokens; // 0x10
		private TokenizerShortBlock m_headTokens; // 0x18
		private TokenizerShortBlock m_lastTokens; // 0x20
		private TokenizerShortBlock m_currentTokens; // 0x28
		private int m_indexTokens; // 0x30
		private TokenizerStringBlock m_headStrings; // 0x38
		private TokenizerStringBlock m_currentStrings; // 0x40
		private int m_indexStrings; // 0x48
	
		// Constructors
		internal TokenizerStream(); // 0x0000000181484A30-0x0000000181484B90
	
		// Methods
		internal void AddToken(short token); // 0x0000000181484640-0x0000000181484780
		internal void AddString(string str); // 0x0000000181484500-0x0000000181484640
		internal void Reset(); // 0x0000000181484930-0x0000000181484990
		internal short GetNextFullToken(); // 0x0000000181484780-0x0000000181484810
		internal short GetNextToken(); // 0x0000000181484890-0x00000001814848B0
		internal string GetNextString(); // 0x0000000181484810-0x0000000181484890
		internal void ThrowAwayNextString(); // 0x0000000181484A20-0x0000000181484A30
		internal void TagLastToken(short tag); // 0x0000000181484990-0x0000000181484A20
		internal int GetTokenCount(); // 0x00000001802E64B0-0x00000001802E64C0
		internal void GoToPosition(int position); // 0x00000001814848B0-0x0000000181484930
	}
}
