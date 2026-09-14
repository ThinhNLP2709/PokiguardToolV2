/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class DotAffixHud // TypeDefIndex: 2180
{
	// Fields
	private static readonly Dictionary<EntityId, DotAffixHudView> _views; // 0x00
	private static readonly List<DotAffixHudView> _listBuf; // 0x08
	private static readonly HashSet<int> _revealed; // 0x10
	private static readonly HashSet<string> _warned; // 0x18
	private static string _matchId; // 0x20
	private static bool _hidden; // 0x28

	// Properties
	public static bool Hidden { get; } // 0x0000000180A723B0-0x0000000180A72410 

	// Constructors
	static DotAffixHud(); // 0x0000000180A74150-0x0000000180A744D0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics(); // 0x0000000180A718A0-0x0000000180A71A00
	public static void Bind(SpriteRenderer host, int actorNumber, bool selfSide); // 0x0000000180A71A00-0x0000000180A71D30
	public static void Clear(SpriteRenderer host); // 0x0000000180A71D30-0x0000000180A71F20
	public static void BeginMatch(string matchId); // 0x0000000180A71F20-0x0000000180A72090
	public static void HideAll(); // 0x0000000180A72090-0x0000000180A720F0
	public static void ClearAll(); // 0x0000000180A720F0-0x0000000180A723B0
	internal static bool FirstReveal(int actor); // 0x0000000180A72410-0x0000000180A724B0
	internal static bool TryRead(int actor, int[] pct, out int luckIndex, out int luck); // 0x0000000180A724B0-0x0000000180A72A20
	internal static void WarnOnce(string key, string message); // 0x0000000180A72A20-0x0000000180A72B00
	internal static void NotifyDestroyed(DotAffixHudView v); // 0x0000000180A72B00-0x0000000180A72CA0
	internal static void Discard(DotAffixHudView v); // 0x0000000180A72CA0-0x0000000180A72E40
	private static void Remove(EntityId id); // 0x0000000180A72E40-0x0000000180A72F20
	private static void Kill(DotAffixHudView v); // 0x0000000180A72F20-0x0000000180A730F0
	private static DotAffixHudView Ensure(SpriteRenderer host, bool selfSide); // 0x0000000180A730F0-0x0000000180A73A40
	private static RectTransform ResolveContainer(SpriteRenderer host, out Canvas rootCanvas); // 0x0000000180A73A40-0x0000000180A73E90
	internal static Transform FindDeep(Transform root, string name, int maxDepth); // 0x0000000180A73E90-0x0000000180A74150
}

