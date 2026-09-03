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
	public struct StyleInt : IStyleValue<int>, IEquatable<StyleInt> // TypeDefIndex: 4669
	{
		// Fields
		[SerializeField]
		private int m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x04
	
		// Properties
		public int value { get; set; } // 0x0000000180DF9000-0x0000000180DF9010 0x0000000180DF9550-0x0000000180DF9560
		public StyleKeyword keyword { get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
	
		// Constructors
		public StyleInt(int v); // 0x0000000180DF8E10-0x0000000180DF8E20
		public StyleInt(StyleKeyword keyword); // 0x0000000180DF8E30-0x0000000180DF8E40
		internal StyleInt(int v, StyleKeyword keyword); // 0x0000000180DF8E20-0x0000000180DF8E30
	
		// Methods
		public static bool operator ==(StyleInt lhs, StyleInt rhs); // 0x0000000180DF91C0-0x0000000180DF91E0
		public static implicit operator StyleInt(StyleKeyword keyword); // 0x0000000180DF91E0-0x0000000180DF9200
		public static implicit operator StyleInt(int v); // 0x0000000180DF93D0-0x0000000180DF93F0
		public bool Equals(StyleInt other); // 0x0000000180DF8A80-0x0000000180DF8AA0
		public override bool Equals(object obj); // 0x0000000182564EE0-0x0000000182564F80
		public override int GetHashCode(); // 0x0000000180DF8AA0-0x0000000180DF8AB0
		public override string ToString(); // 0x0000000182564F80-0x0000000182564FE0
	}
}
