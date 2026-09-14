/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class DotAffixHud // TypeDefIndex: 2182
{
	// Fields
	private static readonly Dictionary<EntityId, DotAffixHudView> _views; // 0x00
	private static readonly List<DotAffixHudView> _listBuf; // 0x08
	private static readonly HashSet<int> _revealed; // 0x10
	private static readonly HashSet<string> _warned; // 0x18
	private static string _matchId; // 0x20
	private static bool _hidden; // 0x28

	// Properties
	public static bool Hidden { get; } // 0x0000000180A3D9D0-0x0000000180A3DA30 

	// Constructors
	static DotAffixHud(); // 0x0000000180A3FA20-0x0000000180A3FDA0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics(); // 0x0000000180A3CE60-0x0000000180A3CFC0
	public static void Bind(SpriteRenderer host, int actorNumber, bool selfSide); // 0x0000000180A3CFC0-0x0000000180A3D2F0
	public static void Clear(SpriteRenderer host); // 0x0000000180A3D2F0-0x0000000180A3D4E0
	public static void BeginMatch(string matchId); // 0x0000000180A3D4E0-0x0000000180A3D650
	public static void HideAll(); // 0x0000000180A3D650-0x0000000180A3D6E0
	public static void ClearAll(); // 0x0000000180A3D6E0-0x0000000180A3D9D0
	internal static bool FirstReveal(int actor); // 0x0000000180A3DA30-0x0000000180A3DAD0
	internal static bool TryRead(int actor, int[] pct, out int luckIndex, out int luck); // 0x0000000180A3DAD0-0x0000000180A3E040
	internal static string TryName(int actor); // 0x0000000180A3E040-0x0000000180A3E2F0
	internal static void WarnOnce(string key, string message); // 0x0000000180A3E2F0-0x0000000180A3E3D0
	internal static void NotifyDestroyed(DotAffixHudView v); // 0x0000000180A3E3D0-0x0000000180A3E570
	internal static void Discard(DotAffixHudView v); // 0x0000000180A3E570-0x0000000180A3E710
	private static void Remove(EntityId id); // 0x0000000180A3E710-0x0000000180A3E7F0
	private static void Kill(DotAffixHudView v); // 0x0000000180A3E7F0-0x0000000180A3E9C0
	private static DotAffixHudView Ensure(SpriteRenderer host, bool selfSide); // 0x0000000180A3E9C0-0x0000000180A3F310
	private static RectTransform ResolveContainer(SpriteRenderer host, out Canvas rootCanvas); // 0x0000000180A3F310-0x0000000180A3F760
	internal static Transform FindDeep(Transform root, string name, int maxDepth); // 0x0000000180A3F760-0x0000000180A3FA20
}

