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
	public struct FilterParameter : IEquatable<FilterParameter> // TypeDefIndex: 4380
	{
		// Fields
		[SerializeField]
		private FilterParameterType m_Type; // 0x00
		[SerializeField]
		private float m_FloatValue; // 0x04
		[SerializeField]
		private Color m_ColorValue; // 0x08
	
		// Properties
		public FilterParameterType type { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public float floatValue { get; set; } // 0x000000018035C790-0x000000018035C7A0 0x0000000181CE28C0-0x0000000181CE28D0
		public Color colorValue { get; set; } // 0x0000000180C57230-0x0000000180C57240 0x0000000181259E20-0x0000000181259E30
	
		// Constructors
		public FilterParameter(float value); // 0x0000000182525820-0x0000000182525840
		public FilterParameter(Color value); // 0x0000000182525840-0x0000000182525850
	
		// Methods
		public static bool operator ==(FilterParameter a, FilterParameter b); // 0x0000000182525850-0x00000001825258E0
		public static bool operator !=(FilterParameter a, FilterParameter b); // 0x00000001825258E0-0x00000001825259A0
		public override bool Equals(object obj); // 0x0000000182525520-0x0000000182525650
		public bool Equals(FilterParameter other); // 0x0000000182525650-0x0000000182525710
		public override int GetHashCode(); // 0x0000000182525710-0x00000001825257B0
		public override string ToString(); // 0x00000001825257B0-0x0000000182525820
	}
}
