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
	public struct GlyphMetrics : IEquatable<GlyphMetrics> // TypeDefIndex: 15511
	{
		// Fields
		[NativeName("width")]
		[SerializeField]
		private float m_Width; // 0x00
		[NativeName("height")]
		[SerializeField]
		private float m_Height; // 0x04
		[NativeName("horizontalBearingX")]
		[SerializeField]
		private float m_HorizontalBearingX; // 0x08
		[NativeName("horizontalBearingY")]
		[SerializeField]
		private float m_HorizontalBearingY; // 0x0C
		[NativeName("horizontalAdvance")]
		[SerializeField]
		private float m_HorizontalAdvance; // 0x10
	
		// Properties
		public float width { get; } // 0x000000018035C780-0x000000018035C790 
		public float height { get; } // 0x000000018035C790-0x000000018035C7A0 
		public float horizontalBearingX { get; } // 0x00000001802DB050-0x00000001802DB060 
		public float horizontalBearingY { get; } // 0x00000001802DB040-0x00000001802DB050 
		public float horizontalAdvance { get; } // 0x00000001807187E0-0x00000001807187F0 
	
		// Constructors
		public GlyphMetrics(float width, float height, float bearingX, float bearingY, float advance); // 0x00000001822F3A50-0x00000001822F3A80
	
		// Methods
		public override int GetHashCode(); // 0x00000001822F39F0-0x00000001822F3A50
		public override bool Equals(object obj); // 0x00000001822F3980-0x00000001822F39F0
		public bool Equals(GlyphMetrics other); // 0x00000001822F38F0-0x00000001822F3980
	}
}
