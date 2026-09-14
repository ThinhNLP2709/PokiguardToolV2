/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class HomeHandFocus : MonoBehaviour // TypeDefIndex: 971
{
	// Fields
	private const float TIMEOUT_SEC = 8f; // Metadata: 0x005F0566
	private const float BOB_SEC = 0.6f; // Metadata: 0x005F056A
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
	public HomeHandFocus(); // 0x00000001805E6380-0x00000001805E63E0

	// Methods
	private void Awake(); // 0x00000001805E5340-0x00000001805E55D0
	private void OnDisable(); // 0x00000001805E55D0-0x00000001805E5750
	private void Update(); // 0x00000001805E5750-0x00000001805E5A00
	public void PointAt(RectTransform target); // 0x00000001805E5A00-0x00000001805E6090
	public void Hide(); // 0x00000001805E6090-0x00000001805E6380
}

