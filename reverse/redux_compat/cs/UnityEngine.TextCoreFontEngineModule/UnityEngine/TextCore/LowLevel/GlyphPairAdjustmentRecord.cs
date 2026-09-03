/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 50: UnityEngine.TextCoreFontEngineModule.dll - Assembly: UnityEngine.TextCoreFontEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15505-15532

namespace UnityEngine.TextCore.LowLevel
{
	[Serializable]
	[DebuggerDisplay("First glyphIndex = {m_FirstAdjustmentRecord.m_GlyphIndex},  Second glyphIndex = {m_SecondAdjustmentRecord.m_GlyphIndex}")]
	[UsedByNativeCode]
	public struct GlyphPairAdjustmentRecord : IEquatable<GlyphPairAdjustmentRecord> // TypeDefIndex: 15526
	{
		// Fields
		[NativeName("firstAdjustmentRecord")]
		[SerializeField]
		private GlyphAdjustmentRecord m_FirstAdjustmentRecord; // 0x00
		[NativeName("secondAdjustmentRecord")]
		[SerializeField]
		private GlyphAdjustmentRecord m_SecondAdjustmentRecord; // 0x14
		[SerializeField]
		private FontFeatureLookupFlags m_FeatureLookupFlags; // 0x28
	
		// Properties
		public GlyphAdjustmentRecord firstAdjustmentRecord { get; set; } // 0x0000000181D8ABA0-0x0000000181D8ABB0 0x0000000181D8ABB0-0x0000000181D8ABC0
		public GlyphAdjustmentRecord secondAdjustmentRecord { get; } // 0x000000018110BD10-0x000000018110BD30 
		public FontFeatureLookupFlags featureLookupFlags { get; } // 0x0000000180377930-0x0000000180377940 
	
		// Constructors
		public GlyphPairAdjustmentRecord(GlyphAdjustmentRecord firstAdjustmentRecord, GlyphAdjustmentRecord secondAdjustmentRecord); // 0x00000001822F3C30-0x00000001822F3C60
	
		// Methods
		[ExcludeFromDocs]
		public override int GetHashCode(); // 0x00000001822F3BC0-0x00000001822F3C30
		[ExcludeFromDocs]
		public override bool Equals(object obj); // 0x00000001822F3A80-0x00000001822F3B00
		[ExcludeFromDocs]
		public bool Equals(GlyphPairAdjustmentRecord other); // 0x00000001822F3B00-0x00000001822F3BC0
	}
}
