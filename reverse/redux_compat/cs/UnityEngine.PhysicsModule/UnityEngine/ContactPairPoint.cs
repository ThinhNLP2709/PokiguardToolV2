/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 48: UnityEngine.PhysicsModule.dll - Assembly: UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15413-15444

namespace UnityEngine
{
	[IsReadOnly]
	[UsedByNativeCode]
	public struct ContactPairPoint // TypeDefIndex: 15438
	{
		// Fields
		internal readonly Vector3 m_Position; // 0x00
		internal readonly float m_Separation; // 0x0C
		internal readonly Vector3 m_Normal; // 0x10
		internal readonly uint m_InternalFaceIndex0; // 0x1C
		internal readonly Vector3 m_Impulse; // 0x20
		internal readonly uint m_InternalFaceIndex1; // 0x2C
	
		// Properties
		public Vector3 position { get; } // 0x0000000181D8BE70-0x0000000181D8BE90 
		public float separation { get; } // 0x00000001802DB040-0x00000001802DB050 
		public Vector3 normal { get; } // 0x0000000180719290-0x00000001807192B0 
		public Vector3 impulse { get; } // 0x00000001821255F0-0x0000000182125610 
	}
}
