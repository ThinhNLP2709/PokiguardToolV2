/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[Serializable]
	public struct TMP_GlyphValueRecord // TypeDefIndex: 11833
	{
		// Fields
		[SerializeField]
		internal float m_XPlacement; // 0x00
		[SerializeField]
		internal float m_YPlacement; // 0x04
		[SerializeField]
		internal float m_XAdvance; // 0x08
		[SerializeField]
		internal float m_YAdvance; // 0x0C
	
		// Properties
		public float xPlacement { get; set; } // 0x000000018035C780-0x000000018035C790 0x0000000181DBFEC0-0x0000000181DBFED0
		public float yPlacement { get; set; } // 0x000000018035C790-0x000000018035C7A0 0x0000000181CE28C0-0x0000000181CE28D0
		public float xAdvance { get; set; } // 0x00000001802DB050-0x00000001802DB060 0x0000000181DA9A50-0x0000000181DA9A60
		public float yAdvance { get; set; } // 0x00000001802DB040-0x00000001802DB050 0x0000000181DD0800-0x0000000181DD0810
	
		// Constructors
		public TMP_GlyphValueRecord(float xPlacement, float yPlacement, float xAdvance, float yAdvance); // 0x0000000182082140-0x0000000182082160
		internal TMP_GlyphValueRecord(GlyphValueRecord_Legacy valueRecord); // 0x00000001820825F0-0x0000000182082610
		internal TMP_GlyphValueRecord(GlyphValueRecord valueRecord); // 0x00000001820825F0-0x0000000182082610
	
		// Methods
		public static TMP_GlyphValueRecord operator +(TMP_GlyphValueRecord a, TMP_GlyphValueRecord b); // 0x0000000182084F70-0x0000000182084F90
	}
}
