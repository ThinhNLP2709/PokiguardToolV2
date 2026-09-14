/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class VipArt // TypeDefIndex: 1458
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
	public static float CurrentBadgeAspect { get; } // 0x00000001807EBF00-0x00000001807EBF70 
	public static bool CompactOn { get; } // 0x00000001807EC4A0-0x00000001807EC500 

	// Constructors
	static VipArt(); // 0x00000001807EF180-0x00000001807EF450

	// Methods
	public static float AspectOf(Sprite sprite); // 0x00000001807EBF70-0x00000001807EC1D0
	public static float FrameToLocal(RectTransform node); // 0x00000001807EC1D0-0x00000001807EC340
	public static float Px(float framePx, float frameToLocal); // 0x00000001807EC340-0x00000001807EC350
	private static int ClampTier(int level); // 0x00000001807EC350-0x00000001807EC370
	public static string BadgePath(int level); // 0x00000001807EC370-0x00000001807EC4A0
	public static void SafeDestroy(UnityEngine.Object target); // 0x00000001807EC500-0x00000001807EC660
	public static string PathOf(string name); // 0x00000001807EC660-0x00000001807EC6E0
	public static Sprite Load(string name); // 0x00000001807EC6E0-0x00000001807EC7D0
	public static Sprite LoadReal(string name); // 0x00000001807EC7D0-0x00000001807EC920
	public static Color TierColor(int level); // 0x00000001807EC920-0x00000001807ECA50
	public static Sprite ProceduralBadge(int level); // 0x00000001807ECA50-0x00000001807ECF30
	public static Sprite ProceduralEmblem(int level); // 0x00000001807ECF30-0x00000001807ED4F0
	private static float ShieldHalf(float py); // 0x00000001807ED4F0-0x00000001807ED560
	private static float CrownLine(float dx); // 0x00000001807ED560-0x00000001807ED600
	public static Sprite ProceduralCrown(int level); // 0x00000001807ED600-0x00000001807EDA30
	private static float TopLine(float x); // 0x00000001807EDA30-0x00000001807EDBC0
	private static Sprite Rasterize(bool[] inside, int w, int h, Color fill, Color outline, string name); // 0x00000001807EDBC0-0x00000001807EE220
	public static Sprite ProceduralSoftGlow(); // 0x00000001807EE220-0x00000001807EE8B0
	public static Sprite ProceduralNamePlate(); // 0x00000001807EE8B0-0x00000001807EEF70
	private static bool IsEdge(bool[] inside, int w, int h, int x, int y); // 0x00000001803287E0-0x0000000180328890
	public static void Bind(MonoBehaviour host, Image img, string name, Image.Type type, Sprite fallback, Color tint); // 0x00000001807EEF70-0x00000001807EF180
}

