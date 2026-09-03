/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[DebuggerDisplay("{DebuggerDisplay()}")]
	internal struct TextProcessingElement // TypeDefIndex: 11915
	{
		// Fields
		private TextProcessingElementType m_ElementType; // 0x00
		private int m_StartIndex; // 0x04
		private int m_Length; // 0x08
		private CharacterElement m_CharacterElement; // 0x10
		private MarkupElement m_MarkupElement; // 0x20
	
		// Properties
		public TextProcessingElementType ElementType { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public int StartIndex { get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public int Length { get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public CharacterElement CharacterElement { get; } // 0x00000001802E65B0-0x00000001802E65C0 
		public MarkupElement MarkupElement { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000182109850-0x0000000182109860
		public static TextProcessingElement Undefined { get; } // 0x0000000182109830-0x0000000182109850 
	
		// Constructors
		public TextProcessingElement(TextProcessingElementType elementType, int startIndex, int length); // 0x0000000182109810-0x0000000182109830
		public TextProcessingElement(TMP_TextElement textElement, int startIndex, int length); // 0x00000001821097C0-0x0000000182109810
		public TextProcessingElement(CharacterElement characterElement, int startIndex, int length); // 0x0000000182109730-0x0000000182109770
		public TextProcessingElement(MarkupElement markupElement); // 0x0000000182109770-0x00000001821097C0
	
		// Methods
		private string DebuggerDisplay(); // 0x0000000182109640-0x0000000182109730
	}
}
