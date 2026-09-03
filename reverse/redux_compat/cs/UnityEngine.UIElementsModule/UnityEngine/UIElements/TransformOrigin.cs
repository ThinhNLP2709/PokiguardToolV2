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
	public struct TransformOrigin : IEquatable<TransformOrigin> // TypeDefIndex: 4691
	{
		// Fields
		[SerializeField]
		private Length m_X; // 0x00
		[SerializeField]
		private Length m_Y; // 0x08
		[SerializeField]
		private float m_Z; // 0x10
	
		// Properties
		public Length x { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180CBE820-0x0000000180CBE830
		public Length y { get; set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000181663F00-0x0000000181663F10
		public float z { get; set; } // 0x00000001807187E0-0x00000001807187F0 0x00000001807187F0-0x0000000180718800
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<TransformOrigin> // TypeDefIndex: 4692
		{
			// Nested types
			private class XProperty : Property<TransformOrigin, Length> // TypeDefIndex: 4693
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
				public XProperty(); // 0x0000000182577880-0x00000001825778D0
	
				// Methods
				public override Length GetValue(ref TransformOrigin container); // 0x0000000180691EA0-0x0000000180691EB0
				public override void SetValue(ref TransformOrigin container, Length value); // 0x00000001823CEF70-0x00000001823CEF80
			}
	
			private class YProperty : Property<TransformOrigin, Length> // TypeDefIndex: 4694
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
				public YProperty(); // 0x00000001825778D0-0x0000000182577920
	
				// Methods
				public override Length GetValue(ref TransformOrigin container); // 0x0000000181B55CB0-0x0000000181B55CC0
				public override void SetValue(ref TransformOrigin container, Length value); // 0x00000001823CEF10-0x00000001823CEF20
			}
	
			private class ZProperty : Property<TransformOrigin, float> // TypeDefIndex: 4695
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
				public ZProperty(); // 0x00000001825779E0-0x0000000182577E00
	
				// Methods
				public override float GetValue(ref TransformOrigin container); // 0x0000000182577970-0x0000000182577980
				public override void SetValue(ref TransformOrigin container, float value); // 0x0000000182577980-0x0000000182577990
			}
	
			// Constructors
			public PropertyBag(); // 0x000000018255DEB0-0x000000018255E080
		}
	
		// Constructors
		public TransformOrigin(Length x, Length y, float z); // 0x000000018256EF00-0x000000018256EF10
		internal TransformOrigin(Vector3 vector); // 0x000000018256EF10-0x000000018256EF60
	
		// Methods
		public static TransformOrigin Initial(); // 0x000000018256ED50-0x000000018256EDA0
		public static bool operator ==(TransformOrigin lhs, TransformOrigin rhs); // 0x000000018256EF60-0x000000018256EFD0
		public static bool operator !=(TransformOrigin lhs, TransformOrigin rhs); // 0x000000018256EFD0-0x000000018256F060
		public bool Equals(TransformOrigin other); // 0x000000018256EB40-0x000000018256EBD0
		public override bool Equals(object obj); // 0x000000018256EBD0-0x000000018256ECF0
		public override int GetHashCode(); // 0x000000018256ECF0-0x000000018256ED50
		public override string ToString(); // 0x000000018256EDA0-0x000000018256EF00
	}
}
