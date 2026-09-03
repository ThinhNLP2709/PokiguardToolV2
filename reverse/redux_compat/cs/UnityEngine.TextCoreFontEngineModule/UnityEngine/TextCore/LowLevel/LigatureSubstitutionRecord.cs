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
	[VisibleToOtherModules(new string[2] {"UnityEngine.TextCoreTextEngineModule", "UnityEditor.TextCoreTextEngineModule" })]
	internal struct LigatureSubstitutionRecord : IEquatable<LigatureSubstitutionRecord> // TypeDefIndex: 15532
	{
		// Fields
		[NativeName("componentGlyphs")]
		[SerializeField]
		private uint[] m_ComponentGlyphIDs; // 0x00
		[NativeName("ligatureGlyph")]
		[SerializeField]
		private uint m_LigatureGlyphID; // 0x08
	
		// Properties
		public uint[] componentGlyphIDs { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
		public uint ligatureGlyphID { get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
	
		// Methods
		public bool Equals(LigatureSubstitutionRecord other); // 0x00000001822F4070-0x00000001822F4130
		public override bool Equals(object obj); // 0x00000001822F4130-0x00000001822F41C0
		public override int GetHashCode(); // 0x0000000180E68690-0x0000000180E686C0
		public static bool operator ==(LigatureSubstitutionRecord lhs, LigatureSubstitutionRecord rhs); // 0x00000001822F41C0-0x00000001822F4300
	}
}
