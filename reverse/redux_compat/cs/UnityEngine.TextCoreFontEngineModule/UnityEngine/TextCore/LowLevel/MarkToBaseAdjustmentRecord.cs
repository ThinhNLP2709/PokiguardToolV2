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
	internal struct MarkToBaseAdjustmentRecord // TypeDefIndex: 15529
	{
		// Fields
		[NativeName("baseGlyphID")]
		[SerializeField]
		private uint m_BaseGlyphID; // 0x00
		[NativeName("baseAnchor")]
		[SerializeField]
		private GlyphAnchorPoint m_BaseGlyphAnchorPoint; // 0x04
		[NativeName("markGlyphID")]
		[SerializeField]
		private uint m_MarkGlyphID; // 0x0C
		[NativeName("markPositionAdjustment")]
		[SerializeField]
		private MarkPositionAdjustment m_MarkPositionAdjustment; // 0x10
	
		// Properties
		public uint baseGlyphID { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public GlyphAnchorPoint baseGlyphAnchorPoint { get; set; } // 0x0000000180C5D180-0x0000000180C5D1A0 0x0000000181663EE0-0x0000000181663EF0
		public uint markGlyphID { get; set; } // 0x0000000180732D30-0x0000000180732D40 0x0000000180732D70-0x0000000180732D80
		public MarkPositionAdjustment markPositionAdjustment { get; set; } // 0x0000000180719040-0x0000000180719060 0x0000000180719060-0x0000000180719070
	}
}
