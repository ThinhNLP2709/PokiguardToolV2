/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class RoomSlotGuildLabel // TypeDefIndex: 60
{
	// Fields
	private static readonly Color LABEL_COLOR; // 0x00
	private static readonly Color OUTLINE_COLOR; // 0x10
	private static readonly Color PILL_COLOR; // 0x20
	public static Placement Last; // 0x30

	// Nested types
	public struct Placement // TypeDefIndex: 61
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
	static RoomSlotGuildLabel(); // 0x0000000180466DD0-0x0000000180466E50

	// Methods
	public static void Hide(Transform slotRoot); // 0x0000000180460F50-0x0000000180461250
	public static UnityEngine.UI.Text Apply(Transform slotRoot, UnityEngine.UI.Text sample, string guildName); // 0x0000000180461250-0x0000000180461840
	private static UnityEngine.UI.Text FindLabel(Transform slotRoot); // 0x0000000180461840-0x0000000180461B90
	private static UnityEngine.UI.Text TextOf(Transform node); // 0x0000000180461B90-0x0000000180461E60
	private static RectTransform CardOf(UnityEngine.UI.Text label); // 0x0000000180461E60-0x00000001804620F0
	private static UnityEngine.UI.Text FindAnySample(RectTransform slotRt); // 0x00000001804620F0-0x0000000180462570
	private static UnityEngine.UI.Text GetOrCreate(RectTransform parent, UnityEngine.UI.Text sample, RectTransform slotRt); // 0x0000000180462570-0x0000000180463350
	private static void EnsureSorting(UnityEngine.UI.Text label, UnityEngine.UI.Text sample, RectTransform slotRt); // 0x0000000180463350-0x0000000180463860
	private static int MaxSpriteOrder(RectTransform slotRt, out bool hasSprite); // 0x0000000180463860-0x0000000180463A50
	private static Font FallbackFont(); // 0x0000000180463A50-0x0000000180463BC0
	private static void Place(UnityEngine.UI.Text label, RectTransform slotRt, RectTransform parent, UnityEngine.UI.Text sample); // 0x0000000180463BC0-0x00000001804645C0
	private static float Score(Placement p); // 0x00000001804645C0-0x00000001804645E0
	private static Placement Solve(Rect slot, Rect name, float w, float h, List<Rect> hard, List<Rect> soft); // 0x00000001804645E0-0x0000000180464D70
	private static Vector2 ClampInside(Vector2 c, float w, float h, Rect slot); // 0x0000000180464D70-0x0000000180464EB0
	private static float Overlap(Rect r, List<Rect> others); // 0x0000000180464EB0-0x0000000180465030
	private static void Collect(RectTransform slotRt, Transform parent, GameObject label, Rect slot, List<Rect> hard, List<string> names, List<Rect> soft); // 0x0000000180465030-0x0000000180465F10
	private static bool ActiveWithin(Transform t, Transform root); // 0x0000000180465F10-0x0000000180466160
	private static Rect GlyphRect(UnityEngine.UI.Text t, Transform parent); // 0x0000000180466160-0x00000001804666D0
	private static Rect RectInParent(RectTransform rt, Transform parent); // 0x00000001804666D0-0x0000000180466910
	private static Rect PointsInParent(Transform from, Transform parent, params Vector3[] localPts); // 0x0000000180466910-0x0000000180466BA0
	private static Rect BoundsInParent(Bounds b, Transform parent); // 0x0000000180466BA0-0x0000000180466DD0
}

