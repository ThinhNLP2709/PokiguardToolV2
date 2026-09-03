/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 54: UnityEngine.Physics2DModule.dll - Assembly: UnityEngine.Physics2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15597-15610

namespace UnityEngine
{
	[RequiredByNativeCode]
	public class Collision2D // TypeDefIndex: 15603
	{
		// Fields
		internal EntityId m_Collider; // 0x10
		internal EntityId m_OtherCollider; // 0x18
		internal EntityId m_Rigidbody; // 0x20
		internal EntityId m_OtherRigidbody; // 0x28
		internal Vector2 m_RelativeVelocity; // 0x30
		internal int m_Enabled; // 0x38
		internal int m_ContactCount; // 0x3C
		internal ContactPoint2D[] m_ReusedContacts; // 0x40
		internal ContactPoint2D[] m_LegacyContacts; // 0x48
	
		// Constructors
		public Collision2D(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		[RequiredByNativeCode]
		internal static Collision2D CreateNew(EntityId collider, EntityId otherCollider, EntityId rigidbody, EntityId otherRigidbody, Vector2 relativeVelocity, int enabled, int contactCount, ContactPoint2D[] reusedContacts, ContactPoint2D[] legacyContacts); // 0x00000001822C0CA0-0x00000001822C0D80
		[RequiredByNativeCode]
		internal static void AssignFieldsFromNative(Collision2D self, EntityId collider, EntityId otherCollider, EntityId rigidbody, EntityId otherRigidbody, Vector2 relativeVelocity, int enabled, int contactCount, ContactPoint2D[] reusedContacts, ContactPoint2D[] legacyContacts); // 0x00000001822C0BC0-0x00000001822C0C40
		internal void AssignFields(EntityId collider, EntityId otherCollider, EntityId rigidbody, EntityId otherRigidbody, Vector2 relativeVelocity, int enabled, int contactCount, ContactPoint2D[] reusedContacts, ContactPoint2D[] legacyContacts); // 0x00000001822C0C40-0x00000001822C0CA0
	}
}
