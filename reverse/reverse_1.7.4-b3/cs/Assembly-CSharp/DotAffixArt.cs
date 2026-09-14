/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

internal static class DotAffixArt // TypeDefIndex: 2177
{
	// Fields
	private static Sprite _fill; // 0x00
	private static Sprite _frame; // 0x08
	private static Sprite _ring; // 0x10
	private static Sprite _dot; // 0x18

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2178
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<float, float> __9__8_0; // 0x08
		public static Func<float, float> __9__9_0; // 0x10

		// Constructors
		static __c(); // 0x0000000180A6ECF0-0x0000000180A6ED90
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal float _RoundedFill_b__8_0(float dist); // 0x0000000180A6ED90-0x0000000180A6EDC0
		internal float _RoundedFrame_b__9_0(float dist); // 0x0000000180A6EDC0-0x0000000180A6EE30
	}

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics(); // 0x0000000180A6DB80-0x0000000180A6DD70
	internal static Sprite RoundedFill(); // 0x0000000180A6DD70-0x0000000180A6E050
	internal static Sprite RoundedFrame(); // 0x0000000180A6E050-0x0000000180A6E340
	internal static Sprite Ring(); // 0x0000000180A6E340-0x0000000180A6E4E0
	private static Sprite Build(string name, Func<float, float> alphaOf); // 0x0000000180A6E4E0-0x0000000180A6E870
	private static Sprite BuildCircle(string name, bool hollow); // 0x0000000180A6E870-0x0000000180A6EBE0
	private static Texture2D NewTex(string name, int size); // 0x0000000180A6EBE0-0x0000000180A6ECF0
}

