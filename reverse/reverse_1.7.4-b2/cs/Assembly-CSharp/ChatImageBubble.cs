/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class ChatImageBubble // TypeDefIndex: 433
{
	// Fields
	public const float DEFAULT_THUMB_PX = 120f; // Metadata: 0x0068B276
	private const float MAX_WIDTH_PX = 240f; // Metadata: 0x0068B27A
	private static readonly Color SKELETON; // 0x00
	private const float FADE_SECONDS = 0.2f; // Metadata: 0x0068B27E
	public const string NODE_NAME = "imgImage"; // Metadata: 0x0068B282

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass11_0 // TypeDefIndex: 434
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass11_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FadeIn_b__0(float a); // 0x0000000180378870-0x0000000180378940
		internal void _FadeIn_b__1(); // 0x0000000180378940-0x00000001803789E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass5_0 // TypeDefIndex: 435
	{
		// Fields
		public Image target; // 0x10
		public string wantedId; // 0x18
		public Action onExpired; // 0x20

		// Constructors
		public __c__DisplayClass5_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Attach_b__0(Texture2D tex); // 0x00000001803789E0-0x0000000180378BC0
		internal void _Attach_b__1(); // 0x0000000180378BC0-0x0000000180378C60
	}

	// Constructors
	static ChatImageBubble(); // 0x000000018036D9B0-0x000000018036D9F0

	// Methods
	public static bool Attach(GameObject row, Transform host, string id, int w, int h, long expiresAtMs, float thumbPx, Action onExpired); // 0x000000018036C550-0x000000018036CA70
	public static void Hide(Transform host); // 0x000000018036D650-0x000000018036D790
	public static void EnsureRowFits(GameObject row); // 0x000000018036CEE0-0x000000018036D3F0
	public static long NowMs(); // 0x000000018036D790-0x000000018036D800
	public static string RemainText(long expiresAtMs); // 0x000000018036D800-0x000000018036D9B0
	private static Image EnsureNode(Transform host, int w, int h, float thumbPx); // 0x000000018036CA70-0x000000018036CEE0
	private static void FadeIn(Image img); // 0x000000018036D3F0-0x000000018036D650
}

