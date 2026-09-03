/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;
using UnityEngine.UIElements.UIR;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	internal class DynamicAtlas : AtlasBase // TypeDefIndex: 3797
	{
		// Fields
		private Dictionary<Texture, TextureInfo> m_Database; // 0x18
		private DynamicAtlasPage m_PointPage; // 0x20
		private DynamicAtlasPage m_BilinearPage; // 0x28
		private ColorSpace m_ColorSpace; // 0x30
		private List<IPanel> m_Panels; // 0x38
		private int m_MinAtlasSize; // 0x40
		private int m_MaxAtlasSize; // 0x44
		private int m_MaxSubTextureSize; // 0x48
		private DynamicAtlasFilters m_ActiveFilters; // 0x4C
		private DynamicAtlasCustomFilter m_CustomFilter; // 0x50
	
		// Properties
		internal bool isInitialized { get; } // 0x000000018238B020-0x000000018238B040 
		public int minAtlasSize { set; } // 0x000000018238B100-0x000000018238B120
		public int maxAtlasSize { set; } // 0x000000018238B0C0-0x000000018238B0E0
		public static DynamicAtlasFilters defaultFilters { get; } // 0x0000000181AEE450-0x0000000181AEE460 
		public DynamicAtlasFilters activeFilters { set; } // 0x000000018238B040-0x000000018238B060
		public int maxSubTextureSize { get; set; } // 0x000000018033D1C0-0x000000018033D1D0 0x000000018238B0E0-0x000000018238B100
		public DynamicAtlasCustomFilter customFilter { set; } // 0x000000018238B060-0x000000018238B0C0
	
		// Nested types
		internal class TextureInfo : LinkedPoolItem<TextureInfo> // TypeDefIndex: 3798
		{
			// Fields
			public DynamicAtlasPage page; // 0x18
			public int counter; // 0x20
			public Allocator2D.Alloc2D alloc; // 0x28
			public RectInt rect; // 0x58
			public static readonly LinkedPool<TextureInfo> pool; // 0x00
	
			// Constructors
			public TextureInfo(); // 0x00000001802F4070-0x00000001802F4080
			static TextureInfo(); // 0x0000000182392CB0-0x0000000182392DC0
	
			// Methods
			private static TextureInfo Create(); // 0x0000000182392C10-0x0000000182392C60
			private static void Reset(TextureInfo info); // 0x0000000182392C60-0x0000000182392CB0
		}
	
		// Constructors
		public DynamicAtlas(); // 0x000000018238AEB0-0x000000018238B020
	
		// Methods
		protected override void OnAssignedToPanel(IPanel panel); // 0x000000018238A500-0x000000018238A5C0
		protected override void OnRemovedFromPanel(IPanel panel); // 0x000000018238A5C0-0x000000018238A640
		public override void Reset(); // 0x000000018238A6C0-0x000000018238A810
		private void InitPages(); // 0x000000018238A150-0x000000018238A2A0
		private void DestroyPages(); // 0x000000018238A0E0-0x000000018238A150
		public override bool TryGetAtlas(VisualElement ve, Texture2D src, out TextureId atlas, out RectInt atlasRect); // 0x000000018238A950-0x000000018238AEB0
		public override void ReturnAtlas(VisualElement ve, Texture2D src, TextureId atlas); // 0x000000018238A810-0x000000018238A950
		protected override void OnUpdateDynamicTextures(IPanel panel); // 0x000000018238A640-0x000000018238A6C0
		internal static bool IsTextureFormatSupported(TextureFormat format); // 0x000000018238A2A0-0x000000018238A330
		public virtual bool IsTextureValid(Texture2D texture, FilterMode atlasFilterMode); // 0x000000018238A330-0x000000018238A500
	}
}
