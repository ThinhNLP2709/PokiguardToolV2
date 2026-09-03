/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.TextCore.LowLevel;

// Image 50: UnityEngine.TextCoreFontEngineModule.dll - Assembly: UnityEngine.TextCoreFontEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15505-15532

namespace UnityEngine.TextCore
{
	[Serializable]
	[UsedByNativeCode]
	public class Glyph // TypeDefIndex: 15512
	{
		// Fields
		[NativeName("index")]
		[SerializeField]
		private uint m_Index; // 0x10
		[NativeName("metrics")]
		[SerializeField]
		private GlyphMetrics m_Metrics; // 0x14
		[NativeName("glyphRect")]
		[SerializeField]
		private GlyphRect m_GlyphRect; // 0x28
		[NativeName("scale")]
		[SerializeField]
		private float m_Scale; // 0x38
		[NativeName("atlasIndex")]
		[SerializeField]
		private int m_AtlasIndex; // 0x3C
		[NativeName("type")]
		[SerializeField]
		private GlyphClassDefinitionType m_ClassDefinitionType; // 0x40
	
		// Properties
		public uint index { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public GlyphMetrics metrics { get; set; } // 0x000000018110BD10-0x000000018110BD30 0x00000001822F4060-0x00000001822F4070
		public GlyphRect glyphRect { get; set; } // 0x0000000180C46B90-0x0000000180C46BA0 0x00000001815D9CA0-0x00000001815D9CB0
		public float scale { get; set; } // 0x0000000181C62E80-0x0000000181C62E90 0x0000000181C62E90-0x0000000181C62EA0
		public int atlasIndex { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001805D5550-0x00000001805D5560
	
		// Constructors
		public Glyph(); // 0x00000001822F4020-0x00000001822F4060
		internal Glyph(GlyphMarshallingStruct glyphStruct); // 0x00000001822F3F60-0x00000001822F3FB0
		public Glyph(uint index, GlyphMetrics metrics, GlyphRect glyphRect, float scale, int atlasIndex); // 0x00000001822F3FB0-0x00000001822F4020
	}
}
