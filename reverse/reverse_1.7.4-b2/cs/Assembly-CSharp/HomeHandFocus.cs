/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class HomeHandFocus : MonoBehaviour // TypeDefIndex: 802
{
	// Fields
	private const float TIMEOUT_SEC = 8f; // Metadata: 0x0068BC32
	private const float BOB_SEC = 0.6f; // Metadata: 0x0068BC36
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
	public HomeHandFocus(); // 0x0000000180491170-0x0000000180491190

	// Methods
	private void Awake(); // 0x0000000180490AC0-0x0000000180490BA0
	private void OnDisable(); // 0x0000000180490C90-0x0000000180490D40
	private void Update(); // 0x0000000180491000-0x0000000180491170
	public void PointAt(RectTransform target); // 0x0000000180490D40-0x0000000180491000
	public void Hide(); // 0x0000000180490BA0-0x0000000180490C90
}

