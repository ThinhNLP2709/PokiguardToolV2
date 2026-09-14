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

public static class CanDauVanArt // TypeDefIndex: 387
{
	// Fields
	public static readonly string[] ALL_NAMES; // 0x00
	public static readonly Color OUTLINE; // 0x08
	public static readonly Color DICE_TEAL; // 0x18
	public static readonly Color GOLD; // 0x28
	public static readonly Color PURPLE; // 0x38
	public static readonly Color RED; // 0x48
	public static readonly Color BLUE; // 0x58
	public static readonly Color CLOUD_SHADE; // 0x68
	private static readonly Regex PREFIX_RE; // 0x78
	private static readonly Dictionary<string, Sprite> _cache; // 0x80
	private static readonly Color SHARD_PURPLE; // 0x88
	private static readonly Color SHARD_GREEN; // 0x98

	// Constructors
	static CanDauVanArt(); // 0x0000000180328C70-0x00000001803298E0

	// Methods
	public static string Prefix(CanDauVanTheme t); // 0x0000000180323010-0x0000000180323250
	public static string PathOf(CanDauVanTheme t, string name); // 0x0000000180323250-0x0000000180323300
	public static Sprite Load(CanDauVanTheme t, string name); // 0x0000000180323300-0x00000001803233B0
	public static Sprite LoadReal(CanDauVanTheme t, string name); // 0x00000001803233B0-0x0000000180323590
	public static void Bind(MonoBehaviour host, Image img, CanDauVanTheme t, string name, Sprite procedural, bool sliced = false /* Metadata: 0x005EF12B */); // 0x0000000180323590-0x00000001803239C0
	public static void SafeDestroy(UnityEngine.Object target); // 0x00000001803239C0-0x0000000180323B20
	public static Sprite Procedural(string name); // 0x0000000180323B20-0x0000000180323DD0
	private static Sprite Build(string name); // 0x0000000180323DD0-0x0000000180324F60
	public static Color IslandColor(string name); // 0x0000000180324F60-0x0000000180325530
	private static Sprite Cloud(int w, int h, Color fill, Color outline, string key); // 0x0000000180325530-0x0000000180325A30
	private static Sprite Island(int w, int h, Color fill, string key); // 0x0000000180325A30-0x0000000180325E00
	private static Sprite Hero(int w, int h, bool jump, string key); // 0x0000000180325E00-0x00000001803262B0
	private static Sprite Heart(int size, string key); // 0x00000001803262B0-0x00000001803265A0
	private static Sprite RoundedBox(int w, int h, float radiusFrac, Color fill, Color outline, string key, Vector4 border); // 0x00000001803265A0-0x0000000180326950
	private static Sprite Disc(int size, Color fill, Color outline, string key); // 0x0000000180326950-0x0000000180326C00
	private static Sprite HelpBadge(int size, string key); // 0x0000000180326C00-0x0000000180326FE0
	private static Sprite ShardMystery(int size, string key); // 0x0000000180326FE0-0x00000001803274E0
	private static bool InQuestionMark(float u, float v, float grow); // 0x00000001803274E0-0x00000001803277D0
	private static bool InPolygon(float x, float y, Vector2[] poly); // 0x00000001803277D0-0x00000001803278B0
	private static Sprite Ring(int size, Color tint, string key); // 0x00000001803278B0-0x0000000180327BD0
	private static Sprite Rays(int size, int count, Color tint, string key); // 0x0000000180327BD0-0x0000000180327FA0
	private static Sprite Glow(int size, Color tint, string key); // 0x0000000180327FA0-0x0000000180328250
	private static bool InDisc(float x, float y, float cx, float cy, float r); // 0x0000000180328250-0x0000000180328280
	private static Color32[] Paint(bool[] inside, int w, int h, Color fill, Color outline, Vector3 highlight); // 0x0000000180328280-0x0000000180328800
	private static Sprite Rasterize(bool[] inside, int w, int h, Color fill, Color outline, string name, Vector3 highlight, Vector4 border); // 0x0000000180328800-0x0000000180328900
	private static bool IsEdge(bool[] inside, int w, int h, int x, int y); // 0x0000000180328900-0x00000001803289B0
	private static Sprite Finish(Color32[] px, int w, int h, string name, Vector4 border); // 0x00000001803289B0-0x0000000180328C70
}

