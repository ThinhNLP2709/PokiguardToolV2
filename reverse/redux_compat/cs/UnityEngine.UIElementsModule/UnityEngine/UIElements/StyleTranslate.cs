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
	public struct StyleTranslate : IStyleValue<Translate>, IEquatable<StyleTranslate> // TypeDefIndex: 4678
	{
		// Fields
		[SerializeField]
		private Translate m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x18
	
		// Properties
		public Translate value { get; set; } // 0x000000018256DD90-0x000000018256DE40 0x0000000182564530-0x0000000182564550
		public StyleKeyword keyword { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
	
		// Constructors
		public StyleTranslate(Translate v); // 0x0000000182564530-0x0000000182564550
		public StyleTranslate(StyleKeyword keyword); // 0x00000001825644E0-0x0000000182564510
		internal StyleTranslate(Translate v, StyleKeyword keyword); // 0x0000000182564510-0x0000000182564530
	
		// Methods
		public static bool operator ==(StyleTranslate lhs, StyleTranslate rhs); // 0x000000018256DE40-0x000000018256DED0
		public static implicit operator StyleTranslate(StyleKeyword keyword); // 0x0000000182568E90-0x0000000182568EC0
		public static implicit operator StyleTranslate(Translate v); // 0x0000000182568E70-0x0000000182568E90
		public static implicit operator StyleTranslate(Vector3 v); // 0x000000018256DED0-0x000000018256DF60
		public bool Equals(StyleTranslate other); // 0x000000018256DB40-0x000000018256DC00
		public override bool Equals(object obj); // 0x000000018256DC00-0x000000018256DCA0
		public override int GetHashCode(); // 0x000000018256DCA0-0x000000018256DD10
		public override string ToString(); // 0x000000018256DD10-0x000000018256DD90
	}
}
