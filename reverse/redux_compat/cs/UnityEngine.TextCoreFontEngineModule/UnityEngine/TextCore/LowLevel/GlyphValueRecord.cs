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
	public struct GlyphValueRecord : IEquatable<GlyphValueRecord> // TypeDefIndex: 15524
	{
		// Fields
		[NativeName("xPlacement")]
		[SerializeField]
		private float m_XPlacement; // 0x00
		[NativeName("yPlacement")]
		[SerializeField]
		private float m_YPlacement; // 0x04
		[NativeName("xAdvance")]
		[SerializeField]
		private float m_XAdvance; // 0x08
		[NativeName("yAdvance")]
		[SerializeField]
		private float m_YAdvance; // 0x0C
	
		// Properties
		public float xPlacement { get; set; } // 0x000000018035C780-0x000000018035C790 0x0000000181DBFEC0-0x0000000181DBFED0
		public float yPlacement { get; set; } // 0x000000018035C790-0x000000018035C7A0 0x0000000181CE28C0-0x0000000181CE28D0
		public float xAdvance { get; set; } // 0x00000001802DB050-0x00000001802DB060 0x0000000181DA9A50-0x0000000181DA9A60
		public float yAdvance { get; } // 0x00000001802DB040-0x00000001802DB050 
	
		// Constructors
		public GlyphValueRecord(float xPlacement, float yPlacement, float xAdvance, float yAdvance); // 0x0000000182082140-0x0000000182082160
	
		// Methods
		public static GlyphValueRecord operator +(GlyphValueRecord a, GlyphValueRecord b); // 0x0000000182084F70-0x0000000182084F90
		public override int GetHashCode(); // 0x00000001822F3F10-0x00000001822F3F60
		public override bool Equals(object obj); // 0x00000001822F3E30-0x00000001822F3E90
		public bool Equals(GlyphValueRecord other); // 0x00000001822F3E90-0x00000001822F3F10
	}
}
