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
	public struct StyleRotate : IStyleValue<Rotate>, IEquatable<StyleRotate> // TypeDefIndex: 4674
	{
		// Fields
		[SerializeField]
		private Rotate m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x18
	
		// Properties
		public Rotate value { get; set; } // 0x0000000182568CC0-0x0000000182568E10 0x0000000182564530-0x0000000182564550
		public StyleKeyword keyword { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
	
		// Constructors
		public StyleRotate(Rotate v); // 0x0000000182564530-0x0000000182564550
		public StyleRotate(StyleKeyword keyword); // 0x00000001825644E0-0x0000000182564510
		internal StyleRotate(Rotate v, StyleKeyword keyword); // 0x0000000182564510-0x0000000182564530
	
		// Methods
		public static bool operator ==(StyleRotate lhs, StyleRotate rhs); // 0x0000000182568E10-0x0000000182568E70
		public static implicit operator StyleRotate(StyleKeyword keyword); // 0x0000000182568E90-0x0000000182568EC0
		public static implicit operator StyleRotate(Rotate v); // 0x0000000182568E70-0x0000000182568E90
		public bool Equals(StyleRotate other); // 0x0000000182568B90-0x0000000182568C20
		public override bool Equals(object obj); // 0x0000000182568A90-0x0000000182568B90
		public override int GetHashCode(); // 0x0000000182568C20-0x0000000182568C40
		public override string ToString(); // 0x0000000182568C40-0x0000000182568CC0
	}
}
