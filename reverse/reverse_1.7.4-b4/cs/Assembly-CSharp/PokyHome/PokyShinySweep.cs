/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyShinySweep : MonoBehaviour // TypeDefIndex: 2698
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
		private sealed class __c__DisplayClass10_0 // TypeDefIndex: 2699
		{
			// Fields
			public PokyShinySweep __4__this; // 0x10
			public float y; // 0x18
	
			// Constructors
			public __c__DisplayClass10_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Play_b__0(float v); // 0x0000000180C55C20-0x0000000180C55D50
			internal void _Play_b__1(); // 0x0000000180C55D50-0x0000000180C55F40
		}
	
		// Constructors
		public PokyShinySweep(); // 0x0000000180C55BC0-0x0000000180C55C20
	
		// Methods
		private void OnEnable(); // 0x0000000180C55140-0x0000000180C554B0
		private void OnDisable(); // 0x0000000180C554B0-0x0000000180C556A0
		private void Update(); // 0x0000000180C556A0-0x0000000180C558A0
		private void Play(); // 0x0000000180C558A0-0x0000000180C55BC0
	}
}
