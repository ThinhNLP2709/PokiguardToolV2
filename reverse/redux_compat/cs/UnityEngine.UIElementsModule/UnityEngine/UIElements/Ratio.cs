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
	[IsReadOnly]
	public struct Ratio : IEquatable<UnityEngine.UIElements.Ratio> // TypeDefIndex: 4645
	{
		// Fields
		private readonly float m_Value; // 0x00
	
		// Properties
		public float value { get; } // 0x000000018035C780-0x000000018035C790 
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<Ratio> // TypeDefIndex: 4646
		{
			// Nested types
			private class ValueProperty : Property<Ratio, float> // TypeDefIndex: 4647
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
				public ValueProperty(); // 0x00000001825711B0-0x0000000182571200
	
				// Methods
				public override float GetValue(ref Ratio container); // 0x00000001822E1A10-0x00000001822E1A20
				public override void SetValue(ref Ratio container, float value); // 0x0000000182571170-0x00000001825711B0
			}
	
			private class AutoProperty : Property<Ratio, bool> // TypeDefIndex: 4648
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
				public AutoProperty(); // 0x000000018255DAA0-0x000000018255DB00
	
				// Methods
				public override bool GetValue(ref Ratio container); // 0x000000018255DA50-0x000000018255DA60
				public override void SetValue(ref Ratio container, bool value); // 0x000000018255DA60-0x000000018255DAA0
			}
	
			// Constructors
			public PropertyBag(); // 0x000000018255E610-0x000000018255E770
		}
	
		// Constructors
		public Ratio(float value); // 0x0000000181DBFEC0-0x0000000181DBFED0
	
		// Methods
		public static Ratio Auto(); // 0x000000018255E9C0-0x000000018255E9D0
		public bool IsAuto(); // 0x000000018255EAE0-0x000000018255EAF0
		public static implicit operator Ratio(float value); // 0x000000018155DBB0-0x000000018155DBC0
		public static implicit operator float(Ratio value); // 0x000000018155DBA0-0x000000018155DBB0
		public static bool operator ==(Ratio lhs, Ratio rhs); // 0x000000018255EB70-0x000000018255EBB0
		public static bool operator !=(Ratio lhs, Ratio rhs); // 0x000000018255EBB0-0x000000018255EBF0
		public bool Equals(Ratio other); // 0x000000018255EA80-0x000000018255EAC0
		public override bool Equals(object obj); // 0x000000018255E9D0-0x000000018255EA80
		public override int GetHashCode(); // 0x000000018255EAC0-0x000000018255EAE0
		public override string ToString(); // 0x000000018255EAF0-0x000000018255EB70
	}
}
