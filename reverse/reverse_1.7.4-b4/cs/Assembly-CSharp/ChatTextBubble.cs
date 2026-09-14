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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ChatTextBubble : MonoBehaviour // TypeDefIndex: 518
{
	// Fields
	public const string FLAG_KEY = "chat.bubble"; // Metadata: 0x005EF572
	private const float PopInSec = 0.2f; // Metadata: 0x005EF57E
	private const float FadeOutSec = 0.3f; // Metadata: 0x005EF582
	private const float HoldMinSec = 3f; // Metadata: 0x005EF586
	private const float HoldPerCharSec = 0.05f; // Metadata: 0x005EF58A
	private const float HoldMaxSec = 7f; // Metadata: 0x005EF58E
	private const int MaxChars = 120; // Metadata: 0x005EF592
	private const int MaxLines = 5; // Metadata: 0x005EF594
	private const float MsgFontFrac = 0.034f; // Metadata: 0x005EF595
	private const float NameFontFrac = 0.026f; // Metadata: 0x005EF599
	private const float MaxWidthFrac = 0.32f; // Metadata: 0x005EF59D
	private const float MatchMaxWidthFrac = 0.26f; // Metadata: 0x005EF5A1
	private const float MatchMinBandFrac = 0.16f; // Metadata: 0x005EF5A5
	private const float BoardGapFrac = 0.012f; // Metadata: 0x005EF5A9
	private const float MinWidthFrac = 0.09f; // Metadata: 0x005EF5AD
	private const int MatchSortingOrder = 300; // Metadata: 0x005EF5B1
	private const float ScreenMarginFrac = 0.015f; // Metadata: 0x005EF5B3
	private static readonly Color NameColor; // 0x00
	private static readonly Color MsgColor; // 0x10
	private static readonly Color FallbackBg; // 0x20
	private CanvasGroup _group; // 0x20
	private Vector3 _baseScale; // 0x28
	private float _holdSec; // 0x34

	// Properties
	public static bool Enabled { get; } // 0x00000001803B9290-0x00000001803B9300 

	// Nested types
	[CompilerGenerated]
	private sealed class _PlayRoutine_d__36 : IEnumerator<object> // TypeDefIndex: 519
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatTextBubble __4__this; // 0x20
		private float _t_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayRoutine_d__36(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001803BCF50-0x00000001803BD710
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BD710-0x00000001803BD750
	}

	// Constructors
	public ChatTextBubble(); // 0x00000001803BCE60-0x00000001803BCED0
	static ChatTextBubble(); // 0x00000001803BCED0-0x00000001803BCF50

	// Methods
	public static bool ShowBesideRect(RectTransform anchor, string username, string text, Transform parent = null, RectTransform avoid = null); // 0x00000001803B9300-0x00000001803B9B70
	private static bool TryGetScreenRect(RectTransform rt, Camera cam, out Rect result); // 0x00000001803B9B70-0x00000001803B9F00
	public static bool ShowAbovePoint(Transform parent, Vector3 worldPoint, string username, string text, SpriteRenderer sortAbove); // 0x00000001803B9F00-0x00000001803BA310
	private static Canvas FindRootCanvas(Transform t); // 0x00000001803BA310-0x00000001803BA430
	private static Camera CameraOf(Canvas canvas); // 0x00000001803BA430-0x00000001803BA590
	private static bool Create(Transform parent, Canvas canvas, Camera cam, Vector3 worldPoint, Vector2 pivot, float nudgeXPx, string username, string text, SpriteRenderer sortAbove, float nudgeYPx, float maxWidthPx, float bandMinX, float bandMaxX, int fixedSortingOrder); // 0x00000001803BA590-0x00000001803BAF60
	private static Vector2 PixelsPerParentUnit(Transform parent, Camera cam); // 0x00000001803BAF60-0x00000001803BB260
	private void Build(RectTransform rect, Vector2 ppu, Vector2 pivot, Vector3 worldPoint, float nudgeXPx, float nudgeYPx, Camera cam, string username, string text, float maxWidthPx, float bandMinX, float bandMaxX); // 0x00000001803BB260-0x00000001803BC410
	private UnityEngine.UI.Text MakeText(string nodeName, int size, Color color, FontStyle style); // 0x00000001803BC410-0x00000001803BC780
	private static void Place(RectTransform rt, float x, float y, float w, float h); // 0x00000001803BC780-0x00000001803BC7D0
	private static void ClampIntoBand(RectTransform rect, Camera cam, Vector2 ppu, float signX, float signY, float bandMinX, float bandMaxX); // 0x00000001803BC7D0-0x00000001803BCDC0
	[IteratorStateMachine(typeof(_PlayRoutine_d__36))]
	private IEnumerator PlayRoutine(); // 0x00000001803BCDC0-0x00000001803BCE60
}

