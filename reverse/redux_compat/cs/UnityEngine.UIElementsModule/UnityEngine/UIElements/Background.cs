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
	public struct Background : IEquatable<Background> // TypeDefIndex: 4355
	{
		// Fields
		[SerializeField]
		private Texture2D m_Texture; // 0x00
		[SerializeField]
		private Sprite m_Sprite; // 0x08
		[SerializeField]
		private RenderTexture m_RenderTexture; // 0x10
		[SerializeField]
		private VectorImage m_VectorImage; // 0x18
		[SerializeField]
		private BackgroundGradient m_Gradient; // 0x20
	
		// Properties
		public Texture2D texture { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x00000001824D0D80-0x00000001824D0E40
		public Sprite sprite { get; set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x00000001824D0CC0-0x00000001824D0D80
		public RenderTexture renderTexture { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001824D0C00-0x00000001824D0CC0
		public VectorImage vectorImage { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001824D0E40-0x00000001824D0F00
		public BackgroundGradient gradient { get; } // 0x00000001824D0AE0-0x00000001824D0B00 
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<Background> // TypeDefIndex: 4356
		{
			// Nested types
			private class TextureProperty : Property<Background, Texture2D> // TypeDefIndex: 4357
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
				public TextureProperty(); // 0x00000001824DD250-0x00000001824DD2A0
	
				// Methods
				public override Texture2D GetValue(ref Background container); // 0x0000000180691EA0-0x0000000180691EB0
				public override void SetValue(ref Background container, Texture2D value); // 0x00000001824DD230-0x00000001824DD250
			}
	
			private class SpriteProperty : Property<Background, Sprite> // TypeDefIndex: 4358
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
				public SpriteProperty(); // 0x00000001824DCE70-0x00000001824DCEC0
	
				// Methods
				public override Sprite GetValue(ref Background container); // 0x0000000181B55CB0-0x0000000181B55CC0
				public override void SetValue(ref Background container, Sprite value); // 0x00000001824DCE50-0x00000001824DCE70
			}
	
			private class RenderTextureProperty : Property<Background, RenderTexture> // TypeDefIndex: 4359
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
				public RenderTextureProperty(); // 0x00000001824DC890-0x00000001824DC8E0
	
				// Methods
				public override RenderTexture GetValue(ref Background container); // 0x00000001824DC860-0x00000001824DC870
				public override void SetValue(ref Background container, RenderTexture value); // 0x00000001824DC870-0x00000001824DC890
			}
	
			private class VectorImageProperty : Property<Background, VectorImage> // TypeDefIndex: 4360
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
				public VectorImageProperty(); // 0x00000001824E2FE0-0x00000001824E3030
	
				// Methods
				public override VectorImage GetValue(ref Background container); // 0x00000001824E2FB0-0x00000001824E2FC0
				public override void SetValue(ref Background container, VectorImage value); // 0x00000001824E2FC0-0x00000001824E2FE0
			}
	
			// Constructors
			public PropertyBag(); // 0x00000001824DC4B0-0x00000001824DC700
		}
	
		// Methods
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static void To([IsReadOnly] in Background background, out EntityId entityId); // 0x00000001824D09F0-0x00000001824D0AE0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static Background From([IsReadOnly] in UnmanagedBackground bg); // 0x00000001824D0630-0x00000001824D0710
		public static Background FromTexture2D(Texture2D t); // 0x00000001824D05D0-0x00000001824D0600
		public static Background FromRenderTexture(RenderTexture rt); // 0x00000001824D0570-0x00000001824D05A0
		public static Background FromSprite(Sprite s); // 0x00000001824D05A0-0x00000001824D05D0
		public static Background FromVectorImage(VectorImage vi); // 0x00000001824D0600-0x00000001824D0630
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static Background FromObject(object obj); // 0x00000001824D0330-0x00000001824D0570
		public UnityEngine.Object GetSelectedImage(); // 0x00000001824D0810-0x00000001824D08E0
		public static bool operator ==(Background lhs, Background rhs); // 0x00000001824D0B00-0x00000001824D0C00
		public bool Equals(Background other); // 0x00000001824D02C0-0x00000001824D0330
		public override bool Equals(object obj); // 0x00000001824D01D0-0x00000001824D02C0
		public override int GetHashCode(); // 0x00000001824D0710-0x00000001824D0810
		public override string ToString(); // 0x00000001824D08E0-0x00000001824D09F0
	}
}
