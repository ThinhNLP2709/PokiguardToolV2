/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Plugins
{
	internal static class StringPluginExtensions // TypeDefIndex: 13469
	{
		// Fields
		public static readonly char[] ScrambledCharsAll; // 0x00
		public static readonly char[] ScrambledCharsUppercase; // 0x08
		public static readonly char[] ScrambledCharsLowercase; // 0x10
		public static readonly char[] ScrambledCharsNumerals; // 0x18
		private static int _lastRndSeed; // 0x20
	
		// Constructors
		static StringPluginExtensions(); // 0x000000018072A5A0-0x000000018072A9C0
	
		// Extension methods
		internal static void ScrambleChars(this char[] chars); // 0x000000018072A500-0x000000018072A5A0
		internal static StringBuilder AppendScrambledChars(this StringBuilder buffer, int length, char[] chars); // 0x000000018072A3E0-0x000000018072A500
	}
}
