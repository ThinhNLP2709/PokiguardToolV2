/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[AddComponentMenu("UI (Canvas)/Legacy/Text", 100)]
	[RequireComponent(typeof(CanvasRenderer))]
	[UGUIHelpURL("Text")]
	public class Text : MaskableGraphic, ILayoutElement // TypeDefIndex: 13125
	{
		// Fields
		[SerializeField]
		private FontData m_FontData; // 0xE0
		[SerializeField]
		[TextArea(3, 10)]
		protected string m_Text; // 0xE8
		private TextGenerator m_TextCache; // 0xF0
		private TextGenerator m_TextCacheForLayout; // 0xF8
		[NonSerialized]
		protected bool m_DisableFontTextureRebuiltCallback; // 0x100
		private readonly UIVertex[] m_TempVerts; // 0x108
	
		// Properties
		public TextGenerator cachedTextGenerator { get; } // 0x00000001825AA0C0-0x00000001825AA170 
		public TextGenerator cachedTextGeneratorForLayout { get; } // 0x00000001825AA040-0x00000001825AA0C0 
		public override Texture mainTexture { get; } // 0x00000001825AA210-0x00000001825AA3C0 
		public Font font { get; set; } // 0x00000001825AA1B0-0x00000001825AA1D0 0x00000001825AA960-0x00000001825AAA90
		public virtual string text { get; set; } // 0x00000001806BAE70-0x00000001806BAE80 0x00000001825AACE0-0x00000001825AADD0
		public bool supportRichText { get; set; } // 0x00000001825AA7C0-0x00000001825AA7E0 0x00000001825AAC80-0x00000001825AACE0
		public bool resizeTextForBestFit { get; set; } // 0x00000001825AA760-0x00000001825AA780 0x00000001825AAB60-0x00000001825AABC0
		public int resizeTextMinSize { get; set; } // 0x00000001825AA7A0-0x00000001825AA7C0 0x00000001825AAC20-0x00000001825AAC80
		public int resizeTextMaxSize { get; set; } // 0x00000001825AA780-0x00000001825AA7A0 0x00000001825AABC0-0x00000001825AAC20
		public TextAnchor alignment { get; set; } // 0x00000001825AA020-0x00000001825AA040 0x00000001825AA840-0x00000001825AA8A0
		public bool alignByGeometry { get; set; } // 0x00000001825AA000-0x00000001825AA020 0x00000001825AA800-0x00000001825AA840
		public int fontSize { get; set; } // 0x00000001825AA170-0x00000001825AA190 0x00000001825AA8A0-0x00000001825AA900
		public HorizontalWrapMode horizontalOverflow { get; set; } // 0x00000001825AA1D0-0x00000001825AA1F0 0x00000001825AAA90-0x00000001825AAAF0
		public VerticalWrapMode verticalOverflow { get; set; } // 0x00000001825AA7E0-0x00000001825AA800 0x00000001825AADD0-0x00000001825AAE30
		public float lineSpacing { get; set; } // 0x00000001825AA1F0-0x00000001825AA210 0x00000001825AAAF0-0x00000001825AAB60
		public FontStyle fontStyle { get; set; } // 0x00000001825AA190-0x00000001825AA1B0 0x00000001825AA900-0x00000001825AA960
		public float pixelsPerUnit { get; } // 0x00000001825AA3C0-0x00000001825AA510 
		public virtual float minWidth { get; } // 0x00000001807185C0-0x00000001807185D0 
		public virtual float maxWidth { get; } // 0x00000001820939A0-0x00000001820939B0 
		public virtual float preferredWidth { get; } // 0x00000001825AA650-0x00000001825AA760 
		public virtual float flexibleWidth { get; } // 0x0000000181D048F0-0x0000000181D04900 
		public virtual float minHeight { get; } // 0x00000001807185C0-0x00000001807185D0 
		public virtual float maxHeight { get; } // 0x00000001820939A0-0x00000001820939B0 
		public virtual float preferredHeight { get; } // 0x00000001825AA510-0x00000001825AA650 
		public virtual float flexibleHeight { get; } // 0x0000000181D048F0-0x0000000181D04900 
		public virtual int layoutPriority { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		protected Text(); // 0x00000001825A9F60-0x00000001825AA000
	
		// Methods
		public void FontTextureChanged(); // 0x00000001825A9170-0x00000001825A9280
		protected override void OnEnable(); // 0x00000001825A96D0-0x00000001825A9780
		protected override void OnDisable(); // 0x00000001825A95D0-0x00000001825A96D0
		protected override void UpdateGeometry(); // 0x00000001825A9EE0-0x00000001825A9F60
		internal void AssignDefaultFont(); // 0x00000001825A9110-0x00000001825A9170
		internal void AssignDefaultFontIfNecessary(); // 0x00000001825A9060-0x00000001825A9110
		public TextGenerationSettings GetGenerationSettings(Vector2 extents); // 0x00000001825A9280-0x00000001825A94D0
		public static Vector2 GetTextAnchorPivot(TextAnchor anchor); // 0x00000001825A94D0-0x00000001825A95D0
		protected override void OnPopulateMesh(VertexHelper toFill); // 0x00000001825A9780-0x00000001825A9EE0
		public virtual void CalculateLayoutInputHorizontal(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void CalculateLayoutInputVertical(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
