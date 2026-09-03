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
	public struct PhysicsRelativeJointDefinition // TypeDefIndex: 14668
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
		private Vector2 m_LinearVelocity; // 0x34
		[SerializeField]
		private float m_AngularVelocity; // 0x3C
		[Min(0f)]
		[SerializeField]
		private float m_MaxForce; // 0x40
		[Min(0f)]
		[SerializeField]
		private float m_MaxTorque; // 0x44
		[Min(0f)]
		[SerializeField]
		private float m_SpringLinearFrequency; // 0x48
		[Min(0f)]
		[SerializeField]
		private float m_SpringAngularFrequency; // 0x4C
		[Min(0f)]
		[SerializeField]
		private float m_SpringLinearDamping; // 0x50
		[Min(0f)]
		[SerializeField]
		private float m_SpringAngularDamping; // 0x54
		[Min(0f)]
		[SerializeField]
		private float m_SpringMaxForce; // 0x58
		[Min(0f)]
		[SerializeField]
		private float m_SpringMaxTorque; // 0x5C
		[Min(0f)]
		[SerializeField]
		private float m_ForceThreshold; // 0x60
		[Min(0f)]
		[SerializeField]
		private float m_TorqueThreshold; // 0x64
		[Range(0f, 1000f)]
		[SerializeField]
		private float m_TuningFrequency; // 0x68
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TuningDamping; // 0x6C
		[Range(0.0001f, 10f)]
		[SerializeField]
		private float m_DrawScale; // 0x70
		[SerializeField]
		private bool m_WorldDrawing; // 0x74
		[SerializeField]
		private bool m_CollideConnected; // 0x75
	
		// Properties
		public static PhysicsRelativeJointDefinition defaultDefinition { get; } // 0x00000001822C9650-0x00000001822C9710 
	
		// Constructors
		public PhysicsRelativeJointDefinition(); // 0x00000001822C94C0-0x00000001822C9580
		public PhysicsRelativeJointDefinition(bool useSettings); // 0x00000001822C9580-0x00000001822C9650
	}
}
