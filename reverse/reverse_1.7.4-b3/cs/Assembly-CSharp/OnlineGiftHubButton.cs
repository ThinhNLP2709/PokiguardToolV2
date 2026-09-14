/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class OnlineGiftHubButton : MonoBehaviour // TypeDefIndex: 1727
{
	// Fields
	private const float VISIBILITY_POLL = 0.25f; // Metadata: 0x005F0152
	private const float FADE_SPEED = 8f; // Metadata: 0x005F0156
	private const float REFETCH_COOLDOWN = 5f; // Metadata: 0x005F015A
	private const float EMPTY_RETRY = 15f; // Metadata: 0x005F015E
	public GameObject point; // 0x20
	public UnityEngine.UI.Text txtTimer; // 0x28
	private OnlineGiftData _data; // 0x30
	private float _fetchAtRealtime; // 0x38
	private float _nextUiTick; // 0x3C
	private bool _fetched; // 0x40
	private float _lastFetchAttempt; // 0x44
	private float _nextEmptyRetry; // 0x48
	private CanvasGroup _canvasGroup; // 0x50
	private float _nextVisibilityCheck; // 0x58
	private bool _shouldShow; // 0x5C
	private bool _hasClaimable; // 0x5D
	private Vector3 _baseScale; // 0x60
	private HubOnlineGiftBadge _summary; // 0x70
	private float _summaryAtRealtime; // 0x78
	private Vector3 _pointBaseScale; // 0x7C
	private float _lastPulseAt; // 0x88
	private int _pulseTweenId; // 0x8C

	// Constructors
	public OnlineGiftHubButton(); // 0x00000001808BED10-0x00000001808BEDB0

	// Methods
	private void Awake(); // 0x00000001808BC760-0x00000001808BD130
	private void OnEnable(); // 0x00000001808BD130-0x00000001808BD2C0
	private void OnDisable(); // 0x00000001808BD2C0-0x00000001808BD3E0
	private bool TryApplyBadges(HubBadgesData badges); // 0x00000001808BD3E0-0x00000001808BD4B0
	private void OpenPanel(); // 0x00000001808BD4B0-0x00000001808BD500
	private void FetchOnce(); // 0x00000001808BD500-0x00000001808BD7C0
	private void OnStatus(OnlineGiftData data); // 0x00000001808BD7C0-0x00000001808BD880
	private void Update(); // 0x00000001808BD880-0x00000001808BE2B0
	private void RefreshBadge(float now); // 0x00000001808BE2B0-0x00000001808BED10
	[CompilerGenerated]
	private void _FetchOnce_b__27_0(string err); // 0x000000018039D810-0x000000018039D820
}

