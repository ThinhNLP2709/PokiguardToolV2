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
	public struct PhysicsDistanceJointDefinition // TypeDefIndex: 14664
	{
		// Fields
		private PhysicsBody m_BodyA; // 0x00
		private PhysicsBody m_BodyB; // 0x08
		[SerializeField]
		private PhysicsTransform m_LocalAnchorA; // 0x10
		[SerializeField]
		private PhysicsTransform m_LocalAnchorB; // 0x20
		[SerializeField]
		private bool m_AutoAnchorA; // 0x30
		[SerializeField]
		private bool m_AutoAnchorB; // 0x31
		[SerializeField]
		private bool m_AutoDistance; // 0x32
		[Min(1E-45f)]
		[SerializeField]
		private float m_Distance; // 0x34
		[SerializeField]
		private bool m_EnableSpring; // 0x38
		[Min(0f)]
		[SerializeField]
		private float m_SpringFrequency; // 0x3C
		[Min(0f)]
		[SerializeField]
		private float m_SpringDamping; // 0x40
		[SerializeField]
		private float m_SpringLowerForce; // 0x44
		[SerializeField]
		private float m_SpringUpperForce; // 0x48
		[SerializeField]
		private bool m_EnableMotor; // 0x4C
		[SerializeField]
		private float m_MotorSpeed; // 0x50
		[SerializeField]
		private float m_MaxMotorForce; // 0x54
		[SerializeField]
		private bool m_EnableLimit; // 0x58
		[Min(0f)]
		[SerializeField]
		private float m_MinDistanceLimit; // 0x5C
		[Min(0f)]
		[SerializeField]
		private float m_MaxDistanceLimit; // 0x60
		[Min(0f)]
		[SerializeField]
		private float m_ForceThreshold; // 0x64
		[Min(0f)]
		[SerializeField]
		private float m_TorqueThreshold; // 0x68
		[Range(0f, 1000f)]
		[SerializeField]
		private float m_TuningFrequency; // 0x6C
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TuningDamping; // 0x70
		[Range(0.0001f, 10f)]
		[SerializeField]
		private float m_DrawScale; // 0x74
		[SerializeField]
		private bool m_WorldDrawing; // 0x78
		[SerializeField]
		private bool m_CollideConnected; // 0x79
	
		// Properties
		public static PhysicsDistanceJointDefinition defaultDefinition { get; } // 0x00000001822C8130-0x00000001822C8200 
	
		// Constructors
		public PhysicsDistanceJointDefinition(); // 0x00000001822C8060-0x00000001822C8130
		public PhysicsDistanceJointDefinition(bool useSettings); // 0x00000001822C7F80-0x00000001822C8060
	}
}
