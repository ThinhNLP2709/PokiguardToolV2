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
	[UsedByNativeCode]
	public struct GlyphAdjustmentRecord : IEquatable<GlyphAdjustmentRecord> // TypeDefIndex: 15525
	{
		// Fields
		[NativeName("glyphIndex")]
		[SerializeField]
		private uint m_GlyphIndex; // 0x00
		[NativeName("glyphValueRecord")]
		[SerializeField]
		private GlyphValueRecord m_GlyphValueRecord; // 0x04
	
		// Properties
		public uint glyphIndex { get; } // 0x0000000180732D10-0x0000000180732D20 
		public GlyphValueRecord glyphValueRecord { get; } // 0x0000000180C572D0-0x0000000180C572E0 
	
		// Constructors
		public GlyphAdjustmentRecord(uint glyphIndex, GlyphValueRecord glyphValueRecord); // 0x0000000181327C80-0x0000000181327C90
	
		// Methods
		[ExcludeFromDocs]
		public override int GetHashCode(); // 0x00000001822F3890-0x00000001822F38F0
		[ExcludeFromDocs]
		public override bool Equals(object obj); // 0x00000001822F3820-0x00000001822F3890
		[ExcludeFromDocs]
		public bool Equals(GlyphAdjustmentRecord other); // 0x00000001822F3790-0x00000001822F3820
	}
}
