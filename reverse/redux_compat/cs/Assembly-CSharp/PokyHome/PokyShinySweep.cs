/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyShinySweep : MonoBehaviour // TypeDefIndex: 1929
	{
		// Fields
		[Tooltip("D\u1EA3i s\u00E1ng (con c\u1EE7a n\u00FAt). Null \u21D2 component t\u1EF1 t\u1EAFt.")]
		public RectTransform sweep; // 0x20
		[Tooltip("N\u00FAt ch\u1EE7 \u2014 \u0111ang kho\u00E1 (interactable=false) th\u00EC KH\u00D4NG qu\u00E9t (\u0111ang g\u1EEDi API).")]
		public Button button; // 0x28
		[Tooltip("Qu\u00E3ng \u0111\u01B0\u1EDDng qu\u00E9t (\u0111\u01A1n v\u1ECB canvas) \u2014 n\u00EAn \u2265 b\u1EC1 r\u1ED9ng n\u00FAt + b\u1EC1 r\u1ED9ng d\u1EA3i.")]
		public float travel; // 0x30
		[Tooltip("Th\u1EDDi gian m\u1ED9t l\u01B0\u1EE3t qu\u00E9t (gi\u00E2y).")]
		public float duration; // 0x34
		[Tooltip("Ngh\u1EC9 gi\u1EEFa hai l\u01B0\u1EE3t qu\u00E9t (gi\u00E2y).")]
		public float interval; // 0x38
		private bool _running; // 0x3C
		private float _next; // 0x40
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass10_0 // TypeDefIndex: 1930
		{
			// Fields
			public PokyShinySweep __4__this; // 0x10
			public float y; // 0x18
	
			// Constructors
			public __c__DisplayClass10_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Play_b__0(float v); // 0x00000001806573E0-0x0000000180657490
			internal void _Play_b__1(); // 0x0000000180657490-0x0000000180657570
		}
	
		// Constructors
		public PokyShinySweep(); // 0x000000018064CED0-0x000000018064CEF0
	
		// Methods
		private void OnEnable(); // 0x000000018064CA90-0x000000018064CBB0
		private void OnDisable(); // 0x000000018064C9C0-0x000000018064CA90
		private void Update(); // 0x000000018064CE00-0x000000018064CED0
		private void Play(); // 0x000000018064CBB0-0x000000018064CE00
	}
}
