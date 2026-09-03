/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class GuideHubButton : MonoBehaviour // TypeDefIndex: 594
{
	// Fields
	private const string PREF_SEEN = "GuideSeen"; // Metadata: 0x0064C592
	private const float VISIBILITY_POLL = 0.25f; // Metadata: 0x0064C59C
	private const float FADE_SPEED = 8f; // Metadata: 0x0064C5A0
	public GameObject point; // 0x20
	private CanvasGroup _canvasGroup; // 0x28
	private float _nextVisibilityCheck; // 0x30
	private bool _shouldShow; // 0x34
	private Vector3 _baseScale; // 0x38

	// Constructors
	public GuideHubButton(); // 0x00000001803AB6B0-0x00000001803AB6E0

	// Methods
	private void Awake(); // 0x00000001803AAEA0-0x00000001803AB0F0
	private void OnEnable(); // 0x00000001803AB0F0-0x00000001803AB100
	private void OpenPanel(); // 0x00000001803AB100-0x00000001803AB180
	private void RefreshBadge(); // 0x00000001803AB180-0x00000001803AB220
	private void Update(); // 0x00000001803AB220-0x00000001803AB6B0
}

