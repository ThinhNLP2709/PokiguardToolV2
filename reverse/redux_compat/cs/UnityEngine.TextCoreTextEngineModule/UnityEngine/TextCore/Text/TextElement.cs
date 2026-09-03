/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.TextCore;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[Serializable]
	public abstract class TextElement // TypeDefIndex: 12677
	{
		// Fields
		[SerializeField]
		protected TextElementType m_ElementType; // 0x10
		[SerializeField]
		internal uint m_Unicode; // 0x14
		internal TextAsset m_TextAsset; // 0x18
		internal Glyph m_Glyph; // 0x20
		[SerializeField]
		internal uint m_GlyphIndex; // 0x28
		[SerializeField]
		internal float m_Scale; // 0x2C
	
		// Properties
		public TextElementType elementType { get; } // 0x00000001805625D0-0x00000001805625E0 
		public uint unicode { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public TextAsset textAsset { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public Glyph glyph { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public uint glyphIndex { get; set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		public float scale { get; set; } // 0x000000018206CB50-0x000000018206CB60 0x000000018206CC90-0x000000018206CCA0
	
		// Constructors
		protected TextElement(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
