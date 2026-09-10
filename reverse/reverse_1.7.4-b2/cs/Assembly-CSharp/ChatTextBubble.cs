/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ChatTextBubble : MonoBehaviour // TypeDefIndex: 463
{
	// Fields
	public const string FLAG_KEY = "chat.bubble"; // Metadata: 0x0068B2E2
	private const float PopInSec = 0.2f; // Metadata: 0x0068B2EE
	private const float FadeOutSec = 0.3f; // Metadata: 0x0068B2F2
	private const float HoldMinSec = 3f; // Metadata: 0x0068B2F6
	private const float HoldPerCharSec = 0.05f; // Metadata: 0x0068B2FA
	private const float HoldMaxSec = 7f; // Metadata: 0x0068B2FE
	private const int MaxChars = 120; // Metadata: 0x0068B302
	private const int MaxLines = 5; // Metadata: 0x0068B304
	private const float MsgFontFrac = 0.034f; // Metadata: 0x0068B305
	private const float NameFontFrac = 0.026f; // Metadata: 0x0068B309
	private const float MaxWidthFrac = 0.32f; // Metadata: 0x0068B30D
	private const float MatchMaxWidthFrac = 0.26f; // Metadata: 0x0068B311
	private const float MatchMinBandFrac = 0.16f; // Metadata: 0x0068B315
	private const float BoardGapFrac = 0.012f; // Metadata: 0x0068B319
	private const float MinWidthFrac = 0.09f; // Metadata: 0x0068B31D
	private const int MatchSortingOrder = 300; // Metadata: 0x0068B321
	private const float ScreenMarginFrac = 0.015f; // Metadata: 0x0068B323
	private static readonly Color NameColor; // 0x00
	private static readonly Color MsgColor; // 0x10
	private static readonly Color FallbackBg; // 0x20
	private CanvasGroup _group; // 0x20
	private Vector3 _baseScale; // 0x28
	private float _holdSec; // 0x34

	// Properties
	public static bool Enabled { get; } // 0x000000018038C1D0-0x000000018038C230 

	// Nested types
	[CompilerGenerated]
	private sealed class _PlayRoutine_d__36 : IEnumerator<object> // TypeDefIndex: 464
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatTextBubble __4__this; // 0x20
		private float _t_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayRoutine_d__36(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018038E0A0-0x000000018038E4E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018038E4E0-0x000000018038E520
	}

	// Constructors
	public ChatTextBubble(); // 0x000000018038C1A0-0x000000018038C1D0
	static ChatTextBubble(); // 0x000000018038C120-0x000000018038C1A0

	// Methods
	public static bool ShowBesideRect(RectTransform anchor, string username, string text, Transform parent = null, RectTransform avoid = null); // 0x000000018038B900-0x000000018038BE60
	private static bool TryGetScreenRect(RectTransform rt, Camera cam, out Rect result); // 0x000000018038BE60-0x000000018038C120
	public static bool ShowAbovePoint(Transform parent, Vector3 worldPoint, string username, string text, SpriteRenderer sortAbove); // 0x000000018038B660-0x000000018038B900
	private static Canvas FindRootCanvas(Transform t); // 0x000000018038B120-0x000000018038B1B0
	private static Camera CameraOf(Canvas canvas); // 0x000000018038A5A0-0x000000018038A670
	private static bool Create(Transform parent, Canvas canvas, Camera cam, Vector3 worldPoint, Vector2 pivot, float nudgeXPx, string username, string text, SpriteRenderer sortAbove, float nudgeYPx, float maxWidthPx, float bandMinX, float bandMaxX, int fixedSortingOrder); // 0x000000018038AAD0-0x000000018038B120
	private static Vector2 PixelsPerParentUnit(Transform parent, Camera cam); // 0x000000018038B390-0x000000018038B5A0
	private void Build(RectTransform rect, Vector2 ppu, Vector2 pivot, Vector3 worldPoint, float nudgeXPx, float nudgeYPx, Camera cam, string username, string text, float maxWidthPx, float bandMinX, float bandMaxX); // 0x0000000180389B10-0x000000018038A5A0
	private UnityEngine.UI.Text MakeText(string nodeName, int size, Color color, FontStyle style); // 0x000000018038B1B0-0x000000018038B390
	private static void Place(RectTransform rt, float x, float y, float w, float h); // 0x000000018038B5A0-0x000000018038B5F0
	private static void ClampIntoBand(RectTransform rect, Camera cam, Vector2 ppu, float signX, float signY, float bandMinX, float bandMaxX); // 0x000000018038A670-0x000000018038AAD0
	[IteratorStateMachine(typeof(_PlayRoutine_d__36))]
	private IEnumerator PlayRoutine(); // 0x000000018038B5F0-0x000000018038B660
}

