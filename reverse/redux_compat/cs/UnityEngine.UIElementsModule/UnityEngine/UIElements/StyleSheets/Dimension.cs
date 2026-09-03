/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.StyleSheets
{
	[Serializable]
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal struct Dimension : IEquatable<Dimension> // TypeDefIndex: 5228
	{
		// Fields
		public Unit unit; // 0x00
		public float value; // 0x04
	
		// Nested types
		public enum Unit // TypeDefIndex: 5229
		{
			Unitless = 0,
			Pixel = 1,
			Percent = 2,
			Second = 3,
			Millisecond = 4,
			Degree = 5,
			Gradian = 6,
			Radian = 7,
			Turn = 8
		}
	
		// Constructors
		public Dimension(float value, Unit unit); // 0x000000018244EBD0-0x000000018244EBE0
	
		// Methods
		public Length ToLength(); // 0x000000018244EA90-0x000000018244EAE0
		public TimeValue ToTime(); // 0x000000018244EBA0-0x000000018244EBD0
		public Angle ToAngle(); // 0x000000018244EA00-0x000000018244EA90
		public static bool operator ==(Dimension lhs, Dimension rhs); // 0x000000018244EBE0-0x000000018244EC10
		public bool Equals(Dimension other); // 0x000000018244E960-0x000000018244E990
		public override bool Equals(object obj); // 0x000000018244E8C0-0x000000018244E960
		public override int GetHashCode(); // 0x000000018244E990-0x000000018244E9D0
		public override string ToString(); // 0x000000018244EAE0-0x000000018244EBA0
		public bool IsLength(); // 0x000000018244E9E0-0x000000018244E9F0
		public bool IsTimeValue(); // 0x000000018244E9F0-0x000000018244EA00
		public bool IsAngle(); // 0x000000018244E9D0-0x000000018244E9E0
	}
}
