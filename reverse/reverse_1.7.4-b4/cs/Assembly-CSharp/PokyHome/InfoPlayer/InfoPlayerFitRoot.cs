/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerFitRoot : MonoBehaviour // TypeDefIndex: 2842
	{
		// Fields
		[Tooltip("B\u1EC1 r\u1ED9ng khung thi\u1EBFt k\u1EBF MM3.")]
		public float designWidth; // 0x20
		[Tooltip("Chi\u1EC1u cao khung thi\u1EBFt k\u1EBF MM3.")]
		public float designHeight; // 0x24
		private RectTransform _rt; // 0x28
		private RectTransform _parentRect; // 0x30
		private float _lastW; // 0x38
		private float _lastH; // 0x3C
	
		// Constructors
		public InfoPlayerFitRoot(); // 0x0000000180D01AA0-0x0000000180D01B10
	
		// Methods
		private void OnEnable(); // 0x0000000180D01060-0x0000000180D01180
		private void LateUpdate(); // 0x0000000180D01180-0x0000000180D01410
		public void Fit(); // 0x0000000180D01410-0x0000000180D01AA0
		private static bool IsUsable(float v); // 0x0000000180704710-0x0000000180704740
	}
}
