/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class LoginFieldKit // TypeDefIndex: 1048
{
	// Fields
	public static readonly Color PLACEHOLDER; // 0x00
	public static readonly Color COUNTER; // 0x10
	public static readonly Color NOTE; // 0x20
	public static readonly Color NOTE_SOFT; // 0x30
	private static readonly TextGenerator _ink; // 0x40

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass11_0 // TypeDefIndex: 1049
	{
		// Fields
		public LoginField captured; // 0x10
		public float rp; // 0x48

		// Constructors
		public __c__DisplayClass11_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Build_b__0(); // 0x0000000180650500-0x00000001806505D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 1050
	{
		// Fields
		public Image capturedIcon; // 0x10
		public UnityEngine.UI.Text lb; // 0x18

		// Constructors
		public __c__DisplayClass19_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EyeButton_b__0(); // 0x00000001806505D0-0x0000000180650880
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 1051
	{
		// Fields
		public Image captured; // 0x10
		public UnityEngine.UI.Text cap; // 0x18

		// Constructors
		public __c__DisplayClass20_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetEyeState_b__0(); // 0x0000000180650880-0x0000000180650B30
	}

	// Constructors
	static LoginFieldKit(); // 0x00000001806503D0-0x0000000180650500

	// Methods
	public static void EnsureTouch(Graphic hit, float w, float h); // 0x000000018064D960-0x000000018064DAD0
	public static float InkWidth(UnityEngine.UI.Text t); // 0x000000018064DAD0-0x000000018064E000
	public static float Fs(float raw); // 0x000000018064E000-0x000000018064E0F0
	public static LoginField Build(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, string iconSprite, string placeholder, int limit, InputField.ContentType type, float rightPad); // 0x000000018064E0F0-0x000000018064F0A0
	private static void Repad(LoginField f, float left, float right); // 0x000000018064F0A0-0x000000018064F560
	private static string Suffix(string fieldName); // 0x000000018064F560-0x000000018064F5F0
	public static char FilterUser(string text, int index, char ch); // 0x000000018064F5F0-0x000000018064F630
	public static char FilterUserLower(string text, int index, char ch); // 0x000000018064F630-0x000000018064F690
	public static void GoldLabel(UnityEngine.UI.Text label); // 0x000000018064F690-0x000000018064F8E0
	public static char FilterPassword(string text, int index, char ch); // 0x000000018064F8E0-0x000000018064F940
	public static void SetPasswordVisible(InputField input, bool show); // 0x000000018064F940-0x000000018064FAA0
	public static Button EyeButton(MonoBehaviour host, Transform parent, float x, float y, float size, out Image icon, out UnityEngine.UI.Text label, UnityAction onTap); // 0x000000018064FAA0-0x000000018064FFA0
	public static void SetEyeState(MonoBehaviour host, Image icon, UnityEngine.UI.Text label, bool visible); // 0x000000018064FFA0-0x00000001806503D0
}

