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
	public struct BackgroundSize : IEquatable<BackgroundSize> // TypeDefIndex: 3811
	{
		// Fields
		[SerializeField]
		private BackgroundSizeType m_SizeType; // 0x00
		[SerializeField]
		private Length m_X; // 0x04
		[SerializeField]
		private Length m_Y; // 0x0C
	
		// Properties
		public BackgroundSizeType sizeType { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x000000018237DBA0-0x000000018237DC00
		public Length x { get; set; } // 0x0000000180C57300-0x0000000180C57310 0x000000018237DD00-0x000000018237DD10
		public Length y { get; set; } // 0x00000001822C4EB0-0x00000001822C4EC0 0x000000018237DD10-0x000000018237DD20
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<BackgroundSize> // TypeDefIndex: 3812
		{
			// Nested types
			private class SizeTypeProperty : Property<BackgroundSize, BackgroundSizeType> // TypeDefIndex: 3813
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
				public SizeTypeProperty(); // 0x0000000182392B40-0x0000000182392B90
	
				// Methods
				public override BackgroundSizeType GetValue(ref BackgroundSize container); // 0x0000000180E6B260-0x0000000180E6B270
				public override void SetValue(ref BackgroundSize container, BackgroundSizeType value); // 0x0000000182392AE0-0x0000000182392B40
			}
	
			private class XProperty : Property<BackgroundSize, Length> // TypeDefIndex: 3814
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
				public XProperty(); // 0x0000000182399680-0x00000001823996D0
	
				// Methods
				public override Length GetValue(ref BackgroundSize container); // 0x0000000182392540-0x0000000182392550
				public override void SetValue(ref BackgroundSize container, Length value); // 0x0000000182399670-0x0000000182399680
			}
	
			private class YProperty : Property<BackgroundSize, Length> // TypeDefIndex: 3815
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
				public YProperty(); // 0x0000000182399740-0x0000000182399790
	
				// Methods
				public override Length GetValue(ref BackgroundSize container); // 0x0000000182399720-0x0000000182399730
				public override void SetValue(ref BackgroundSize container, Length value); // 0x0000000182399730-0x0000000182399740
			}
	
			// Constructors
			public PropertyBag(); // 0x0000000182392860-0x0000000182392A30
		}
	
		// Constructors
		public BackgroundSize(Length sizeX, Length sizeY); // 0x000000018237DB90-0x000000018237DBA0
		public BackgroundSize(BackgroundSizeType sizeType); // 0x000000018237DBA0-0x000000018237DC00
		internal BackgroundSize(BackgroundSizeType sizeType, Length x, Length y); // 0x000000018237DC00-0x000000018237DC10
	
		// Methods
		internal static BackgroundSize Initial(); // 0x000000018237DA70-0x000000018237DAD0
		public override bool Equals(object obj); // 0x000000018237D8F0-0x000000018237D9B0
		public bool Equals(BackgroundSize other); // 0x000000018237D9B0-0x000000018237DA10
		public override int GetHashCode(); // 0x000000018237DA10-0x000000018237DA70
		public static bool operator ==(BackgroundSize style1, BackgroundSize style2); // 0x000000018237DC10-0x000000018237DC80
		public static bool operator !=(BackgroundSize style1, BackgroundSize style2); // 0x000000018237DC80-0x000000018237DD00
		public override string ToString(); // 0x000000018237DAD0-0x000000018237DB90
	}
}
