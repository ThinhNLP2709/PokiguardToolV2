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
	public struct StyleTextShadow : IStyleValue<TextShadow>, IEquatable<StyleTextShadow> // TypeDefIndex: 4676
	{
		// Fields
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x00
		[SerializeField]
		private TextShadow m_Value; // 0x04
	
		// Properties
		public TextShadow value { get; set; } // 0x000000018256D660-0x000000018256D6B0 0x000000018256D620-0x000000018256D640
		public StyleKeyword keyword { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
	
		// Constructors
		public StyleTextShadow(TextShadow v); // 0x000000018256D620-0x000000018256D640
		public StyleTextShadow(StyleKeyword keyword); // 0x000000018256D5F0-0x000000018256D620
		internal StyleTextShadow(TextShadow v, StyleKeyword keyword); // 0x000000018256D640-0x000000018256D660
	
		// Methods
		public static bool operator ==(StyleTextShadow lhs, StyleTextShadow rhs); // 0x000000018256D6B0-0x000000018256D750
		public static implicit operator StyleTextShadow(StyleKeyword keyword); // 0x000000018256D750-0x000000018256D780
		public static implicit operator StyleTextShadow(TextShadow v); // 0x000000018256D780-0x000000018256D7B0
		public bool Equals(StyleTextShadow other); // 0x000000018256D490-0x000000018256D540
		public override bool Equals(object obj); // 0x000000018256D360-0x000000018256D490
		public override int GetHashCode(); // 0x000000018256D540-0x000000018256D580
		public override string ToString(); // 0x000000018256D580-0x000000018256D5F0
	}
}
