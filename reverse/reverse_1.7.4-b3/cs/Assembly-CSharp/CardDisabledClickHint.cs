/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class CardDisabledClickHint : MonoBehaviour, IPointerClickHandler, IPointerDownHandler // TypeDefIndex: 2241
{
	// Fields
	private const float THROTTLE_SEC = 1f; // Metadata: 0x005F0875
	private static float _lastHintAt; // 0x00
	private Button _btn; // 0x20
	private CardUI _cardUI; // 0x28
	private CardUIPVP _cardUIPvp; // 0x30
	private float _baseLocalX; // 0x38
	private bool _baseCaptured; // 0x3C
	private bool _lockedOnDown; // 0x3D

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass11_0 // TypeDefIndex: 2242
	{
		// Fields
		public RectTransform rt; // 0x10
		public float x; // 0x18

		// Constructors
		public __c__DisplayClass11_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayDeniedShake_b__0(float v); // 0x0000000180AC7310-0x0000000180AC7450
		internal void _PlayDeniedShake_b__1(); // 0x0000000180AC7450-0x0000000180AC7580
	}

	// Constructors
	public CardDisabledClickHint(); // 0x000000018028A560-0x000000018028A5B0
	static CardDisabledClickHint(); // 0x0000000180AC72D0-0x0000000180AC7310

	// Methods
	private void Awake(); // 0x0000000180AC6930-0x0000000180AC6AC0
	public void OnPointerDown(PointerEventData eventData); // 0x0000000180AC6AC0-0x0000000180AC6BE0
	public void OnPointerClick(PointerEventData eventData); // 0x0000000180AC6BE0-0x0000000180AC6F20
	private void PlayDeniedShake(); // 0x0000000180AC6F20-0x0000000180AC72D0
}

