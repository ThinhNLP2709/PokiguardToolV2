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
	public struct ContactPairHeader // TypeDefIndex: 15436
	{
		// Fields
		internal readonly EntityId m_BodyID; // 0x00
		internal readonly EntityId m_OtherBodyID; // 0x08
		internal readonly IntPtr m_StartPtr; // 0x10
		internal readonly uint m_NbPairs; // 0x18
		internal readonly CollisionPairHeaderFlags m_Flags; // 0x1C
		internal readonly Vector3 m_ThisBodyLinearVelocity; // 0x20
		internal readonly Vector3 m_ThisBodyAngularVelocity; // 0x2C
		internal readonly Vector3 m_OtherBodyLinearVelocity; // 0x38
		internal readonly Vector3 m_OtherBodyAngularVelocity; // 0x44
	
		// Properties
		public Component body { get; } // 0x00000001822D4AC0-0x00000001822D4B10 
		public Component otherBody { get; } // 0x00000001822D4B30-0x00000001822D4B80 
		internal bool hasRemovedBody { get; } // 0x00000001822D4B10-0x00000001822D4B30 
	
		// Methods
		public ref ContactPair GetContactPair(int index); // 0x00000001822D4A40-0x00000001822D4AC0
		internal unsafe ContactPair* GetContactPair_Internal(int index); // 0x00000001822D4A40-0x00000001822D4AC0
	}
}
