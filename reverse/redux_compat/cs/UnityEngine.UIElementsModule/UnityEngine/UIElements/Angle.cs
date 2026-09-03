/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
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
	public struct Angle : IEquatable<Angle> // TypeDefIndex: 4350
	{
		// Fields
		private static readonly Dictionary<string, AngleUnit> s_AngleUnitLookup; // 0x00
		[SerializeField]
		private float m_Value; // 0x00
		[SerializeField]
		private Unit m_Unit; // 0x04
	
		// Properties
		public float value { get; set; } // 0x000000018035C780-0x000000018035C790 0x0000000181DBFEC0-0x0000000181DBFED0
		public AngleUnit unit { get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
	
		// Nested types
		private enum Unit // TypeDefIndex: 4351
		{
			Degree = 0,
			Gradian = 1,
			Radian = 2,
			Turn = 3,
			None = 4
		}
	
		internal class PropertyBag : ContainerPropertyBag<Angle> // TypeDefIndex: 4352
		{
			// Nested types
			private class ValueProperty : Property<Angle, float> // TypeDefIndex: 4353
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
				public ValueProperty(); // 0x00000001824E2F60-0x00000001824E2FB0
	
				// Methods
				public override float GetValue(ref Angle container); // 0x00000001824E2EB0-0x00000001824E2F00
				public override void SetValue(ref Angle container, float value); // 0x00000001824E2F00-0x00000001824E2F60
			}
	
			private class UnitProperty : Property<Angle, AngleUnit> // TypeDefIndex: 4354
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
				public UnitProperty(); // 0x00000001824E2B40-0x00000001824E2B90
	
				// Methods
				public override AngleUnit GetValue(ref Angle container); // 0x00000001824E2AA0-0x00000001824E2AF0
				public override void SetValue(ref Angle container, AngleUnit value); // 0x00000001824E2AF0-0x00000001824E2B40
			}
	
			// Constructors
			public PropertyBag(); // 0x00000001824DC700-0x00000001824DC860
		}
	
		// Constructors
		public Angle(float value, AngleUnit unit); // 0x00000001824CC650-0x00000001824CC6B0
		private Angle(float value, Unit unit); // 0x00000001824CC640-0x00000001824CC650
		static Angle(); // 0x00000001824CC480-0x00000001824CC640
	
		// Methods
		public static Angle Degrees(float value); // 0x00000001824CC090-0x00000001824CC0F0
		internal static Angle None(); // 0x00000001824CC250-0x00000001824CC270
		internal bool IsNone(); // 0x00000001824CC240-0x00000001824CC250
		public float ToDegrees(); // 0x00000001824CC270-0x00000001824CC2D0
		public static implicit operator Angle(float value); // 0x00000001824CC090-0x00000001824CC0F0
		public static bool operator ==(Angle lhs, Angle rhs); // 0x00000001824CC6B0-0x00000001824CC6E0
		public static bool operator !=(Angle lhs, Angle rhs); // 0x00000001824CC6E0-0x00000001824CC770
		public bool Equals(Angle other); // 0x00000001824CC190-0x00000001824CC220
		public override bool Equals(object obj); // 0x00000001824CC0F0-0x00000001824CC190
		public override int GetHashCode(); // 0x00000001824CC220-0x00000001824CC240
		public override string ToString(); // 0x00000001824CC2D0-0x00000001824CC480
	}
}
