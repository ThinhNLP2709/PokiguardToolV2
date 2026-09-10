/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class FriendHubButton : MonoBehaviour // TypeDefIndex: 595
{
	// Fields
	private const float REFETCH_COOLDOWN = 5f; // Metadata: 0x0068B6CC
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
	private sealed class __c // TypeDefIndex: 596
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__14_0; // 0x08

		// Constructors
		static __c(); // 0x00000001803F6BE0-0x00000001803F6C50
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Fetch_b__14_0(string err); // 0x00000001802EB6C0-0x00000001802EB6D0
	}

	// Constructors
	public FriendHubButton(); // 0x00000001803EE7A0-0x00000001803EE7E0

	// Methods
	private void Awake(); // 0x00000001803ED7D0-0x00000001803EDA50
	private void OnEnable(); // 0x00000001803EE210-0x00000001803EE410
	private bool TryApplyBadges(HubBadgesData badges); // 0x00000001803EE630-0x00000001803EE6F0
	private void OnDisable(); // 0x00000001803EE0A0-0x00000001803EE210
	private void OpenPanel(); // 0x00000001803EE420-0x00000001803EE470
	private void OnFriendSignal(ChatMessageDTO _); // 0x00000001803EE410-0x00000001803EE420
	private void Fetch(); // 0x00000001803EDB50-0x00000001803EDDC0
	private void FetchDelayed(); // 0x00000001803EDB40-0x00000001803EDB50
	private void OnBadge(FriendBadgeData data); // 0x00000001803EDDC0-0x00000001803EE0A0
	private void Pulse(); // 0x00000001803EE470-0x00000001803EE630
	private void CancelPulse(); // 0x00000001803EDA50-0x00000001803EDB40
	[CompilerGenerated]
	private void _Pulse_b__17_0(); // 0x00000001803EE6F0-0x00000001803EE7A0
}

