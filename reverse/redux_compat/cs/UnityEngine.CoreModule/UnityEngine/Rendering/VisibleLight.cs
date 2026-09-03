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
	public struct VisibleLight : IEquatable<VisibleLight> // TypeDefIndex: 8448
	{
		// Fields
		private LightType m_LightType; // 0x00
		private Color m_FinalColor; // 0x04
		private Rect m_ScreenRect; // 0x14
		private Matrix4x4 m_LocalToWorldMatrix; // 0x24
		private float m_Range; // 0x64
		private float m_SpotAngle; // 0x68
		private float m_InnerSpotAngle; // 0x6C
		private Vector2 m_AreaSize; // 0x70
		private float m_ShapeRadius; // 0x78
		private EntityId m_EntityId; // 0x80
		private VisibleLightFlags m_Flags; // 0x88
	
		// Properties
		public Light light { get; } // 0x0000000182270050-0x00000001822700D0 
		public LightType lightType { get; } // 0x0000000180732D10-0x0000000180732D20 
		public Color finalColor { get; } // 0x0000000180C572D0-0x0000000180C572E0 
		public Matrix4x4 localToWorldMatrix { get; } // 0x00000001822700D0-0x0000000182270100 
		public float range { get; } // 0x0000000182141FA0-0x0000000182141FB0 
		public float spotAngle { get; } // 0x0000000180C245B0-0x0000000180C245C0 
	
		// Methods
		public bool Equals(VisibleLight other); // 0x000000018226FA10-0x000000018226FD70
		public override bool Equals(object obj); // 0x000000018226FD70-0x000000018226FE70
		public override int GetHashCode(); // 0x000000018226FE70-0x0000000182270050
	}
}
