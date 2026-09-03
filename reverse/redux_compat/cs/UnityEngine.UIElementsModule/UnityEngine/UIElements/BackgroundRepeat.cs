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
	public struct BackgroundRepeat : IEquatable<UnityEngine.UIElements.BackgroundRepeat> // TypeDefIndex: 3807
	{
		// Fields
		public Repeat x; // 0x00
		public Repeat y; // 0x04
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<BackgroundRepeat> // TypeDefIndex: 3808
		{
			// Nested types
			private class XProperty : Property<BackgroundRepeat, Repeat> // TypeDefIndex: 3809
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
				public XProperty(); // 0x00000001823996D0-0x0000000182399720
	
				// Methods
				public override Repeat GetValue(ref BackgroundRepeat container); // 0x0000000180E6B260-0x0000000180E6B270
				public override void SetValue(ref BackgroundRepeat container, Repeat value); // 0x000000018132C1A0-0x000000018132C1B0
			}
	
			private class YProperty : Property<BackgroundRepeat, Repeat> // TypeDefIndex: 3810
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
				public YProperty(); // 0x0000000182399790-0x00000001823997E0
	
				// Methods
				public override Repeat GetValue(ref BackgroundRepeat container); // 0x000000018132C0D0-0x000000018132C0E0
				public override void SetValue(ref BackgroundRepeat container, Repeat value); // 0x000000018132C1B0-0x000000018132C1C0
			}
	
			// Constructors
			public PropertyBag(); // 0x00000001823925B0-0x0000000182392700
		}
	
		// Constructors
		public BackgroundRepeat(Repeat repeatX, Repeat repeatY); // 0x0000000180C55C70-0x0000000180C55C80
	
		// Methods
		internal static BackgroundRepeat Initial(); // 0x0000000180E5ACD0-0x0000000180E5ACE0
		public override bool Equals(object obj); // 0x000000018237D750-0x000000018237D7E0
		public bool Equals(BackgroundRepeat other); // 0x0000000182274600-0x0000000182274620
		public override int GetHashCode(); // 0x000000018237D7E0-0x000000018237D820
		public static bool operator ==(BackgroundRepeat style1, BackgroundRepeat style2); // 0x000000018237D8B0-0x000000018237D8D0
		public static bool operator !=(BackgroundRepeat style1, BackgroundRepeat style2); // 0x000000018237D8D0-0x000000018237D8F0
		public override string ToString(); // 0x000000018237D820-0x000000018237D8B0
	}
}
