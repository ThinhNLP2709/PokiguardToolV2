/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GuideHubButton : MonoBehaviour // TypeDefIndex: 765
{
	// Fields
	private const string PREF_SEEN = "GuideSeen"; // Metadata: 0x005EFA67
	private const float VISIBILITY_POLL = 0.25f; // Metadata: 0x005EFA71
	private const float FADE_SPEED = 8f; // Metadata: 0x005EFA75
	public GameObject point; // 0x20
	private CanvasGroup _canvasGroup; // 0x28
	private float _nextVisibilityCheck; // 0x30
	private bool _shouldShow; // 0x34
	private Vector3 _baseScale; // 0x38

	// Constructors
	public GuideHubButton(); // 0x00000001804E9190-0x00000001804E9200

	// Methods
	private void Awake(); // 0x00000001804E7DC0-0x00000001804E8360
	private void OnEnable(); // 0x00000001804E8360-0x00000001804E8370
	private void OpenPanel(); // 0x00000001804E8370-0x00000001804E85E0
	private void RefreshBadge(); // 0x00000001804E85E0-0x00000001804E8750
	private void Update(); // 0x00000001804E8750-0x00000001804E9190
}

