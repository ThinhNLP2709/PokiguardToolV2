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
	public struct StyleFont : IStyleValue<Font>, IEquatable<StyleFont> // TypeDefIndex: 4667
	{
		// Fields
		[SerializeField]
		private Font m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x08
	
		// Properties
		public Font value { get; set; } // 0x0000000182562580-0x0000000182562590 0x000000018171B230-0x000000018171B250
		public StyleKeyword keyword { get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
	
		// Constructors
		public StyleFont(Font v); // 0x0000000182564E10-0x0000000182564E20
		public StyleFont(StyleKeyword keyword); // 0x00000001815046B0-0x00000001815046D0
		internal StyleFont(Font v, StyleKeyword keyword); // 0x0000000182564E00-0x0000000182564E10
	
		// Methods
		public static bool operator ==(StyleFont lhs, StyleFont rhs); // 0x0000000182564E20-0x0000000182564E90
		public static implicit operator StyleFont(StyleKeyword keyword); // 0x0000000182564E90-0x0000000182564EC0
		public static implicit operator StyleFont(Font v); // 0x0000000182564EC0-0x0000000182564EE0
		public bool Equals(StyleFont other); // 0x0000000182564C90-0x0000000182564D10
		public override bool Equals(object obj); // 0x0000000182564B90-0x0000000182564C90
		public override int GetHashCode(); // 0x0000000182564D10-0x0000000182564DA0
		public override string ToString(); // 0x0000000182564DA0-0x0000000182564E00
	}
}
