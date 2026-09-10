/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyPressScale : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler // TypeDefIndex: 2249
	{
		// Fields
		public const float DOWN_SCALE = 0.9f; // Metadata: 0x0068E45C
		public const float DOWN_TIME = 0.1f; // Metadata: 0x0068E460
		public const float UP_TIME = 0.1f; // Metadata: 0x0068E464
		[Tooltip("Object b\u1ECB co gi\u00E3n. B\u1ECF tr\u1ED1ng = ch\u00EDnh object n\u00E0y.")]
		public Transform target; // 0x20
		private Vector3 _baseScale; // 0x28
		private bool _captured; // 0x34
		private int _tweenId; // 0x38
		private bool _suppressed; // 0x3C
	
		// Constructors
		public PokyPressScale(); // 0x000000018078FE40-0x000000018078FE70
	
		// Methods
		private void Awake(); // 0x000000018078F6B0-0x000000018078F6C0
		private void OnDisable(); // 0x000000018078F950-0x000000018078F9F0
		public void CaptureBaseScale(); // 0x000000018078F790-0x000000018078F840
		public void OnPointerDown(PointerEventData eventData); // 0x000000018078F9F0-0x000000018078FCA0
		public void OnPointerUp(PointerEventData eventData); // 0x000000018078FCA0-0x000000018078FCB0
		public void OnPointerExit(PointerEventData eventData); // 0x000000018078FCA0-0x000000018078FCB0
		private void Release(); // 0x000000018078FCB0-0x000000018078FE40
		private void ClearTweenId(); // 0x000000018078F840-0x000000018078F850
		private void CancelOwnTween(); // 0x000000018078F6C0-0x000000018078F790
		private bool HasForeignTween(); // 0x000000018078F850-0x000000018078F950
	}
}
