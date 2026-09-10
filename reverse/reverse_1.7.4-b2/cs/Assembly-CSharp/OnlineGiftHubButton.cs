/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class OnlineGiftHubButton : MonoBehaviour // TypeDefIndex: 1338
{
	// Fields
	private const float VISIBILITY_POLL = 0.25f; // Metadata: 0x0068CEBE
	private const float FADE_SPEED = 8f; // Metadata: 0x0068CEC2
	private const float REFETCH_COOLDOWN = 5f; // Metadata: 0x0068CEC6
	private const float EMPTY_RETRY = 15f; // Metadata: 0x0068CECA
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
	public OnlineGiftHubButton(); // 0x00000001805B4C10-0x00000001805B4C80

	// Methods
	private void Awake(); // 0x00000001805B3700-0x00000001805B3A80
	private void OnEnable(); // 0x00000001805B3D50-0x00000001805B3F00
	private void OnDisable(); // 0x00000001805B3C50-0x00000001805B3D50
	private bool TryApplyBadges(HubBadgesData badges); // 0x00000001805B4520-0x00000001805B4570
	private void OpenPanel(); // 0x00000001805B3F40-0x00000001805B3F90
	private void FetchOnce(); // 0x00000001805B3A80-0x00000001805B3C50
	private void OnStatus(OnlineGiftData data); // 0x00000001805B3F00-0x00000001805B3F40
	private void Update(); // 0x00000001805B4570-0x00000001805B4C10
	private void RefreshBadge(float now); // 0x00000001805B3F90-0x00000001805B4520
	[CompilerGenerated]
	private void _FetchOnce_b__27_0(string err); // 0x0000000180379CB0-0x0000000180379CC0
}

