/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class CardDisabledClickHint : MonoBehaviour, IPointerClickHandler // TypeDefIndex: 1611
{
	// Fields
	private const float THROTTLE_SEC = 1f; // Metadata: 0x0064D7DE
	private static float _lastHintAt; // 0x00
	private Button _btn; // 0x20
	private CardUI _cardUI; // 0x28
	private CardUIPVP _cardUIPvp; // 0x30
	private float _baseLocalX; // 0x38
	private bool _baseCaptured; // 0x3C

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass9_0 // TypeDefIndex: 1612
	{
		// Fields
		public RectTransform rt; // 0x10
		public float x; // 0x18

		// Constructors
		public __c__DisplayClass9_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayDeniedShake_b__0(float v); // 0x00000001805C04A0-0x00000001805C0560
		internal void _PlayDeniedShake_b__1(); // 0x00000001805C0560-0x00000001805C0670
	}

	// Constructors
	public CardDisabledClickHint(); // 0x00000001802E7A70-0x00000001802E7BC0
	static CardDisabledClickHint(); // 0x00000001805AD5F0-0x00000001805AD630

	// Methods
	private void Awake(); // 0x00000001805AD140-0x00000001805AD1E0
	public void OnPointerClick(PointerEventData eventData); // 0x00000001805AD1E0-0x00000001805AD350
	private void PlayDeniedShake(); // 0x00000001805AD350-0x00000001805AD5F0
}

