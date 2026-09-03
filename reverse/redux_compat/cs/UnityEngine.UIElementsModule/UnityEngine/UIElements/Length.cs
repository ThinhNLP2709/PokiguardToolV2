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
using UnityEngine.UIElements.Layout;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	public struct Length : IEquatable<Length> // TypeDefIndex: 4634
	{
		// Fields
		[SerializeField]
		private float m_Value; // 0x00
		[SerializeField]
		private LayoutUnit m_Unit; // 0x04
	
		// Properties
		public float value { get; set; } // 0x000000018035C780-0x000000018035C790 0x0000000182544990-0x00000001825449B0
		public LengthUnit unit { get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		internal float pixelValue { get; } // 0x00000001825448A0-0x00000001825448B0 
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<Length> // TypeDefIndex: 4635
		{
			// Nested types
			private class ValueProperty : Property<Length, float> // TypeDefIndex: 4636
			{
				// Fields
				[CompilerGenerated]
				private readonly string _Name_k__BackingField; // 0x18
				[CompilerGenerated]
				private readonly bool _IsReadOnly_k__BackingField; // 0x20
	
				// Properties
				public override string Name { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
				public override bool IsReadOnly { [CompilerGenerated] get; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 
	
				// Constructors
				public ValueProperty(); // 0x000000018255BDA0-0x000000018255BDF0
	
				// Methods
				public override float GetValue(ref Length container); // 0x00000001822E1A10-0x00000001822E1A20
				public override void SetValue(ref Length container, float value); // 0x000000018255BD80-0x000000018255BDA0
			}
	
			private class UnitProperty : Property<Length, LengthUnit> // TypeDefIndex: 4637
			{
				// Fields
				[CompilerGenerated]
				private readonly string _Name_k__BackingField; // 0x18
				[CompilerGenerated]
				private readonly bool _IsReadOnly_k__BackingField; // 0x20
	
				// Properties
				public override string Name { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
				public override bool IsReadOnly { [CompilerGenerated] get; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 
	
				// Constructors
				public UnitProperty(); // 0x000000018255A880-0x000000018255A8D0
	
				// Methods
				public override LengthUnit GetValue(ref Length container); // 0x000000018132C0D0-0x000000018132C0E0
				public override void SetValue(ref Length container, LengthUnit value); // 0x000000018132C1B0-0x000000018132C1C0
			}
	
			// Constructors
			public PropertyBag(); // 0x0000000182545A40-0x0000000182545BA0
		}
	
		// Constructors
		public Length(float value); // 0x0000000182544840-0x0000000182544870
		public Length(float value, LengthUnit unit); // 0x0000000182544870-0x00000001825448A0
		private Length(float value, LayoutUnit unit); // 0x0000000182544870-0x00000001825448A0
	
		// Methods
		public static Length Percent(float value); // 0x00000001825446C0-0x00000001825446F0
		public static Length Auto(); // 0x0000000182544570-0x0000000182544590
		public static Length None(); // 0x00000001825446A0-0x00000001825446C0
		public bool IsAuto(); // 0x0000000182544680-0x0000000182544690
		public bool IsNone(); // 0x0000000182544690-0x00000001825446A0
		public static implicit operator Length(float value); // 0x00000001825448F0-0x0000000182544950
		public static bool operator ==(Length lhs, Length rhs); // 0x00000001825448B0-0x00000001825448F0
		public static bool operator !=(Length lhs, Length rhs); // 0x0000000182544950-0x0000000182544990
		public bool Equals(Length other); // 0x0000000182544590-0x00000001825445D0
		public override bool Equals(object obj); // 0x00000001825445D0-0x0000000182544680
		public override int GetHashCode(); // 0x00000001824CC220-0x00000001824CC240
		public override string ToString(); // 0x00000001825446F0-0x0000000182544840
	}
}
