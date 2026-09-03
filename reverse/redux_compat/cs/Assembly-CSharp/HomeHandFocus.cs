/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class HomeHandFocus : MonoBehaviour // TypeDefIndex: 606
{
	// Fields
	private const float TIMEOUT_SEC = 8f; // Metadata: 0x0064C607
	private const float BOB_SEC = 0.6f; // Metadata: 0x0064C60B
	[Tooltip("Node g\u1ED1c c\u1EE7a b\u00E0n tay (b\u1EADt/t\u1EAFt).")]
	public GameObject root; // 0x20
	[Tooltip("RectTransform di chuy\u1EC3n t\u1EDBi v\u1ECB tr\u00ED m\u1EE5c ti\u00EAu.")]
	public RectTransform hand; // 0x28
	[Tooltip("V\u00F2ng s\u00E1ng quanh m\u1EE5c ti\u00EAu (12 frame EffectFocus). B\u1ECF tr\u1ED1ng = ch\u1EC9 c\u00F3 b\u00E0n tay.")]
	public Image focusRing; // 0x30
	public Sprite[] focusFrames; // 0x38
	public float focusFps; // 0x40
	private float _hideAt; // 0x44
	private float _frameTimer; // 0x48
	private int _frameIndex; // 0x4C

	// Constructors
	public HomeHandFocus(); // 0x00000001803B1830-0x00000001803B1850

	// Methods
	private void Awake(); // 0x00000001803B1180-0x00000001803B1260
	private void OnDisable(); // 0x00000001803B1350-0x00000001803B1400
	private void Update(); // 0x00000001803B16C0-0x00000001803B1830
	public void PointAt(RectTransform target); // 0x00000001803B1400-0x00000001803B16C0
	public void Hide(); // 0x00000001803B1260-0x00000001803B1350
}

