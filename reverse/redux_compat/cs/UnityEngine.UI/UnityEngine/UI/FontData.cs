/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Serialization;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[Serializable]
	public class FontData : ISerializationCallbackReceiver // TypeDefIndex: 13033
	{
		// Fields
		[FormerlySerializedAs("font")]
		[SerializeField]
		private Font m_Font; // 0x10
		[FormerlySerializedAs("fontSize")]
		[SerializeField]
		private int m_FontSize; // 0x18
		[FormerlySerializedAs("fontStyle")]
		[SerializeField]
		private FontStyle m_FontStyle; // 0x1C
		[SerializeField]
		private bool m_BestFit; // 0x20
		[SerializeField]
		private int m_MinSize; // 0x24
		[SerializeField]
		private int m_MaxSize; // 0x28
		[FormerlySerializedAs("alignment")]
		[SerializeField]
		private TextAnchor m_Alignment; // 0x2C
		[SerializeField]
		private bool m_AlignByGeometry; // 0x30
		[FormerlySerializedAs("richText")]
		[SerializeField]
		private bool m_RichText; // 0x31
		[SerializeField]
		private HorizontalWrapMode m_HorizontalOverflow; // 0x34
		[SerializeField]
		private VerticalWrapMode m_VerticalOverflow; // 0x38
		[SerializeField]
		private float m_LineSpacing; // 0x3C
	
		// Properties
		public static FontData defaultFontData { get; } // 0x000000018236B190-0x000000018236B210 
		public Font font { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public int fontSize { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public FontStyle fontStyle { get; set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public bool bestFit { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
		public int minSize { get; set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
		public int maxSize { get; set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		public TextAnchor alignment { get; set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
		public bool alignByGeometry { get; set; } // 0x00000001802E8950-0x00000001802E8960 0x00000001802E8960-0x00000001802E8970
		public bool richText { get; set; } // 0x0000000180634F10-0x0000000180634F20 0x0000000181B14860-0x0000000181B14870
		public HorizontalWrapMode horizontalOverflow { get; set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
		public VerticalWrapMode verticalOverflow { get; set; } // 0x000000018047EDE0-0x000000018047EDF0 0x00000001805D5570-0x00000001805D5580
		public float lineSpacing { get; set; } // 0x0000000181C58AB0-0x0000000181C58AC0 0x0000000181DBEB40-0x0000000181DBEB50
	
		// Constructors
		public FontData(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		void ISerializationCallbackReceiver.OnBeforeSerialize(); // 0x00000001802E76C0-0x00000001802E76D0
		void ISerializationCallbackReceiver.OnAfterDeserialize(); // 0x000000018236B140-0x000000018236B190
	}
}
