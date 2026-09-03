/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Util;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	internal sealed class SharedStatics // TypeDefIndex: 2434
	{
		// Fields
		private static readonly SharedStatics _sharedStatics; // 0x00
		private Tokenizer.StringMaker _maker; // 0x10
	
		// Constructors
		private SharedStatics(); // 0x00000001802E76C0-0x00000001802E76D0
		static SharedStatics(); // 0x000000018165A020-0x000000018165A080
	
		// Methods
		public static Tokenizer.StringMaker GetSharedStringMaker(); // 0x0000000181659D90-0x0000000181659F10
		public static void ReleaseSharedStringMaker(ref Tokenizer.StringMaker maker); // 0x0000000181659F10-0x000000018165A020
	}
}
