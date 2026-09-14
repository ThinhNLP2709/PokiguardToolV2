/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class FriendHubButton : MonoBehaviour // TypeDefIndex: 687
{
	// Fields
	private const float REFETCH_COOLDOWN = 5f; // Metadata: 0x005EE634
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
	private sealed class __c // TypeDefIndex: 688
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__14_0; // 0x08

		// Constructors
		static __c(); // 0x00000001804A2130-0x00000001804A21D0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Fetch_b__14_0(string err); // 0x000000018028A320-0x000000018028A330
	}

	// Constructors
	public FriendHubButton(); // 0x00000001804A1F40-0x00000001804A1FC0

	// Methods
	private void Awake(); // 0x00000001804A05A0-0x00000001804A0C60
	private void OnEnable(); // 0x00000001804A0C60-0x00000001804A1030
	private bool TryApplyBadges(HubBadgesData badges); // 0x00000001804A1030-0x00000001804A1110
	private void OnDisable(); // 0x00000001804A1110-0x00000001804A1430
	private void OpenPanel(); // 0x00000001804A1430-0x00000001804A1480
	private void OnFriendSignal(ChatMessageDTO _); // 0x00000001804A1480-0x00000001804A1490
	private void Fetch(); // 0x00000001804A1490-0x00000001804A1810
	private void FetchDelayed(); // 0x00000001804A1810-0x00000001804A1820
	private void OnBadge(FriendBadgeData data); // 0x00000001804A1820-0x00000001804A1B20
	private void Pulse(); // 0x00000001804A1B20-0x00000001804A1D70
	private void CancelPulse(); // 0x00000001804A1D70-0x00000001804A1F40
	[CompilerGenerated]
	private void _Pulse_b__17_0(); // 0x00000001804A1FC0-0x00000001804A2130
}

