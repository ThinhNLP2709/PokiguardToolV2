/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[Serializable]
	public struct LigatureSubstitutionRecord // TypeDefIndex: 11778
	{
		// Fields
		[SerializeField]
		private uint[] m_ComponentGlyphIDs; // 0x00
		[SerializeField]
		private uint m_LigatureGlyphID; // 0x08
	
		// Properties
		public uint[] componentGlyphIDs { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
		public uint ligatureGlyphID { get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
	
		// Methods
		public static bool operator ==(LigatureSubstitutionRecord lhs, LigatureSubstitutionRecord rhs); // 0x000000018206D7C0-0x000000018206D840
		public static bool operator !=(LigatureSubstitutionRecord lhs, LigatureSubstitutionRecord rhs); // 0x000000018206D840-0x000000018206D8E0
	}
}
