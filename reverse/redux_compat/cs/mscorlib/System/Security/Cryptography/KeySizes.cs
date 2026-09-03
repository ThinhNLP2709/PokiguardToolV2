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

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public sealed class KeySizes // TypeDefIndex: 2784
	{
		// Fields
		private int m_minSize; // 0x10
		private int m_maxSize; // 0x14
		private int m_skipSize; // 0x18
	
		// Properties
		public int MinSize { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public int MaxSize { get; } // 0x0000000180A5E110-0x0000000180A5E120 
		public int SkipSize { get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Constructors
		public KeySizes(int minSize, int maxSize, int skipSize); // 0x0000000181491200-0x0000000181491250
	
		// Methods
		internal bool IsLegal(int keySize); // 0x00000001814911D0-0x0000000181491200
		internal static bool IsLegalKeySize(KeySizes[] legalKeys, int size); // 0x0000000181491140-0x00000001814911D0
	}
}
