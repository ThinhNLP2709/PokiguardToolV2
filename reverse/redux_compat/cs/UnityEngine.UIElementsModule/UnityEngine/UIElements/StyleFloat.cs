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
	public struct StyleFloat : IStyleValue<float>, IEquatable<StyleFloat> // TypeDefIndex: 4666
	{
		// Fields
		[SerializeField]
		private float m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x04
	
		// Properties
		public float value { get; set; } // 0x0000000182564790-0x00000001825647A0 0x0000000182564780-0x0000000182564790
		public StyleKeyword keyword { get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
	
		// Constructors
		public StyleFloat(float v); // 0x0000000182564780-0x0000000182564790
		public StyleFloat(StyleKeyword keyword); // 0x0000000180DF8E30-0x0000000180DF8E40
		internal StyleFloat(float v, StyleKeyword keyword); // 0x00000001824CC640-0x00000001824CC650
	
		// Methods
		public static bool operator ==(StyleFloat lhs, StyleFloat rhs); // 0x00000001825647A0-0x00000001825647D0
		public static implicit operator StyleFloat(StyleKeyword keyword); // 0x0000000180DF91E0-0x0000000180DF9200
		public static implicit operator StyleFloat(float v); // 0x00000001825647D0-0x00000001825647F0
		public bool Equals(StyleFloat other); // 0x00000001825646F0-0x0000000182564720
		public override bool Equals(object obj); // 0x0000000182564640-0x00000001825646F0
		public override int GetHashCode(); // 0x00000001824CC220-0x00000001824CC240
		public override string ToString(); // 0x0000000182564720-0x0000000182564780
	}
}
