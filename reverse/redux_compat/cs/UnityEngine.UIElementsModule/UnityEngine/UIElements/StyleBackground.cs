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
	public struct StyleBackground : IStyleValue<Background>, IEquatable<StyleBackground> // TypeDefIndex: 4656
	{
		// Fields
		[SerializeField]
		private Background m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x40
	
		// Properties
		public Background value { get; set; } // 0x0000000182562C60-0x0000000182562CA0 0x0000000182562DF0-0x0000000182562E30
		public StyleKeyword keyword { get; set; } // 0x000000018033D790-0x000000018033D7A0 0x000000018033ED10-0x000000018033ED20
	
		// Constructors
		public StyleBackground(Background v); // 0x0000000182562BE0-0x0000000182562C10
		public StyleBackground(StyleKeyword keyword); // 0x0000000182562C10-0x0000000182562C30
		internal StyleBackground(Background v, StyleKeyword keyword); // 0x0000000182562C30-0x0000000182562C60
	
		// Methods
		public static bool operator ==(StyleBackground lhs, StyleBackground rhs); // 0x0000000182562CA0-0x0000000182562D70
		public static implicit operator StyleBackground(StyleKeyword keyword); // 0x0000000182562D70-0x0000000182562DB0
		public static implicit operator StyleBackground(Background v); // 0x0000000182562DB0-0x0000000182562DF0
		public bool Equals(StyleBackground other); // 0x0000000182562950-0x0000000182562A70
		public override bool Equals(object obj); // 0x0000000182562A70-0x0000000182562B30
		public override int GetHashCode(); // 0x0000000182562B30-0x0000000182562B50
		public override string ToString(); // 0x0000000182562B50-0x0000000182562BE0
	}
}
