/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class OnlineGiftHubButton : MonoBehaviour // TypeDefIndex: 1124
{
	// Fields
	private const float VISIBILITY_POLL = 0.25f; // Metadata: 0x0064D367
	private const float FADE_SPEED = 8f; // Metadata: 0x0064D36B
	private const float REFETCH_COOLDOWN = 5f; // Metadata: 0x0064D36F
	public GameObject point; // 0x20
	public UnityEngine.UI.Text txtTimer; // 0x28
	private OnlineGiftData _data; // 0x30
	private float _fetchAtRealtime; // 0x38
	private float _nextUiTick; // 0x3C
	private bool _fetched; // 0x40
	private float _lastFetchAttempt; // 0x44
	private CanvasGroup _canvasGroup; // 0x48
	private float _nextVisibilityCheck; // 0x50
	private bool _shouldShow; // 0x54
	private bool _hasClaimable; // 0x55
	private Vector3 _baseScale; // 0x58

	// Constructors
	public OnlineGiftHubButton(); // 0x00000001804B6870-0x00000001804B68A0

	// Methods
	private void Awake(); // 0x00000001804B5860-0x00000001804B5B30
	private void OnEnable(); // 0x00000001804B5D90-0x00000001804B5FE0
	private void OnDisable(); // 0x00000001804B5D00-0x00000001804B5D90
	private void OpenPanel(); // 0x00000001804B6020-0x00000001804B6070
	private void FetchOnce(); // 0x00000001804B5B30-0x00000001804B5D00
	private void OnStatus(OnlineGiftData data); // 0x00000001804B5FE0-0x00000001804B6020
	private void Update(); // 0x00000001804B6400-0x00000001804B6870
	private void RefreshBadge(float now); // 0x00000001804B6070-0x00000001804B63F0
	[CompilerGenerated]
	private void _FetchOnce_b__19_0(string err); // 0x00000001804B63F0-0x00000001804B6400
}

