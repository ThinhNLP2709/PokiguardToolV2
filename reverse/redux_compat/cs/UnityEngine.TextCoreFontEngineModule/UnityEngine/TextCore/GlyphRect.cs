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
	public struct GlyphRect : IEquatable<GlyphRect> // TypeDefIndex: 15510
	{
		// Fields
		[NativeName("x")]
		[SerializeField]
		private int m_X; // 0x00
		[NativeName("y")]
		[SerializeField]
		private int m_Y; // 0x04
		[NativeName("width")]
		[SerializeField]
		private int m_Width; // 0x08
		[NativeName("height")]
		[SerializeField]
		private int m_Height; // 0x0C
		private static readonly GlyphRect s_ZeroGlyphRect; // 0x00
	
		// Properties
		public int x { get; } // 0x0000000180732D10-0x0000000180732D20 
		public int y { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
		public int width { get; } // 0x0000000180732D20-0x0000000180732D30 
		public int height { get; } // 0x0000000180732D30-0x0000000180732D40 
		public static GlyphRect zero { get; } // 0x00000001822F3DD0-0x00000001822F3E30 
	
		// Constructors
		public GlyphRect(int x, int y, int width, int height); // 0x000000018192E480-0x000000018192E4A0
		static GlyphRect(); // 0x00000001822F3D90-0x00000001822F3DD0
	
		// Methods
		public override int GetHashCode(); // 0x00000001822F3D40-0x00000001822F3D90
		public override bool Equals(object obj); // 0x00000001822F3CE0-0x00000001822F3D40
		public bool Equals(GlyphRect other); // 0x00000001822F3C60-0x00000001822F3CE0
	}
}
