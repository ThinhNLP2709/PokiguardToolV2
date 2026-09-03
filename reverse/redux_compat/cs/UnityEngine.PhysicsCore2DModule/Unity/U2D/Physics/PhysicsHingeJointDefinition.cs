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
	public struct PhysicsHingeJointDefinition // TypeDefIndex: 14666
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
		private bool m_EnableUnpinned; // 0x32
		[SerializeField]
		private bool m_EnableSpring; // 0x33
		[SerializeField]
		private float m_SpringTargetAngle; // 0x34
		[Min(0f)]
		[SerializeField]
		private float m_SpringFrequency; // 0x38
		[Min(0f)]
		[SerializeField]
		private float m_SpringDamping; // 0x3C
		[SerializeField]
		private bool m_EnableMotor; // 0x40
		[SerializeField]
		private float m_MotorSpeed; // 0x44
		[Min(0f)]
		[SerializeField]
		private float m_MaxMotorTorque; // 0x48
		[SerializeField]
		private bool m_EnableLimit; // 0x4C
		[Range(-178f, 178f)]
		[SerializeField]
		private float m_LowerAngleLimit; // 0x50
		[Range(-178f, 178f)]
		[SerializeField]
		private float m_UpperAngleLimit; // 0x54
		[Min(0f)]
		[SerializeField]
		private float m_ForceThreshold; // 0x58
		[Min(0f)]
		[SerializeField]
		private float m_TorqueThreshold; // 0x5C
		[Range(0f, 1000f)]
		[SerializeField]
		private float m_TuningFrequency; // 0x60
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TuningDamping; // 0x64
		[Range(0.0001f, 10f)]
		[SerializeField]
		private float m_DrawScale; // 0x68
		[SerializeField]
		private bool m_WorldDrawing; // 0x6C
		[SerializeField]
		private bool m_CollideConnected; // 0x6D
	
		// Properties
		public static PhysicsHingeJointDefinition defaultDefinition { get; } // 0x00000001822C8C30-0x00000001822C8CE0 
	
		// Constructors
		public PhysicsHingeJointDefinition(); // 0x00000001822C8B90-0x00000001822C8C30
		public PhysicsHingeJointDefinition(bool useSettings); // 0x00000001822C8AE0-0x00000001822C8B90
	}
}
