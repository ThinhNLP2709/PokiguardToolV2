/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyPressScale : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler // TypeDefIndex: 2692
	{
		// Fields
		public const float DOWN_SCALE = 0.9f; // Metadata: 0x005F28DF
		public const float DOWN_TIME = 0.1f; // Metadata: 0x005F28E3
		public const float UP_TIME = 0.1f; // Metadata: 0x005F28E7
		[Tooltip("Object b\u1ECB co gi\u00E3n. B\u1ECF tr\u1ED1ng = ch\u00EDnh object n\u00E0y.")]
		public Transform target; // 0x20
		private Vector3 _baseScale; // 0x28
		private bool _captured; // 0x34
		private int _tweenId; // 0x38
		private bool _suppressed; // 0x3C
	
		// Constructors
		public PokyPressScale(); // 0x0000000180C51940-0x0000000180C519B0
	
		// Methods
		private void Awake(); // 0x0000000180C50D00-0x0000000180C50D10
		private void OnDisable(); // 0x0000000180C50D10-0x0000000180C50E80
		public void CaptureBaseScale(); // 0x0000000180C50E80-0x0000000180C51050
		public void OnPointerDown(PointerEventData eventData); // 0x0000000180C51050-0x0000000180C51430
		public void OnPointerUp(PointerEventData eventData); // 0x0000000180C51430-0x0000000180C51440
		public void OnPointerExit(PointerEventData eventData); // 0x0000000180C51430-0x0000000180C51440
		private void Release(); // 0x0000000180C51440-0x0000000180C51660
		private void ClearTweenId(); // 0x00000001805507D0-0x00000001805507E0
		private void CancelOwnTween(); // 0x0000000180C51660-0x0000000180C517B0
		private bool HasForeignTween(); // 0x0000000180C517B0-0x0000000180C51940
	}
}
