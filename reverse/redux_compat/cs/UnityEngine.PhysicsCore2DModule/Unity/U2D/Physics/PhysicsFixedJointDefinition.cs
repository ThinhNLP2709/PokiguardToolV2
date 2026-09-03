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
	public struct PhysicsFixedJointDefinition // TypeDefIndex: 14665
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
		[Min(0f)]
		[SerializeField]
		private float m_LinearFrequency; // 0x34
		[Min(0f)]
		[SerializeField]
		private float m_LinearDamping; // 0x38
		[Min(0f)]
		[SerializeField]
		private float m_AngularFrequency; // 0x3C
		[Min(0f)]
		[SerializeField]
		private float m_AngularDamping; // 0x40
		[Min(0f)]
		[SerializeField]
		private float m_ForceThreshold; // 0x44
		[Min(0f)]
		[SerializeField]
		private float m_TorqueThreshold; // 0x48
		[Range(0f, 1000f)]
		[SerializeField]
		private float m_TuningFrequency; // 0x4C
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TuningDamping; // 0x50
		[Range(0.0001f, 10f)]
		[SerializeField]
		private float m_DrawScale; // 0x54
		[SerializeField]
		private bool m_WorldDrawing; // 0x58
		[SerializeField]
		private bool m_CollideConnected; // 0x59
	
		// Properties
		public static PhysicsFixedJointDefinition defaultDefinition { get; } // 0x00000001822C88A0-0x00000001822C8950 
	
		// Constructors
		public PhysicsFixedJointDefinition(); // 0x00000001822C8730-0x00000001822C87E0
		public PhysicsFixedJointDefinition(bool useSettings); // 0x00000001822C87E0-0x00000001822C88A0
	}
}
