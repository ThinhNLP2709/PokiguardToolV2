/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	public struct StyleColor : IStyleValue<Color>, IEquatable<StyleColor> // TypeDefIndex: 4660
	{
		// Fields
		[SerializeField]
		private Color m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x10
	
		// Properties
		public Color value { get; set; } // 0x00000001825630C0-0x00000001825630E0 0x00000001815595F0-0x0000000181559600
		public StyleKeyword keyword { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
	
		// Constructors
		public StyleColor(Color v); // 0x00000001815595F0-0x0000000181559600
		public StyleColor(StyleKeyword keyword); // 0x00000001825630B0-0x00000001825630C0
		internal StyleColor(Color v, StyleKeyword keyword); // 0x0000000180F378A0-0x0000000180F378B0
	
		// Methods
		public static bool operator ==(StyleColor lhs, StyleColor rhs); // 0x00000001825630E0-0x0000000182563170
		public static implicit operator StyleColor(StyleKeyword keyword); // 0x0000000182563170-0x0000000182563180
		public static implicit operator StyleColor(Color v); // 0x0000000182563180-0x00000001825631A0
		public bool Equals(StyleColor other); // 0x0000000182562E30-0x0000000182562EC0
		public override bool Equals(object obj); // 0x0000000182562EC0-0x0000000182562FC0
		public override int GetHashCode(); // 0x0000000182562FC0-0x0000000182563040
		public override string ToString(); // 0x0000000182563040-0x00000001825630B0
	}
}
