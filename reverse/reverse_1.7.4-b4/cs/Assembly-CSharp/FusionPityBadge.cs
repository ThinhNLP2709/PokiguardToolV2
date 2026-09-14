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

public static class FusionPityBadge // TypeDefIndex: 2319
{
	// Fields
	private static readonly Color TextColor; // 0x00
	private static readonly Color PillColor; // 0x10
	private static readonly Dictionary<EntityId, FusionPityBadgeDriver> _badges; // 0x20
	private static Sprite _pillFallback; // 0x28
	private static readonly HashSet<string> _warnedPaths; // 0x30

	// Properties
	internal static int ParticleBudget { get; } // 0x0000000180B29AE0-0x0000000180B29BA0 

	// Constructors
	static FusionPityBadge(); // 0x0000000180B29BA0-0x0000000180B29D80

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics(); // 0x0000000180B26140-0x0000000180B26240
	public static void Bind(SpriteRenderer host, int percent, bool isSelfSide); // 0x0000000180B26240-0x0000000180B26490
	public static void Clear(SpriteRenderer host); // 0x0000000180B26490-0x0000000180B265B0
	public static void PlayGain(SpriteRenderer host, int before, int after); // 0x0000000180B265B0-0x0000000180B267B0
	public static void PlayBurst(SpriteRenderer host); // 0x0000000180B267B0-0x0000000180B269E0
	public static void ClearAll(); // 0x0000000180B269E0-0x0000000180B26BD0
	private static void Remove(EntityId hostId); // 0x0000000180B26BD0-0x0000000180B26CB0
	internal static void Discard(FusionPityBadgeDriver d); // 0x0000000180B26CB0-0x0000000180B26E60
	private static void Kill(FusionPityBadgeDriver d); // 0x0000000180B26E60-0x0000000180B27030
	private static FusionPityBadgeDriver Ensure(SpriteRenderer host, bool isSelfSide); // 0x0000000180B27030-0x0000000180B27DE0
	internal static Sprite LoadSpriteSafe(string resourcePath); // 0x0000000180B27DE0-0x0000000180B28040
	private static void WarnOnce(string path, Exception e); // 0x0000000180B28040-0x0000000180B28280
	private static Image BuildPill(RectTransform parent); // 0x0000000180B28280-0x0000000180B28830
	private static Image BuildIcon(RectTransform parent); // 0x0000000180B28830-0x0000000180B28C90
	private static UnityEngine.UI.Text BuildText(RectTransform parent, bool hasIcon); // 0x0000000180B28C90-0x0000000180B29310
	private static void AttachStyle(GameObject go, string key, Graphic target); // 0x0000000180B29310-0x0000000180B29490
	private static Sprite PillSprite(); // 0x0000000180B29490-0x0000000180B29AE0
}

