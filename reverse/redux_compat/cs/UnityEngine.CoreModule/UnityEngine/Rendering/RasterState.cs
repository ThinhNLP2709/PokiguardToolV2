/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct RasterState : IEquatable<UnityEngine.Rendering.RasterState> // TypeDefIndex: 8418
	{
		// Fields
		public static readonly RasterState defaultValue; // 0x00
		private CullMode m_CullingMode; // 0x00
		private int m_OffsetUnits; // 0x04
		private float m_OffsetFactor; // 0x08
		private byte m_DepthClip; // 0x0C
		private byte m_Conservative; // 0x0D
		private byte m_Padding1; // 0x0E
		private byte m_Padding2; // 0x0F
	
		// Constructors
		public RasterState(CullMode cullingMode = CullMode.Back /* Metadata: 0x0069DBAE */, int offsetUnits = 0 /* Metadata: 0x0069DBAF */, float offsetFactor = 0f /* Metadata: 0x0069DBB0 */, bool depthClip = true /* Metadata: 0x0069DBB4 */); // 0x000000018225E640-0x000000018225E6D0
		static RasterState(); // 0x000000018225E5A0-0x000000018225E640
	
		// Methods
		public bool Equals(RasterState other); // 0x000000018225E3A0-0x000000018225E400
		public override bool Equals(object obj); // 0x000000018225E400-0x000000018225E510
		public override int GetHashCode(); // 0x000000018225E510-0x000000018225E5A0
	}
}
