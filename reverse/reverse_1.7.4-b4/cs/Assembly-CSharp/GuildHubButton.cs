/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GuildHubButton : MonoBehaviour // TypeDefIndex: 798
{
	// Fields
	public const string FLAG_KEY = "guild"; // Metadata: 0x005EFD8C
	private const float REFETCH_COOLDOWN = 5f; // Metadata: 0x005EFD92
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
	private sealed class __c // TypeDefIndex: 799
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__17_0; // 0x08

		// Constructors
		static __c(); // 0x000000018052D9E0-0x000000018052DA80
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Fetch_b__17_0(string err); // 0x000000018052DA80-0x000000018052DB00
	}

	// Constructors
	public GuildHubButton(); // 0x00000001804A3340-0x00000001804A33C0

	// Methods
	private void Awake(); // 0x000000018052BBD0-0x000000018052C210
	private void EnsureGate(); // 0x000000018052C210-0x000000018052C530
	private void OnEnable(); // 0x000000018052C530-0x000000018052C7C0
	private bool TryApplyBadges(HubBadgesData badges); // 0x000000018052C7C0-0x000000018052C910
	private void OnDisable(); // 0x000000018052C910-0x000000018052CAE0
	private void OpenPanel(); // 0x000000018052CAE0-0x000000018052CBF0
	private void OnGuildSignal(ChatMessageDTO _); // 0x000000018052CBF0-0x000000018052CC00
	private void OnMembershipChanged(bool _); // 0x000000018052CBF0-0x000000018052CC00
	private void Fetch(); // 0x000000018052CC00-0x000000018052CFD0
	private void FetchDelayed(); // 0x000000018052CFD0-0x000000018052CFE0
	private void OnHome(GuildHomeData data); // 0x000000018052CFE0-0x000000018052D0D0
	private void ApplyBadge(bool hasGuild, long requestCount, bool bossNotify, bool shopNotify); // 0x000000018052D0D0-0x000000018052D3E0
	private void Pulse(); // 0x000000018052D3E0-0x000000018052D6A0
	private void CancelPulse(); // 0x000000018052D6A0-0x000000018052D870
	[CompilerGenerated]
	private void _Pulse_b__21_0(); // 0x000000018052D870-0x000000018052D9E0
}

