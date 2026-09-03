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
	public struct VisibleReflectionProbe : IEquatable<VisibleReflectionProbe> // TypeDefIndex: 8450
	{
		// Fields
		private Bounds m_Bounds; // 0x00
		private Matrix4x4 m_LocalToWorldMatrix; // 0x18
		private Vector4 m_HdrData; // 0x58
		private Vector3 m_Center; // 0x68
		private float m_BlendDistance; // 0x74
		private int m_Importance; // 0x78
		private int m_BoxProjection; // 0x7C
		private EntityId m_EntityId; // 0x80
		private EntityId m_TextureId; // 0x88
	
		// Properties
		public Texture texture { get; } // 0x0000000182270730-0x00000001822707D0 
		public ReflectionProbe reflectionProbe { get; } // 0x00000001822706B0-0x0000000182270730 
		public Bounds bounds { get; } // 0x00000001808BAC90-0x00000001808BACB0 
		public Matrix4x4 localToWorldMatrix { get; } // 0x00000001810FD890-0x00000001810FD8C0 
		public Vector4 hdrData { get; } // 0x0000000181B2AD40-0x0000000181B2AD50 
		public float blendDistance { get; } // 0x0000000181F63F10-0x0000000181F63F20 
		public int importance { get; } // 0x000000018169BB50-0x000000018169BB60 
		public bool isBoxProjection { get; } // 0x0000000182270660-0x00000001822706B0 
	
		// Methods
		public bool Equals(VisibleReflectionProbe other); // 0x0000000182270200-0x0000000182270490
		public override bool Equals(object obj); // 0x0000000182270100-0x0000000182270200
		public override int GetHashCode(); // 0x0000000182270490-0x0000000182270660
	}
}
