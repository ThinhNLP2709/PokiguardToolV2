/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GuideHubButton : MonoBehaviour // TypeDefIndex: 674
{
	// Fields
	private const string PREF_SEEN = "GuideSeen"; // Metadata: 0x0068B770
	private const float VISIBILITY_POLL = 0.25f; // Metadata: 0x0068B77A
	private const float FADE_SPEED = 8f; // Metadata: 0x0068B77E
	public GameObject point; // 0x20
	private CanvasGroup _canvasGroup; // 0x28
	private float _nextVisibilityCheck; // 0x30
	private bool _shouldShow; // 0x34
	private Vector3 _baseScale; // 0x38

	// Constructors
	public GuideHubButton(); // 0x00000001804360D0-0x0000000180436100

	// Methods
	private void Awake(); // 0x00000001804358C0-0x0000000180435B10
	private void OnEnable(); // 0x0000000180435B10-0x0000000180435B20
	private void OpenPanel(); // 0x0000000180435B20-0x0000000180435BA0
	private void RefreshBadge(); // 0x0000000180435BA0-0x0000000180435C40
	private void Update(); // 0x0000000180435C40-0x00000001804360D0
}

