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
	public struct BackgroundPosition : IEquatable<UnityEngine.UIElements.BackgroundPosition> // TypeDefIndex: 3802
	{
		// Fields
		public BackgroundPositionKeyword keyword; // 0x00
		public Length offset; // 0x04
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<BackgroundPosition> // TypeDefIndex: 3803
		{
			// Nested types
			private class KeywordProperty : Property<BackgroundPosition, BackgroundPositionKeyword> // TypeDefIndex: 3804
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
				public KeywordProperty(); // 0x0000000182392380-0x00000001823923D0
	
				// Methods
				public override BackgroundPositionKeyword GetValue(ref BackgroundPosition container); // 0x0000000180E6B260-0x0000000180E6B270
				public override void SetValue(ref BackgroundPosition container, BackgroundPositionKeyword value); // 0x000000018132C1A0-0x000000018132C1B0
			}
	
			private class OffsetProperty : Property<BackgroundPosition, Length> // TypeDefIndex: 3805
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
				public OffsetProperty(); // 0x0000000182392560-0x00000001823925B0
	
				// Methods
				public override Length GetValue(ref BackgroundPosition container); // 0x0000000182392540-0x0000000182392550
				public override void SetValue(ref BackgroundPosition container, Length value); // 0x0000000182392550-0x0000000182392560
			}
	
			// Constructors
			public PropertyBag(); // 0x0000000182392700-0x0000000182392860
		}
	
		// Constructors
		public BackgroundPosition(BackgroundPositionKeyword keyword); // 0x000000018237D170-0x000000018237D1B0
		public BackgroundPosition(BackgroundPositionKeyword keyword, Length offset); // 0x0000000181327DB0-0x0000000181327DC0
	
		// Methods
		internal static BackgroundPosition Initial(); // 0x000000018237D080-0x000000018237D0D0
		public override bool Equals(object obj); // 0x000000018237CF90-0x000000018237D040
		public bool Equals(BackgroundPosition other); // 0x000000018237CF40-0x000000018237CF90
		public override int GetHashCode(); // 0x000000018237D040-0x000000018237D080
		public static bool operator ==(BackgroundPosition style1, BackgroundPosition style2); // 0x000000018237D1B0-0x000000018237D210
		public static bool operator !=(BackgroundPosition style1, BackgroundPosition style2); // 0x000000018237D210-0x000000018237D280
		public override string ToString(); // 0x000000018237D0D0-0x000000018237D170
	}
}
