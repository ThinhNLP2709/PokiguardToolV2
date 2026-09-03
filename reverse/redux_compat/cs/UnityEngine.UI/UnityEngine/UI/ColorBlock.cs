/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Serialization;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[Serializable]
	public struct ColorBlock : IEquatable<ColorBlock> // TypeDefIndex: 13016
	{
		// Fields
		[FormerlySerializedAs("normalColor")]
		[SerializeField]
		private Color m_NormalColor; // 0x00
		[FormerlySerializedAs("highlightedColor")]
		[SerializeField]
		private Color m_HighlightedColor; // 0x10
		[FormerlySerializedAs("pressedColor")]
		[SerializeField]
		private Color m_PressedColor; // 0x20
		[SerializeField]
		private Color m_SelectedColor; // 0x30
		[FormerlySerializedAs("disabledColor")]
		[SerializeField]
		private Color m_DisabledColor; // 0x40
		[Range(1f, 5f)]
		[SerializeField]
		private float m_ColorMultiplier; // 0x50
		[FormerlySerializedAs("fadeDuration")]
		[SerializeField]
		private float m_FadeDuration; // 0x54
		public static readonly ColorBlock defaultColorBlock; // 0x00
	
		// Properties
		public Color normalColor { get; set; } // 0x000000018092E600-0x000000018092E610 0x0000000180D17CD0-0x0000000180D17CE0
		public Color highlightedColor { get; set; } // 0x00000001802E65B0-0x00000001802E65C0 0x00000001806F7670-0x00000001806F7680
		public Color pressedColor { get; set; } // 0x0000000180D91A40-0x0000000180D91A50 0x0000000181424780-0x0000000181424790
		public Color selectedColor { get; set; } // 0x0000000181E304D0-0x0000000181E304E0 0x0000000181E305E0-0x0000000181E305F0
		public Color disabledColor { get; set; } // 0x0000000181E304C0-0x0000000181E304D0 0x0000000181E305D0-0x0000000181E305E0
		public float colorMultiplier { get; set; } // 0x0000000181D8CC80-0x0000000181D8CC90 0x0000000182141FC0-0x0000000182141FD0
		public float fadeDuration { get; set; } // 0x0000000181D8CC70-0x0000000181D8CC80 0x00000001820CF470-0x00000001820CF480
	
		// Constructors
		static ColorBlock(); // 0x00000001823624C0-0x00000001823627F0
	
		// Methods
		public override bool Equals(object obj); // 0x00000001823620B0-0x00000001823621A0
		public bool Equals(ColorBlock other); // 0x00000001823621A0-0x0000000182362430
		public static bool operator ==(ColorBlock point1, ColorBlock point2); // 0x00000001823627F0-0x0000000182362890
		public static bool operator !=(ColorBlock point1, ColorBlock point2); // 0x0000000182362890-0x0000000182362930
		public override int GetHashCode(); // 0x0000000182362430-0x00000001823624C0
	}
}
