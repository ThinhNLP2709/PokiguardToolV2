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

// Image 54: UnityEngine.Physics2DModule.dll - Assembly: UnityEngine.Physics2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15597-15610

namespace UnityEngine
{
	[NativeClass("RaycastHit2D", "struct RaycastHit2D;")]
	[NativeHeader("Runtime/Interfaces/IPhysics2D.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = false)]
	public struct RaycastHit2D // TypeDefIndex: 15605
	{
		// Fields
		[NativeName("centroid")]
		private Vector2 m_Centroid; // 0x00
		[NativeName("point")]
		private Vector2 m_Point; // 0x08
		[NativeName("normal")]
		private Vector2 m_Normal; // 0x10
		[NativeName("distance")]
		private float m_Distance; // 0x18
		[NativeName("fraction")]
		private float m_Fraction; // 0x1C
		[NativeName("collider")]
		private EntityId m_Collider; // 0x20
	
		// Properties
		public Vector2 point { get; } // 0x0000000181DD08D0-0x0000000181DD08F0 
		public Vector2 normal { get; } // 0x0000000180719040-0x0000000180719060 
		public float distance { get; } // 0x00000001806CB0A0-0x00000001806CB0B0 
		public Collider2D collider { get; } // 0x00000001822C21A0-0x00000001822C2240 
	}
}
