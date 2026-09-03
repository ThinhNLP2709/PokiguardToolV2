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
	public struct StyleCursor : IStyleValue<Cursor>, IEquatable<StyleCursor> // TypeDefIndex: 4661
	{
		// Fields
		[SerializeField]
		private Cursor m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x18
	
		// Properties
		public Cursor value { get; set; } // 0x0000000182564550-0x00000001825645A0 0x0000000182564530-0x0000000182564550
		public StyleKeyword keyword { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
	
		// Constructors
		public StyleCursor(Cursor v); // 0x0000000182564530-0x0000000182564550
		public StyleCursor(StyleKeyword keyword); // 0x00000001825644E0-0x0000000182564510
		internal StyleCursor(Cursor v, StyleKeyword keyword); // 0x0000000182564510-0x0000000182564530
	
		// Methods
		public static bool operator ==(StyleCursor lhs, StyleCursor rhs); // 0x00000001825645A0-0x00000001825645F0
		public static implicit operator StyleCursor(StyleKeyword keyword); // 0x0000000182564610-0x0000000182564640
		public static implicit operator StyleCursor(Cursor v); // 0x00000001825645F0-0x0000000182564610
		public bool Equals(StyleCursor other); // 0x0000000182564310-0x0000000182564380
		public override bool Equals(object obj); // 0x0000000182564380-0x0000000182564450
		public override int GetHashCode(); // 0x0000000182564450-0x0000000182564470
		public override string ToString(); // 0x0000000182564470-0x00000001825644E0
	}
}
