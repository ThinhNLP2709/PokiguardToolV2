/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyPressScale : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler // TypeDefIndex: 2685
	{
		// Fields
		public const float DOWN_SCALE = 0.9f; // Metadata: 0x005F14C8
		public const float DOWN_TIME = 0.1f; // Metadata: 0x005F14CC
		public const float UP_TIME = 0.1f; // Metadata: 0x005F14D0
		[Tooltip("Object b\u1ECB co gi\u00E3n. B\u1ECF tr\u1ED1ng = ch\u00EDnh object n\u00E0y.")]
		public Transform target; // 0x20
		private Vector3 _baseScale; // 0x28
		private bool _captured; // 0x34
		private int _tweenId; // 0x38
		private bool _suppressed; // 0x3C
	
		// Constructors
		public PokyPressScale(); // 0x0000000180C44380-0x0000000180C443F0
	
		// Methods
		private void Awake(); // 0x0000000180C43740-0x0000000180C43750
		private void OnDisable(); // 0x0000000180C43750-0x0000000180C438C0
		public void CaptureBaseScale(); // 0x0000000180C438C0-0x0000000180C43A90
		public void OnPointerDown(PointerEventData eventData); // 0x0000000180C43A90-0x0000000180C43E70
		public void OnPointerUp(PointerEventData eventData); // 0x0000000180C43E70-0x0000000180C43E80
		public void OnPointerExit(PointerEventData eventData); // 0x0000000180C43E70-0x0000000180C43E80
		private void Release(); // 0x0000000180C43E80-0x0000000180C440A0
		private void ClearTweenId(); // 0x000000018054EFE0-0x000000018054EFF0
		private void CancelOwnTween(); // 0x0000000180C440A0-0x0000000180C441F0
		private bool HasForeignTween(); // 0x0000000180C441F0-0x0000000180C44380
	}
}
