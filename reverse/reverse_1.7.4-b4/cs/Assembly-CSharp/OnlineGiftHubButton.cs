/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class OnlineGiftHubButton : MonoBehaviour // TypeDefIndex: 1729
{
	// Fields
	private const float VISIBILITY_POLL = 0.25f; // Metadata: 0x005F151F
	private const float FADE_SPEED = 8f; // Metadata: 0x005F1523
	private const float REFETCH_COOLDOWN = 5f; // Metadata: 0x005F1527
	private const float EMPTY_RETRY = 15f; // Metadata: 0x005F152B
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
	public OnlineGiftHubButton(); // 0x00000001808C1750-0x00000001808C17F0

	// Methods
	private void Awake(); // 0x00000001808BF170-0x00000001808BFB40
	private void OnEnable(); // 0x00000001808BFB40-0x00000001808BFCD0
	private void OnDisable(); // 0x00000001808BFCD0-0x00000001808BFDF0
	private bool TryApplyBadges(HubBadgesData badges); // 0x00000001808BFDF0-0x00000001808BFEC0
	private void OpenPanel(); // 0x00000001808BFEC0-0x00000001808BFF10
	private void FetchOnce(); // 0x00000001808BFF10-0x00000001808C0200
	private void OnStatus(OnlineGiftData data); // 0x00000001808C0200-0x00000001808C02C0
	private void Update(); // 0x00000001808C02C0-0x00000001808C0CF0
	private void RefreshBadge(float now); // 0x00000001808C0CF0-0x00000001808C1750
	[CompilerGenerated]
	private void _FetchOnce_b__27_0(string err); // 0x000000018039D9E0-0x000000018039D9F0
}

