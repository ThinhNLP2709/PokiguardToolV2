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
	public struct ContactPair // TypeDefIndex: 15437
	{
		// Fields
		internal readonly EntityId m_ColliderID; // 0x00
		internal readonly EntityId m_OtherColliderID; // 0x08
		internal readonly IntPtr m_StartPtr; // 0x10
		internal readonly uint m_NbPoints; // 0x18
		internal readonly CollisionPairFlags m_Flags; // 0x1C
		internal readonly CollisionPairEventFlags m_Events; // 0x1E
		internal readonly Vector3 m_ImpulseSum; // 0x20
	
		// Properties
		public Collider collider { get; } // 0x00000001822D4E70-0x00000001822D4EF0 
		public Collider otherCollider { get; } // 0x00000001822D4F20-0x00000001822D4FA0 
		public bool isCollisionEnter { get; } // 0x00000001822D4EF0-0x00000001822D4F00 
		public bool isCollisionExit { get; } // 0x00000001822D4F00-0x00000001822D4F10 
		public bool isCollisionStay { get; } // 0x00000001822D4F10-0x00000001822D4F20 
		internal bool hasRemovedCollider { get; } // 0x00000001822D4B10-0x00000001822D4B30 
	
		// Methods
		internal int ExtractContactsArray(ContactPoint[] managedContainer, bool flipped); // 0x00000001822D4B80-0x00000001822D4DF0
		public ref ContactPairPoint GetContactPoint(int index); // 0x00000001822D4DF0-0x00000001822D4E70
		internal unsafe ContactPairPoint* GetContactPoint_Internal(int index); // 0x00000001822D4DF0-0x00000001822D4E70
	}
}
