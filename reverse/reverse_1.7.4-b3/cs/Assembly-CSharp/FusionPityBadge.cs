/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class FusionPityBadge // TypeDefIndex: 2312
{
	// Fields
	private static readonly Color TextColor; // 0x00
	private static readonly Color PillColor; // 0x10
	private static readonly Dictionary<EntityId, FusionPityBadgeDriver> _badges; // 0x20
	private static Sprite _pillFallback; // 0x28
	private static readonly HashSet<string> _warnedPaths; // 0x30

	// Properties
	internal static int ParticleBudget { get; } // 0x0000000180B1C900-0x0000000180B1C9C0 

	// Constructors
	static FusionPityBadge(); // 0x0000000180B1C9C0-0x0000000180B1CBA0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics(); // 0x0000000180B18F60-0x0000000180B19060
	public static void Bind(SpriteRenderer host, int percent, bool isSelfSide); // 0x0000000180B19060-0x0000000180B192B0
	public static void Clear(SpriteRenderer host); // 0x0000000180B192B0-0x0000000180B193D0
	public static void PlayGain(SpriteRenderer host, int before, int after); // 0x0000000180B193D0-0x0000000180B195D0
	public static void PlayBurst(SpriteRenderer host); // 0x0000000180B195D0-0x0000000180B19800
	public static void ClearAll(); // 0x0000000180B19800-0x0000000180B199F0
	private static void Remove(EntityId hostId); // 0x0000000180B199F0-0x0000000180B19AD0
	internal static void Discard(FusionPityBadgeDriver d); // 0x0000000180B19AD0-0x0000000180B19C80
	private static void Kill(FusionPityBadgeDriver d); // 0x0000000180B19C80-0x0000000180B19E50
	private static FusionPityBadgeDriver Ensure(SpriteRenderer host, bool isSelfSide); // 0x0000000180B19E50-0x0000000180B1AC00
	internal static Sprite LoadSpriteSafe(string resourcePath); // 0x0000000180B1AC00-0x0000000180B1AE60
	private static void WarnOnce(string path, Exception e); // 0x0000000180B1AE60-0x0000000180B1B0A0
	private static Image BuildPill(RectTransform parent); // 0x0000000180B1B0A0-0x0000000180B1B650
	private static Image BuildIcon(RectTransform parent); // 0x0000000180B1B650-0x0000000180B1BAB0
	private static UnityEngine.UI.Text BuildText(RectTransform parent, bool hasIcon); // 0x0000000180B1BAB0-0x0000000180B1C130
	private static void AttachStyle(GameObject go, string key, Graphic target); // 0x0000000180B1C130-0x0000000180B1C2B0
	private static Sprite PillSprite(); // 0x0000000180B1C2B0-0x0000000180B1C900
}

