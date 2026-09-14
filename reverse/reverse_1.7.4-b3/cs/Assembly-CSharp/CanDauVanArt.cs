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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
	static CanDauVanArt(); // 0x0000000180328B50-0x00000001803297C0

	// Methods
	public static string Prefix(CanDauVanTheme t); // 0x0000000180322EF0-0x0000000180323130
	public static string PathOf(CanDauVanTheme t, string name); // 0x0000000180323130-0x00000001803231E0
	public static Sprite Load(CanDauVanTheme t, string name); // 0x00000001803231E0-0x0000000180323290
	public static Sprite LoadReal(CanDauVanTheme t, string name); // 0x0000000180323290-0x0000000180323470
	public static void Bind(MonoBehaviour host, Image img, CanDauVanTheme t, string name, Sprite procedural, bool sliced = false /* Metadata: 0x005EDD5B */); // 0x0000000180323470-0x00000001803238A0
	public static void SafeDestroy(UnityEngine.Object target); // 0x00000001803238A0-0x0000000180323A00
	public static Sprite Procedural(string name); // 0x0000000180323A00-0x0000000180323CB0
	private static Sprite Build(string name); // 0x0000000180323CB0-0x0000000180324E40
	public static Color IslandColor(string name); // 0x0000000180324E40-0x0000000180325410
	private static Sprite Cloud(int w, int h, Color fill, Color outline, string key); // 0x0000000180325410-0x0000000180325910
	private static Sprite Island(int w, int h, Color fill, string key); // 0x0000000180325910-0x0000000180325CE0
	private static Sprite Hero(int w, int h, bool jump, string key); // 0x0000000180325CE0-0x0000000180326190
	private static Sprite Heart(int size, string key); // 0x0000000180326190-0x0000000180326480
	private static Sprite RoundedBox(int w, int h, float radiusFrac, Color fill, Color outline, string key, Vector4 border); // 0x0000000180326480-0x0000000180326830
	private static Sprite Disc(int size, Color fill, Color outline, string key); // 0x0000000180326830-0x0000000180326AE0
	private static Sprite HelpBadge(int size, string key); // 0x0000000180326AE0-0x0000000180326EC0
	private static Sprite ShardMystery(int size, string key); // 0x0000000180326EC0-0x00000001803273C0
	private static bool InQuestionMark(float u, float v, float grow); // 0x00000001803273C0-0x00000001803276B0
	private static bool InPolygon(float x, float y, Vector2[] poly); // 0x00000001803276B0-0x0000000180327790
	private static Sprite Ring(int size, Color tint, string key); // 0x0000000180327790-0x0000000180327AB0
	private static Sprite Rays(int size, int count, Color tint, string key); // 0x0000000180327AB0-0x0000000180327E80
	private static Sprite Glow(int size, Color tint, string key); // 0x0000000180327E80-0x0000000180328130
	private static bool InDisc(float x, float y, float cx, float cy, float r); // 0x0000000180328130-0x0000000180328160
	private static Color32[] Paint(bool[] inside, int w, int h, Color fill, Color outline, Vector3 highlight); // 0x0000000180328160-0x00000001803286E0
	private static Sprite Rasterize(bool[] inside, int w, int h, Color fill, Color outline, string name, Vector3 highlight, Vector4 border); // 0x00000001803286E0-0x00000001803287E0
	private static bool IsEdge(bool[] inside, int w, int h, int x, int y); // 0x00000001803287E0-0x0000000180328890
	private static Sprite Finish(Color32[] px, int w, int h, string name, Vector4 border); // 0x0000000180328890-0x0000000180328B50
}

