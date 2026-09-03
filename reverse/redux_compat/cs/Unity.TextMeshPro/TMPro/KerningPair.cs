/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[Serializable]
	public class KerningPair // TypeDefIndex: 11822
	{
		// Fields
		[FormerlySerializedAs("AscII_Left")]
		[SerializeField]
		private uint m_FirstGlyph; // 0x10
		[SerializeField]
		private GlyphValueRecord_Legacy m_FirstGlyphAdjustments; // 0x14
		[FormerlySerializedAs("AscII_Right")]
		[SerializeField]
		private uint m_SecondGlyph; // 0x24
		[SerializeField]
		private GlyphValueRecord_Legacy m_SecondGlyphAdjustments; // 0x28
		[FormerlySerializedAs("XadvanceOffset")]
		public float xOffset; // 0x38
		[SerializeField]
		private bool m_IgnoreSpacingAdjustments; // 0x3C
	
		// Properties
		public uint firstGlyph { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public GlyphValueRecord_Legacy firstGlyphAdjustments { get; } // 0x00000001811027F0-0x0000000181102800 
		public uint secondGlyph { get; set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
		public GlyphValueRecord_Legacy secondGlyphAdjustments { get; } // 0x0000000180C46B90-0x0000000180C46BA0 
		public bool ignoreSpacingAdjustments { get; } // 0x00000001804654D0-0x00000001804654E0 
	
		// Constructors
		public KerningPair(); // 0x0000000182082740-0x0000000182082770
		public KerningPair(uint left, uint right, float offset); // 0x0000000182082690-0x00000001820826E0
		public KerningPair(uint firstGlyph, GlyphValueRecord_Legacy firstGlyphAdjustments, uint secondGlyph, GlyphValueRecord_Legacy secondGlyphAdjustments); // 0x00000001820826E0-0x0000000182082740
	
		// Methods
		internal void ConvertLegacyKerningData(); // 0x0000000182082680-0x0000000182082690
	}
}
