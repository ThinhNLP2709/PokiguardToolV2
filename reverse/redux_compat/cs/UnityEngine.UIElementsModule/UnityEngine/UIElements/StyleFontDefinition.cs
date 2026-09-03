/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	public struct StyleFontDefinition : IStyleValue<FontDefinition>, IEquatable<StyleFontDefinition> // TypeDefIndex: 4668
	{
		// Fields
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x00
		[SerializeField]
		private FontDefinition m_Value; // 0x08
	
		// Properties
		public FontDefinition value { get; set; } // 0x0000000182564A90-0x0000000182564AB0 0x0000000182564B60-0x0000000182564B90
		public StyleKeyword keyword { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
	
		// Constructors
		public StyleFontDefinition(FontDefinition f); // 0x00000001825649B0-0x00000001825649D0
		public StyleFontDefinition(FontAsset f); // 0x0000000182564970-0x00000001825649B0
		public StyleFontDefinition(Font f); // 0x0000000182564A10-0x0000000182564A50
		public StyleFontDefinition(StyleKeyword keyword); // 0x0000000182564950-0x0000000182564970
		internal StyleFontDefinition(FontAsset f, StyleKeyword keyword); // 0x00000001825649D0-0x0000000182564A10
		internal StyleFontDefinition(Font f, StyleKeyword keyword); // 0x0000000182564A50-0x0000000182564A90
		internal StyleFontDefinition(FontDefinition f, StyleKeyword keyword); // 0x0000000182564930-0x0000000182564950
	
		// Methods
		public static implicit operator StyleFontDefinition(StyleKeyword keyword); // 0x0000000182564B00-0x0000000182564B30
		public static implicit operator StyleFontDefinition(FontDefinition f); // 0x0000000182564B30-0x0000000182564B60
		public bool Equals(StyleFontDefinition other); // 0x00000001825648B0-0x0000000182564900
		public override bool Equals(object obj); // 0x00000001825647F0-0x00000001825648B0
		public override int GetHashCode(); // 0x0000000182564900-0x0000000182564930
		public static bool operator ==(StyleFontDefinition left, StyleFontDefinition right); // 0x0000000182564AB0-0x0000000182564B00
	}
}
