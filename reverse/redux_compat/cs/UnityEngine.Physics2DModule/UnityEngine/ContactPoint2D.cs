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
	[NativeClass("ScriptingContactPoint2D", "struct ScriptingContactPoint2D;")]
	[NativeHeader("Modules/Physics2D/Public/PhysicsScripting2D.h")]
	[RequiredByNativeCode(Optional = false, GenerateProxy = false)]
	public struct ContactPoint2D // TypeDefIndex: 15604
	{
		// Fields
		[NativeName("point")]
		private Vector2 m_Point; // 0x00
		[NativeName("normal")]
		private Vector2 m_Normal; // 0x08
		[NativeName("relativeVelocity")]
		private Vector2 m_RelativeVelocity; // 0x10
		[NativeName("friction")]
		private float m_Friction; // 0x18
		[NativeName("bounciness")]
		private float m_Bounciness; // 0x1C
		[NativeName("separation")]
		private float m_Separation; // 0x20
		[NativeName("normalImpulse")]
		private float m_NormalImpulse; // 0x24
		[NativeName("tangentImpulse")]
		private float m_TangentImpulse; // 0x28
		[NativeName("collider")]
		private EntityId m_Collider; // 0x30
		[NativeName("otherCollider")]
		private EntityId m_OtherCollider; // 0x38
		[NativeName("rigidbody")]
		private EntityId m_Rigidbody; // 0x40
		[NativeName("otherRigidbody")]
		private EntityId m_OtherRigidbody; // 0x48
		[NativeName("enabled")]
		private int m_Enabled; // 0x50
	}
}
