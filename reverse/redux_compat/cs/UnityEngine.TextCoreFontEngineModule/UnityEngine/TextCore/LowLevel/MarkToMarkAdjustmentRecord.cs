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

namespace UnityEngine.TextCore.LowLevel
{
	[Serializable]
	[UsedByNativeCode]
	[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
	internal struct MarkToMarkAdjustmentRecord // TypeDefIndex: 15530
	{
		// Fields
		[NativeName("baseMarkGlyphID")]
		[SerializeField]
		private uint m_BaseMarkGlyphID; // 0x00
		[NativeName("baseMarkAnchor")]
		[SerializeField]
		private GlyphAnchorPoint m_BaseMarkGlyphAnchorPoint; // 0x04
		[NativeName("combiningMarkGlyphID")]
		[SerializeField]
		private uint m_CombiningMarkGlyphID; // 0x0C
		[NativeName("combiningMarkPositionAdjustment")]
		[SerializeField]
		private MarkPositionAdjustment m_CombiningMarkPositionAdjustment; // 0x10
	
		// Properties
		public uint baseMarkGlyphID { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public GlyphAnchorPoint baseMarkGlyphAnchorPoint { get; set; } // 0x0000000180C5D180-0x0000000180C5D1A0 0x0000000181663EE0-0x0000000181663EF0
		public uint combiningMarkGlyphID { get; set; } // 0x0000000180732D30-0x0000000180732D40 0x0000000180732D70-0x0000000180732D80
		public MarkPositionAdjustment combiningMarkPositionAdjustment { get; set; } // 0x0000000180719040-0x0000000180719060 0x0000000180719060-0x0000000180719070
	}
}
