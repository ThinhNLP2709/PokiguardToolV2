/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerTapSpark : MonoBehaviour // TypeDefIndex: 2872
	{
		// Fields
		public const string SPARK_SPRITE = "Image/InfoPlayer/spark"; // Metadata: 0x005F1FEA
		public const int POOL_SIZE = 8; // Metadata: 0x005F2001
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
		public bool Ready { get; } // 0x0000000180D1B190-0x0000000180D1B280 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass13_0 // TypeDefIndex: 2873
		{
			// Fields
			public Image img; // 0x10
	
			// Constructors
			public __c__DisplayClass13_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Emit_b__0(float a); // 0x0000000180D1CBC0-0x0000000180D1CD40
			internal void _Emit_b__1(); // 0x0000000180D1CD40-0x0000000180D1CE90
		}
	
		// Constructors
		public InfoPlayerTapSpark(); // 0x0000000180D1CB60-0x0000000180D1CBC0
	
		// Methods
		private void OnDisable(); // 0x0000000180D1B280-0x0000000180D1B4A0
		private void EnsurePool(); // 0x0000000180D1B4A0-0x0000000180D1C1B0
		public void Emit(Vector2 localPos); // 0x0000000180D1C1B0-0x0000000180D1C780
		public void EmitAt(RectTransform anchor); // 0x0000000180D1C780-0x0000000180D1CB60
	}
}
