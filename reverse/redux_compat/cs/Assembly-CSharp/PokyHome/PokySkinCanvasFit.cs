/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokySkinCanvasFit : MonoBehaviour // TypeDefIndex: 1933
	{
		// Fields
		[Tooltip("B\u1EC1 r\u1ED9ng canvas m\u00E0 thi\u1EBFt k\u1EBF Poky \u0111\u01B0\u1EE3c v\u1EBD (bundle n\u00E0o c\u0169ng 1300).")]
		public float referenceWidth; // 0x20
		[Range(0f, 1f)]
		[Tooltip("0 = kh\u1EDBp b\u1EC1 r\u1ED9ng (gi\u1ED1ng Poky), 1 = kh\u1EDBp chi\u1EC1u cao.")]
		public float match; // 0x24
		[Tooltip("Chi\u1EC1u cao thi\u1EBFt k\u1EBF \u2014 ch\u1EC9 d\u00F9ng khi match > 0.")]
		public float referenceHeight; // 0x28
		private RectTransform _rt; // 0x30
		private RectTransform _rootRect; // 0x38
		private float _lastW; // 0x40
		private float _lastH; // 0x44
		private float _lastParentLossy; // 0x48
	
		// Constructors
		public PokySkinCanvasFit(); // 0x000000018064E240-0x000000018064E270
	
		// Methods
		private void OnEnable(); // 0x000000018064E190-0x000000018064E240
		private void LateUpdate(); // 0x000000018064DFB0-0x000000018064E190
		public void Fit(); // 0x000000018064DB40-0x000000018064DFB0
	}
}
