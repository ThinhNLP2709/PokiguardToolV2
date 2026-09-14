/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GuideHubButton : MonoBehaviour // TypeDefIndex: 764
{
	// Fields
	private const string PREF_SEEN = "GuideSeen"; // Metadata: 0x005EE696
	private const float VISIBILITY_POLL = 0.25f; // Metadata: 0x005EE6A0
	private const float FADE_SPEED = 8f; // Metadata: 0x005EE6A4
	public GameObject point; // 0x20
	private CanvasGroup _canvasGroup; // 0x28
	private float _nextVisibilityCheck; // 0x30
	private bool _shouldShow; // 0x34
	private Vector3 _baseScale; // 0x38

	// Constructors
	public GuideHubButton(); // 0x00000001804E7B20-0x00000001804E7B90

	// Methods
	private void Awake(); // 0x00000001804E6750-0x00000001804E6CF0
	private void OnEnable(); // 0x00000001804E6CF0-0x00000001804E6D00
	private void OpenPanel(); // 0x00000001804E6D00-0x00000001804E6F70
	private void RefreshBadge(); // 0x00000001804E6F70-0x00000001804E70E0
	private void Update(); // 0x00000001804E70E0-0x00000001804E7B20
}

