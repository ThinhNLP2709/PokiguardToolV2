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
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public struct StylePropertyName : IEquatable<UnityEngine.UIElements.StylePropertyName>, IEquatable<StylePropertyId> // TypeDefIndex: 4774
	{
		// Fields
		[CompilerGenerated]
		private readonly StylePropertyId _id_k__BackingField; // 0x00
		[CompilerGenerated]
		private readonly string _name_k__BackingField; // 0x08
	
		// Properties
		internal StylePropertyId id { [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] [IsReadOnly] [CompilerGenerated] get; } // 0x0000000180732D10-0x0000000180732D20 
		private string name { [IsReadOnly] [CompilerGenerated] get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<StylePropertyName> // TypeDefIndex: 4775
		{
			// Nested types
			private class IdProperty : Property<StylePropertyName, StylePropertyId> // TypeDefIndex: 4776
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
				public IdProperty(); // 0x000000018255DD90-0x000000018255DDF0
	
				// Methods
				public override StylePropertyId GetValue(ref StylePropertyName container); // 0x0000000180E6B260-0x0000000180E6B270
				public override void SetValue(ref StylePropertyName container, StylePropertyId value); // 0x00000001802E76C0-0x00000001802E76D0
			}
	
			private class NameProperty : Property<StylePropertyName, string> // TypeDefIndex: 4777
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
				public NameProperty(); // 0x000000018255DE50-0x000000018255DEB0
	
				// Methods
				public override string GetValue(ref StylePropertyName container); // 0x0000000181B55CB0-0x0000000181B55CC0
				public override void SetValue(ref StylePropertyName container, string value); // 0x00000001802E76C0-0x00000001802E76D0
			}
	
			// Constructors
			public PropertyBag(); // 0x000000018255E340-0x000000018255E4B0
		}
	
		// Constructors
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal StylePropertyName(StylePropertyId stylePropertyId); // 0x0000000182567A40-0x0000000182567B00
		public StylePropertyName(string name); // 0x0000000182567980-0x0000000182567A40
	
		// Methods
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal static StylePropertyId StylePropertyIdFromString(string name); // 0x00000001825678E0-0x0000000182567980
		public static bool operator ==(StylePropertyName lhs, StylePropertyName rhs); // 0x000000018216CF90-0x000000018216CFA0
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		public override bool Equals(object other); // 0x0000000182567860-0x00000001825678E0
		public bool Equals(StylePropertyName other); // 0x000000018216CF90-0x000000018216CFA0
		bool IEquatable<StylePropertyId>.Equals(StylePropertyId other); // 0x00000001815FCAB0-0x00000001815FCAC0
		public override string ToString(); // 0x0000000180C5CF90-0x0000000180C5CFA0
	}
}
