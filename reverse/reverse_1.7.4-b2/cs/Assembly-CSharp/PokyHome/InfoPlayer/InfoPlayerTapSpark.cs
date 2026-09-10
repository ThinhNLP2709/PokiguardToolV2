/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerTapSpark : MonoBehaviour // TypeDefIndex: 2427
	{
		// Fields
		public const string SPARK_SPRITE = "Image/InfoPlayer/spark"; // Metadata: 0x0068F1AE
		public const int POOL_SIZE = 8; // Metadata: 0x0068F1C5
		[Tooltip("C\u1EA1nh c\u1EE7a tia lo\u00E9 l\u00FAc n\u1EDF h\u1EBFt (\u0111\u01A1n v\u1ECB thi\u1EBFt k\u1EBF 1774\u00D7887).")]
		public float size; // 0x20
		[Tooltip("Th\u1EDDi gian m\u1ED9t tia s\u1ED1ng (gi\u00E2y).")]
		public float life; // 0x24
		[Tooltip("M\u00E0u tia. Alpha gi\u1EA3m d\u1EA7n v\u1EC1 0 trong su\u1ED1t v\u00F2ng \u0111\u1EDDi.")]
		public Color tint; // 0x28
		private Image[] _pool; // 0x38
		private int _next; // 0x40
		private Sprite _sprite; // 0x48
		private bool _resolved; // 0x50
	
		// Properties
		public bool Ready { get; } // 0x00000001807FF500-0x00000001807FF560 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass13_0 // TypeDefIndex: 2428
		{
			// Fields
			public Image img; // 0x10
	
			// Constructors
			public __c__DisplayClass13_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Emit_b__0(float a); // 0x000000018080CB50-0x000000018080CC40
			internal void _Emit_b__1(); // 0x000000018080CC40-0x000000018080CCD0
		}
	
		// Constructors
		public InfoPlayerTapSpark(); // 0x00000001807FF4D0-0x00000001807FF500
	
		// Methods
		private void OnDisable(); // 0x00000001807FF380-0x00000001807FF4D0
		private void EnsurePool(); // 0x00000001807FEEE0-0x00000001807FF380
		public void Emit(Vector2 localPos); // 0x00000001807FEAF0-0x00000001807FEEE0
		public void EmitAt(RectTransform anchor); // 0x00000001807FE950-0x00000001807FEAF0
	}
}
