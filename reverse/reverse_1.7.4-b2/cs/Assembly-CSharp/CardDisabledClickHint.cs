/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class CardDisabledClickHint : MonoBehaviour, IPointerClickHandler, IPointerDownHandler // TypeDefIndex: 1875
{
	// Fields
	private const float THROTTLE_SEC = 1f; // Metadata: 0x0068DA0B
	private static float _lastHintAt; // 0x00
	private Button _btn; // 0x20
	private CardUI _cardUI; // 0x28
	private CardUIPVP _cardUIPvp; // 0x30
	private float _baseLocalX; // 0x38
	private bool _baseCaptured; // 0x3C
	private bool _lockedOnDown; // 0x3D

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass11_0 // TypeDefIndex: 1876
	{
		// Fields
		public RectTransform rt; // 0x10
		public float x; // 0x18

		// Constructors
		public __c__DisplayClass11_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayDeniedShake_b__0(float v); // 0x00000001806E5BD0-0x00000001806E5C90
		internal void _PlayDeniedShake_b__1(); // 0x00000001806E5C90-0x00000001806E5D40
	}

	// Constructors
	public CardDisabledClickHint(); // 0x00000001802EBA70-0x00000001802EBAF0
	static CardDisabledClickHint(); // 0x00000001806D8B40-0x00000001806D8B80

	// Methods
	private void Awake(); // 0x00000001806D85A0-0x00000001806D8640
	public void OnPointerDown(PointerEventData eventData); // 0x00000001806D8800-0x00000001806D88A0
	public void OnPointerClick(PointerEventData eventData); // 0x00000001806D8640-0x00000001806D8800
	private void PlayDeniedShake(); // 0x00000001806D88A0-0x00000001806D8B40
}

