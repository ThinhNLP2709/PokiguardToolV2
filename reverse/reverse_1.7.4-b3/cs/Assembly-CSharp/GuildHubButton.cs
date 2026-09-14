/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GuildHubButton : MonoBehaviour // TypeDefIndex: 797
{
	// Fields
	public const string FLAG_KEY = "guild"; // Metadata: 0x005EE9BD
	private const float REFETCH_COOLDOWN = 5f; // Metadata: 0x005EE9C3
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
	private sealed class __c // TypeDefIndex: 798
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__17_0; // 0x08

		// Constructors
		static __c(); // 0x000000018052C200-0x000000018052C2A0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Fetch_b__17_0(string err); // 0x000000018052C2A0-0x000000018052C320
	}

	// Constructors
	public GuildHubButton(); // 0x00000001804A1F40-0x00000001804A1FC0

	// Methods
	private void Awake(); // 0x000000018052A410-0x000000018052AA50
	private void EnsureGate(); // 0x000000018052AA50-0x000000018052AD70
	private void OnEnable(); // 0x000000018052AD70-0x000000018052B000
	private bool TryApplyBadges(HubBadgesData badges); // 0x000000018052B000-0x000000018052B150
	private void OnDisable(); // 0x000000018052B150-0x000000018052B320
	private void OpenPanel(); // 0x000000018052B320-0x000000018052B430
	private void OnGuildSignal(ChatMessageDTO _); // 0x000000018052B430-0x000000018052B440
	private void OnMembershipChanged(bool _); // 0x000000018052B430-0x000000018052B440
	private void Fetch(); // 0x000000018052B440-0x000000018052B7F0
	private void FetchDelayed(); // 0x000000018052B7F0-0x000000018052B800
	private void OnHome(GuildHomeData data); // 0x000000018052B800-0x000000018052B8F0
	private void ApplyBadge(bool hasGuild, long requestCount, bool bossNotify, bool shopNotify); // 0x000000018052B8F0-0x000000018052BC00
	private void Pulse(); // 0x000000018052BC00-0x000000018052BEC0
	private void CancelPulse(); // 0x000000018052BEC0-0x000000018052C090
	[CompilerGenerated]
	private void _Pulse_b__21_0(); // 0x000000018052C090-0x000000018052C200
}

