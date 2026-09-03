/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[UsedByNativeCode]
	public struct ShadowSplitData : IEquatable<ShadowSplitData> // TypeDefIndex: 8437
	{
		// Fields
		public static readonly int maximumCullingPlaneCount; // 0x00
		private int m_CullingPlaneCount; // 0x00
		internal unsafe fixed /* 0x00000000-0x00000000 */ byte m_CullingPlanes[0]; // 0x04
		private Vector4 m_CullingSphere; // 0xA4
		private float m_ShadowCascadeBlendCullingFactor; // 0xB4
		private float m_CullingNearPlane; // 0xB8
		private Matrix4x4 m_CullingMatrix; // 0xBC
	
		// Properties
		public int cullingPlaneCount { get; } // 0x0000000180732D10-0x0000000180732D20 
		public Vector4 cullingSphere { get; } // 0x000000018226A6D0-0x000000018226A6E0 
		public float shadowCascadeBlendCullingFactor { set; } // 0x000000018226A6E0-0x000000018226A7F0
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_CullingPlanes_e__FixedBuffer // TypeDefIndex: 8438
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		// Constructors
		static ShadowSplitData(); // 0x000000018226A690-0x000000018226A6D0
	
		// Methods
		public Plane GetCullingPlane(int index); // 0x000000018226A4A0-0x000000018226A600
		public bool Equals(ShadowSplitData other); // 0x000000018226A1A0-0x000000018226A4A0
		public override bool Equals(object obj); // 0x000000018226A050-0x000000018226A1A0
		public override int GetHashCode(); // 0x000000018226A600-0x000000018226A690
	}
}
