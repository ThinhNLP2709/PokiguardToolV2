/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 50: UnityEngine.TextCoreFontEngineModule.dll - Assembly: UnityEngine.TextCoreFontEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15505-15532

namespace UnityEngine.TextCore
{
	[Serializable]
	[UsedByNativeCode]
	public struct FaceInfo // TypeDefIndex: 15508
	{
		// Fields
		[NativeName("faceIndex")]
		[SerializeField]
		private int m_FaceIndex; // 0x00
		[NativeName("familyName")]
		[SerializeField]
		private string m_FamilyName; // 0x08
		[NativeName("styleName")]
		[SerializeField]
		private string m_StyleName; // 0x10
		[NativeName("pointSize")]
		[SerializeField]
		private float m_PointSize; // 0x18
		[NativeName("scale")]
		[SerializeField]
		private float m_Scale; // 0x1C
		[NativeName("unitsPerEM")]
		[SerializeField]
		private int m_UnitsPerEM; // 0x20
		[NativeName("lineHeight")]
		[SerializeField]
		private float m_LineHeight; // 0x24
		[NativeName("ascentLine")]
		[SerializeField]
		private float m_AscentLine; // 0x28
		[NativeName("capLine")]
		[SerializeField]
		private float m_CapLine; // 0x2C
		[NativeName("meanLine")]
		[SerializeField]
		private float m_MeanLine; // 0x30
		[NativeName("baseline")]
		[SerializeField]
		private float m_Baseline; // 0x34
		[NativeName("descentLine")]
		[SerializeField]
		private float m_DescentLine; // 0x38
		[NativeName("superscriptOffset")]
		[SerializeField]
		private float m_SuperscriptOffset; // 0x3C
		[NativeName("superscriptSize")]
		[SerializeField]
		private float m_SuperscriptSize; // 0x40
		[NativeName("subscriptOffset")]
		[SerializeField]
		private float m_SubscriptOffset; // 0x44
		[NativeName("subscriptSize")]
		[SerializeField]
		private float m_SubscriptSize; // 0x48
		[NativeName("underlineOffset")]
		[SerializeField]
		private float m_UnderlineOffset; // 0x4C
		[NativeName("underlineThickness")]
		[SerializeField]
		private float m_UnderlineThickness; // 0x50
		[NativeName("strikethroughOffset")]
		[SerializeField]
		private float m_StrikethroughOffset; // 0x54
		[NativeName("strikethroughThickness")]
		[SerializeField]
		private float m_StrikethroughThickness; // 0x58
		[NativeName("tabWidth")]
		[SerializeField]
		private float m_TabWidth; // 0x5C
	
		// Properties
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal int faceIndex { get; } // 0x0000000180732D10-0x0000000180732D20 
		public string familyName { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
		public string styleName { get; } // 0x0000000180377550-0x0000000180377560 
		public float pointSize { get; } // 0x00000001806CB0A0-0x00000001806CB0B0 
		public float scale { get; set; } // 0x0000000181CE2A30-0x0000000181CE2A40 0x0000000181EB7970-0x0000000181EB7980
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal int unitsPerEM { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public float lineHeight { get; } // 0x0000000181CE2830-0x0000000181CE2840 
		public float ascentLine { get; } // 0x0000000180F99790-0x0000000180F997A0 
		public float capLine { get; set; } // 0x000000018206CB50-0x000000018206CB60 0x000000018206CC90-0x000000018206CCA0
		public float meanLine { get; set; } // 0x00000001806CCB40-0x00000001806CCB50 0x00000001806CCD50-0x00000001806CCD60
		public float baseline { get; } // 0x0000000181230A40-0x0000000181230A50 
		public float descentLine { get; } // 0x0000000181C62E80-0x0000000181C62E90 
		public float superscriptOffset { get; } // 0x0000000181C58AB0-0x0000000181C58AC0 
		public float superscriptSize { get; } // 0x0000000181D8CC60-0x0000000181D8CC70 
		public float subscriptOffset { get; } // 0x0000000180349420-0x0000000180349430 
		public float subscriptSize { get; } // 0x000000018047EDF0-0x000000018047EE00 
		public float underlineOffset { get; } // 0x0000000181D8CC50-0x0000000181D8CC60 
		public float underlineThickness { get; } // 0x0000000181D8CC80-0x0000000181D8CC90 
		public float strikethroughOffset { get; set; } // 0x0000000181D8CC70-0x0000000181D8CC80 0x00000001820CF470-0x00000001820CF480
		public float tabWidth { get; } // 0x0000000181D8CCB0-0x0000000181D8CCC0 
	}
}
