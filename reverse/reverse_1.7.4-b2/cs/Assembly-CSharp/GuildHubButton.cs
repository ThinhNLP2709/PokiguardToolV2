/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GuildHubButton : MonoBehaviour // TypeDefIndex: 708
{
	// Fields
	public const string FLAG_KEY = "guild"; // Metadata: 0x0068BA6D
	private const float REFETCH_COOLDOWN = 5f; // Metadata: 0x0068BA73
	public GameObject badge; // 0x20
	public UnityEngine.UI.Text txtCount; // 0x28
	private long _count; // 0x30
	private float _lastFetchAt; // 0x38
	private bool _pendingFetch; // 0x3C
	private Vector3 _badgeBaseScale; // 0x40
	private int _pulseTweenId; // 0x4C

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 709
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__17_0; // 0x08

		// Constructors
		static __c(); // 0x000000018047F700-0x000000018047F7B0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Fetch_b__17_0(string err); // 0x000000018047DD60-0x000000018047DDD0
	}

	// Constructors
	public GuildHubButton(); // 0x00000001803EE7A0-0x00000001803EE7E0

	// Methods
	private void Awake(); // 0x0000000180468EB0-0x0000000180469250
	private void EnsureGate(); // 0x0000000180469340-0x0000000180469480
	private void OnEnable(); // 0x0000000180469960-0x0000000180469BF0
	private bool TryApplyBadges(HubBadgesData badges); // 0x0000000180469EC0-0x0000000180469F30
	private void OnDisable(); // 0x0000000180469760-0x0000000180469960
	private void OpenPanel(); // 0x0000000180469C40-0x0000000180469CD0
	private void OnGuildSignal(ChatMessageDTO _); // 0x0000000180469BF0-0x0000000180469C00
	private void OnMembershipChanged(bool _); // 0x0000000180469BF0-0x0000000180469C00
	private void Fetch(); // 0x0000000180469490-0x0000000180469760
	private void FetchDelayed(); // 0x0000000180469480-0x0000000180469490
	private void OnHome(GuildHomeData data); // 0x0000000180469C00-0x0000000180469C40
	private void ApplyBadge(bool hasGuild, long requestCount, bool bossNotify, bool shopNotify); // 0x0000000180468B70-0x0000000180468EB0
	private void Pulse(); // 0x0000000180469CD0-0x0000000180469EC0
	private void CancelPulse(); // 0x0000000180469250-0x0000000180469340
	[CompilerGenerated]
	private void _Pulse_b__21_0(); // 0x0000000180469F30-0x0000000180469FE0
}

