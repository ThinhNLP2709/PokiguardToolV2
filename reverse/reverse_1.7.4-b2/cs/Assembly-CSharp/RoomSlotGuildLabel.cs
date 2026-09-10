/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class RoomSlotGuildLabel // TypeDefIndex: 59
{
	// Fields
	public const string NODE = "txtGuild"; // Metadata: 0x0068AA69
	private const float PAD = 5f; // Metadata: 0x0068AA72
	private const float GAP = 2f; // Metadata: 0x0068AA76
	private const float SOFT_WEIGHT = 0.02f; // Metadata: 0x0068AA7A
	private const float DIST_WEIGHT = 0.05f; // Metadata: 0x0068AA7E
	private const float MIN_H = 12f; // Metadata: 0x0068AA82
	private const float MAX_H = 26f; // Metadata: 0x0068AA86
	private static readonly Color LABEL_COLOR; // 0x00
	private static readonly Color OUTLINE_COLOR; // 0x10
	public const string TXT = "txt"; // Metadata: 0x0068AA8A
	private static readonly Color PILL_COLOR; // 0x20
	private const float PILL_PAD_X = 6f; // Metadata: 0x0068AA8E
	private const float PILL_PAD_Y = 2f; // Metadata: 0x0068AA92
	public static Placement Last; // 0x30

	// Nested types
	public struct Placement // TypeDefIndex: 60
	{
		// Fields
		public Rect label; // 0x00
		public Rect slot; // 0x10
		public Rect name; // 0x20
		public float hardOverlap; // 0x30
		public float softOverlap; // 0x34
		public int candidate; // 0x38
		public int candidates; // 0x3C
		public int hardCount; // 0x40
		public int softCount; // 0x44
		public bool retried; // 0x48
		public List<string> obstacles; // 0x50
	}

	// Constructors
	static RoomSlotGuildLabel(); // 0x0000000180421520-0x00000001804215A0

	// Methods
	public static void Hide(Transform slotRoot); // 0x000000018041FBD0-0x000000018041FDD0
	public static UnityEngine.UI.Text Apply(Transform slotRoot, UnityEngine.UI.Text sample, string guildName); // 0x000000018041D4D0-0x000000018041D850
	private static UnityEngine.UI.Text FindLabel(Transform slotRoot); // 0x000000018041ED20-0x000000018041EE70
	private static UnityEngine.UI.Text TextOf(Transform node); // 0x0000000180421420-0x0000000180421520
	private static RectTransform CardOf(UnityEngine.UI.Text label); // 0x000000018041D9F0-0x000000018041DB30
	private static UnityEngine.UI.Text FindAnySample(RectTransform slotRt); // 0x000000018041EAF0-0x000000018041ED20
	private static UnityEngine.UI.Text GetOrCreate(RectTransform parent, UnityEngine.UI.Text sample, RectTransform slotRt); // 0x000000018041EE70-0x000000018041F650
	private static void EnsureSorting(UnityEngine.UI.Text label, UnityEngine.UI.Text sample, RectTransform slotRt); // 0x000000018041E6C0-0x000000018041EA20
	private static int MaxSpriteOrder(RectTransform slotRt, out bool hasSprite); // 0x000000018041FDD0-0x000000018041FF10
	private static Font FallbackFont(); // 0x000000018041EA20-0x000000018041EAF0
	private static void Place(UnityEngine.UI.Text label, RectTransform slotRt, RectTransform parent, UnityEngine.UI.Text sample); // 0x0000000180420060-0x0000000180420820
	private static float Score(Placement p); // 0x0000000180420CD0-0x0000000180420CF0
	private static Placement Solve(Rect slot, Rect name, float w, float h, List<Rect> hard, List<Rect> soft); // 0x0000000180420CF0-0x0000000180421420
	private static Vector2 ClampInside(Vector2 c, float w, float h, Rect slot); // 0x000000018041DB30-0x000000018041DC70
	private static float Overlap(Rect r, List<Rect> others); // 0x000000018041FF10-0x0000000180420060
	private static void Collect(RectTransform slotRt, Transform parent, GameObject label, Rect slot, List<Rect> hard, List<string> names, List<Rect> soft); // 0x000000018041DC70-0x000000018041E6C0
	private static bool ActiveWithin(Transform t, Transform root); // 0x000000018041D3E0-0x000000018041D4D0
	private static Rect GlyphRect(UnityEngine.UI.Text t, Transform parent); // 0x000000018041F650-0x000000018041FBD0
	private static Rect RectInParent(RectTransform rt, Transform parent); // 0x00000001804209E0-0x0000000180420CD0
	private static Rect PointsInParent(Transform from, Transform parent, params Vector3[] localPts); // 0x0000000180420820-0x00000001804209E0
	private static Rect BoundsInParent(Bounds b, Transform parent); // 0x000000018041D850-0x000000018041D9F0
}

