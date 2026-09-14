/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerFitRoot : MonoBehaviour // TypeDefIndex: 2835
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
		public InfoPlayerFitRoot(); // 0x0000000180CF4220-0x0000000180CF4290
	
		// Methods
		private void OnEnable(); // 0x0000000180CF37E0-0x0000000180CF3900
		private void LateUpdate(); // 0x0000000180CF3900-0x0000000180CF3B90
		public void Fit(); // 0x0000000180CF3B90-0x0000000180CF4220
		private static bool IsUsable(float v); // 0x0000000180702960-0x0000000180702990
	}
}
