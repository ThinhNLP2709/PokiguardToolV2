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

namespace UnityEngine.UIElements
{
	[Serializable]
	public struct Rotate : IEquatable<Rotate> // TypeDefIndex: 4649
	{
		// Fields
		[SerializeField]
		private Angle m_Angle; // 0x00
		[SerializeField]
		private Vector3 m_Axis; // 0x08
		[SerializeField]
		private bool m_IsNone; // 0x14
	
		// Properties
		public Angle angle { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180CBE820-0x0000000180CBE830
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal Vector3 axis { get; set; } // 0x0000000181325DC0-0x0000000181325DE0 0x000000018255F2C0-0x000000018255F2D0
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<Rotate> // TypeDefIndex: 4650
		{
			// Nested types
			private class AngleProperty : Property<Rotate, Angle> // TypeDefIndex: 4651
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
				public AngleProperty(); // 0x000000018255DA00-0x000000018255DA50
	
				// Methods
				public override Angle GetValue(ref Rotate container); // 0x0000000180691EA0-0x0000000180691EB0
				public override void SetValue(ref Rotate container, Angle value); // 0x00000001823CEF70-0x00000001823CEF80
			}
	
			private class AxisProperty : Property<Rotate, Vector3> // TypeDefIndex: 4652
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
				public AxisProperty(); // 0x000000018255DB40-0x000000018255DB90
	
				// Methods
				public override Vector3 GetValue(ref Rotate container); // 0x000000018255DB00-0x000000018255DB20
				public override void SetValue(ref Rotate container, Vector3 value); // 0x000000018255DB20-0x000000018255DB40
			}
	
			// Constructors
			public PropertyBag(); // 0x000000018255E4B0-0x000000018255E610
		}
	
		// Constructors
		public Rotate(Angle angle, Vector3 axis); // 0x000000018255F0F0-0x000000018255F110
		public Rotate(Angle angle); // 0x000000018255F110-0x000000018255F140
		public Rotate(Quaternion quaternion); // 0x000000018255F030-0x000000018255F0F0
	
		// Methods
		internal static Rotate Initial(); // 0x000000018255EDE0-0x000000018255EE60
		public static Rotate None(); // 0x000000018255EE60-0x000000018255EF10
		public static bool operator ==(Rotate lhs, Rotate rhs); // 0x000000018255F140-0x000000018255F270
		public static bool operator !=(Rotate lhs, Rotate rhs); // 0x000000018255F270-0x000000018255F2C0
		public bool Equals(Rotate other); // 0x000000018255ECA0-0x000000018255ECF0
		public override bool Equals(object obj); // 0x000000018255EBF0-0x000000018255ECA0
		public override int GetHashCode(); // 0x000000018255ECF0-0x000000018255EDE0
		public override string ToString(); // 0x000000018255EFA0-0x000000018255F030
		internal Quaternion ToQuaternion(); // 0x000000018255EF10-0x000000018255EFA0
	}
}
