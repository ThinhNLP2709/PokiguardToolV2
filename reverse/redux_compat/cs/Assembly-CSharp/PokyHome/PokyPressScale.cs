/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyPressScale : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler // TypeDefIndex: 1923
	{
		// Fields
		public const float DOWN_SCALE = 0.9f; // Metadata: 0x0064DFDC
		public const float DOWN_TIME = 0.1f; // Metadata: 0x0064DFE0
		public const float UP_TIME = 0.1f; // Metadata: 0x0064DFE4
		[Tooltip("Object b\u1ECB co gi\u00E3n. B\u1ECF tr\u1ED1ng = ch\u00EDnh object n\u00E0y.")]
		public Transform target; // 0x20
		private Vector3 _baseScale; // 0x28
		private bool _captured; // 0x34
		private int _tweenId; // 0x38
		private bool _suppressed; // 0x3C
	
		// Constructors
		public PokyPressScale(); // 0x000000018064B880-0x000000018064B8B0
	
		// Methods
		private void Awake(); // 0x000000018064B0F0-0x000000018064B100
		private void OnDisable(); // 0x000000018064B390-0x000000018064B430
		public void CaptureBaseScale(); // 0x000000018064B1D0-0x000000018064B280
		public void OnPointerDown(PointerEventData eventData); // 0x000000018064B430-0x000000018064B6E0
		public void OnPointerUp(PointerEventData eventData); // 0x000000018064B6E0-0x000000018064B6F0
		public void OnPointerExit(PointerEventData eventData); // 0x000000018064B6E0-0x000000018064B6F0
		private void Release(); // 0x000000018064B6F0-0x000000018064B880
		private void ClearTweenId(); // 0x000000018064B280-0x000000018064B290
		private void CancelOwnTween(); // 0x000000018064B100-0x000000018064B1D0
		private bool HasForeignTween(); // 0x000000018064B290-0x000000018064B390
	}
}
