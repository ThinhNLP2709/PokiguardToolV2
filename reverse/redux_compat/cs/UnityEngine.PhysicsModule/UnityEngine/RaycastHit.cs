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

// Image 48: UnityEngine.PhysicsModule.dll - Assembly: UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15413-15444

namespace UnityEngine
{
	[NativeHeader("Modules/Physics/RaycastHit.h")]
	[NativeHeader("Runtime/Interfaces/IPhysics.h")]
	[NativeHeader("PhysicsScriptingClasses.h")]
	[UsedByNativeCode]
	public struct RaycastHit // TypeDefIndex: 15443
	{
		// Fields
		[NativeName("point")]
		internal Vector3 m_Point; // 0x00
		[NativeName("normal")]
		internal Vector3 m_Normal; // 0x0C
		[NativeName("faceID")]
		internal uint m_FaceID; // 0x18
		[NativeName("distance")]
		internal float m_Distance; // 0x1C
		[NativeName("uv")]
		internal Vector2 m_UV; // 0x20
		[NativeName("collider")]
		internal EntityId m_Collider; // 0x28
	
		// Properties
		public Collider collider { get; } // 0x00000001822D8540-0x00000001822D85E0 
		public Vector3 point { get; } // 0x0000000181D8BE70-0x0000000181D8BE90 
		public Vector3 normal { get; } // 0x0000000181EB8370-0x0000000181EB8390 
		public float distance { get; } // 0x0000000181CE2A30-0x0000000181CE2A40 
		public Transform transform { get; } // 0x00000001822D86D0-0x00000001822D8860 
		public Rigidbody rigidbody { get; } // 0x00000001822D85E0-0x00000001822D86D0 
	}
}
