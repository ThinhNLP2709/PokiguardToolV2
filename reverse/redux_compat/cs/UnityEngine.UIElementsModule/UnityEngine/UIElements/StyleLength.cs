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
	public struct StyleLength : IStyleValue<Length>, IEquatable<StyleLength> // TypeDefIndex: 4670
	{
		// Fields
		[SerializeField]
		private Length m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x08
	
		// Properties
		public Length value { get; set; } // 0x00000001825653B0-0x00000001825653D0 0x00000001825655F0-0x0000000182565650
		public StyleKeyword keyword { get; set; } // 0x0000000180732D20-0x0000000180732D30 0x00000001825655A0-0x00000001825655F0
	
		// Constructors
		public StyleLength(float v); // 0x0000000182565190-0x0000000182565230
		public StyleLength(Length v); // 0x0000000182565330-0x00000001825653B0
		public StyleLength(StyleKeyword keyword); // 0x0000000182565230-0x00000001825652B0
		internal StyleLength(Length v, StyleKeyword keyword); // 0x00000001825652B0-0x0000000182565330
	
		// Methods
		public static bool operator ==(StyleLength lhs, StyleLength rhs); // 0x00000001825653D0-0x00000001825653F0
		public static implicit operator StyleLength(StyleKeyword keyword); // 0x0000000182565470-0x00000001825654F0
		public static implicit operator StyleLength(float v); // 0x00000001825654F0-0x00000001825655A0
		public static implicit operator StyleLength(Length v); // 0x00000001825653F0-0x0000000182565470
		public bool Equals(StyleLength other); // 0x0000000182564FE0-0x0000000182565040
		public override bool Equals(object obj); // 0x0000000182565040-0x0000000182565100
		public override int GetHashCode(); // 0x0000000182565100-0x0000000182565120
		public override string ToString(); // 0x0000000182565120-0x0000000182565190
	}
}
