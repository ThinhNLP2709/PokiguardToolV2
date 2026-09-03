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
	public struct TMP_GlyphAdjustmentRecord // TypeDefIndex: 11834
	{
		// Fields
		[SerializeField]
		internal uint m_GlyphIndex; // 0x00
		[SerializeField]
		internal TMP_GlyphValueRecord m_GlyphValueRecord; // 0x04
	
		// Properties
		public uint glyphIndex { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public TMP_GlyphValueRecord glyphValueRecord { get; set; } // 0x0000000180C572D0-0x0000000180C572E0 0x0000000182084E00-0x0000000182084E10
	
		// Constructors
		public TMP_GlyphAdjustmentRecord(uint glyphIndex, TMP_GlyphValueRecord glyphValueRecord); // 0x0000000181327C80-0x0000000181327C90
		internal TMP_GlyphAdjustmentRecord(GlyphAdjustmentRecord adjustmentRecord); // 0x0000000182084DB0-0x0000000182084E00
	}
}
