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
	public struct StyleScale : IStyleValue<Scale>, IEquatable<StyleScale> // TypeDefIndex: 4675
	{
		// Fields
		[SerializeField]
		private Scale m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x10
	
		// Properties
		public Scale value { get; set; } // 0x0000000182569850-0x0000000182569960 0x00000001815595F0-0x0000000181559600
		public StyleKeyword keyword { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
	
		// Constructors
		public StyleScale(Scale v); // 0x00000001815595F0-0x0000000181559600
		public StyleScale(StyleKeyword keyword); // 0x00000001825630B0-0x00000001825630C0
		internal StyleScale(Scale v, StyleKeyword keyword); // 0x0000000180F378A0-0x0000000180F378B0
	
		// Methods
		public static bool operator ==(StyleScale lhs, StyleScale rhs); // 0x0000000182569960-0x00000001825699D0
		public static implicit operator StyleScale(StyleKeyword keyword); // 0x0000000182563170-0x0000000182563180
		public static implicit operator StyleScale(Scale v); // 0x0000000182563180-0x00000001825631A0
		public bool Equals(StyleScale other); // 0x0000000182569630-0x00000001825696A0
		public override bool Equals(object obj); // 0x00000001825696A0-0x0000000182569780
		public override int GetHashCode(); // 0x0000000182569780-0x00000001825697E0
		public override string ToString(); // 0x00000001825697E0-0x0000000182569850
	}
}
