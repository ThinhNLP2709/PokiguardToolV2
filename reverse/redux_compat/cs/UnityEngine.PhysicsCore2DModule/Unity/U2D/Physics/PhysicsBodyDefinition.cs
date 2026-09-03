/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[Serializable]
	[MovedFrom(true, "UnityEngine.LowLevelPhysics2D", "UnityEngine.Physics2DModule", null)]
	public struct PhysicsBodyDefinition // TypeDefIndex: 14633
	{
		// Fields
		[SerializeField]
		private PhysicsBody.BodyType m_BodyType; // 0x00
		[SerializeField]
		private PhysicsBody.BodyConstraints m_BodyConstraints; // 0x04
		[SerializeField]
		private PhysicsBody.TransformWriteMode m_TransformWriteMode; // 0x08
		[SerializeField]
		private Vector2 m_Position; // 0x0C
		[SerializeField]
		private PhysicsRotate m_Rotation; // 0x14
		[SerializeField]
		private Vector2 m_LinearVelocity; // 0x1C
		[SerializeField]
		private float m_AngularVelocity; // 0x24
		[Min(0f)]
		[SerializeField]
		private float m_LinearDamping; // 0x28
		[Min(0f)]
		[SerializeField]
		private float m_AngularDamping; // 0x2C
		[SerializeField]
		private float m_GravityScale; // 0x30
		[Min(0f)]
		[SerializeField]
		private float m_SleepThreshold; // 0x34
		[Range(0f, 1f)]
		[SerializeField]
		private float m_CollisionThreshold; // 0x38
		[SerializeField]
		private bool m_FastCollisionsAllowed; // 0x3C
		[SerializeField]
		private bool m_FastRotationAllowed; // 0x3D
		[SerializeField]
		private bool m_ContactRecyclingAllowed; // 0x3E
		[SerializeField]
		private bool m_SleepingAllowed; // 0x3F
		[SerializeField]
		private bool m_Awake; // 0x40
		[SerializeField]
		private bool m_Enabled; // 0x41
		[SerializeField]
		private bool m_WorldDrawing; // 0x42
	
		// Properties
		public static PhysicsBodyDefinition defaultDefinition { get; } // 0x00000001822C66E0-0x00000001822C6770 
	
		// Constructors
		public PhysicsBodyDefinition(); // 0x00000001822C65D0-0x00000001822C6650
		public PhysicsBodyDefinition(bool useSettings); // 0x00000001822C6650-0x00000001822C66E0
	}
}
