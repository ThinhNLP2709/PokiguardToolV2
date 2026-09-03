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
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	public struct FontDefinition : IEquatable<FontDefinition> // TypeDefIndex: 4383
	{
		// Fields
		[SerializeField]
		private Font m_Font; // 0x00
		[SerializeField]
		private FontAsset m_FontAsset; // 0x08
	
		// Properties
		public Font font { [IsReadOnly] get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000182526FE0-0x00000001825270B0
		public FontAsset fontAsset { [IsReadOnly] get; set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000182526F10-0x0000000182526FE0
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<FontDefinition> // TypeDefIndex: 4384
		{
			// Nested types
			private class FontProperty : Property<FontDefinition, Font> // TypeDefIndex: 4385
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
				public FontProperty(); // 0x0000000182527180-0x00000001825271D0
	
				// Methods
				public override Font GetValue(ref FontDefinition container); // 0x0000000180691EA0-0x0000000180691EB0
				public override void SetValue(ref FontDefinition container, Font value); // 0x00000001825270B0-0x0000000182527180
			}
	
			private class FontAssetProperty : Property<FontDefinition, FontAsset> // TypeDefIndex: 4386
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
				public FontAssetProperty(); // 0x0000000182526A10-0x0000000182526A60
	
				// Methods
				public override FontAsset GetValue(ref FontDefinition container); // 0x0000000181B55CB0-0x0000000181B55CC0
				public override void SetValue(ref FontDefinition container, FontAsset value); // 0x0000000182526940-0x0000000182526A10
			}
	
			// Constructors
			public PropertyBag(); // 0x0000000182537C90-0x0000000182537DF0
		}
	
		// Methods
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal static FontDefinition From([IsReadOnly] in EntityId entityId); // 0x0000000182526CA0-0x0000000182526CE0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static void To([IsReadOnly] in FontDefinition fontDefinition, out EntityId entityId); // 0x0000000182526ED0-0x0000000182526F10
		[IsReadOnly]
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal UnityEngine.Object GetSelectedFont(); // 0x0000000182526DB0-0x0000000182526E40
		public static FontDefinition FromFont(Font f); // 0x0000000182526B10-0x0000000182526B40
		public static FontDefinition FromSDFFont(FontAsset f); // 0x0000000182526C70-0x0000000182526CA0
		internal static FontDefinition FromObject(object obj); // 0x0000000182526B40-0x0000000182526C70
		public override string ToString(); // 0x0000000182526E40-0x0000000182526ED0
		public bool Equals(FontDefinition other); // 0x0000000180DF4E40-0x0000000180DF4E90
		public override bool Equals(object obj); // 0x0000000182526A60-0x0000000182526B10
		public override int GetHashCode(); // 0x0000000182526CE0-0x0000000182526DB0
	}
}
