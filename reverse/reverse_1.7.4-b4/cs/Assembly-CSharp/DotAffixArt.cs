/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

internal static class DotAffixArt // TypeDefIndex: 2179
{
	// Fields
	private static Sprite _fill; // 0x00
	private static Sprite _frame; // 0x08
	private static Sprite _ring; // 0x10
	private static Sprite _dot; // 0x18

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2180
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<float, float> __9__8_0; // 0x08
		public static Func<float, float> __9__9_0; // 0x10

		// Constructors
		static __c(); // 0x0000000180A39DD0-0x0000000180A39E70
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal float _RoundedFill_b__8_0(float dist); // 0x0000000180A39E70-0x0000000180A39EA0
		internal float _RoundedFrame_b__9_0(float dist); // 0x0000000180A39EA0-0x0000000180A39F10
	}

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics(); // 0x0000000180A38C60-0x0000000180A38E50
	internal static Sprite RoundedFill(); // 0x0000000180A38E50-0x0000000180A39130
	internal static Sprite RoundedFrame(); // 0x0000000180A39130-0x0000000180A39420
	internal static Sprite Ring(); // 0x0000000180A39420-0x0000000180A395C0
	private static Sprite Build(string name, Func<float, float> alphaOf); // 0x0000000180A395C0-0x0000000180A39950
	private static Sprite BuildCircle(string name, bool hollow); // 0x0000000180A39950-0x0000000180A39CC0
	private static Texture2D NewTex(string name, int size); // 0x0000000180A39CC0-0x0000000180A39DD0
}

