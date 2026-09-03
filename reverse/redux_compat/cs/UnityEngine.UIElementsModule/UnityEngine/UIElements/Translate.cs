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
	public struct Translate : IEquatable<Translate> // TypeDefIndex: 4696
	{
		// Fields
		[SerializeField]
		private Length m_X; // 0x00
		[SerializeField]
		private Length m_Y; // 0x08
		[SerializeField]
		private float m_Z; // 0x10
		[SerializeField]
		private bool m_isNone; // 0x14
	
		// Properties
		public Length x { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180CBE820-0x0000000180CBE830
		public Length y { get; set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000181663F00-0x0000000181663F10
		public float z { get; set; } // 0x00000001807187E0-0x00000001807187F0 0x00000001807187F0-0x0000000180718800
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<Translate> // TypeDefIndex: 4697
		{
			// Nested types
			private class XProperty : Property<Translate, Length> // TypeDefIndex: 4698
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
				public XProperty(); // 0x0000000182577830-0x0000000182577880
	
				// Methods
				public override Length GetValue(ref Translate container); // 0x0000000180691EA0-0x0000000180691EB0
				public override void SetValue(ref Translate container, Length value); // 0x00000001823CEF70-0x00000001823CEF80
			}
	
			private class YProperty : Property<Translate, Length> // TypeDefIndex: 4699
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
				public YProperty(); // 0x0000000182577920-0x0000000182577970
	
				// Methods
				public override Length GetValue(ref Translate container); // 0x0000000181B55CB0-0x0000000181B55CC0
				public override void SetValue(ref Translate container, Length value); // 0x00000001823CEF10-0x00000001823CEF20
			}
	
			private class ZProperty : Property<Translate, float> // TypeDefIndex: 4700
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
				public ZProperty(); // 0x0000000182577990-0x00000001825779E0
	
				// Methods
				public override float GetValue(ref Translate container); // 0x0000000182577970-0x0000000182577980
				public override void SetValue(ref Translate container, float value); // 0x0000000182577980-0x0000000182577990
			}
	
			// Constructors
			public PropertyBag(); // 0x000000018255E080-0x000000018255E250
		}
	
		// Constructors
		public Translate(Length x, Length y, float z); // 0x000000018256F380-0x000000018256F3A0
		internal Translate(Vector3 v); // 0x000000018256F330-0x000000018256F380
	
		// Methods
		public static implicit operator Translate(Vector3 v); // 0x000000018256F460-0x000000018256F4D0
		public static Translate None(); // 0x000000018256F1B0-0x000000018256F1D0
		public static bool operator ==(Translate lhs, Translate rhs); // 0x000000018256F3A0-0x000000018256F460
		public static bool operator !=(Translate lhs, Translate rhs); // 0x000000018256F4D0-0x000000018256F5B0
		public bool Equals(Translate other); // 0x000000018256F060-0x000000018256F110
		public override bool Equals(object obj); // 0x000000018256F110-0x000000018256F1B0
		public override int GetHashCode(); // 0x000000018256ECF0-0x000000018256ED50
		public override string ToString(); // 0x000000018256F1D0-0x000000018256F330
	}
}
