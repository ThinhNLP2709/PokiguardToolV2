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
	public struct TimeValue : IEquatable<TimeValue> // TypeDefIndex: 4687
	{
		// Fields
		[SerializeField]
		private float m_Value; // 0x00
		[SerializeField]
		private TimeUnit m_Unit; // 0x04
	
		// Properties
		public float value { get; set; } // 0x000000018035C780-0x000000018035C790 0x0000000181DBFEC0-0x0000000181DBFED0
		public TimeUnit unit { get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<TimeValue> // TypeDefIndex: 4688
		{
			// Nested types
			private class ValueProperty : Property<TimeValue, float> // TypeDefIndex: 4689
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
				public ValueProperty(); // 0x0000000182571200-0x0000000182571250
	
				// Methods
				public override float GetValue(ref TimeValue container); // 0x00000001822E1A10-0x00000001822E1A20
				public override void SetValue(ref TimeValue container, float value); // 0x00000001822E1A20-0x00000001822E1A30
			}
	
			private class UnitProperty : Property<TimeValue, TimeUnit> // TypeDefIndex: 4690
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
				public UnitProperty(); // 0x000000018256F640-0x000000018256F690
	
				// Methods
				public override TimeUnit GetValue(ref TimeValue container); // 0x000000018132C0D0-0x000000018132C0E0
				public override void SetValue(ref TimeValue container, TimeUnit value); // 0x000000018132C1B0-0x000000018132C1C0
			}
	
			// Constructors
			public PropertyBag(); // 0x000000018255E860-0x000000018255E9C0
		}
	
		// Constructors
		public TimeValue(float value); // 0x0000000182564780-0x0000000182564790
		public TimeValue(float value, TimeUnit unit); // 0x00000001824CC640-0x00000001824CC650
	
		// Methods
		public static implicit operator TimeValue(float value); // 0x00000001825647D0-0x00000001825647F0
		public static bool operator ==(TimeValue lhs, TimeValue rhs); // 0x00000001824CC6B0-0x00000001824CC6E0
		public static bool operator !=(TimeValue lhs, TimeValue rhs); // 0x000000018256EB10-0x000000018256EB40
		public bool Equals(TimeValue other); // 0x000000018256E950-0x000000018256E980
		public override bool Equals(object obj); // 0x000000018256E980-0x000000018256EA30
		public override int GetHashCode(); // 0x00000001824CC220-0x00000001824CC240
		public override string ToString(); // 0x000000018256EA30-0x000000018256EB10
	}
}
