/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class EventTrackArt // TypeDefIndex: 607
{
	// Fields
	public static readonly Color OUTLINE; // 0x00
	public static readonly Color PRIMARY_FALLBACK; // 0x10
	public static readonly Color ACCENT_FALLBACK; // 0x20
	private static readonly Regex PREFIX_RE; // 0x30
	private static readonly Dictionary<string, Sprite> _cache; // 0x38
	private static readonly Color CHEST_1; // 0x40
	private static readonly Color CHEST_2; // 0x50
	private static readonly Color CHEST_3; // 0x60

	// Constructors
	static EventTrackArt(); // 0x0000000180433160-0x0000000180433790

	// Methods
	public static string Prefix(EventTrackTheme t); // 0x000000018042F060-0x000000018042F1D0
	public static string PathOf(EventTrackTheme t, string name); // 0x000000018042F1D0-0x000000018042F280
	public static string ChestName(int tier); // 0x000000018042F280-0x000000018042F340
	public static Sprite Load(EventTrackTheme t, string name); // 0x000000018042F340-0x000000018042F3F0
	public static Sprite LoadReal(EventTrackTheme t, string name); // 0x000000018042F3F0-0x000000018042F5D0
	public static void Bind(MonoBehaviour host, Image img, EventTrackTheme t, string name, Sprite fallback, Color tint); // 0x000000018042F5D0-0x000000018042F9F0
	public static bool BindKit(MonoBehaviour host, Image img, EventTrackTheme t, string name, string kitName, Image.Type type, Color waiting, Color ready, bool preserveAspect = false /* Metadata: 0x005EF808 */); // 0x000000018042F9F0-0x000000018042FE90
	public static Color ParseColor(string hex, Color fallback); // 0x000000018042FE90-0x000000018042FFD0
	public static void SafeDestroy(UnityEngine.Object target); // 0x000000018042FFD0-0x0000000180430130
	public static Sprite Procedural(string name, Color primary); // 0x0000000180430130-0x00000001804304C0
	private static Sprite Build(string name, Color primary, string key); // 0x00000001804304C0-0x0000000180430BA0
	private static Sprite Drop(int size, Color primary, string key); // 0x0000000180430BA0-0x0000000180430F10
	private static Sprite Disc(int size, string key); // 0x0000000180430F10-0x0000000180431190
	public static Color ChestColor(int tier); // 0x0000000180431190-0x0000000180431270
	private static Sprite Chest(int size, int tier, string key); // 0x0000000180431270-0x00000001804317A0
	private static Sprite Glow(int size, string key); // 0x00000001804317A0-0x00000001804319D0
	private static Sprite Streak(int w, int h, string key); // 0x00000001804319D0-0x0000000180431C60
	private static Sprite Splash(int size, string key); // 0x0000000180431C60-0x0000000180431F30
	private static Sprite HubIcon(int size, Color primary, string key); // 0x0000000180431F30-0x00000001804324C0
	private static bool Disc(float x, float y, float cx, float cy, float r); // 0x0000000180328250-0x0000000180328280
	private static Sprite Banner(int w, int h, Color primary, string key); // 0x00000001804324C0-0x0000000180432820
	private static Color32[] Paint(bool[] inside, int w, int h, Color fill, Color outline, Vector3 highlight); // 0x0000000180432820-0x0000000180432DA0
	private static Sprite Rasterize(bool[] inside, int w, int h, Color fill, Color outline, string name, Vector3 highlight); // 0x0000000180432DA0-0x0000000180432E90
	private static bool IsEdge(bool[] inside, int w, int h, int x, int y); // 0x0000000180328900-0x00000001803289B0
	private static Sprite Finish(Color32[] px, int w, int h, string name); // 0x0000000180432E90-0x0000000180433160
}

