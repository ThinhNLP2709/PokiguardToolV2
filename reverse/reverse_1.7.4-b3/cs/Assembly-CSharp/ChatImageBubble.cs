/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class ChatImageBubble // TypeDefIndex: 487
{
	// Fields
	private static readonly Color SKELETON; // 0x00

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass11_0 // TypeDefIndex: 488
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass11_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FadeIn_b__0(float a); // 0x0000000180394FF0-0x0000000180395140
		internal void _FadeIn_b__1(); // 0x0000000180395140-0x0000000180395260
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass5_0 // TypeDefIndex: 489
	{
		// Fields
		public Image target; // 0x10
		public string wantedId; // 0x18
		public Action onExpired; // 0x20

		// Constructors
		public __c__DisplayClass5_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Attach_b__0(Texture2D tex); // 0x0000000180395260-0x00000001803955C0
		internal void _Attach_b__1(); // 0x00000001803955C0-0x0000000180395730
	}

	// Constructors
	static ChatImageBubble(); // 0x0000000180394FA0-0x0000000180394FF0

	// Methods
	public static bool Attach(GameObject row, Transform host, string id, int w, int h, long expiresAtMs, float thumbPx, Action onExpired); // 0x0000000180392BC0-0x00000001803932D0
	public static void Hide(Transform host); // 0x00000001803932D0-0x0000000180393610
	public static void EnsureRowFits(GameObject row); // 0x0000000180393610-0x0000000180394120
	public static long NowMs(); // 0x0000000180394120-0x00000001803941D0
	public static string RemainText(long expiresAtMs); // 0x00000001803941D0-0x00000001803943C0
	private static Image EnsureNode(Transform host, int w, int h, float thumbPx); // 0x00000001803943C0-0x0000000180394C20
	private static void FadeIn(Image img); // 0x0000000180394C20-0x0000000180394FA0
}

