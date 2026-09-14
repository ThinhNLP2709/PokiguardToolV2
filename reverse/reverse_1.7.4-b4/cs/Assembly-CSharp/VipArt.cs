/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class VipArt // TypeDefIndex: 1460
{
	// Fields
	private static readonly Color OUTLINE; // 0x00
	private static readonly Color OUTLINE_INVITE; // 0x10
	private static readonly Sprite[] _badgeCache; // 0x20
	private static readonly Sprite[] _crownCache; // 0x28
	private static readonly Sprite[] _emblemCache; // 0x30
	private static Sprite _auraCache; // 0x38
	private static Sprite _plateCache; // 0x40

	// Properties
	public static float CurrentBadgeAspect { get; } // 0x00000001807EDFF0-0x00000001807EE060 
	public static bool CompactOn { get; } // 0x00000001807EE590-0x00000001807EE5F0 

	// Constructors
	static VipArt(); // 0x00000001807F1270-0x00000001807F1540

	// Methods
	public static float AspectOf(Sprite sprite); // 0x00000001807EE060-0x00000001807EE2C0
	public static float FrameToLocal(RectTransform node); // 0x00000001807EE2C0-0x00000001807EE430
	public static float Px(float framePx, float frameToLocal); // 0x00000001807EE430-0x00000001807EE440
	private static int ClampTier(int level); // 0x00000001807EE440-0x00000001807EE460
	public static string BadgePath(int level); // 0x00000001807EE460-0x00000001807EE590
	public static void SafeDestroy(UnityEngine.Object target); // 0x00000001807EE5F0-0x00000001807EE750
	public static string PathOf(string name); // 0x00000001807EE750-0x00000001807EE7D0
	public static Sprite Load(string name); // 0x00000001807EE7D0-0x00000001807EE8C0
	public static Sprite LoadReal(string name); // 0x00000001807EE8C0-0x00000001807EEA10
	public static Color TierColor(int level); // 0x00000001807EEA10-0x00000001807EEB40
	public static Sprite ProceduralBadge(int level); // 0x00000001807EEB40-0x00000001807EF020
	public static Sprite ProceduralEmblem(int level); // 0x00000001807EF020-0x00000001807EF5E0
	private static float ShieldHalf(float py); // 0x00000001807EF5E0-0x00000001807EF650
	private static float CrownLine(float dx); // 0x00000001807EF650-0x00000001807EF6F0
	public static Sprite ProceduralCrown(int level); // 0x00000001807EF6F0-0x00000001807EFB20
	private static float TopLine(float x); // 0x00000001807EFB20-0x00000001807EFCB0
	private static Sprite Rasterize(bool[] inside, int w, int h, Color fill, Color outline, string name); // 0x00000001807EFCB0-0x00000001807F0310
	public static Sprite ProceduralSoftGlow(); // 0x00000001807F0310-0x00000001807F09A0
	public static Sprite ProceduralNamePlate(); // 0x00000001807F09A0-0x00000001807F1060
	private static bool IsEdge(bool[] inside, int w, int h, int x, int y); // 0x0000000180328900-0x00000001803289B0
	public static void Bind(MonoBehaviour host, Image img, string name, Image.Type type, Sprite fallback, Color tint); // 0x00000001807F1060-0x00000001807F1270
}

